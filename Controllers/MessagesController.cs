using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using slack_back.Models;

namespace slack_back.Controllers;

[Route("/[controller]")]
[ApiController]
public class MessagesController : Controller
{
    private readonly ILogger<MessagesController> _logger;
    private readonly DbslackContext _context;

    public MessagesController(ILogger<MessagesController> logger, DbslackContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetMessages(int? threadId)
    {
        IQueryable<Message> messages = _context.Messages;
        if (threadId != null)
        {
            messages = messages.Where(m => m.ThreadId == threadId);
        }

        return Ok(messages);
    }

    [HttpGet("{id}")]
    public IActionResult getMessage(int id)
    {
        var message = _context.Messages.Find(id);

        return Ok(message);
    }

    [HttpPost]
    public void createMessage(Message message)
    {
        _context.Messages.Add(message);
        _context.SaveChanges();
    }

    [HttpPut("{id}")]
    public void updateMessage(int id, Message message)
    {
        var messageEntity = _context.Messages.Find(id);
        messageEntity.Content = message.Content;
        messageEntity.Date = message.Date;
        _context.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void DeleteMessage(int id)
    {
        var messageEntity = _context.Messages.Find(id);
        _context.Messages.Remove(messageEntity);
    }
}
