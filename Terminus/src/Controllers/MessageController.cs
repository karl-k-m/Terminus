using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Terminus.Data;
using Terminus.Models;

namespace Terminus.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMemoryCache _cache;

    public MessageController(ApiContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    /// <summary>
    /// GET all messages sent by nodes in the connections array
    /// </summary>
    /// <param name="id">Node ID</param>
    /// <param name="connections">Node connections</param>
    /// <param name="authHash">Authentication hash</param>
    /// <returns>JsonResult of messages</returns>
    [HttpGet]
    public async Task<ActionResult<JsonResult>> GetMessages(int id, int[] connections, string authHash)
    {
        if (VerifyAuthHash(id, authHash))
        {
            var messages = await _context.Messages.Where(m => connections.Contains(m.Sender)).ToListAsync();
            return new JsonResult(messages);
        }
        
        return new JsonResult(new { error = "Hash challenge incorrect or expired." });
    }
    
    /// <summary>
    /// POST a message to the database
    /// </summary>
    /// <param name="message">Sent message</param>
    /// <param name="authHash">Authentication hash</param>
    /// <returns>JsonResult of success or error</returns>
    [HttpPost]
    public async Task<ActionResult<string>> PostMessage(Message message, string authHash)
    {
        if (VerifyAuthHash(message.Sender, authHash))
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return new JsonResult("Message sent successfully.");
        }
        
        return new JsonResult(new { error = "Hash challenge incorrect or expired." });
    }
    
    /// <summary>
    /// Verify the authentication hash from the cache
    /// </summary>
    /// <param name="id">Node ID</param>
    /// <param name="authHash">Authentication hash</param>
    /// <returns></returns>
    [NonAction]
    public bool VerifyAuthHash(int id, string authHash)
    {
        var hash = _cache.Get<string>(id);
        
        if (hash != null)
        {
            _cache.Remove(id);
            return authHash == hash;
        }
        
        return false;
    }
}