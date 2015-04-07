using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using Codes.Repositories;
using System.Web;

namespace Codes.Models
{
    public class Station
    {
        public Station()
        {
            this._Measurements = new System.Collections.Generic.HashSet<Measurement>();
        }

        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual string Name { get; set; }
        public virtual int Code { get; set; }

        public virtual void Save()
        {
            IRepository<Station> repo = new StationRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Station> repo = new StationRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

        private ICollection<Measurement> _Measurements;
        public virtual ICollection<Measurement> Measurements
        {
            get
            {
                return this._Measurements;
            }
            set
            {
                this._Measurements = value;
            }
        }
    }
}
