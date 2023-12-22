using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using slack_back.Models;

namespace slack_back.Controllers;

public class MessagesController : Controller
{
    private readonly ILogger<MessagesController> _logger;
    private readonly DbslackContext _context;

    public MessagesController(ILogger<MessagesController> logger, DbslackContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("messages")]
    public IActionResult GetMessagesByThreadId(int threadId)
    {
        var messages = _context.Messages.Where(m => m.ThreadId == threadId);

        return Json(messages);
    }

    [HttpPost("messages")]
    public void createMessage(Message message)
    {
        _context.Messages.Add(message);
        _context.SaveChanges();
    }

    [HttpPut("messages/{id}")]
    public void updateMessage(int id, Message message)
    {
        var messageEntity = _context.Messages.Find(id);
        messageEntity.Content = message.Content;
        messageEntity.Date = message.Date;
        _context.SaveChanges();
    }

    [HttpDelete("messages/{id}")]
    public void DeleteMessage(int id)
    {
        var messageEntity = _context.Messages.Find(id);
        _context.Messages.Remove(messageEntity);
    }
}
