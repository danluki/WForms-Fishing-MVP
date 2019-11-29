namespace Fishing.BL.Model.Game {

    public sealed class Sounder {
        private static Sounder sounder;
        public int Column { get; set; }
        public int Row { get; set; }

        private Sounder() {
        }

        public static Sounder GetSounder() {
            if (sounder == null) {
                sounder = new Sounder();
            }

            return sounder;
        }
    }
}