using Fishing.BL.Model.Game;
using Fishing.Presenter;
using Fishing.View.ShopForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Tests {
    [TestClass]
    public class ShopPresenterTests {

        private IShop _view;

        [TestMethod]
        public void FailData() {
            Assert.ThrowsException<ArgumentException>(delegate() { new ShopPresenter(_view); });
        }

    }
}
