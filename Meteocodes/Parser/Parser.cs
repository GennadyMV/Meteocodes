using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes;
using Codes.Models;
using Codes.Repositories;

namespace Parser
{
    static public class Parser
    {
        static public void Razdel01(int year, int month, int day, string rawData)
        {
            int YYYY = year;
            int MM = month;

            rawData = rawData.Replace("  ", " ");

            int index = 0;
            string[] rawArray = rawData.Split(' ');
            
            index++;
            string dis;
            dis = rawArray[index];            
            int DD = Convert.ToInt32(dis.Substring(0, 2));
            if (DD > 50)
            {
                DD -= 50;
            }
            int GG = Convert.ToInt32(dis.Substring(2, 2));
            //theCode.Idd = Convert.ToInt32(dis.Substring(4, 1));            
            

            // индекс станции
            index++;
            dis = rawArray[index];
            int Code = Convert.ToInt32(dis.Substring(0, 5));
            StationRepository repo = new StationRepository();
            Station station = repo.GetByCode(Code);
            if (station == null)
            {
                station = new Station();
                station.Save();
            }
            station.Code = Code;
            
            // срок наблюдения
            Measurement meas = (new Measurement()).GetByDateUTC(station, YYYY, MM, DD, GG);
            if (meas == null)
            {
                meas = new Measurement();
                meas.YYYY = YYYY;
                meas.MM = MM;
                meas.DD = DD;
                meas.GG = GG;
                meas.Station = station;
                meas.Save();

            }

            // Давление на поверхности земли
            index++;
            dis = rawArray[index];
            string control = dis.Substring(0, 2);
            if (control != "99")
            {
                throw new Exception("35.2.2.1.1 Группа не соответствует контрольной цифре 99: " + dis);
            }
            string presure = dis.Substring(2,3);
            int surface_pressure = Convert.ToInt32(presure);
            if (surface_pressure < 100)
            {
                surface_pressure += 1000;
            }
            meas.surface_pressure = surface_pressure;
            meas.Update();


            // Температура на поверхности земли
            index++;
            dis = rawArray[index];
            int T0T0 = Convert.ToInt32(dis.Substring(0, 2));
            int Ta0 = Convert.ToInt32(dis.Substring(2, 1));
            meas.surface_temperature = (float)T0T0;
            meas.surface_temperature += (float)(Ta0 * 0.1);
            switch (Ta0)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    meas.surface_temperature *= (float)(-1);
                    break;
            }
            string dewpoint = dis.Substring(3, 2);
            if (dewpoint == "//")
            {
                dewpoint = "-999";
            }
            int surface_dewpoint = Convert.ToInt32(dewpoint);
            meas.surface_dewpoint = (float) surface_dewpoint;
            if (0 <= surface_dewpoint && surface_dewpoint <= 50)
            {
                meas.surface_dewpoint = (float)((float)surface_dewpoint * 0.1);
            }
            if (56 <= surface_dewpoint && surface_dewpoint <= 99)
            {
                meas.surface_dewpoint = (float)((float)surface_dewpoint - 50);
            }
            
            meas.Update();



            // Ветер
            index++;
            dis = rawArray[index];
            string wind = dis.Substring(0, 2);
            if (wind == "//")
            {
                wind = "-999";
            }
            string windspeed = dis.Substring(2, 3);
            if (windspeed == "///")
            {
                windspeed = "-999";
            }

            int _wind = Convert.ToInt32(wind);
            int _windspeed = Convert.ToInt32(windspeed);
            meas.surface_wind = _wind * 10;
            if (_windspeed >= 500)
            {
                _windspeed -= 500;
                meas.surface_wind += 5;
            }
            meas.surface_windspeed = _windspeed;
            
            meas.Update();

            // Стандартные изобарические поверхности
            index++;
            dis = rawArray[index];
            while (dis.Substring(0, 2) != "88" && dis.Substring(0, 2) != "77" && index < rawArray.Count()) 
            {
                

                string code_isobarc_surface_str = dis.Substring(0, 2);
                int code_isobaric_surface = Convert.ToInt32(code_isobarc_surface_str);

                string code_geopotential_str = dis.Substring(2, 3);
                if (code_geopotential_str == "///")
                {
                    code_geopotential_str = "-999";
                }
                int code_geopotential = Convert.ToInt32(code_geopotential_str);

                if (code_isobaric_surface == 0 && code_geopotential >= 500)
                {
                    code_geopotential -= 500;
                }


                // Температура на стандартной изобарической поверхности
                index++;
                dis = rawArray[index];
                int T0T0_isobaric;
                int Ta0_isobaric;
                float meas_surface_temperature=-999;
                int surface_dewpoint_isobaric=-999;
                float meas_surface_dewpoint=-999;

                if (dis != "/////")
                {
                    T0T0_isobaric = Convert.ToInt32(dis.Substring(0, 2));
                    Ta0_isobaric = Convert.ToInt32(dis.Substring(2, 1));
                    meas_surface_temperature = (float)T0T0_isobaric;
                    meas_surface_temperature += (float)(Ta0_isobaric * 0.1);
                    switch (Ta0)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 9:
                            meas_surface_temperature *= (float)(-1);
                            break;
                    }
                    string dewpoint_isobaric = dis.Substring(3, 2);
                    if (dewpoint_isobaric == "//")
                    {
                        dewpoint_isobaric = "-999";
                    }
                    surface_dewpoint_isobaric = Convert.ToInt32(dewpoint_isobaric);

                    meas_surface_dewpoint = (float)surface_dewpoint_isobaric;
                    if (0 <= surface_dewpoint_isobaric && surface_dewpoint_isobaric <= 50)
                    {
                        meas_surface_dewpoint = (float)((float)surface_dewpoint_isobaric * 0.1);
                    }
                    if (56 <= surface_dewpoint_isobaric && surface_dewpoint_isobaric <= 99)
                    {
                        meas_surface_dewpoint = (float)((float)surface_dewpoint_isobaric - 50);
                    }
                }

                // Ветер
                index++;
                dis = rawArray[index];
                string wind_isobaric = dis.Substring(0, 2);
                if (wind_isobaric == "//")
                {
                    wind_isobaric = "-999";
                }
                string windspeed_isobaric = dis.Substring(2, 3);
                if (windspeed_isobaric == "///")
                {
                    windspeed_isobaric = "-999";
                }

                int _wind_isobaric = Convert.ToInt32(wind_isobaric);
                int _windspeed_isobaric = Convert.ToInt32(windspeed_isobaric);
                int meas_surface_wind = _wind_isobaric * 10;
                if (_windspeed_isobaric >= 500)
                {
                    _windspeed_isobaric -= 500;
                    meas_surface_wind += 5;
                }
                int meas_surface_windspeed = _windspeed_isobaric;

                
                switch (code_isobaric_surface)
                {
                    case 0:
                        meas.surface_isobaric1000_geopotential = code_geopotential;
                        meas.surface_isobaric1000_temperature = meas_surface_temperature;
                        meas.surface_isobaric1000_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric1000_wind = meas_surface_wind;
                        meas.surface_isobaric1000_windspeed = meas_surface_windspeed;
                        break;
                    case 92:
                        meas.surface_isobaric0925_geopotential = code_geopotential;
                        meas.surface_isobaric0925_temperature = meas_surface_temperature;
                        meas.surface_isobaric0925_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0925_wind = meas_surface_wind;
                        meas.surface_isobaric0925_windspeed = meas_surface_windspeed;
                        break;
                    case 85:
                        meas.surface_isobaric0850_geopotential = code_geopotential;
                        meas.surface_isobaric0850_temperature = meas_surface_temperature;
                        meas.surface_isobaric0850_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0850_wind = meas_surface_wind;
                        meas.surface_isobaric0850_windspeed = meas_surface_windspeed;
                        break;
                    case 70:
                        meas.surface_isobaric0700_geopotential = code_geopotential;
                        meas.surface_isobaric0700_temperature = meas_surface_temperature;
                        meas.surface_isobaric0700_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0700_wind = meas_surface_wind;
                        meas.surface_isobaric0700_windspeed = meas_surface_windspeed;
                        break;
                    case 50:
                        meas.surface_isobaric0500_geopotential = code_geopotential;
                        meas.surface_isobaric0500_temperature = meas_surface_temperature;
                        meas.surface_isobaric0500_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0500_wind = meas_surface_wind;
                        meas.surface_isobaric0500_windspeed = meas_surface_windspeed;
                        break;
                    case 40:
                        meas.surface_isobaric0400_geopotential = code_geopotential;
                        meas.surface_isobaric0400_temperature = meas_surface_temperature;
                        meas.surface_isobaric0400_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0400_wind = meas_surface_wind;
                        meas.surface_isobaric0400_windspeed = meas_surface_windspeed;
                        break;
                    case 30:
                        meas.surface_isobaric0300_geopotential = code_geopotential;
                        meas.surface_isobaric0300_temperature = meas_surface_temperature;
                        meas.surface_isobaric0300_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0300_wind = meas_surface_wind;
                        meas.surface_isobaric0300_windspeed = meas_surface_windspeed;
                        break;
                    case 25:
                        meas.surface_isobaric0250_geopotential = code_geopotential;
                        meas.surface_isobaric0250_temperature = meas_surface_temperature;
                        meas.surface_isobaric0250_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0250_wind = meas_surface_wind;
                        meas.surface_isobaric0250_windspeed = meas_surface_windspeed;
                        break;
                    case 20:
                        meas.surface_isobaric0200_geopotential = code_geopotential;
                        meas.surface_isobaric0200_temperature = meas_surface_temperature;
                        meas.surface_isobaric0200_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0200_wind = meas_surface_wind;
                        meas.surface_isobaric0200_windspeed = meas_surface_windspeed;
                        break;
                    case 15:
                        meas.surface_isobaric0150_geopotential = code_geopotential;
                        meas.surface_isobaric0150_temperature = meas_surface_temperature;
                        meas.surface_isobaric0150_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0150_wind = meas_surface_wind;
                        meas.surface_isobaric0150_windspeed = meas_surface_windspeed;
                        break;
                    case 10:
                        meas.surface_isobaric0100_geopotential = code_geopotential;
                        meas.surface_isobaric0100_temperature = meas_surface_temperature;
                        meas.surface_isobaric0100_dewpoint = meas_surface_dewpoint;
                        meas.surface_isobaric0100_wind = meas_surface_wind;
                        meas.surface_isobaric0100_windspeed = meas_surface_windspeed;
                        break;
                    default:
                        throw new Exception("Не обнаружена стандартная изобарическая поверхность в разделе TTAA с кодом:" + code_isobaric_surface.ToString());
                        break;
                }
                meas.Update();

                index++;
                dis = rawArray[index];

                if (code_isobaric_surface == 10)
                {
                    break;
                }
            } 

            

            station.Update();
            /*
            index++;
            dis = rawArray[index];
            string control = dis.Substring(0, 2);
            if (control != "99")
            {
                throw new Exception("35.2.1.5 Группа не соответствует контрольной цифре 99: " + dis);
            }
            theCode.LaLaLa = Convert.ToInt32(dis.Substring(2, 3));

            index++;
            dis = rawArray[index];
            theCode.Qc = Convert.ToInt32(dis.Substring(0, 1));
            theCode.L0L0L0L0 = Convert.ToInt32(dis.Substring(1, 4));

            index++;
            dis = rawArray[index];
            theCode.MMM = Convert.ToInt32(dis.Substring(0, 3));
            theCode.ULa = Convert.ToInt32(dis.Substring(3, 1));
            theCode.UL0 = Convert.ToInt32(dis.Substring(4, 1));
            */
            
        }

        static public void Razdel02(ref Meteocode theCode, string raw)
        {
            int index = 0;
            string[] rawArray = raw.Split(' ');
            theCode.MiMiMiMi = rawArray[index];

            index++;
            string dis;
            dis = rawArray[index];
            theCode.YY = Convert.ToInt32(dis.Substring(0, 2));
            theCode.GG = Convert.ToInt32(dis.Substring(2, 2));
            theCode.Idd = Convert.ToInt32(dis.Substring(4, 1));

            index++;
            dis = rawArray[index];
            theCode.II = Convert.ToInt32(dis.Substring(0, 2));
            theCode.iii = Convert.ToInt32(dis.Substring(2, 3));

        }

    }
}
