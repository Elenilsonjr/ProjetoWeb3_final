using ProjetoWeb3_Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWeb3_Service.Interface
{
    public interface ICityEventService
    {
        

        List<CityEvent> SelectEvents();
        List<CityEvent> SelectEventsByTitle(string title);
        List<CityEvent> SelectEventsByDateAndLocal(DateTime dateHourEvent, string local);
        List<CityEvent> SelectEventsByPriceAndDate(decimal low, decimal high, DateTime dateHourEvent);
        bool InsertCityEvent(CityEvent cityEvent);
        bool DeleteCityEvent(long id);
        bool UpdateCityEvent(CityEvent cityEvent);
    }
}
