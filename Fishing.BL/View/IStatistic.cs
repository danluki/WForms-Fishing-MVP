using Fishing.BL.Presenter;
using System;
using System.Windows.Forms;

namespace Fishing.BL.View {

    public interface IStatistic : IView<StatisticPresenter> {

        event EventHandler LoadForm;

        string NameLText { get; set; }
        string MoneyLText { get; set; }
        string GatheringLText { get; set; }
        string BrokenRoadsLText { get; set; }
        string TornFLineLText { get; set; }
        string TakeFishesLText { get; set; }

        void addEventToView(ListViewItem i);
    }
}