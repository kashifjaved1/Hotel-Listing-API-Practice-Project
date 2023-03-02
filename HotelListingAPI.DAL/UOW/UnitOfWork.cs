using HotelListingAPI.DAL;
using HotelListingAPI.Repository;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HotelListingAPI.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        private readonly HotelListingContext _context;

        public UnitOfWork( HotelListingContext context)
        {
            _context = context;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
