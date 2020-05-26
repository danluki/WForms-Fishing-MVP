using Fishing.AbstractFish;
using Fishing.BL.Controller;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Fishing.BL.Model.Game.Inventory;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public sealed class Player {

        private const int SATIETY_MAX_VALUE = 100;
        private const int SATIETY_MIN_VALUE = 0;




        #region Properties
        public PInventory Inventory { get; set; } = new PInventory();
        public FishInventory FishInventory { get; set; } = new FishInventory();
        [field: NonSerialized]
        public Feedup EquipedFeedUp { get; set; }
        public GameRod FirstRoad { get; set; }
        public GameRod SecondRoad { get; set; }
        public GameRod ThirdRoad { get; set; }
        public GameRod EquipedRoad { get; set; }
        public Lvl CurrentLvl { get; set; }
        [field: NonSerialized]
        public bool IsFeedingUp { get; set; }
        [field: NonSerialized]
        public bool IsNettingFish { get; set; }
        public int Satiety { get; set; } = 100;
        public Statistic Statistic { get; set; } = new Statistic();
        public string NickName { get; set; } = "Рыболов";
        public int Money { get; set; } = 999999;
        public int WindingSpeed { get; set; }
        public int HoursRemain { get; set; } = 999999;

        #endregion

        #region Events
        [field: NonSerialized]
        public event Action SatietyUpdated;
        [field: NonSerialized]
        public event Action Gathering;
        [field: NonSerialized]
        public event Action DoNetting;
        [field: NonSerialized]
        public event Action UpdateBucketImage;
        [field: NonSerialized]
        public event Action<Point> GiveUped;

        #endregion


        public Player() { }


        public bool IsAbleToBuyItem(Item item) {
            bool result = false;
            if (item != null) {
                result = item.Price <= Money;
            }
            return result;
        }

        public bool BuyItem(Item item) {
            if (IsAbleToBuyItem(item)) {
                item.UniqueIdentifer = Guid.NewGuid();
                Inventory.AddItem(item);
                Money -= item.Price;
                return true;
            }
            return false;

        }



        public void GiveUp(GameRod road) {
            road.CurrentFeedUp = EquipedFeedUp;
            road.CurrentFeedUp.Count -= 1;
            IsFeedingUp = true;
            GiveUped?.Invoke(road.CurPoint);
        }

        public void StartNetting() {
            DoNetting?.Invoke();
        }


        public bool IsPlayerAbleToFishing() {
            if (EquipedRoad.Assembly?.FishBait != null) {
                if (Satiety > 0) {
                    return true;
                }
            }
            return false;
        }


        public void SetGameRoad(Assembly ass, int index) {
            if (ass == null) return;
            if (ass.IsAssemblyFull()) {
                switch (index) {
                    case 1:
                    FirstRoad = new GameRod(ass) {
                        RoadX = 100,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;

                    case 2:
                    SecondRoad = new GameRod(ass) {
                        RoadX = 200,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;

                    case 3:
                    ThirdRoad = new GameRod(ass) {
                        RoadX = 300,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;
                }
            }
            else {
                MessageBox.Show(@"Сборка не собрана");
            }
        }

        public GameRod GetRoadByIndex(int index) {
            switch (index) {
                case 1:
                return FirstRoad;

                case 2:
                return SecondRoad;

                case 3:
                return ThirdRoad;
            }
            return null;
        }

        public void SetEquipedRoad(int index) {
            switch (index) {
                case 1:
                EquipedRoad = FirstRoad;
                break;

                case 2:
                EquipedRoad = SecondRoad;
                break;

                case 3:
                EquipedRoad = ThirdRoad;
                break;
            }
        }

        public void SetEquipedRoad(GameRod rod) {
            EquipedRoad = rod;
        }

        public void LetGoFish(Fish fish) {
            //Need to add Carma
            FishInventory.RemoveFish(fish);
        }

        public int CountPriceOfFish(Fish fish) {
            if (fish != null) {
                if (!fish.IsTrophy()) {
                   return (int)fish.Price * fish.Weight;
                }
                else {
                    return (int)fish.Price * 3 * fish.Weight;
                }
            }
            return 0;
        }

        public void SellFish(Fish fish) {
            if (fish != null) {
                var fPrice = CountPriceOfFish(fish);
                Money += fPrice;
                FishInventory.RemoveFish(fish);
            }
        }      

        public void DoGathering(GameRod road) {
            road.IsFishAttack = false;
            Statistic.GatheringCount++;
            Statistic.AddEventToHistory(new GatheringEvent());
            SoundsPlayer.PlayGatheringSound();
            road.Image = Roads.road;
            road.FLineIncValue = 0;
            road.RoadIncValue = 0;
            if (road.Assembly.Rod.RodType == RodType.Feeder || road.Assembly.Rod.RodType == RodType.Float) {
                ((Bait)road.Assembly.FishBait).Count -= 1;
                if (((Bait)road.Assembly.FishBait)?.Count <= 0) {
                    //BaitInventory.Remove((Bait)road.Assembly.FishBait);
                }
                road.Assembly.FishBait = null;
            }
            Gathering?.Invoke();
        }

        public void BrokeRoad() {
            EquipedRoad.Image = Roads.broken;
            EquipedRoad.IsBaitInWater = false;
            EquipedRoad.IsFishAttack = false;
            EquipedRoad.Assembly.Rod = null;
            EquipedRoad.CurPoint = Point.Empty;
            EquipedRoad.FLineIncValue = 0;
            EquipedRoad.RoadIncValue = 0;
            Statistic.BrokensRoadsCount++;
        }

        public void TornFLine() {
            EquipedRoad.Image = Roads.road;
            EquipedRoad.IsFishAttack = false;
            EquipedRoad.Assembly.FishBait = null;
            EquipedRoad.IsBaitMoving = false;
            EquipedRoad.CurPoint = Point.Empty;
            EquipedRoad.FLineIncValue = 0;
            EquipedRoad.RoadIncValue = 0;
            Statistic.TornsFLinesCount++;
            Statistic.GatheringCount++;
        }

        public void DecSatiety(int value) {
            if (value >= 0) {
                if (Satiety - value >= SATIETY_MIN_VALUE) {
                    Satiety -= value;
                }
            }
            SatietyUpdated?.Invoke();
        }

        public void AddFishToPond() {
            Statistic.TakenFishesCount++;
            if (!EquipedRoad.Fish.IsTrophy()) {
                Statistic.AddEventToHistory(new FishEvent(EquipedRoad.Fish,
                    EquipedRoad.Assembly.FishBait));
            }
            else {
                Statistic.AddEventToHistory(new TrophyFishEvent(EquipedRoad.Fish,
                    EquipedRoad.Assembly.FishBait));
            }
            if (EquipedRoad.Assembly.Rod.RodType == RodType.Feeder || EquipedRoad.Assembly.Rod.RodType == RodType.Float) {
                ((Bait)EquipedRoad.Assembly.FishBait).Count -= 1;
                if (((Bait)EquipedRoad.Assembly.FishBait).Count <= 0) {
                    EquipedRoad.Assembly.FishBait = null;
                }
            }
        }

        public bool Eat(Food food) {
            if (food != null) {
                if (Satiety + food.Productivity <= SATIETY_MAX_VALUE) {
                    Satiety += food.Productivity;
                    Inventory.AddItem(food);
                    Statistic.AddEventToHistory(new FoodEvent(food));
                    SatietyUpdated?.Invoke();
                    return true;
                }
                else {
                    MessageBox.Show(@"Игрок не достаточно голоден, чтобы съесть это");
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
}