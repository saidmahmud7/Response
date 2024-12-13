using Dapper;
using Domain.Model;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class RentalService(DapperContext _context) : IRentalService
{
    public List<Rental> GetRental()
    {
        using var context = _context.Connection();
        var sql = "select * from rentals";
        var res = context.Query<Rental>(sql).ToList();
        return res;
    }

    public bool CreateRental(Rental rental)
    {
        using var context = _context.Connection();
        var sql = @"insert into rentals (carid,customerid,startdate,enddate,TotalCost) 
                    values (@CarId,@CustomerId,@StartDate,@EndDate,@TotalCost)";
        var res = context.Execute(sql, rental);
        return res > 0;
    }

    public bool UpdateRental(Rental rental)
    {
        using var context = _context.Connection();
        var sql = @"update rentals set carid = @CarId,customerid=@CustomerId,startdate=@StartDate,enddate=@EndDate,TotalCost=@TotalCost
                     where RentalId = @Id";
        var res = context.Execute(sql, rental);
        return res > 0;
    }

    public bool DeleteRental(int id)
    {
        using var context = _context.Connection();
        var sql = "delete from rentals where RentalId = @Id";
        var res = context.Execute(sql, new { Id = id });
        return res != 0;
    }
}