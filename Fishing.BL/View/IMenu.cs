using Fishing.BL.View;
using Fishing.Presenter;
using System;

namespace Fishing.View.Menu {

    public interface IMenu : IView<MenuPresenter> {

        event EventHandler ExitButtonClick;

        event EventHandler MenuLoad;

        string NickNameL { get; set; }

        string LowerLValue { get; set; }
    }
}