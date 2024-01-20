using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Terminus.Data;

namespace Terminus.Controllers;

public class AuthController
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
        
        if (node != null)
        {
            // Get Node Salt
            var salt = node.HashSalt;
            
            // Generate random challenge
            var challenge = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(challenge);
            
            // Generate hash
            byte[] hash = SHA256.HashData(challenge.Concat(salt).ToArray());
            
            // Write hash to cache with 30 second sliding expiration
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));
            _cache.Set(nodeId, hash, cacheEntryOptions);
            
            // Return challenge
            return new JsonResult(challenge);
        }
        
        return new JsonResult(new { error = "Invalid node." });
    }
}