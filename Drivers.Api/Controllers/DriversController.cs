using Drivers.Api.Models;
using Drivers.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drivers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{

    private readonly ILogger<DriversController> _logger;
    private readonly DriverServices _driverServices;
    public DriversController(
    ILogger<DriversController> 
    logger,
    DriverServices driverServices)
    {
        _logger = logger;
        _driverServices = driverServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrivers()
    {
        var drivers = await _driverServices.GetAsync();
        return Ok(drivers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDriverById(string id)
    {
        return Ok(await _driverServices.GetDriverById(id));
    }


    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] Drive drive)
    {
        if(drive == null)        
            return BadRequest();
        if(drive.Name == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio pendejazo");

        await _driverServices.InsertDriver(drive);
        return Created("Created", true);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver([FromBody] Drive drive, string id)
    {
        if(drive == null)        
            return BadRequest();
        if(drive.Name == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio pendejazo");
        
        drive.id = id;

        await _driverServices.UpdatetDriver(drive);
        return Created("Created", true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(string id)
    {
        await _driverServices.DeleteDriver(id);

        return NoContent();
    }




}
