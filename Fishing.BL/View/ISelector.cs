using Fishing.BL.Model.Baits;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using System;
using System.Drawing;

namespace Fishing.View.LureSelector.View {

    public interface ISelector<T> : IView<SelectorPresenter<T>> where T : FishBait {
        T FishBait { get; set; }
        Image Picture { get; set; }
        string DeepBoxText { get; set; }
        string SizeBoxText { get; set; }

        event EventHandler LureListIndexChanged;

        event EventHandler LureListDoubleClick;
    }
}