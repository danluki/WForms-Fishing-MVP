using Fishing.AbstractFish;
using Fishing.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        LvlPresenter LVLPresenter { get; set; }

        void UpdateForm();

        void CreateCurrentFish(Fish fish);
    }
}