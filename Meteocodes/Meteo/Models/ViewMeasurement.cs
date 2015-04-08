using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codes.Models
{
    public class ViewMeasurement
    {
        public ViewMeasurement()
        {
            const string unk = "Данные отсутствуют";
            surface_pressure = unk;
            surface_temperature = unk;
            surface_dewpoint = unk;
            station = unk;
            surface_wind = unk;
            surface_windspeed = unk;
            surface_windunit = unk;
        }
        public string surface_pressure;
        public string surface_temperature;
        public string surface_dewpoint;
        public string station;
        public string surface_wind;
        public string surface_windspeed;
        public string surface_windunit;
    }
}
