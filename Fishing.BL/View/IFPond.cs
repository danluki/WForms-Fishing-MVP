using System;
using System.Drawing;
using Fishing.BL.View;

namespace Fishing.BL.View {

    public interface IFPond  : IView {

        event EventHandler SelectedIndexChanged;

        event EventHandler SellButtonClick;

        Image RightImage { get; set; }
        int SelectedIndex { get; set; }
        string DescriptionText { get; set; }
    }
}