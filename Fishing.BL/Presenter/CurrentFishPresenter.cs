using Fishing.BL.View;

namespace Fishing.BL.Presenter {

    public class CurrentFishPresenter {
        private readonly ICurrentFishF view;

        public CurrentFishPresenter(ICurrentFishF view) {
            this.view = view;
        }
    }
}