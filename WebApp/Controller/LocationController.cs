using Domain.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;



[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService service):ControllerBase
{
    [HttpGet]
    public List<Location> GetAll()
    {
        var response = service.GetLocation();
        return response;
    }

    [HttpPost]
    public bool CreateLocation(Location location)
    {
        var response = service.CreateLocation(location);
        return response;
    }

    [HttpPut]
    public bool UpdateLocation(Location location)
    {
        var response = service.UpdateLocation(location);
        return response;
    }
    [HttpDelete]
    public bool DeleteLocation(int id)
    {
        var response = service.DeleteLocation(id);
        return response;
    }
}