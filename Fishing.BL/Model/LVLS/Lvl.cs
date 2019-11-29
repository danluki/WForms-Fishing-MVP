using Fishing.AbstractFish;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fishing.BL.Model.LVLS {

    public class Lvl {
        public Image Image { get; set; }
        public int Widgth;
        public int Height;
        public int DeepTiesStartY;
        public int DeepTiesStartX;
        public string Name { get; set; }

        public Label[,] DeepArray;
        protected List<Fish> Fishes = new List<Fish>(1000);

        public (bool isFish, bool gathering) GetFish(GameRoad road) {
            try {
                Shuffle(Fishes);
                var randomGathering = new Random();
                var randomFish = new Random();
                if (road.Assembly.FishBait != null) {
                    if (!road.IsFishAttack) {
                        road.Fish = Fishes[randomFish.Next(1, 1000)];
                        if (IsFishAttackPossible(road.Fish, road)) {
                            road.IsFishAttack = true;
                            var roadCoef = road.Fish.Weight / (double)road.Assembly.Road.Power;
                            var flineCoef = road.Fish.Weight / (double)road.Assembly.FLine.Power;

                            road.RoadIncValue = Convert.ToInt32(roadCoef * 100);
                            road.FLineIncValue = Convert.ToInt32(flineCoef * 100);

                            var gathering = randomGathering.Next(1, 100);
                            if (road.Assembly.Road is Spinning) {
                                if (gathering <= 5) {
                                    return (true, true);
                                }
                            }

                            if (!(road.Assembly.Road is Feeder)) return (true, false);
                            return gathering <= road.Assembly.Hook.GatheringChance ? (true, true) : (true, false);
                        }
                    }
                }
            }
            catch (NullReferenceException) { }

            return (false, false);
        }

        public static bool IsFishAttackPossible(Fish fish, GameRoad road) {
            try {
                if (fish.MinDeep > road.CurrentDeep || fish.MaxDeep < road.CurrentDeep) return false;
                var part = fish.ActivityParts.First(p => p == Game.Game.GetGame().Time.Part);
                var l = fish.WorkingLures.First(b => b.Name.Equals(road.Assembly.FishBait.Name));
                var ba = l != null;
                var pa = part != default;
                return ba && pa;
            }
            catch (InvalidOperationException) {
                return false;
            }
        }

        public void Shuffle<T>(IList<T> list) {
            var rng = new Random();
            var n = list.Count;
            while (n > 1) {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private string _pathToLvl;

        public void AddFishes() {
            string line;
            var file =
                    new StreamReader(_pathToLvl + "\\" + "FishesList");
            while ((line = file.ReadLine()) != null) {
                var fs = new FishString(line);
                Fishes.Add((Fish)fs);
            }
            file.Close();
        }

        public void SetDeep() {
            var saver = new SerializeDataSaver();

            var deepField = saver.Load<LabelInfo[,]>(_pathToLvl + "\\" + "DeepField.dat");
            DeepArray = new Label[Widgth, Height];
            for (var y = 0; y < Height; y++) {
                for (var x = 0; x < Widgth; x++) {
                    DeepArray[x, y] = new Label {
                        Left = DeepTiesStartX + 5 + x * 40,
                        Top = DeepTiesStartY + y * 23,
                        Height = 23,
                        TextAlign = ContentAlignment.MiddleLeft,
                        ForeColor = Color.White,
                        Width = 40,
                        Visible = true,
                        Font = new Font("Arial", 8, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = deepField[x, y].Deep,
                        Tag = deepField[x, y].IsSnag
                    };
                }
            }
        }

        public Lvl GetLVLData(string name) {
            Name = name;
            _pathToLvl = @"C:\Users\Programmer\Desktop\MVPFishing-master\Fishing.BL\Model\Waters"
                         + Path.DirectorySeparatorChar
                         + Game.Game.GetGame().CurrentWater.Name
                         + Path.DirectorySeparatorChar + Name;
            Image = Image.FromFile(_pathToLvl + "\\BackImg.jpg");

            var sb = File.ReadAllText(_pathToLvl + "\\" + "LVLInfo");
            var ar = sb.Split(' ');

            Widgth = Convert.ToInt32(ar[0]);
            Height = Convert.ToInt32(ar[1]);

            DeepTiesStartX = Convert.ToInt32(ar[2]);
            DeepTiesStartY = Convert.ToInt32(ar[3]);

            return this;
        }
    }
}