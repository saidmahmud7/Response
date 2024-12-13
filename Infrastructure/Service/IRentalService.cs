using Domain.Model;

namespace Infrastructure.Service;

public interface IRentalService
{
    List<Rental> GetRental();
    bool CreateRental(Rental rental);
    bool UpdateRental(Rental rental);
    bool DeleteRental(int id);
}