﻿using Microsoft.AspNetCore.Mvc;
using Prettifier.Interfaces;

namespace NumberPrettifier.Controllers;

[ApiController]
[Route("[controller]")]
public class PrettifierController : ControllerBase
{
    private readonly ILogger<PrettifierController> _logger;
    private readonly IPrettifierServiceFactory _prettifierServiceFactory;

    public PrettifierController(ILogger<PrettifierController> logger,
        IPrettifierServiceFactory prettifierServiceFactory)
    {
        _logger = logger;
        _prettifierServiceFactory = prettifierServiceFactory;
    }

    [HttpGet]
    public string? Get(double number, string? type)
    {
        var prettyService = _prettifierServiceFactory.GetPrettifier(type);
        return prettyService.Pretty(number, type);
    }
}