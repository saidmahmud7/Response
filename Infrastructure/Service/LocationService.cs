using Dapper;
using Domain.Model;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class LocationService(DapperContext _context) : ILocationService
{
    public List<Location> GetLocation()
    {
        using var context = _context.Connection();
        var sql = "select * from locations";
        var res = context.Query<Location>(sql).ToList();
        return res;
    }

    public bool CreateLocation(Location location)
    {
        using var context = _context.Connection();
        var sql = @"insert into locations (city,address) 
                    values (@City,@Address)";
        var res = context.Execute(sql, location);
        return res > 0;
    }

    public bool UpdateLocation(Location location)
    {
        using var context = _context.Connection();
        var sql = @"update locations set city = @City,address=@Address
                     where LocationId = @LocationId";
        var res = context.Execute(sql, location);
        return res > 0;
    }

    public bool DeleteLocation(int id)
    {
        using var context = _context.Connection();
        var sql = "delete from locations where LocationId = @Id";
        var res = context.Execute(sql, new { Id = id });
        return res != 0;
    }
}