using Fishing.BL.View;
using System;

namespace Fishing.BL.Presenter {

    public class StatisticPresenter : BasePresenter {
        private readonly IStatistic view;

        public StatisticPresenter(IStatistic view) {
            this.view = view;
            view.Presenter = this;
            view.LoadForm += View_Load;
        }

        private void View_Load(object sender, EventArgs e) {
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}