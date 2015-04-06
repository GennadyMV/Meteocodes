using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Codes
{
    public class Meteocode
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual string raw { get; set; }

        public virtual string MiMiMiMi { get; set; } //Буквенный указатель кодовой формы и ее части

        // Группа 35.2.1.3 YYGGId
        public virtual int YY { get; set; } // Число месяца
        public virtual int GG { get; set; } // Срок наблюдения по МСВ
        public virtual int Idd { get; set; } // Указатель последеней стандартной изобарической поверхности,
                                // для которой в сводку включены данные о ветре
        
        // Группа 35.2.1.4 IIiii
        public virtual int II { get; set; } //Номер района
        public virtual int iii { get; set; } //Номер станции в пределах района

        // Группа 35.2.2 Данные наблюдений у поверхности земли и на стандартных изобарических поверхностях
        // 99P0P0P0     T0T0Ta0D0D0 d0d0f0f0f0
        // . . .
        // 99PnPnPn     TnTnTanDnDn dndnfnfnfn
        public virtual float pressure { get; set; }      // Давление в целых гПа
        public virtual float temperature { get; set; }       // Температура воздуха в целых градусах
        public virtual float dewpoint { get; set; } // дефицит точки росы
        public virtual int wind_direction { get; set; } // направление ветра
        public virtual int wind_speed { get; set; } // скорость ветра


        public virtual void Save()
        {
            
            ISession session = Domain.Domain.CurrentSession;
            ITransaction tr = session.BeginTransaction();

            try
            {
                this.created_at = DateTime.Now;
                this.updated_at = DateTime.Now;
                                
                session.Save(this);
                tr.Commit();
                session.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                tr.Rollback();
            }            

        }

        public virtual void Print()
        {

            ISession session = Domain.Domain.CurrentSession;
            

            IQuery q = session.CreateQuery("FROM Meteocode");
            foreach (var p in q.List().Cast<Meteocode>())
            {
                Console.WriteLine(string.Format("{0} {1} {2} {3}",
                                                p.MiMiMiMi , p.YY, p.GG, p.Idd));
            }

        }
    

    }
}
