using System.Diagnostics;
using slack_back.Models;
using Microsoft.AspNetCore.Mvc;
namespace slack_back.Controllers;

[Route("/[controller]")]
[ApiController]
public class ThreadsController : Controller
{
    private readonly ILogger<ThreadsController> _logger;
    private readonly DbslackContext _context;

    public ThreadsController(ILogger<ThreadsController> logger, DbslackContext context)
    {
        _context = context;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult GetThreads()
    {
        var mes_threads = _context.Threads;

        return Ok(mes_threads);
    }

    [HttpGet("{id}")]
    public IActionResult GetThreadById(int id)
    {
        var mes_threadId = _context.Threads.Find(id);

        return Ok(mes_threadId);
    }

    [HttpPost]
    public IActionResult CreateThread(Models.Thread newThread)
    {
        _context.Threads.Add(newThread);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetThreadById), new { id = newThread.Id }, newThread);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateThread(int id, Models.Thread updatedThread)
    {
        var oldThread = _context.Threads.Find(id);
        oldThread.Label = updatedThread.Label;
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("id")]
    public IActionResult DeleteThread(int id)
    {
        var thread = _context.Threads.Find(id);
        if (thread == null)
        {
            return NotFound();
        }
        _context.Threads.Remove(thread);
        _context.SaveChanges();
        return NoContent();
    }

}
