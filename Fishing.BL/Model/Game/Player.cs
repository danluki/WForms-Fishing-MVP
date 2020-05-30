using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game.Inventory;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public sealed class Player {

        #region Constants
        private const int SATIETY_MAX_VALUE = 100;
        private const int SATIETY_MIN_VALUE = 0;
        #endregion

        #region Properties
        public PInventory Inventory { get; set; } = new PInventory();
        public FishInventory FishInventory { get; set; } = new FishInventory();
        [field: NonSerialized]
        public Feedup EquipedFeedUp { get; set; }
        public GameRod FirstRod { get; set; }
        public GameRod SecondRod { get; set; }
        public GameRod ThirdRod { get; set; }
        public GameRod EquipedRod { get; set; }
        [field: NonSerialized]
        public Lvl CurrentLevel { get; set; }
        [field: NonSerialized]
        public bool IsFeedingUp { get; set; }
        [field: NonSerialized]
        public bool IsNettingFish { get; set; }
        public int Satiety { get; set; } = 100;
        public Statistic Statistic { get; set; } = new Statistic();
        public string Nickname { get; set; } = "Рыболов";
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
        public event Action<GameRod> DoNetting;
        [field: NonSerialized]
        public event Action UpdateBucketImage;
        [field: NonSerialized]
        public event Action<Point> GiveUped;

        #endregion

        #region ctor
        public Player() { }
        #endregion


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
            if (EquipedFeedUp == null) return;
            road.CurrentFeedUp = EquipedFeedUp;
            road.CurrentFeedUp.Count -= 1;
            IsFeedingUp = true;
            GiveUped?.Invoke(road.CurPoint);
        }

        public void StartNetting(GameRod rod) {       
            DoNetting?.Invoke(rod);
        }


        public bool IsPlayerAbleToFishing() {
            if (EquipedRod == null || EquipedRod.Assembly == null) return false;
            
            if (EquipedRod.Assembly.IsFull()) {
                if (Satiety > 0) {
                    return true;
                }
            }
            return false;
        }

        public void SetGameRoad(Assembly assembly, int index) {
            if (assembly == null) return;
            if (assembly.IsFull()) {
                switch (index) {
                    case 1:
                    FirstRod = new GameRod(assembly) {
                        RoadX = 100,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;

                    case 2:
                    SecondRod = new GameRod(assembly) {
                        RoadX = 200,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;

                    case 3:
                    ThirdRod = new GameRod(assembly) {
                        RoadX = 300,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;
                }
            }
        }

        private GameRod GetRoadByIndex(int index) {
            switch (index) {
                case 1:
                return FirstRod;

                case 2:
                return SecondRod;

                case 3:
                return ThirdRod;
            }
            return null;
        }

        public void SetEquipedRoad(int index) {
            EquipedRod = GetRoadByIndex(index);
        }

        public void SetEquipedRoad(GameRod rod) {
            EquipedRod = rod;
        }

        public void LetGoFish(Fish fish) {
            //Need to add Carma
            FishInventory.RemoveFish(fish);
        }

        public void SellFish(Fish fish) {
            if (fish != null) {
                var fPrice = fish.CountPrice();
                Money += fPrice;
                FishInventory.RemoveFish(fish);
            }
        }      

        public void DoGathering(GameRod rod) {

            rod.IsFishAttack = false;

            Statistic.GatheringCount++;
            Statistic.AddEventToHistory(new GatheringEvent());
            SoundsPlayer.PlayGatheringSound();

            rod.Image = Roads.road;
            rod.FlineIncValue = 0;
            rod.RoadIncValue = 0;

            if (rod.Assembly.Rod.RodType == RodType.Feeder || rod.Assembly.Rod.RodType == RodType.Float) {
                ((Bait)rod.Assembly.FishBait).Count -= 1;
                if (((Bait)rod.Assembly.FishBait)?.Count <= 0) {
                    //BaitInventory.Remove((Bait)road.Assembly.FishBait);
                }
                rod.Assembly.FishBait = null;
            }
            Gathering?.Invoke();
        }

        public void BrokeRoad() {
            EquipedRod.Image = Roads.broken;
            EquipedRod.IsBaitInWater = false;
            EquipedRod.IsFishAttack = false;
            EquipedRod.Assembly.Rod = null;
            EquipedRod.CurPoint = Point.Empty;
            EquipedRod.FlineIncValue = 0;
            EquipedRod.RoadIncValue = 0;
            Statistic.BrokensRoadsCount++;
        }

        public void TornFLine() {
            EquipedRod.Image = Roads.road;
            EquipedRod.IsFishAttack = false;
            EquipedRod.Assembly.FishBait = null;
            EquipedRod.IsBaitMoving = false;
            EquipedRod.CurPoint = Point.Empty;
            EquipedRod.FlineIncValue = 0;
            EquipedRod.RoadIncValue = 0;
            Statistic.TornsFlinesCount++;
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
            if (!EquipedRod.Fish.IsTrophy()) {
                Statistic.AddEventToHistory(new FishEvent(EquipedRod.Fish,
                                            EquipedRod.Assembly.FishBait));
            }
            else {
                Statistic.AddEventToHistory(new TrophyFishEvent(EquipedRod.Fish,
                                            EquipedRod.Assembly.FishBait));
            }
            if (EquipedRod.Assembly.Rod.RodType == RodType.Feeder 
                || EquipedRod.Assembly.Rod.RodType == RodType.Float) {
                ((Bait)EquipedRod.Assembly.FishBait).Count -= 1;
                if (((Bait)EquipedRod.Assembly.FishBait).Count <= 0) {
                    EquipedRod.Assembly.FishBait = null;
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
                MessageBox.Show(@"Игрок не достаточно голоден, чтобы съесть это");
                return false;
            }
            return false;
        }

        public void ResetRod(GameRod rod) {
            rod.Image = Roads.road;
            rod.FlineIncValue = 0;
            rod.RoadIncValue = 0;
        }
    }
}