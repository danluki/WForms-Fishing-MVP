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

namespace Fishing.BL.Model.Game {

    [Serializable]
    public sealed class Player {
        private const int SATIETY_MAX_VALUE = 100;
        private const int SATIETY_MIN_VALUE = 0;

        public FeedUp EquipedFeedUp { get; set; }
        [NonSerialized]
        public GameRoad FirstRoad;
        [NonSerialized]
        public GameRoad SecondRoad;
        [NonSerialized]
        public GameRoad ThirdRoad;
        [NonSerialized]
        public GameRoad EquipedRoad;
        public BindingList<Fish> Fishlist { get; set; }
        public BindingList<Assembly> Assemblies { get; set; }
        public BindingList<Road> RoadInv { get; set; }
        public BindingList<Reel> ReelInv { get; set; }
        public BindingList<FLine> FLineInv { get; set; }
        public BindingList<Lure> LureInv { get; set; }
        public BindingList<Food> FoodInv { get; set; }
        public BindingList<Bait> BaitInv { get; set; }
        public BindingList<BaseHook> HooksInv { get; set; }
        public BindingList<FeedUp> FeedUpInventory { get; set; }
        public BindingList<Aroma> AromaInventory { get; set; }
        public BindingList<Basic> BasicInventory { get; set; }
        [NonSerialized]
        public Stack<BaseEvent> EventHistory;
        [NonSerialized]
        public Lvl CurrentLvl;
        public event Action EventHistoryUpdated;
        public event Action UpdateBucketImage;
        public event Action<Point> GiveUped;

        public bool IsFeedingUp = false;
        public bool IsNettingFish;
        public int Satiety { get; set; } = 100;

        public event Action SatietyUpdated;
        public event Action Gathering;
        public event Action DoNetting;

        public Statistic Statistic { get; set; }
        public int Money { get; set; }
        public int WindingSpeed { get; set; }
        public int HoursRemain;
        public string NickName { get; set; }

        public Player() {
            Fishlist = new BindingList<Fish>();
            Assemblies = new BindingList<Assembly>();
            RoadInv = new BindingList<Road>();
            ReelInv = new BindingList<Reel>();
            FLineInv = new BindingList<FLine>();
            LureInv = new BindingList<Lure>();
            FoodInv = new BindingList<Food>();
            BaitInv = new BindingList<Bait>();
            HooksInv = new BindingList<BaseHook>();
            FeedUpInventory = new BindingList<FeedUp>();
            AromaInventory = new BindingList<Aroma>();
            BasicInventory = new BindingList<Basic>();
            EventHistory = new Stack<BaseEvent>();
            Statistic = new Statistic();
            HoursRemain = 999999;
            Money = 999999;
            NickName = "Рыболов";
        }

        public void GiveUp(GameRoad road) {
            road.CurrentFeedUp = EquipedFeedUp;
            road.CurrentFeedUp.Count -= 1;
            IsFeedingUp = true;
            GiveUped?.Invoke(road.CurPoint);
        }

        public FeedUp GetFeedUpByName(string name) {
            if (name == null) return null;
            var b = FeedUpInventory.First(i => name.Equals(i.Name));
            if (b != null) {
                UpdateBucketImage?.Invoke();
            }
            return b;
        }

        public void StartNetting() {
            DoNetting?.Invoke();
        }

        public Basic GetBasicByName(string name) {
            if (name == null) return null;
            var b = BasicInventory.First(i => name.Equals(i.Name));
            return b;
        }

        public Aroma GetAromaByName(string name) {
            if (name == null) return null;
            var b = AromaInventory.First(i => name.Equals(i.Name));
            return b;
        }

        public Bait GetBaitByName(string name) {
            if (name == null) return null;
            var b = BaitInv.First(i => name.Equals(i.Name));
            return b;
        }
        public Reel GetReelByName(string name) {
            if (name == null) return null;
            var b = ReelInv.First(i => name.Equals(i.Name));
            return b;
        }

        public Item GetItemByName(string name) {
            var items = new List<Item>();
            items.AddRange(RoadInv);
            items.AddRange(FLineInv);
            items.AddRange(LureInv);
            items.AddRange(BaitInv);
            items.AddRange(HooksInv);
            return items.Find(i => i.Name.Equals(name));
        }

        public void AddEventToHistory(BaseEvent ev) {
            if (ev != null) {
                EventHistory.Push(ev);
                EventHistoryUpdated?.Invoke();
            }
        }

        public bool IsPlayerAbleToFishing() {
            if (EquipedRoad.Assembly?.FishBait != null) {
                if (Satiety > 0) {
                    return true;
                }
            }
            return false;
        }

        public bool IsAbleToBuyItem(Item item) {
            bool result = false;
            if (item != null) {
                result = item.Price <= Money;
            }
            return result;
        }

        public void SetGameRoad(Assembly ass, int index) {
            if (ass == null) return;
            if (ass.IsAssemblyFull()) {
                switch (index) {
                    case 1:
                    FirstRoad = new GameRoad(ass) {
                        RoadX = 100,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;

                    case 2:
                    SecondRoad = new GameRoad(ass) {
                        RoadX = 200,
                        RoadY = 350,
                        Image = Roads.road
                    };
                    break;

                    case 3:
                    ThirdRoad = new GameRoad(ass) {
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

        public GameRoad GetRoadByIndex(int index) {
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

        public void SetEquipedRoad(GameRoad r) {
            EquipedRoad = r;
        }

        public void AddFish(Fish f) {
            if (f != null) {
                Fishlist.Add(f);
            }
        }

        public Fish GetFishByIndex(int index) {
            try {
                return Fishlist[index];
            }
            catch (ArgumentOutOfRangeException) { }

            return null;
        }

        public void SellFish(Fish f) {
            if (f != null) {
                if (!f.IsTrophy()) {
                    Money += (int)f.Price * f.Weight;
                }
                else {
                    Money += (int)f.Price * 3 * f.Weight;
                }
                Fishlist.Remove(f);
                GameLoader.GetLoader().SavePlayer();
            }
        }

        public void AddBait(Bait bait) {
            MessageBox.Show(bait.Count.ToString());
            var b = BaitInv.FirstOrDefault(fb => bait.Name.Equals(fb.Name));
            if (b != default) {
                BaitInv[BaitInv.IndexOf(b)].Count += bait.Count;
            }
            else {
                BaitInv.Add(bait);
            }
        }

        public void DoGathering(GameRoad road) {
            road.IsFishAttack = false;
            Statistic.GatheringCount++;
            AddEventToHistory(new GatheringEvent());
            SoundsPlayer.PlayGatheringSound();
            road.Image = Roads.road;
            road.FLineIncValue = 0;
            road.RoadIncValue = 0;
            if (road.Assembly.Road.Type == RoadType.Feeder || road.Assembly.Road.Type == RoadType.Float) {
                ((Bait)road.Assembly.FishBait).Count -= 1;
                if (((Bait)road.Assembly.FishBait)?.Count <= 0) {
                    BaitInv.Remove((Bait)road.Assembly.FishBait);
                }
                road.Assembly.FishBait = null;
            }
            Gathering?.Invoke();
        }

        public void BrokeRoad() {
            EquipedRoad.Image = Roads.broken;
            EquipedRoad.IsBaitInWater = false;
            EquipedRoad.IsFishAttack = false;
            EquipedRoad.Assembly.Road = null;
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
                AddEventToHistory(new FishEvent(EquipedRoad.Fish,
                    EquipedRoad.Assembly.FishBait));
            }
            else {
               AddEventToHistory(new TrophyFishEvent(EquipedRoad.Fish,
                    EquipedRoad.Assembly.FishBait));
            }
            if (EquipedRoad.Assembly.Road.Type == RoadType.Feeder || EquipedRoad.Assembly.Road.Type == RoadType.Float) {
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
                    FoodInv.Remove(food);
                    AddEventToHistory(new FoodEvent(food));
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