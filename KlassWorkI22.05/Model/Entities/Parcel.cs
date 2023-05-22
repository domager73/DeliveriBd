using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassWorkI22._05.Model.Entities
{
    internal class Parcel
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int IdCiy { get; set; }
        public float Weight { get; set; }
        public string Dimens { get; set; }
        public int Price { get; set; }

        public City City { get; set; }
    }
}
