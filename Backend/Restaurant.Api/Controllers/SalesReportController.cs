using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.UseCases.SalesReports;
using Restaurant.Application.DTOs.SalesReport;
using Restaurant.Api.DTOs.SalesReport;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SalesReportController : ControllerBase
{
    private readonly SalesReport _SalesReport;

    public SalesReportController(SalesReport salesReport)
    {
        _SalesReport = salesReport;
    }
    [HttpGet("report")]
    public async Task<IActionResult> GetSalesReport([FromQuery] SalesReportRequestDto request)
    {
        try
        {   
        var result = await _SalesReport.ExecuteAsync(request.ReportDate, request.AdminId);
        return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}