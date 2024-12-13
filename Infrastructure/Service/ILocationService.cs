using Domain.Model;

namespace Infrastructure.Service;

public interface ILocationService
{
    List<Location> GetLocation();
    bool CreateLocation(Location location);
    bool UpdateLocation(Location location);
    bool DeleteLocation(int id);
}