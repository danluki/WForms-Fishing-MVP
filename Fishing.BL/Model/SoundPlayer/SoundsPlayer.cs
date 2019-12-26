using Fishing.BL.Resources.Sounds;
using System;

namespace Fishing.BL.Model.SoundPlayer {

    public static class SoundsPlayer {
        private static readonly System.Media.SoundPlayer _sp = new System.Media.SoundPlayer();

        public static void PlayGatheringSound() {
            _sp.Stream = SoundsRes.sxod;
            _sp.Play();
        }

        public static void PlayTornSound() {
            _sp.Stream = SoundsRes.leskaobr;
            _sp.Play();
        }

        public static void PlayBuyingSound() {
            _sp.Stream = SoundsRes.kassa;
            _sp.Play();
        }

        public static void PlayDaysSound() {
            var r = new Random();
            var name = "day" + r.Next(1, 9);
            _sp.Stream = SoundsRes.ResourceManager.GetStream(name);
            _sp.Play();
        }

        public static void PlayEatingSound() {
            _sp.Stream = SoundsRes.eat;
            _sp.Play();
        }

        public static void PlayCastSound() {
            _sp.Stream = SoundsRes.zabr;
            _sp.Play();
        }

        public static void PlayFeedUpSound() {
            _sp.Stream = SoundsRes.prik;
            _sp.Play();
        }
    }
}