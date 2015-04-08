using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codes.Models
{
    public class ViewMeasurement
    {
        public string no_data = "Данные отсутствуют";
        public ViewMeasurement()
        {
            surface_pressure = no_data;
            surface_temperature = no_data;
            surface_dewpoint = no_data;
            station = no_data;
            surface_wind = no_data;
            surface_windspeed = no_data;
            surface_windunit = no_data;
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
