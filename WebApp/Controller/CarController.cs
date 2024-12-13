using Domain.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;



[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService):ControllerBase
{
    [HttpGet]
    public List<Car> GetAll()
    {
        var response = carService.GetCars();
        return response;
    }

    [HttpPost]
    public bool CreateCar(Car car)
    {
        var response = carService.CreateCar(car);
        return response;
    }

    [HttpPut]
    public bool UpdateCar(Car car)
    {
        var response = carService.UpdateCar(car);
        return response;
    }

    [HttpDelete]
    public bool DeleteCar(int id)
    {
        var response = carService.DeleteCar(id);
        return response;
    }
}
