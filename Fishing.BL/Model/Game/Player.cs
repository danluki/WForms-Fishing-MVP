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
        private GameRoad _firstRoad;
        private GameRoad _secondRoad;
        private GameRoad _thirdRoad;
        private GameRoad _equipedRoad;
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
        private BindingList<Fish> _fishlist;
        private BindingList<Assembly> _assemblies;
        private BindingList<Road> _roadInventory;
        private BindingList<Reel> _reelInventory;
        private BindingList<FLine> _flineInventory;
        private BindingList<Bait> _baitsInventory;
        private BindingList<Lure> _luresInventory;
        private BindingList<Aroma> _aromasInventory;
        private BindingList<Basic> _basicsInventory;
        private BindingList<FeedUp> _feedUpsInventory;
        private BindingList<Food> _foodsInventory;
        private BindingList<BaseHook> _hooksInventory;
        private Stack<BaseEvent> _eventHistory;



        #region Properties
        public FeedUp EquipedFeedUp {
            get {
                return _equipedFeedUp;
            } 
            set {
                _equipedFeedUp = value;
            } 
        }
        public GameRoad FirstRoad {
            get {
                return _firstRoad;
            }
            set {
                _firstRoad = value;
            }
        }
        public GameRoad SecondRoad {
            get {
                return _secondRoad;
            }
            set {
                _secondRoad = value;
            }
        }
        public GameRoad ThirdRoad {
            get {
                return _thirdRoad;
            }
            set {
                _thirdRoad = value;
            }
        }
        public GameRoad EquipedRoad {
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
        public BindingList<Fish> Fishlist {
            get {
                return _fishlist;
            }
            set {
                _fishlist = value;
            }
        }
        public BindingList<FeedUp> FeedUpInventory {
            get {
                return _feedUpsInventory;
            }
            set {
                _feedUpsInventory = value;
            }
        }
        public BindingList<Aroma> AromaInventory {
            get {
                return _aromasInventory;
            }
            set {
                _aromasInventory = value;
            }
        }
        public BindingList<BaseHook> HooksInventory {
            get {
                return _hooksInventory;
            }
            set {
                _hooksInventory = value;
            }
        }
        public BindingList<Food> FoodInventory {
            get {
                return _foodsInventory;
            }
            set {
                _foodsInventory = value;
            }
        }
        public BindingList<Basic> BasicInventory {
            get {
                return _basicsInventory;
            }
            set {
                _basicsInventory = value;
            }
        }
        public BindingList<Assembly> Assemblies {
            get {
                return _assemblies;
            }
            set {
                _assemblies = value;
            }
        }
        public BindingList<Road> RoadInventory {
            get {
                return _roadInventory;
            }
            set {
                _roadInventory = value;
            }
        }
        public BindingList<Reel> ReelInventory {
            get {
                return _reelInventory;
            }
            set {
                _reelInventory = value;
            }
        }
        public BindingList<FLine> FlineInventory {
            get {
                return _flineInventory;
            }
            set {
                _flineInventory = value;
            }
        }
        public BindingList<Bait> BaitInventory {
            get {
                return _baitsInventory;
            }
            set {
                _baitsInventory = value;
            }
        }
        public BindingList<Lure> LureInventory {
            get {
                return _luresInventory;
            }
            set {
                _luresInventory = value;
            }
        }
        public Stack<BaseEvent> EventHistory {
            get {
                return _eventHistory;
            }
            set {
                _eventHistory = value;
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
            Fishlist = new BindingList<Fish>();
            Assemblies = new BindingList<Assembly>();
            RoadInventory = new BindingList<Road>();
            ReelInventory = new BindingList<Reel>();
            FlineInventory = new BindingList<FLine>();
            LureInventory = new BindingList<Lure>();
            FoodInventory = new BindingList<Food>();
            BaitInventory = new BindingList<Bait>();
            HooksInventory = new BindingList<BaseHook>();
            FeedUpInventory = new BindingList<FeedUp>();
            AromaInventory = new BindingList<Aroma>();
            BasicInventory = new BindingList<Basic>();
            EventHistory = new Stack<BaseEvent>();
            Statistic = new Statistic();
            HoursRemain = 999999;
            Money = 999999;
            Satiety = 100;
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
            items.AddRange(RoadInventory);
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