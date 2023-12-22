using System.Diagnostics;
using slack_back.Models;
using Microsoft.AspNetCore.Mvc;
namespace slack_back.Controllers;

public class ThreadsController : Controller
{
    private readonly ILogger<ThreadsController> _logger;
    private readonly DbslackContext _context;

    public ThreadsController(ILogger<ThreadsController> logger, DbslackContext context)
    {
        _context = context;
        _logger = logger;
    }
}
