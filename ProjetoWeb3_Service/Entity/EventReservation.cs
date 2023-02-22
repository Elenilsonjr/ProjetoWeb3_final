using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWeb3_Service.Entity
{
    public class EventReservation
    {
              //IdReservation long incremento PK
              //IdEvent                long not null FK
              //PersonName            string not null
              //Quantity long not null

        public long IdReservation { get; set; }
        public long IdEvent { get; set; }
        public string PersonName { get; set; }
        public long Quantity { get; set; }
    }
}
