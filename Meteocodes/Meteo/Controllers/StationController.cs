using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codes.Repositories;
using Codes.Models;
using Codes.Common;

namespace Meteo.Controllers
{
    public class StationController : Controller
    {
        //
        // GET: /Station/

        public ActionResult Index(int DD = -1, int GG = -1)
        {
            if (DD == -1)
            {
                DD = DateTime.UtcNow.Day - 1;
            }
            if (GG == -1)
            {
                GG = 12;
            }
            ViewBag.DateTime = DateTime.UtcNow.AddDays(-1).ToString("dd.MM.yyyy");

            Dictionary<string, ViewMeasurement> MeasurementData = new Dictionary<string, ViewMeasurement>();
            foreach (var station in ((IRepository<Station>)(new StationRepository())).GetAll())
            {
                if (station.Code > 0)
                {
                    if (!MeasurementData.ContainsKey(station.Code.ToString()))
                    {

                        ViewMeasurement meas = new ViewMeasurement();
                        meas.station = station.Code.ToString();
                        Measurement measurement = (new Measurement()).GetByDateUTC(station, DD, GG);
                        if (measurement != null)
                        {
                            meas.surface_pressure = String.Format("{0, 5:N0}", measurement.surface_pressure);
                            meas.surface_temperature = String.Format("{0, 6:N1}",     measurement.surface_temperature);
                            meas.surface_dewpoint = String.Format("{0, 4:N1}",        measurement.surface_dewpoint);
                            meas.surface_wind = String.Format("{0, 4}",            measurement.surface_wind);
                            meas.surface_windspeed = String.Format("{0, 4}",       measurement.surface_windspeed);
                        }
                        MeasurementData.Add(station.Code.ToString(), meas);
                    }                  

                }
            }
            return View(MeasurementData);
        }

    }
}
