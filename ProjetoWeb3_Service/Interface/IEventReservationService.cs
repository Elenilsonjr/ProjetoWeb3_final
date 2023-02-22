using ProjetoWeb3_Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWeb3_Service.Interface
{
    public interface IEventReservationService
    {
        bool InsertEventReservation(EventReservation eventReservation);
        bool UpdateEventReservation(long idReservation, long quantity);
        bool DeleteEventReservation(long idReservation);
        List<EventReservation> SelectReservationByPersonNameAndTitle(string personName, string title);
        List<EventReservation> SelectReservation();
    }
}
