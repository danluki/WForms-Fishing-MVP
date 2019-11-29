using Fishing.BL.View;
using System;

namespace Fishing.View.Assembly {

    public interface IAddAssembly : IView {
        string AssemblyName { get; set; }

        event EventHandler AddAssemblyClick;
    }
}