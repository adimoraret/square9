using System.Collections.Generic;

namespace GlobalCapture.ListBinder.Repository
{
    public interface IContext
    {
        IList<Country> GetCountries();
    }
}