using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Fishing.BL.Model.Waters {

    [Serializable]
    public class WaterImplementation : Water {

        public override Water GetLVL(string name) {
            var path = @"C:\Users\Programmer\Desktop\MVPFishing-master\Fishing.BL\Model\Waters" + "\\" + name;
            var s = new SerializeDataSaver();
            var sb = File.ReadAllText(path + "\\" + "WaterInfo");
            var ar = sb.Split(' ');

            MapImage = Image.FromFile(path + "\\" + "MapImg.png");
            Name = ar[0];
            MinLVL = Convert.ToInt32(ar[1]);
            DailyPrice = Convert.ToInt32(ar[2]);
            KmFromNearestStation = Convert.ToInt32(ar[3]);
            Locations = s.Load<List<PicturesBoxInfo>>(path + "\\" + "Map.dat");

            return this;
        }
    }
}