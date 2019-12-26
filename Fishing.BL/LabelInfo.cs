using System;
using System.Windows.Forms;

namespace Fishing.BL {

    [Serializable]
    public class LabelInfo {
        public const int Width = 40;
        public const int Height = 23;
        public string Deep { get; set; }
        public int IsSnag { get; set; }

        public static explicit operator LabelInfo(Label label) {
            var li = new LabelInfo {
                Deep = label.Text,
                IsSnag = int.Parse(label.Tag.ToString()),
            };
            return li;
        }
    }
}