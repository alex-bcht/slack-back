using System.Diagnostics;
using slack_back.Models;
using Microsoft.AspNetCore.Mvc;
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
}
