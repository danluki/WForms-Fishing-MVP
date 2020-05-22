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

        [NonSerialized]
        private FeedUp _equipedFeedUp;
        private GameRod _firstRoad;
        private GameRod _secondRoad;
        private GameRod _thirdRoad;
        private GameRod _equipedRoad;
        [NonSerialized]
        private bool _isFeedingUp;
        [NonSerialized]
        private bool _isNettingFish;
        private int _satiety;
        [NonSerialized]
        private Lvl _currentLvl;
        private Statistic _statistic;
        private string _name;
        private int _money;
        private int _windingSpeed;
        private int _hoursRemain;
        public BindingList<Fish> Fishlist = new BindingList<Fish>();
        public BindingList<Assembly> Assemblies = new BindingList<Assembly>();
        public BindingList<Rod> RodInventory = new BindingList<Rod>();
        public BindingList<Reel> ReelInventory = new BindingList<Reel>();
        public BindingList<Fishingline> FlineInventory = new BindingList<Fishingline>();
        public BindingList<Bait> BaitInventory = new BindingList<Bait>();
        public BindingList<Lure> LureInventory = new BindingList<Lure>();
        public BindingList<Aroma> AromaInventory = new BindingList<Aroma>();
        public BindingList<Basic> BasicInventory = new BindingList<Basic>();
        public BindingList<FeedUp> FeedUpInventory = new BindingList<FeedUp>();
        public BindingList<Food> FoodInventory = new BindingList<Food>();
        public BindingList<BaseHook> HooksInventory = new BindingList<BaseHook>();
        public Stack<BaseEvent> EventHistory = new Stack<BaseEvent>();


        #region Properties
        public FeedUp EquipedFeedUp {
            get {
                return _equipedFeedUp;
            } 
            set {
                _equipedFeedUp = value;
            } 
        }
        public GameRod FirstRoad {
            get {
                return _firstRoad;
            }
            set {
                _firstRoad = value;
            }
        }
        public GameRod SecondRoad {
            get {
                return _secondRoad;
            }
            set {
                _secondRoad = value;
            }
        }
        public GameRod ThirdRoad {
            get {
                return _thirdRoad;
            }
            set {
                _thirdRoad = value;
            }
        }
        public GameRod EquipedRoad {
            get {
                return _equipedRoad;
            }
            set {
                _equipedRoad = value;
            }
        }
        public Lvl CurrentLvl {
            get {
                return _currentLvl;
            }
            set {
                _currentLvl = value;
            }
        }
        
        public bool IsFeedingUp {
            get {
                return _isFeedingUp;
            }
            set {
                _isFeedingUp = value;
            }
        }
        public bool IsNettingFish {
            get {
                return _isNettingFish;
            }
            set {
                _isNettingFish = value;
            }
        }
        public int Satiety {
            get {
                return _satiety;
            }
            set {
                _satiety = value;
            }
        }
        public Statistic Statistic {
            get {
                return _statistic;
            }
            set {
                _statistic = value;
            }
        }
        public string NickName {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }
        public int Money {
            get {
                return _money;
            }
            set {
                _money = value;
            }
        }
        public int WindingSpeed {
            get {
                return _windingSpeed;
            }
            set {
                _windingSpeed = value;
            }
        }
        public int HoursRemain {
            get {
                return _hoursRemain;
            }
            set {
                _hoursRemain = value;
            }
        }

        #endregion

        #region Events
        [field: NonSerialized]
        public event Action SatietyUpdated;
        [field: NonSerialized]
        public event Action Gathering;
        [field: NonSerialized]
        public event Action DoNetting;
        [field: NonSerialized]
        public event Action EventHistoryUpdated;
        [field: NonSerialized]
        public event Action UpdateBucketImage;
        [field: NonSerialized]
        public event Action<Point> GiveUped;

        #endregion


        public Player() {

            Statistic = new Statistic();
            HoursRemain = 999999;
            Money = 999999;
            Satiety = 100;
            NickName = "Рыболов";
        }

        public bool BuyItem(Item item) {
            if (IsAbleToBuyItem(item)) {
                switch (item) {
                    case Rod _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    Assemblies.Add(new Assembly(item as Rod));
                    Money -= item.Price;
                    return true;

                    case Reel _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    ReelInventory.Add(item as Reel);
                    Money -= item.Price;
                    return true;

                    case Fishingline _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    FlineInventory.Add(item as Fishingline);
                    Money -= item.Price;
                    return true;

                    case Bait _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    BaitInventory.Add(item as Bait);
                    Money -= item.Price;
                    return true;

                    case Lure _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    LureInventory.Add(item as Lure);
                    Money -= item.Price;
                    return true;

                    case BaseHook _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    LureInventory.Add(item as Lure);
                    Money -= item.Price;
                    return true;

                    case Basic _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    BasicInventory.Add(item as Basic);
                    Money -= item.Price;
                    return true;

                    case Aroma _:
                    item.UniqueIdentifer = Guid.NewGuid();
                    AromaInventory.Add(item as Aroma);
                    Money -= item.Price;
                    return true;
                }
            }
            return false;

        }

        public void GiveUp(GameRod road) {
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
            var b = BaitInventory.First(i => name.Equals(i.Name));
            return b;
        }

        public Reel GetReelByName(string name) {
            if (name == null) return null;
            var b = ReelInventory.First(i => name.Equals(i.Name));
            return b;
        }

        public Item GetItemByName(string name) {
            var items = new List<Item>();
            items.AddRange(RodInventory);
            items.AddRange(FlineInventory);
            items.AddRange(LureInventory);
            items.AddRange(BaitInventory);
            items.AddRange(HooksInventory);
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

        public void SetEquipedRoad(GameRod r) {
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
                //GameLoader.GetLoader().SavePlayer();
            }
        }

        public void AddBait(Bait bait) {
            var b = BaitInventory.FirstOrDefault(fb => bait.Name.Equals(fb.Name));
            if (b != default) {
                BaitInventory[BaitInventory.IndexOf(b)].Count += bait.Count;
            }
            else {
                BaitInventory.Add(bait);
            }
        }

        public void DoGathering(GameRod road) {
            road.IsFishAttack = false;
            Statistic.GatheringCount++;
            AddEventToHistory(new GatheringEvent());
            SoundsPlayer.PlayGatheringSound();
            road.Image = Roads.road;
            road.FLineIncValue = 0;
            road.RoadIncValue = 0;
            if (road.Assembly.Road.RodType == RodType.Feeder || road.Assembly.Road.RodType == RodType.Float) {
                ((Bait)road.Assembly.FishBait).Count -= 1;
                if (((Bait)road.Assembly.FishBait)?.Count <= 0) {
                    BaitInventory.Remove((Bait)road.Assembly.FishBait);
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
            if (EquipedRoad.Assembly.Road.RodType == RodType.Feeder || EquipedRoad.Assembly.Road.RodType == RodType.Float) {
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
                    FoodInventory.Remove(food);
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