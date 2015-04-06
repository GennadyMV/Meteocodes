using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codes.Models
{
    class Measurement
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
    }
}
