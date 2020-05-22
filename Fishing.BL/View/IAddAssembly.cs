using Fishing.BL.Presenter;
using Fishing.BL.View;
using System;

namespace Fishing.View.Assembly {

    public interface IAddAssembly : IView<BasePresenter> {
        string AssemblyName { get; set; }

        event EventHandler AddAssemblyClick;
    }
}