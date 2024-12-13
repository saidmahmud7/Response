using Domain.Model;

namespace Infrastructure.Service;

public interface ICarService
{
    List<Car> GetCars();
    bool CreateCar(Car car);
    bool UpdateCar(Car car);
    bool DeleteCar(int id);
}