﻿using System;
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

        public ActionResult Index(int YYYY = -1, int MM = -1, int DD = -1, int GG = -1)
        {
            if (YYYY == -1)
            {
                YYYY = DateTime.UtcNow.Year;
            }
            if (MM == -1)
            {
                MM = DateTime.UtcNow.Month;
            }

            if (DD == -1)
            {
                DD = DateTime.UtcNow.AddDays(-1).Day;
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
                        Measurement measurement = (new Measurement()).GetByDateUTC(station, YYYY, MM, DD, GG);
                        if (measurement != null)
                        {
                            meas.surface_pressure = String.Format("{0, 5:N0}", measurement.surface_pressure);
                            meas.surface_temperature = String.Format("{0, 6:N1}",     measurement.surface_temperature);
                            meas.surface_dewpoint = String.Format("{0, 4:N1}",        measurement.surface_dewpoint);
                            meas.surface_wind = String.Format("{0, 4}",            measurement.surface_wind);
                            meas.surface_windspeed = String.Format("{0, 4}",       measurement.surface_windspeed);

                            meas.surface_isobaric0850_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0850_geopotential);
                            meas.surface_isobaric0850_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0850_temperature);
                            meas.surface_isobaric0850_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0850_dewpoint);
                            meas.surface_isobaric0850_wind = String.Format("{0, 4}", measurement.surface_isobaric0850_wind);
                            meas.surface_isobaric0850_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0850_windspeed);

                            meas.surface_isobaric0925_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0925_geopotential);
                            meas.surface_isobaric0925_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0925_temperature);
                            meas.surface_isobaric0925_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0925_dewpoint);
                            meas.surface_isobaric0925_wind = String.Format("{0, 4}", measurement.surface_isobaric0925_wind);
                            meas.surface_isobaric0925_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0925_windspeed);

                            meas.surface_isobaric0850_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0850_geopotential);
                            meas.surface_isobaric0850_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0850_temperature);
                            meas.surface_isobaric0850_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0850_dewpoint);
                            meas.surface_isobaric0850_wind = String.Format("{0, 4}", measurement.surface_isobaric0850_wind);
                            meas.surface_isobaric0850_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0850_windspeed);

                            meas.surface_isobaric0700_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0700_geopotential);
                            meas.surface_isobaric0700_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0700_temperature);
                            meas.surface_isobaric0700_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0700_dewpoint);
                            meas.surface_isobaric0700_wind = String.Format("{0, 4}", measurement.surface_isobaric0700_wind);
                            meas.surface_isobaric0700_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0700_windspeed);

                            meas.surface_isobaric0500_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0500_geopotential);
                            meas.surface_isobaric0500_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0500_temperature);
                            meas.surface_isobaric0500_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0500_dewpoint);
                            meas.surface_isobaric0500_wind = String.Format("{0, 4}", measurement.surface_isobaric0500_wind);
                            meas.surface_isobaric0500_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0500_windspeed);

                            meas.surface_isobaric0400_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0400_geopotential);
                            meas.surface_isobaric0400_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0400_temperature);
                            meas.surface_isobaric0400_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0400_dewpoint);
                            meas.surface_isobaric0400_wind = String.Format("{0, 4}", measurement.surface_isobaric0400_wind);
                            meas.surface_isobaric0400_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0400_windspeed);
                            
                            meas.surface_isobaric0300_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0300_geopotential);
                            meas.surface_isobaric0300_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0300_temperature);
                            meas.surface_isobaric0300_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0300_dewpoint);
                            meas.surface_isobaric0300_wind = String.Format("{0, 4}", measurement.surface_isobaric0300_wind);
                            meas.surface_isobaric0300_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0300_windspeed);


                            meas.surface_isobaric0250_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0250_geopotential);
                            meas.surface_isobaric0250_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0250_temperature);
                            meas.surface_isobaric0250_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0250_dewpoint);
                            meas.surface_isobaric0250_wind = String.Format("{0, 4}", measurement.surface_isobaric0250_wind);
                            meas.surface_isobaric0250_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0250_windspeed);


                            meas.surface_isobaric0200_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0200_geopotential);
                            meas.surface_isobaric0200_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0200_temperature);
                            meas.surface_isobaric0200_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0200_dewpoint);
                            meas.surface_isobaric0200_wind = String.Format("{0, 4}", measurement.surface_isobaric0200_wind);
                            meas.surface_isobaric0200_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0200_windspeed);


                            meas.surface_isobaric0150_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0150_geopotential);
                            meas.surface_isobaric0150_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0150_temperature);
                            meas.surface_isobaric0150_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0150_dewpoint);
                            meas.surface_isobaric0150_wind = String.Format("{0, 4}", measurement.surface_isobaric0150_wind);
                            meas.surface_isobaric0150_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0150_windspeed);


                            meas.surface_isobaric0100_geopotential = String.Format("{0, 5:N0}", measurement.surface_isobaric0100_geopotential);
                            meas.surface_isobaric0100_temperature = String.Format("{0, 6:N1}", measurement.surface_isobaric0100_temperature);
                            meas.surface_isobaric0100_dewpoint = String.Format("{0, 4:N1}", measurement.surface_isobaric0100_dewpoint);
                            meas.surface_isobaric0100_wind = String.Format("{0, 4}", measurement.surface_isobaric0100_wind);
                            meas.surface_isobaric0100_windspeed = String.Format("{0, 4}", measurement.surface_isobaric0100_windspeed);

                            meas.tropopause_pressure = String.Format("{0, 5:N0}", measurement.tropopause_pressure);
                            meas.tropopause_temperature = String.Format("{0, 6:N1}", measurement.tropopause_temperature);
                            meas.tropopause_dewpoint = String.Format("{0, 4:N1}", measurement.tropopause_dewpoint);
                            meas.tropopause_wind = String.Format("{0, 4}", measurement.tropopause_wind);
                            meas.tropopause_windspeed = String.Format("{0, 4}", measurement.tropopause_windspeed);

                            string none = "//";
                            if ((int)measurement.surface_isobaric0850_temperature == -999)
                            {
                                meas.surface_isobaric0850_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0850_dewpoint == -999)
                            {
                                meas.surface_isobaric0850_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0850_windspeed == -999)
                            {
                                meas.surface_isobaric0850_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0850_wind == -9990)
                            {
                                meas.surface_isobaric0850_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0850_geopotential == -999)
                            {
                                meas.surface_isobaric0850_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0925_temperature == -999)
                            {
                                meas.surface_isobaric0925_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0925_dewpoint == -999)
                            {
                                meas.surface_isobaric0925_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0925_windspeed == -999)
                            {
                                meas.surface_isobaric0925_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0925_wind == -9990)
                            {
                                meas.surface_isobaric0925_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0925_geopotential == -999)
                            {
                                meas.surface_isobaric0925_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0850_temperature == -999)
                            {
                                meas.surface_isobaric0850_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0850_dewpoint == -999)
                            {
                                meas.surface_isobaric0850_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0850_windspeed == -999)
                            {
                                meas.surface_isobaric0850_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0850_wind == -9990)
                            {
                                meas.surface_isobaric0850_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0850_geopotential == -999)
                            {
                                meas.surface_isobaric0850_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0700_temperature == -999)
                            {
                                meas.surface_isobaric0700_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0700_dewpoint == -999)
                            {
                                meas.surface_isobaric0700_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0700_windspeed == -999)
                            {
                                meas.surface_isobaric0700_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0700_wind == -9990)
                            {
                                meas.surface_isobaric0700_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0700_geopotential == -999)
                            {
                                meas.surface_isobaric0700_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0500_temperature == -999)
                            {
                                meas.surface_isobaric0500_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0500_dewpoint == -999)
                            {
                                meas.surface_isobaric0500_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0500_windspeed == -999)
                            {
                                meas.surface_isobaric0500_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0500_wind == -9990)
                            {
                                meas.surface_isobaric0500_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0500_geopotential == -999)
                            {
                                meas.surface_isobaric0500_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0400_temperature == -999)
                            {
                                meas.surface_isobaric0400_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0400_dewpoint == -999)
                            {
                                meas.surface_isobaric0400_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0400_windspeed == -999)
                            {
                                meas.surface_isobaric0400_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0400_wind == -9990)
                            {
                                meas.surface_isobaric0400_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0400_geopotential == -999)
                            {
                                meas.surface_isobaric0400_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0300_temperature == -999)
                            {
                                meas.surface_isobaric0300_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0300_dewpoint == -999)
                            {
                                meas.surface_isobaric0300_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0300_windspeed == -999)
                            {
                                meas.surface_isobaric0300_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0300_wind == -9990)
                            {
                                meas.surface_isobaric0300_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0300_geopotential == -999)
                            {
                                meas.surface_isobaric0300_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0250_temperature == -999)
                            {
                                meas.surface_isobaric0250_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0250_dewpoint == -999)
                            {
                                meas.surface_isobaric0250_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0250_windspeed == -999)
                            {
                                meas.surface_isobaric0250_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0250_wind == -9990)
                            {
                                meas.surface_isobaric0250_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0250_geopotential == -999)
                            {
                                meas.surface_isobaric0250_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0200_temperature == -999)
                            {
                                meas.surface_isobaric0200_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0200_dewpoint == -999)
                            {
                                meas.surface_isobaric0200_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0200_windspeed == -999)
                            {
                                meas.surface_isobaric0200_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0200_wind == -9990)
                            {
                                meas.surface_isobaric0200_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0200_geopotential == -999)
                            {
                                meas.surface_isobaric0200_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0150_temperature == -999)
                            {
                                meas.surface_isobaric0150_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0150_dewpoint == -999)
                            {
                                meas.surface_isobaric0150_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0150_windspeed == -999)
                            {
                                meas.surface_isobaric0150_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0150_wind == -9990)
                            {
                                meas.surface_isobaric0150_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0150_geopotential == -999)
                            {
                                meas.surface_isobaric0150_geopotential = none;
                            }

                            if ((int)measurement.surface_isobaric0100_temperature == -999)
                            {
                                meas.surface_isobaric0100_temperature = none;
                            }
                            if ((int)measurement.surface_isobaric0100_dewpoint == -999)
                            {
                                meas.surface_isobaric0100_dewpoint = none;
                            }

                            if ((int)measurement.surface_isobaric0100_windspeed == -999)
                            {
                                meas.surface_isobaric0100_windspeed = none;
                            }
                            if ((int)measurement.surface_isobaric0100_wind == -9990)
                            {
                                meas.surface_isobaric0100_wind = none;
                            }
                            if ((int)measurement.surface_isobaric0100_geopotential == -999)
                            {
                                meas.surface_isobaric0100_geopotential = none;
                            }

                            if ((int)measurement.tropopause_temperature == -999)
                            {
                                meas.tropopause_temperature = none;
                            }
                            if ((int)measurement.tropopause_dewpoint == -999)
                            {
                                meas.tropopause_dewpoint = none;
                            }

                            if ((int)measurement.tropopause_windspeed == -999)
                            {
                                meas.tropopause_windspeed = none;
                            }
                            if ((int)measurement.tropopause_wind == -9990)
                            {
                                meas.tropopause_wind = none;
                            }

                            if ((int)measurement.tropopause_dewpoint == -999)
                            {
                                meas.tropopause_dewpoint = none;
                            }

                        }
                        MeasurementData.Add(station.Code.ToString(), meas);
                    }                  

                }
            }
            return View(MeasurementData);
        }

    }
}
