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
        public virtual Station Station { get; set; }
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual int DD { get; set; }
        public virtual int MM { get; set; }
        public virtual int YYYY { get; set; }
        public virtual int GG { get; set; }
        public virtual int surface_pressure { get; set; }
        public virtual float surface_temperature { get; set; }
        public virtual float surface_dewpoint { get; set; }        
        public virtual int surface_wind { get; set; }
        public virtual int surface_windspeed { get; set; }
        public virtual int surface_windunit { get; set; }

        public virtual float surface_isobaric1000_temperature { get; set; }
        public virtual float surface_isobaric1000_geopotential { get; set; }        
        public virtual float surface_isobaric1000_dewpoint { get; set; }
        public virtual int surface_isobaric1000_wind { get; set; }
        public virtual int surface_isobaric1000_windspeed { get; set; }
        public virtual int surface_isobaric1000_windunit { get; set; }

        public virtual float surface_isobaric0925_temperature { get; set; }
        public virtual float surface_isobaric0925_geopotential { get; set; }        
        public virtual float surface_isobaric0925_dewpoint { get; set; }
        public virtual int surface_isobaric0925_wind { get; set; }
        public virtual int surface_isobaric0925_windspeed { get; set; }
        public virtual int surface_isobaric0925_windunit { get; set; }

        public virtual float surface_isobaric0850_temperature { get; set; }
        public virtual float surface_isobaric0850_geopotential { get; set; }
        public virtual float surface_isobaric0850_dewpoint { get; set; }
        public virtual int surface_isobaric0850_wind { get; set; }
        public virtual int surface_isobaric0850_windspeed { get; set; }
        public virtual int surface_isobaric0850_windunit { get; set; }

        public virtual float surface_isobaric0700_temperature { get; set; }
        public virtual float surface_isobaric0700_geopotential { get; set; }
        public virtual float surface_isobaric0700_dewpoint { get; set; }
        public virtual int surface_isobaric0700_wind { get; set; }
        public virtual int surface_isobaric0700_windspeed { get; set; }
        public virtual int surface_isobaric0700_windunit { get; set; }

        public virtual float surface_isobaric0500_temperature { get; set; }
        public virtual float surface_isobaric0500_geopotential { get; set; }
        public virtual float surface_isobaric0500_dewpoint { get; set; }
        public virtual int surface_isobaric0500_wind { get; set; }
        public virtual int surface_isobaric0500_windspeed { get; set; }
        public virtual int surface_isobaric0500_windunit { get; set; }

        public virtual float surface_isobaric0400_temperature { get; set; }
        public virtual float surface_isobaric0400_geopotential { get; set; }
        public virtual float surface_isobaric0400_dewpoint { get; set; }
        public virtual int surface_isobaric0400_wind { get; set; }
        public virtual int surface_isobaric0400_windspeed { get; set; }
        public virtual int surface_isobaric0400_windunit { get; set; }

        public virtual float surface_isobaric0300_temperature { get; set; }
        public virtual float surface_isobaric0300_geopotential { get; set; }
        public virtual float surface_isobaric0300_dewpoint { get; set; }
        public virtual int surface_isobaric0300_wind { get; set; }
        public virtual int surface_isobaric0300_windspeed { get; set; }
        public virtual int surface_isobaric0300_windunit { get; set; }

        public virtual float surface_isobaric0250_temperature { get; set; }
        public virtual float surface_isobaric0250_geopotential { get; set; }
        public virtual float surface_isobaric0250_dewpoint { get; set; }
        public virtual int surface_isobaric0250_wind { get; set; }
        public virtual int surface_isobaric0250_windspeed { get; set; }
        public virtual int surface_isobaric0250_windunit { get; set; }

        public virtual float surface_isobaric0200_temperature { get; set; }
        public virtual float surface_isobaric0200_geopotential { get; set; }
        public virtual float surface_isobaric0200_dewpoint { get; set; }
        public virtual int surface_isobaric0200_wind { get; set; }
        public virtual int surface_isobaric0200_windspeed { get; set; }
        public virtual int surface_isobaric0200_windunit { get; set; }

        public virtual float surface_isobaric0150_temperature { get; set; }
        public virtual float surface_isobaric0150_geopotential { get; set; }
        public virtual float surface_isobaric0150_dewpoint { get; set; }
        public virtual int surface_isobaric0150_wind { get; set; }
        public virtual int surface_isobaric0150_windspeed { get; set; }
        public virtual int surface_isobaric0150_windunit { get; set; }

        public virtual float surface_isobaric0100_temperature { get; set; }
        public virtual float surface_isobaric0100_geopotential { get; set; }
        public virtual float surface_isobaric0100_dewpoint { get; set; }
        public virtual int surface_isobaric0100_wind { get; set; }
        public virtual int surface_isobaric0100_windspeed { get; set; }
        public virtual int surface_isobaric0100_windunit { get; set; }
        
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

        public virtual Measurement GetByDateUTC(Station station, int YYYY, int MM, int DD, int GG)
        {
            MeasurementRepository repo = new MeasurementRepository();
            return repo.GetByDate(station, YYYY, MM, DD, GG);
        }
    }
}
