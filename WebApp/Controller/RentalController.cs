using Domain.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;


[ApiController]
[Route("api/[controller]")]
public class RentalController(IRentalService service) : ControllerBase
{
    [HttpGet]
    public List<Rental> GetAll()
    {
        var response = service.GetRental();
        return response;
    }

    [HttpPost]
    public bool CreateRental(Rental rental)
    {
        var response = service.CreateRental(rental);
        return response;
    }

    [HttpPut]
    public bool UpdateRental(Rental rental)
    {
        var response = service.UpdateRental(rental);
        return response;
    }
    [HttpDelete]
    public bool DeleteRental(int id)
    {
        var response = service.DeleteRental(id);
        return response;
    }
}