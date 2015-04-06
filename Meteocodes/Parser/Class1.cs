using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes;

namespace Parser
{
    static public class Parser
    {
        static public void Razdel01(ref Meteocode theCode, string raw)
        {
            /*
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
