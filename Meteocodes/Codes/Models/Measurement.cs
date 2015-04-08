using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using Codes.Repositories;

namespace Codes.Models
{
    public class Measurement
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual int DD { get; set; }
        public virtual int GG { get; set; }
        public virtual int surface_pressure { get; set; }
        public virtual float surface_temperature { get; set; }
        public virtual float surface_dewpoint { get; set; }
        public virtual Station Station { get; set; }
        public virtual int surface_wind { get; set; }
        public virtual int surface_windspeed { get; set; }
        public virtual int surface_windunit { get; set; }
        
        public virtual void Save()
        {
            IRepository<Measurement> repo = new MeasurementRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Measurement> repo = new MeasurementRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

        public virtual Measurement GetByDateUTC(Station station, int DD, int GG)
        {
            MeasurementRepository repo = new MeasurementRepository();
            return repo.GetByDate(station, DD, GG);
        }
    }
}
