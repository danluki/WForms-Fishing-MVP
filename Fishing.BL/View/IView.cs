using Fishing.BL.Presenter;

namespace Fishing.BL.View {

    public interface IView<T> where T : BasePresenter {

        void Open();

        void Down();

        T Presenter { get; set; }
    }
}