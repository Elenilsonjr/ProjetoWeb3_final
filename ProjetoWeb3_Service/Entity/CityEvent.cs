using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWeb3_Service.Entity
{
    public class CityEvent
    {
              //IdEvent long incremento PK
              //Title                 string not null
              //Description string        null
              //DateHourEvent DateTime    not null
              //Local string not null
              //Address string        null
              //Price decimal        null
              //Status bit        not null

        public long IdEvent { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateHourEvent { get; set; }
        public string Local { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; } = true;
    }
}
