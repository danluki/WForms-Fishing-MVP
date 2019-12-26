using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL {

    [Serializable]
    public class PicturesBoxInfo {

        public PicturesBoxInfo(int w, int h, Image img, int T, int L, string LocN) {
            Width = w;
            Height = h;
            Image = img;
            Top = T;
            Left = L;
            LocName = LocN;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public Image Image { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public string LocName { get; set; }

        public static explicit operator PicturesBoxInfo(PictureBox box) {
            return new PicturesBoxInfo(box.Width, box.Height, box.BackgroundImage, box.Top, box.Left, box.Tag.ToString());
        }
    }
}