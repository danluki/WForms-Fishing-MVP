using Fishing.AbstractFish;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public class GameRod {

        public GameRod(Assembly ass) {
            Assembly = ass;
            baitTimer.Tick += BaitTimer_Tick;
            countFishMovesTimer.Tick += CountFishMovesTimer_Tick;
            gatheringTimer.Tick += GatheringTimer_Tick;
        }

        private void GatheringTimer_Tick(object sender, EventArgs e) {
            if (IsFishAttack) {
                Game.GetGame().Player.DoGathering(this);
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
                    Assembly.Reel.Wear += 1;
                    if (RoadIncValue >= 30) {
                        Assembly.Rod.Wear += 1;
                    }
                }
            }
            catch (NullReferenceException) { }
        }

        private void BaitTimer_Tick(object sender, EventArgs e) {
            var (isFish, gathering) = CurLVL.GetFish(this);
            if (!isFish) return;
            baitTimer.Stop();
            if (Fish.Weight <= Assembly.Rod.Power * 0.2) {
                GImage = Roads.izg1;
                HImage = Roads.izg1H;
            }
            else if (Fish.Weight <= Assembly.Rod.Power * 0.25) {
                GImage = Roads.izg2;
                HImage = Roads.izg2H;
            }
            else if (Fish.Weight <= Assembly.Rod.Power * 0.3) {
                GImage = Roads.izg3;
                HImage = Roads.izg3H;
            }
            else if (Fish.Weight <= Assembly.Rod.Power * 0.4) {
                GImage = Roads.izg4;
                HImage = Roads.izg4H;
            }
            else if (Fish.Weight >= Assembly.Rod.Power * 0.4) {
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
        [NonSerialized]
        public Timer baitTimer = new Timer() {
            Interval = 5000,
        };
        [NonSerialized]
        public Timer countFishMovesTimer = new Timer() {
            Interval = 2500,
        };
        [NonSerialized]
        public Timer gatheringTimer = new Timer() {
            Interval = 1500,
        };

        public List<Fish> FishesPossibleToAttack { get; set; }
        [NonSerialized]
        public Lvl CurLVL;
        public Image Image { get; set; }
        public Image HImage { get; set; }
        public Image GImage { get; set; }
        public Assembly Assembly { get; set; }
        public Fish Fish { get; set; }
        public Feedup CurrentFeedUp { get; set; }

        public int RoadX;
        public int RoadY;

        public bool IsBaitMoving;
        public bool IsBaitInWater;
        public bool IsFishAttack;

        public Point LastCastPoint;
        public Point CurPoint;

        public int CurrentDeep;
        public int RoadIncValue;
        public int FlineIncValue;

        public void StartBaitTimer() {
            if (IsBaitInWater) {
                baitTimer.Start();
            }
        }

        public void RemoveFromLocation() {
            this.Assembly.IsEquiped = false;
            this.IsBaitInWater = false;
            this.IsBaitMoving = false;
            this.IsFishAttack = false;
        }
    }
}