using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.SoundPlayer;

namespace Fishing.BL.Model.Game {

    public class GameRoad {

        public GameRoad(Assembly ass) {
            Assembly = ass;
            baitTimer.Tick += BaitTimer_Tick;
            countFishMovesTimer.Tick += CountFishMovesTimer_Tick;
            gatheringTimer.Tick += GatheringTimer_Tick;
        }

        private void GatheringTimer_Tick(object sender, EventArgs e) {
            if (IsFishAttack) {
                IsFishAttack = false;
                Player.GetPlayer().Statistic.GatheringCount++;
                Player.GetPlayer().AddEventToHistory(new GatheringEvent());
                SoundsPlayer.PlayGatheringSound();
                Image = Roads.road;
                FLineIncValue = 0;
                RoadIncValue = 0;
                if (this.Assembly.Road is Feeder || this.Assembly.Road is Float)
                {
                    ((Bait) this.Assembly.FishBait).Count -= 1;
                }
            }
            gatheringTimer.Stop();
        }

        private void CountFishMovesTimer_Tick(object sender, EventArgs e) {
            try {
                Random fishMovingX = new Random();
                Random fishMovingY = new Random();
                if (IsFishAttack) {
                    Fish.Power.X = fishMovingX.Next(-Fish.Power.X, Math.Abs(Fish.Power.X) + 1);
                    Fish.Power.Y = fishMovingY.Next(-Math.Abs(Fish.Power.Y), 2);
                    Assembly.Reel.Wear -= 1;
                    if (RoadIncValue >= 30) {
                        Assembly.Road.Wear -= 1;
                    }
                }
            }
            catch (NullReferenceException) { }
        }

        private void BaitTimer_Tick(object sender, EventArgs e) {
            var (isFish, gathering) = CurLVL.GetFish(this);
            if (!isFish) return;
            baitTimer.Stop();
            if (Fish.Weight <= Assembly.Road.Power * 0.2) {
                GImage = Roads.izg1;
                HImage = Roads.izg1H;
            }
            else if (Fish.Weight <= Assembly.Road.Power * 0.25) {
                GImage = Roads.izg2;
                HImage = Roads.izg2H;
            }
            else if (Fish.Weight <= Assembly.Road.Power * 0.3) {
                GImage = Roads.izg3;
                HImage = Roads.izg3H;
            }
            else if (Fish.Weight <= Assembly.Road.Power * 0.4) {
                GImage = Roads.izg4;
                HImage = Roads.izg4H;
            }
            else if (Fish.Weight >= Assembly.Road.Power * 0.4) {
                GImage = Roads.izg5;
                HImage = Roads.izg5H;
            }
            countFishMovesTimer.Start();
            if (gathering) {
                Random r = new Random();
                var res = r.Next(100, 5000);
                gatheringTimer.Interval = res;
                gatheringTimer.Start();
            }
            Image = GImage;
        }

        public Timer baitTimer = new Timer() {
            Interval = 500,
        };

        public Timer countFishMovesTimer = new Timer() {
            Interval = 1500,
        };

        public Timer gatheringTimer = new Timer() {
            Interval = 1500,
        };
        public List<Fish> FishesPossibleToAttack { get; set; }
        public Lvl CurLVL { get; set; }
        public Image Image { get; set; }
        public Image HImage { get; set; }
        public Image GImage { get; set; }
        public Assembly Assembly { get; set; }
        public Fish Fish { get; set; }
        public FeedUp CurrentFeedUp { get; set; }

        public int RoadX = 100;
        public int RoadY = 350;

        public bool IsBaitMoving;
        public bool IsBaitInWater;
        public bool IsFishAttack;

        public Point LastCastPoint;
        public Point CurPoint;

        public int CurrentDeep;
        public int RoadIncValue;
        public int FLineIncValue;

        public void StartBaitTimer() {
            if (IsBaitInWater) {
                baitTimer.Start();
            }
        }
    }
}