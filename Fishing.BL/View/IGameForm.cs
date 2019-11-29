using Fishing.BL.View;
using Fishing.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;
using Fishing.AbstractFish;

namespace Fishing.BL.View {

    public interface IGameForm : IView {
        Point CurPoint { get; set; }
        Image BackImage { get; set; }

        event MouseEventHandler FormMouseClick;

        event PaintEventHandler RepaintScreen;

        event KeyEventHandler KeyDOWN;

        event KeyEventHandler KeyUP;

        event EventHandler MainTimerTick;

        event EventHandler FormClose;

        event EventHandler DecSacietyTimerTick;

        LVLPresenter LVLPresenter { set; }

        void UpdateForm();

        void CreateCurrentFish(Fish fish);
    }
}