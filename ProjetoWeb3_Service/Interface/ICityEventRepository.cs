using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoWeb3_Service.Entity;

namespace ProjetoWeb3_Service.Interface
{
    public interface ICityEventRepository
    {
        bool InsertCityEvent(CityEvent cityEvent);
        bool UpdateCityEvent(CityEvent cityEvent);
        bool DeleteCityEvent(long id);

        List<CityEvent> SelectEvents();
        List<CityEvent> SelectEventsByTitle(string title);
        List<CityEvent> SelectEventsByDateAndLocal(DateTime dataHourEvent, string local);
        List<CityEvent> SelectEventsByPriceAndDate(decimal low, decimal high, DateTime dateHourEvent);
        
    }
}
