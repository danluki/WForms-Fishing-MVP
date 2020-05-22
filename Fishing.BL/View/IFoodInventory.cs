using Fishing.BL.Model.Eating;
using Fishing.BL.Presenter;
using System;

namespace Fishing.BL.View {

    public interface IFoodInventory : IView<FoodPresenter> {
        string FoodsSelectedItem { get; set; }
        string FoodProductivityTextBox { get; set; }

        void ShowFood(Food food);

        event EventHandler ListSelectedIndexChanged;

        event EventHandler ListDoubleClick;
    }
}