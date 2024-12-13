using Dapper;
using Domain.Model;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class CarService(DapperContext _context) : ICarService
{
    public List<Car> GetCars()
    {
        using var context = _context.Connection();
        var sql = "select * from cars";
        var res = context.Query<Car>(sql).ToList();
        return res;
    }

    public bool CreateCar(Car car)
    {
        using var context = _context.Connection();
        var sql = @"insert into cars (model,manufacturer,year,priceperday) 
                    values (@Model,@Manufacturer,@Year,@PricePerDay)";
        var res = context.Execute(sql, car);
        return res > 0;
    }

    public bool UpdateCar(Car car)
    {
        using var context = _context.Connection();
        var sql = @"update cars set model = @Model,manufacturer=@Manufacturer,year=@Year,priceperday=@Priceperday
                     where carid = @CarId";
        var res = context.Execute(sql, car);
        return res > 0;
    }

    public bool DeleteCar(int id)
    {
        using var context = _context.Connection();
        var sql = "delete from cars where CarId = @Id";
        var res = context.Execute(sql, new { Id = id });
        return res != 0;
    }
}