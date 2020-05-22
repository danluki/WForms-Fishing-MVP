using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Fishes;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.Lures;
using Fishing.BL.Model.Waters;
using Fishing.BL.Resources.Images;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fishing.BL.Controller {

    public class GameLoader {
        private static GameLoader _loader;
        private readonly SerializeDataSaver _saver = new SerializeDataSaver();

        private GameLoader() {
        }

        public static GameLoader GetLoader() {
            return _loader ?? (_loader = new GameLoader());
        }

        public void SetAllFishesName() {
            var typelist = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "Fishing.BL.Model.Fishes").ToArray();
            foreach (var type in typelist) {
                var targetObject = Activator.CreateInstance(Type.GetType(type.FullName), 5, 100, 1, null);

                Fish.AllFishes.Add((targetObject as Fish)?.Name ?? throw new InvalidOperationException(), Type.GetType(type.FullName));
            }
        }

        public void SetFeedUps() {
            Item.Aromas.Add(new Aroma("Чеснок", 100, FeedUps.chesnok, new Dictionary<Type, int>()
            {
                {typeof(Roach), 10},
                {typeof(Rybets), 5},
                {typeof(SilverCarp), 7},
                {typeof(Tench), 3},
                {typeof(WildCarp), 1},
                {typeof(GoldCarp), 2},
                {typeof(Bream), 5}
            }));
            Item.Aromas.Add(new Aroma("Карамель", 100, FeedUps.karamel, new Dictionary<Type, int>()
            {
                {typeof(Roach), 2},
                {typeof(Rybets), 2},
                {typeof(SilverCarp), 7},
                {typeof(Tench), 2},
                {typeof(WildCarp), 1},
                {typeof(GoldCarp), 4},
                {typeof(Bream), 1}
            }));
            Item.Aromas.Add(new Aroma("Конопля", 100, FeedUps.konopla, new Dictionary<Type, int>()
            {
                {typeof(Roach), 7},
                {typeof(Rybets), 2},
                {typeof(SilverCarp), 7},
                {typeof(Tench), 4},
                {typeof(WildCarp), 1},
                {typeof(GoldCarp), 4},
                {typeof(Bream), 8}
            }));
            Item.Aromas.Add(new Aroma("Анис", 300, FeedUps.anis, new Dictionary<Type, int>()
            {
                {typeof(Roach), 10},
                {typeof(Rybets), 5},
                {typeof(SilverCarp), 7},
                {typeof(Tench), 3},
                {typeof(WildCarp), 1},
                {typeof(GoldCarp), 2},
                {typeof(Bream), 3}
            }));
            Item.Basics.Add(new Basic("Горох", 800, FeedUps.goroh, new Dictionary<Type, int>()
            {
                {typeof(Bream), 8},
                {typeof(Roach), 3},
                {typeof(Rybets), 6},
                {typeof(SilverCarp), 3},
                {typeof(Tench), 1},
                {typeof(WildCarp), 1},
                {typeof(GoldCarp), 2},
            }));
            Item.Basics.Add(new Basic("Карп Карась", 1000, FeedUps.karpkaras, new Dictionary<Type, int>()
            {
                {typeof(WildCarp), 8},
                {typeof(GoldCarp), 9},
                {typeof(Roach), 1},
                {typeof(Rybets), 1},
                {typeof(SilverCarp), 9},
                {typeof(Tench), 8},
            }));
            Item.Basics.Add(new Basic("Плотва", 200, FeedUps.plotva, new Dictionary<Type, int>()
            {
                {typeof(Roach), 9},
                {typeof(Rybets), 1},
                {typeof(SilverCarp), 1},
                {typeof(Tench), 1},
                {typeof(WildCarp), 1},
                {typeof(Bream), 1},
                {typeof(GoldCarp), 2},
            }));
            Item.Basics.Add(new Basic("Жмых", 200, FeedUps.zhmyh, new Dictionary<Type, int>()
            {
                {typeof(SilverCarp), 1},
                {typeof(Tench), 3},
                {typeof(WildCarp), 7},
                {typeof(Bream), 3},
                {typeof(GoldCarp), 2},
            }));
            Item.Basics.Add(new Basic("Лещ", 1500, FeedUps.leshp, new Dictionary<Type, int>()
            {
                {typeof(Bream), 10},
                {typeof(SilverCarp), 1},
                {typeof(Tench), 1},
                {typeof(WildCarp), 3},
                {typeof(GoldCarp), 2},
            }));
        }

        public void IntializeLures() {
            FishBait.FishBaits.Add(new Bait("Сыр", 30, 500, Images.cheeze));
            FishBait.FishBaits.Add(new Bait("Червь", 30, 50, Images.worm));
            FishBait.FishBaits.Add(new Bait("Опарыш", 30, 150, Images.oparysh));
            FishBait.FishBaits.Add(new Bait("Живец", 30, 150, Images.zhivec));
            FishBait.FishBaits.Add(new Bait("Икра", 30, 1000, Images.ikra));
            FishBait.FishBaits.Add(new Bait("Кукуруза", 30, 250, Images.corn));
            FishBait.FishBaits.Add(new Wobbler("Составник", Size.Large, DeepType.Flying, 3000, Images.Vob_3015));
            FishBait.FishBaits.Add(new Wobbler("Воблер 2", Size.XL, DeepType.Flying, 3000, Images.Vob_3002));
            FishBait.FishBaits.Add(new Wobbler("Воблер 3", Size.Small, DeepType.Top, 3000, Images.Vob_3003));
            FishBait.FishBaits.Add(new Wobbler("Воблер 4", Size.Large, DeepType.Deep, 3000, Images.Vob_3001));
            FishBait.FishBaits.Add(new Wobbler("Воблер 1 Дип", Size.Large, DeepType.Deep, 3000, Images.Deep_112));
            FishBait.FishBaits.Add(new Wobbler("Воблер 2 Дип", Size.Large, DeepType.Deep, 3000, Images.Deep_115));
            FishBait.FishBaits.Add(new Pinwheel("Вертушка 1", Size.Small, DeepType.Deep, 500, Images.Circl_5103));
            FishBait.FishBaits.Add(new Pinwheel("Вертушка 2", Size.Small, DeepType.Deep, 500, Images.Circl_5113));
            FishBait.FishBaits.Add(new Shaker("Колебалка 1", Size.XL, DeepType.Deep, 500, Images.Vib_6000));
            FishBait.FishBaits.Add(new Shaker("Колебалка 2", Size.Large, DeepType.Deep, 500, Images.Vib_6012));
            FishBait.FishBaits.Add(new Jig("Виброхвост 1", Size.Small, DeepType.Jig, 500, Images.Tvis_103));
            FishBait.FishBaits.Add(new Jig("Виброхвост 2", Size.Small, DeepType.Jig, 500, Images.Tvis_105));
            FishBait.FishBaits.Add(new Jig("Виброхвост 3", Size.Large, DeepType.Jig, 500, Images.Tvis_104));
            FishBait.FishBaits.Add(new Jig("Виброхвост 4", Size.XL, DeepType.Jig, 500, Images.Tvis_119));

            Food.Foods.Add(new Food("Хлеб", 50, 10, Images.hleb));
            Food.Foods.Add(new Food("Икра", 1500, 30, Images.ikra));
            Food.Foods.Add(new Food("Икра Чёрная", 5000, 70, Images.black));
            Food.Foods.Add(new Food("Сыр", 1000, 50, Images.cheeze));
            Food.Foods.Add(new Food("Печенье", 500, 25, Images.pech));
            Food.Foods.Add(new Food("Скумбрия", 700, 35, Images.skumb));
            Food.Foods.Add(new Food("Рыбные консервы", 700, 35, Images.fishkonc));
            Food.Foods.Add(new Food("Бананы", 250, 5, Images.banany));
            Food.Foods.Add(new Food("Апельсины", 500, 20, Images.apelsin));
        }

        public void Initiallize(string name) {
            Directory.CreateDirectory(name + "/config");
            SetAllFishesName();
            Game.GetGame().Player = _saver.Load<Player>(name + "/config/player.dat") ?? new Player();
            Game.GetGame().Time = _saver.Load<Time>(name + "/config/time.dat");
            var dir = new DirectoryInfo(@"C:\Users\Programmer\Desktop\MVPFishing-master\Fishing.BL\Model\Waters");
            foreach (var item in dir.GetDirectories()) {
                Game.GetGame().Waters.Add(item.ToString());
            }
            string wName = _saver.Load<string>(name + "/config/currwater.dat") ?? "Озеро";
            WaterImplementation wr = new WaterImplementation();
            wr.GetLVL(wName);
            Game.GetGame().CurrentWater = wr;
        }

        public void SavePlayer() {
            _saver.Save(Game.GetGame().Player.NickName + "/config/time.dat", Game.GetGame().Time);
            _saver.Save(Game.GetGame().Player.NickName + "/config/currwater.dat", Game.GetGame().CurrentWater.Name);
            _saver.Save(Game.GetGame().Player.NickName + "/config/player.dat", Game.GetGame().Player);
        }
    }
}