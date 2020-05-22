using Fishing.BL.Presenter;
using System;
using System.Drawing;

namespace Fishing.BL.View {

    public interface IFPond : IView<FPondPresenter> {

        event EventHandler SelectedIndexChanged;

        event EventHandler SellButtonClick;

        Image RightImage { get; set; }
        int SelectedIndex { get; set; }
        string DescriptionText { get; set; }
    }
}