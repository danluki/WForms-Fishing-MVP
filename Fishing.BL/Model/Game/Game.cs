using Fishing.BL.Model.Waters;
using Fishing.BL.View;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game {

    public enum PartsOfDay {
        Morning,
        Day,
        Evening,
        Night
    }
    [Serializable]
    public class Game {
        public const int GameWidth = 1024;
        [NonSerialized]
        public Player Player;
        public const int GameHeight = 600;
        [NonSerialized]
        private static Game game;
        [NonSerialized]
        public BindingList<string> Waters = new BindingList<string>();

        public event EventHandler HoursInc;
        [NonSerialized]
        public IGameForm View;
        [NonSerialized]
        private Timer HoursTimer;
        [NonSerialized]
        public Water CurrentWater;
        [NonSerialized]
        public Time Time;

        private Game() {
            HoursTimer = new Timer() {
                Interval = 30000
            };
            HoursTimer.Tick += HoursTimer_Tick;
            HoursTimer.Start();
        }

        public static Game GetGame() {
            return game ?? (game = new Game());
        }

        private void HoursTimer_Tick(object sender, EventArgs e) {
            Time.IncHours(1);
            Player.HoursRemain -= 1;
            HoursInc?.Invoke(this, EventArgs.Empty);
        }
    }
}