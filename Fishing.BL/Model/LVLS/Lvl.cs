using Fishing.AbstractFish;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fishing.BL.Model.LVLS {

    [Serializable]
    public class Lvl {
        public Image BackgroundImage { get; set; }
        public int Widgth;
        public int Height;
        public int DeepTiesStartY;
        public int DeepTiesStartX;
        public string Name { get; set; }

        public Label[,] DeepArray;
        protected List<Fish> Fishes = new List<Fish>(1000);
        private Random randomGathering = new Random();
        private Random randomFish = new Random();

        [SuppressMessage("ReSharper", "IdentifierTypo")]
        public (bool isFish, bool gathering) GetFish(GameRod road) {
            try {
                //Проверяем есть ли приманка, и проверяем, что рыбы ещё нет на крючке

                if (road.Assembly.FishBait != null && !road.IsFishAttack) {
                    //Получаем список рыб плавающих на необходимой глубине, шафлим его.

                    road.FishesPossibleToAttack = new List<Fish>();
                    foreach (var f in Fishes.Where(f => f.IsFishInNeededToAttackDeep(road.CurrentDeep))) {
                        road.FishesPossibleToAttack.Add(f);
                    }
                    Shuffle(road.FishesPossibleToAttack);

                    //Если список рыб > 0 выбираем случайную. Производим аттаку, 
                    //если она возможна вычисляем коэффиценты нагрузки, и сход. 

                    Fish fish = null;
                    int index = 0;
                    if (road.FishesPossibleToAttack.Count > 0) {
                        index = randomFish.Next(1, road.FishesPossibleToAttack.Count);
                        fish = road.FishesPossibleToAttack[index];
                    }
                    if (fish != null) {
                        var fishAttacked = fish.Attack(road);
                        if (fishAttacked) {
                            return DoAttack(fish, road);
                        }

                        //Если атака не происходит в работу включается прикормка,
                        //среди списка рыб мы к нашему индексу прибавляем Текущий индекс действия прикормки,
                        //Проверяем, является ли рыба той, на которую действует прикормка.

                        else {
                            if (road.CurrentFeedUp != null && road.CurrentFeedUp.WorkingFishes != null)
                                foreach (var feedup in road.CurrentFeedUp?.WorkingFishes) {
                                    for (var FeedUpPowerToFishIndex = 0; FeedUpPowerToFishIndex < feedup.Value; FeedUpPowerToFishIndex++) {
                                        if (index + FeedUpPowerToFishIndex < 1000) {
                                            fish = road.FishesPossibleToAttack[index + FeedUpPowerToFishIndex];
                                            if (feedup.Key.ToString().Equals(fish.GetType().ToString())) {
                                                return DoAttack(fish, road);
                                            }
                                        }
                                    }
                                }
                        }
                    }
                }
            }
            catch (NullReferenceException) { }

            return (false, false);
        }

        private (bool isFish, bool gathering) DoAttack(Fish fish, GameRod road) {
            var resultOfAttack = fish.Attack(road);
            if (resultOfAttack) {
                road.IsFishAttack = true;

                var roadCoef = road.Fish.Weight / (double)road.Assembly.Rod.Power;
                var flineCoef = road.Fish.Weight / (double)road.Assembly.Fline.Power;

                road.RoadIncValue = Convert.ToInt32(roadCoef * 100);
                road.FlineIncValue = Convert.ToInt32(flineCoef * 100);
                var gathering = randomGathering.Next(1, 100);

                if (road.Assembly.Rod.RodType == RodType.Spinning) {
                    if (gathering <= 5) {
                        return (true, true);
                    }
                }
                if (road.Assembly.Rod.RodType != RodType.Feeder) return (true, false);
                return gathering <= road.Assembly.Hook.GatheringChance ? (true, true) : (true, false);
            }
            return (false, false);
        }

        private void Shuffle<T>(IList<T> list) {
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
                        Left = DeepTiesStartX + 5 + x * LabelInfo.Width,
                        Top = DeepTiesStartY + y * LabelInfo.Height,
                        Height = LabelInfo.Height,
                        TextAlign = ContentAlignment.MiddleLeft,
                        ForeColor = Color.White,
                        Width = LabelInfo.Width,
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
            BackgroundImage = Image.FromFile(_pathToLvl + "\\BackImg.jpg");

            var sb = File.ReadAllText(_pathToLvl + "\\" + "LVLInfo");
            var ar = sb.Split(' ');

            Widgth = Convert.ToInt32(ar[0]);
            Height = Convert.ToInt32(ar[1]);

            DeepTiesStartX = Convert.ToInt32(ar[2]);
            DeepTiesStartY = Convert.ToInt32(ar[3]);

            return this;
        }

        public override string ToString() {
            return Name;
        }
    }
}