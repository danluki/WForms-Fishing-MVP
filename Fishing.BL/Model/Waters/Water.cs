using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing.BL.Model.Waters {

    [Serializable]
    public abstract class Water {
        public Image MapImage { get; set; }
        public List<PicturesBoxInfo> Locations { get; set; }
        public int DailyPrice { get; set; }
        public int KmFromNearestStation { get; set; }
        public string Name { get; set; }

        public int MinLVL { get; set; }

        public abstract Water GetLVL(string name);

        public override string ToString() {
            return Name;
        }
    }
}