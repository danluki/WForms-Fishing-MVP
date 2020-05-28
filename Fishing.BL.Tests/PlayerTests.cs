using Fishing.BL.Controller;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.Lures;
using Fishing.BL.Resources.Images;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fishing.BL.Model.Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Fishing.BL.Model.Hooks;

namespace Fishing.BL.Tests {
    [TestClass]
    public class PlayerTests {

        private Player player;
        GameRod rod1 = new GameRod(new Model.Game.Assembly(new Rod("some rod", RodType.Spinning, 0, 1000, 1000, Images.Titanium)));
        GameRod rod2 = new GameRod(new Model.Game.Assembly(new Rod("some rod2", RodType.Spinning, 0, 1000, 1000, Images.Titanium)));

        [TestInitialize]
        public void Init() {
            GameLoader.GetLoader().Initiallize("Test");
            GameLoader.GetLoader().SetFeedUps();
            GameLoader.GetLoader().IntializeLures();
            player = Game.GetGame().Player;
        }

        private Bait testBait1 = new Bait("Test Bait", 999, 999, Images.banany);
        private Bait testBait2 = new Bait("Test Bait2", 1001, 1001, Images.banany);
        private Bait testBait3 = new Bait("Test Bait3", 1001, 1000, Images.banany);
        private Lure lure1 = new Jig("Виброхвост 4", Size.XL, DeepType.Jig, 500, Images.Tvis_119);

        Rod rod = new Rod("some rod242", RodType.Spinning, 0, 1000, 1000, Images.Titanium);
        Fishingline fl1 = new Fishingline("some fline", 63, 636, Images.Atlantic);
        Reel reel1 = new Reel("some reel", 1, 1, 1, 1, Images.Quest_Reel);

        [TestMethod]
        public void IsPlayerAbleToBuyItemTest() {
            Assert.AreEqual(player.IsAbleToBuyItem(null), false);
            Assert.AreEqual(player.IsAbleToBuyItem(testBait1), true);
            player.Money = 1000;
            Assert.AreEqual(player.IsAbleToBuyItem(testBait2), false);
            Assert.AreEqual(player.IsAbleToBuyItem(testBait3), true);
        }

        [TestMethod]
        public void BuyItemTest() {
            //Проврека на null
            Assert.AreEqual(player.BuyItem(null), false);

            player.Money = 1000;
            //Невозможность покупки
            Assert.AreEqual(player.BuyItem(testBait2), false);

            player.Money = 1000;
            //Возможность покупки
            Assert.AreEqual(player.BuyItem(testBait1), true);

            player.Money = 1000;
            //Покупка, когда деньги игрока равны цене предмета.
            Assert.AreEqual(player.BuyItem(testBait3), true);

            //После обнуляющей покупки деньги должны равняться нулю.
            Assert.AreEqual(player.Money, 0);

            //Проверка, что после покупки предмет добавился правильно
            player.Inventory.Baits.TryGetValue(testBait1.UniqueIdentifer, out Bait bait);
            Assert.AreEqual(bait, testBait1);
            Assert.AreNotEqual(bait, testBait2);
        }

        [TestMethod]
        public void BuyManySameItemsTest() {
            player.Money = lure1.Price * 100000;
            for (int i = 0; i < 100000; i++) {
                player.BuyItem(lure1);
                player.Inventory.Lures.TryGetValue(lure1.UniqueIdentifer, out Lure lure);
                Assert.AreEqual(lure, lure1);
            }
        }

        [TestMethod]
        public void GiveUpTest() {
            player.EquipedFeedUp = null;
            player.GiveUp(rod1);
            Assert.AreEqual(rod1.CurrentFeedUp, null);

            player.EquipedRod = rod1;
            Feedup feedup = new Feedup(Item.Basics[0], Item.Aromas[0], testBait1);
            feedup.Create();

            player.EquipedFeedUp = feedup;
            player.GiveUp(rod1);
            player.GiveUp(rod2);
            Assert.AreEqual(rod1.CurrentFeedUp, player.EquipedFeedUp);
            Assert.AreSame(rod1.CurrentFeedUp, player.EquipedFeedUp);

            Assert.AreEqual(rod2.CurrentFeedUp, player.EquipedFeedUp);
            Assert.AreSame(rod2.CurrentFeedUp, rod1.CurrentFeedUp);

            Assert.AreEqual(rod2.CurrentFeedUp.Count, rod1.CurrentFeedUp.Count);

            Assert.AreEqual(player.IsFeedingUp, true);
        }

        [TestMethod]
        public void StartNettingTest() {
            Drawer drawer = new Drawer();
            player.EquipedRod = rod1;
            player.StartNetting(player.EquipedRod);
            Assert.AreEqual(drawer.Netting.X, player.EquipedRod.RoadX);

        }

        [TestMethod]
        public void IsPlayerAbleToFishingTest() {
            player.EquipedRod = null;
            bool res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, false);

            player.EquipedRod = rod1;
            res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, false);

            player.Satiety = 0;
            res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, false);

            rod1.Assembly = null;
            res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, false);

            player.Satiety = 100;
            rod2.Assembly.FishBait = testBait1;
            rod2.Assembly.Rod = new Rod("some rod", RodType.Spinning, 0, 1000, 1000, Images.Titanium);
            rod2.Assembly.Fline = new Fishingline("some fline", 63, 636, Images.Atlantic);
            rod2.Assembly.Reel = new Reel("some reel", 1, 1, 1, 1, Images.Quest_Reel);
            player.EquipedRod = rod2;
            res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, true);

            rod2.Assembly.FishBait = testBait1;
            rod2.Assembly.Rod = new Rod("some rod242", RodType.Feeder, 0, 1000, 1000, Images.Titanium);
            rod2.Assembly.Fline = new Fishingline("some fline", 63, 636, Images.Atlantic);
            rod2.Assembly.Reel = new Reel("some reel", 1, 1, 1, 1, Images.Quest_Reel);
            rod2.Assembly.Hook = new FeederHook("some hook", 5, 6, Images.Phantom_852);
            player.EquipedRod = rod2;
            res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, true);

            player.Satiety = 100;
            rod2.Assembly.FishBait = testBait1;
            rod2.Assembly.Rod = new Rod("some rod242", RodType.Feeder, 0, 1000, 1000, Images.Titanium);
            rod2.Assembly.Fline = new Fishingline("some fline", 63, 636, Images.Atlantic);
            rod2.Assembly.Reel = new Reel("some reel", 1, 1, 1, 1, Images.Quest_Reel);
            rod2.Assembly.Hook = null;
            player.EquipedRod = rod2;
            res = player.IsPlayerAbleToFishing();
            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void SetGameRodTest() {
            Model.Game.Assembly testAsm = new Model.Game.Assembly(new Rod("some rod", RodType.Spinning, 0, 1000, 1000, Images.Titanium));
            Model.Game.Assembly rightAsm = new Model.Game.Assembly(rod, reel1, fl1, lure1);
            player.SetGameRoad(testAsm, 1);
            Assert.AreEqual(player.FirstRod, null);

            player.SetGameRoad(testAsm, 2);
            Assert.AreEqual(player.SecondRod, null);

            player.SetGameRoad(testAsm, 3);
            Assert.AreEqual(player.ThirdRod, null);

            player.SetGameRoad(rightAsm, 1);
            Assert.AreEqual(player.FirstRod.Assembly, rightAsm);

            player.SetGameRoad(rightAsm, 2);
            Assert.AreEqual(player.SecondRod.Assembly, rightAsm);

            player.SetGameRoad(rightAsm, 3);
            Assert.AreEqual(player.ThirdRod.Assembly, rightAsm);

        }

        [TestMethod]
        public void SetEquipedRodTest() {
            Model.Game.Assembly rightAsm = new Model.Game.Assembly(rod, reel1, fl1, lure1);

            player.SetGameRoad(rightAsm, 1);
            player.SetGameRoad(rightAsm, 2);
            player.SetGameRoad(rightAsm, 3);

            player.SetEquipedRoad(1);
            Assert.AreEqual(player.EquipedRod, player.FirstRod);
            Assert.AreSame(player.EquipedRod, player.FirstRod);

            player.SetEquipedRoad(2);
            Assert.AreEqual(player.EquipedRod, player.SecondRod);
            Assert.AreSame(player.EquipedRod, player.SecondRod);

            player.SetEquipedRoad(3);
            Assert.AreEqual(player.EquipedRod, player.ThirdRod);
            Assert.AreSame(player.EquipedRod, player.ThirdRod);

        }
    }
}
