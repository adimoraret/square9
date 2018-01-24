using System.Collections.Generic;
using System.Linq;

namespace GlobalCapture.ListBinder.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IContext _context;

        public CountryRepository(IContext context)
        {
            _context = context;
        }

        public List<string> GetAllCountries()
        {
            var countries = _context.GetCountries();
            return countries.Select(c => c.Name).ToList();
        }
    }
}