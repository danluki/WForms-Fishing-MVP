using Fishing.BL.Presenter;

namespace Fishing.BL.View {

    public interface IView {

        void Open();

        void Down();

        BasePresenter Presenter { set; }
    }
}