using System.Collections.Generic;

namespace GlobalCapture.ListBinder.Repository
{
    public interface ICountryRepository
    {
        List<string> GetAllCountries();
    }
}