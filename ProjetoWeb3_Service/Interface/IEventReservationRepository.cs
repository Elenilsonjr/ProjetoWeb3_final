using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoWeb3_Service.Entity;

namespace ProjetoWeb3_Service.Interface
{
    public interface IEventReservationRepository
    {
        bool InsertEventReservation(EventReservation eventReservation);
        bool UpdateEventReservation(long idReservation, long quantity);
        bool DeleteEventReservation(long idReservation);
        List<EventReservation> SelectReservationByPersonNameAndTitle(string personName, string title);
        List<EventReservation> SelectReservation();
        
        
        
        
    }
}
