using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Terminus.Data;

namespace Terminus.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMemoryCache _cache;

    public AuthController(ApiContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    /// <summary>
    /// GET a challenge for authentication
    /// </summary>
    /// <param name="nodeId">Node ID</param>
    /// <returns>JsonResult of challenge</returns>
    [HttpGet]
    public JsonResult GetAuthChallenge(int nodeId)
    {
        var node = _context.Nodes.FindAsync(nodeId).Result;

        if (node == null)
        {
            return new JsonResult(new { error = "Invalid node." });
        }
        
        // Get Node Salt
        var salt = node.HashSalt;
        
        // Generate random challenge
        var challengeBytes = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(challengeBytes);
        var challenge = Convert.ToBase64String(challengeBytes);
        
        // Generate hash with SHA256 and salt
        var saltBytes = Encoding.UTF8.GetBytes(salt);

        // Concatenate challengeBytes and saltBytes
        var combinedBytes = challengeBytes.Concat(saltBytes).ToArray();

        // Generate hash with SHA256 and combined bytes
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(combinedBytes);

        
        // Write hash to cache with 30 second sliding expiration
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30));
        _cache.Set(nodeId, hash, cacheEntryOptions);
        
        // Return challenge
        return new JsonResult(challenge);
    }
}