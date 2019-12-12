using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Fishing.AbstractFish;
using Fishing.BL.Controller;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public sealed class Player {

        private const int SATIETY_MAX_VALUE = 100;
        private const int SATIETY_MIN_VALUE = 0;

        private static Player player;

        public FeedUp EquipedFeedUp { get; set; }
        public GameRoad FirstRoad { get; set; }
        public GameRoad SecondRoad { get; set; }
        public GameRoad ThirdRoad { get; set; }
        public GameRoad EquipedRoad { get; set; }
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
        public Stack<BaseEvent> EventHistory { get; set; }

        public event Action EventHistoryUpdated;

        public event Action UpdateBucketImage;

        public event Action GiveUped;

        public int Satiety { get; set; } = 100;

        public event Action<int> SatietyUpdated;

        public event Action Gathering;

        public Statistic Statistic { get; set; } = new Statistic();
        public int Money { get; set; } = 99999999;
        public int WindingSpeed { get; set; }
        public string NickName { get; set; } = "Рыболов";

        private Player() {
        }

        public void GiveUp(GameRoad road)
        {
            road.CurrentFeedUp = player.EquipedFeedUp;
            //Count -= 1
            GiveUped?.Invoke();
        }
        public static Player GetPlayer()
        {
            return player ?? (player = new Player());
        }
        public FeedUp GetFeedUpByName(string name)
        {
            if (name == null) return null;
            var b = FeedUpInventory.First(i => name.Equals(i.Name));
            if (b != null)
            {
                UpdateBucketImage?.Invoke();
            }
            return b;
        }
        public Basic GetBasicByName(string name)
        {
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
        public Item GetItemByName(string name) {
            var items = new List<Item>();
            items.AddRange(RoadInv);
            items.AddRange(ReelInv);
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
            if (item != null)
            {
                result = item.Price <= Money;
            }
            return result;
        }

        public void SetGameRoad(Assembly ass, int index) {
            if(ass == null) return;
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
                    player.Money += (int)f.Price * f.Weight;
                }
                else {
                    player.Money += (int)f.Price * 3 * f.Weight;
                }
                Fishlist.Remove(f);
                BaseController.GetController().SavePlayer();
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

        public void DoGathering(GameRoad road)
        {
            //Do reaction in UI for Gathering TODO
            road.IsFishAttack = false;
            player.Statistic.GatheringCount++;
            player.AddEventToHistory(new GatheringEvent());
            SoundsPlayer.PlayGatheringSound();
            road.Image = Roads.road;
            road.FLineIncValue = 0;
            road.RoadIncValue = 0;
            if (road.Assembly.Road.Type == RoadType.Feeder || road.Assembly.Road.Type == RoadType.Float) {
                ((Bait)road.Assembly.FishBait).Count -= 1;
                if(((Bait)road.Assembly.FishBait)?.Count == 0)
                {
                    road.Assembly.FishBait = null;
                }
                road.Assembly.FishBait = null;
            }
            Gathering?.Invoke();
        }
        public void BrokeRoad() {
            player.EquipedRoad.Image = Roads.broken;
            player.EquipedRoad.IsBaitInWater = false;
            player.EquipedRoad.IsFishAttack = false;
            player.EquipedRoad.Assembly.Road = null;
            player.EquipedRoad.CurPoint = Point.Empty;
            player.EquipedRoad.FLineIncValue = 0;
            player.EquipedRoad.RoadIncValue = 0;
            player.Statistic.BrokensRoadsCount++;
        }

        public void TornFLine() {
            player.EquipedRoad.Image = Roads.road;
            player.EquipedRoad.IsFishAttack = false;
            player.EquipedRoad.Assembly.FishBait = null;
            player.EquipedRoad.IsBaitMoving = false;
            player.EquipedRoad.CurPoint = Point.Empty;
            player.EquipedRoad.FLineIncValue = 0;
            player.EquipedRoad.RoadIncValue = 0;
            player.Statistic.TornsFLinesCount++;
            player.Statistic.GatheringCount++;
        }

        public void DecSatiety(int value) {
            if (value >= 0) {
                if (Satiety - value <= SATIETY_MIN_VALUE) {
                    Satiety -= value;
                }
            }
        }

        public void AddFishToPond()
        {
            player.Statistic.TakenFishesCount++;
            if (!player.EquipedRoad.Fish.IsTrophy()) {
                player.AddEventToHistory(new FishEvent(player.EquipedRoad.Fish,
                    player.EquipedRoad.Assembly.FishBait));
            }
            else {
                player.AddEventToHistory(new TrophyFishEvent(player.EquipedRoad.Fish,
                    player.EquipedRoad.Assembly.FishBait));
            }
            if (player.EquipedRoad.Assembly.Road.Type == RoadType.Feeder || player.EquipedRoad.Assembly.Road.Type == RoadType.Float) {
                ((Bait)player.EquipedRoad.Assembly.FishBait).Count -= 1;
                if (((Bait)player.EquipedRoad.Assembly.FishBait).Count == 0) {
                    player.EquipedRoad.Assembly.FishBait = null;
                }
            }
        }

        public bool Eat(Food food) {
            if (food != null) {
                if (Satiety + food.Productivity <= SATIETY_MAX_VALUE) {
                    Satiety += food.Productivity;
                    FoodInv.Remove(food);
                    AddEventToHistory(new FoodEvent(food));
                    SatietyUpdated?.Invoke(food.Productivity);
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