using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meteo.Models
{
    public class Station
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
    }
}
