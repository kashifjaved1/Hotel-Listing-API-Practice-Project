using HotelListingAPI.Data;
using HotelListingAPI.Repository;
using System;
using System.Threading.Tasks;

namespace HotelListingAPI.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }

        Task SaveAsync();
    }
}
