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
        static public void Razdel01(string rawData)
        {
            
            int index = 0;
            string[] rawArray = rawData.Split(' ');
            //theCode.MiMiMiMi = rawArray[index];

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
            int count = station.Measurements.Count(p => p.GG == GG && p.DD == DD);
            Measurement meas = null;
            if (count == 0)
            {
                meas = new Measurement();
                meas.DD = DD;
                meas.GG = GG;
                meas.Station = station;
                meas.Save();

            }
            else
            {
                meas = station.Measurements.Where(p => p.GG == GG && p.DD == DD).ToList()[0];
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
            meas.surface_temperature = T0T0;
            switch (Ta0)
            {
                case 0:
                case 2:
                case 4:
                case 6:
                case 8:
                    meas.surface_temperature += (float)(T0T0 + Ta0 * 0.1);
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    meas.surface_temperature += (float)(T0T0 + Ta0 * (-1) * 0.1);
                    break;
            }
            //int D0D0 = Convert.ToInt32(dis.Substring(3, 2));
            
            
            meas.Update();

            

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
