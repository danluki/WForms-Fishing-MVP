using System.Drawing;

namespace Fishing.BL.View {

    public interface IMap {
        Image BackImage { get; set; }

        void Open();

        void Down();
    }
}