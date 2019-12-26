using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing.BL {

    [Serializable]
    public class MapInfo {
        public string WaterName { get; set; }

        public string WaterInfoString { get; set; }
        public List<PicturesBoxInfo> Locations { get; set; } = new List<PicturesBoxInfo>();
        public Image BackImg { get; set; }
    }
}