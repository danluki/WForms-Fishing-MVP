using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using System;
using System.ComponentModel;
using System.Linq;

namespace Fishing.BL.Model {

    /// <summary>
    /// Перечисление содержит в себе все типы, которые содержатся в магазине снастей
    /// </summary>
    public enum ShopItemType {
        Rod,
        Reel,
        Fline,
        Lure,
        Bait,
        Aroma,
        Basic,
        Hook
    }

    /// <summary>
    /// Представляет модель магазина, взаимодействует с ShopPresenter, через объект Shop
    /// </summary>
    public sealed class Shop {

        #region public prop

        //Содержит список удочек в магазине
        public BindingList<Rod> Rods { get; } = new BindingList<Rod>();

        //Содержит список катушек в магазине
        public BindingList<Reel> Reels { get; } = new BindingList<Reel>();

        //Содержит список лески в магазине
        public BindingList<Fishingline> Fishinglines { get; } = new BindingList<Fishingline>();

        //Содержит список приманок в магазине
        public BindingList<Lure> Lures { get; } = new BindingList<Lure>();

        //Содержит список наживок в магазине
        public BindingList<Bait> Baits { get; } = new BindingList<Bait>();

        //Содержит список крючков в магазине
        public BindingList<BaseHook> Hooks { get; } = new BindingList<BaseHook>();

        //Содержит список основ в магазине
        public BindingList<Basic> Basics { get; } = new BindingList<Basic>();

        //Содержит список ароматизаторов в магазине
        public BindingList<Aroma> Aromas { get; } = new BindingList<Aroma>();

        #endregion public prop

        #region ctor

        public Shop() {
            //Инициализация удочек

            Rods = Item.Rods ?? throw new ArgumentNullException("Удочки должны присутствовать.");

            //Инициализация катушек

            Reels = Item.Reels ?? throw new ArgumentNullException("Катушки должны присутствовать.");

            //Инициализация лесок

            Fishinglines = Item.Fishinglines ?? throw new ArgumentNullException("Катушки должны присутствовать.");

            //Инициализация приманок и наживок

            foreach (var fb in FishBait.FishBaits) {
                if (fb is Bait) {
                    Baits.Add(fb as Bait);
                }
                else {
                    Lures.Add(fb as Lure);
                }
            }

            //Инициализация крючков

            Hooks = Item.Hooks ?? throw new ArgumentNullException("Крючки должны присутствовать.");

            //Инициализация основ

            Basics = Item.Basics ?? throw new ArgumentNullException("Основы должны присутствовать.");

            //Инициализация ароматизаторов

            Aromas = Item.Aromas ?? throw new ArgumentNullException("Ароматизаторы должны присутствовать.");
        }

        #endregion ctor

        #region public methods

        /// <summary>
        /// Возращает объект удочки по его имени
        /// </summary>
        /// <param name="name">Название удочки</param>
        /// <returns></returns>
        public Rod GetRod(string name) {
            return Rods.Where(road => road.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект катушки по ее имени
        /// </summary>
        /// <param name="name">Название катушки</param>
        /// <returns></returns>
        public Reel GetReel(string name) {
            return Reels.Where(reel => reel.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект лески по ее имени
        /// </summary>
        /// <param name="name">Название лески</param>
        /// <returns></returns>
        public Fishingline GetFishingline(string name) {
            return Fishinglines.Where(fline => fline.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект приманки по ее имени
        /// </summary>
        /// <param name="name">Название приманки</param>
        /// <returns></returns>
        public Lure GetLure(string name) {
            return Lures.Where(lure => lure.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект наживки по ее имени
        /// </summary>
        /// <param name="name">Название наживки</param>
        /// <returns></returns>
        public Bait GetBait(string name) {
            return Baits.Where(bait => bait.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект крючка по его имени
        /// </summary>
        /// <param name="name">Название крючка</param>
        /// <returns></returns>
        public BaseHook GetHook(string name) {
            return Hooks.Where(hook => hook.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект ароматизатор по его имени
        /// </summary>
        /// <param name="name">Название ароматизатора</param>
        /// <returns></returns>
        public Aroma GetAroma(string name) {
            return Aromas.Where(aroma => aroma.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Возращает объект основы по его имени
        /// </summary>
        /// <param name="name">Название основы</param>
        /// <returns></returns>
        public Basic GetBasic(string name) {
            return Basics.Where(basic => basic.Name.Equals(name)).FirstOrDefault();
        }

        #endregion public methods
    }
}