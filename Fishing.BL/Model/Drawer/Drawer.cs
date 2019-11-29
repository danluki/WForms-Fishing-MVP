using System;
using System.Drawing;
using Fishing.BL.Model.Game;

namespace Fishing.BL.Model.Drawer {

    internal class Drawer {
        public Graphics Graphics { get; set; }

        private readonly Player player = Player.GetPlayer();
        private readonly SolidBrush sbrush = new SolidBrush(Color.White);

        public Rectangle FirstNormalRoad;
        public Rectangle FirstBrokenRoad;

        public Rectangle SecondNormalRoad;
        public Rectangle SecondBrokenRoad;

        public Rectangle ThirdNormalRoad;
        public Rectangle ThirdBrokenRoad;

        private Rectangle Netting;
        public Rectangle RTrigon;
        public void DrawPoints() {
            if (player.FirstRoad != null) {
                sbrush.Color = player.FirstRoad == player.EquipedRoad ? Color.Red : Color.White;
                Graphics.DrawEllipse(new Pen(Color.White), player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
                Graphics.FillEllipse(sbrush, player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
            }

            if (player.SecondRoad != null) {
                sbrush.Color = player.SecondRoad == player.EquipedRoad ? Color.Red : Color.White;
                Graphics.DrawEllipse(new Pen(Color.White), player.SecondRoad.CurPoint.X, player.SecondRoad.CurPoint.Y, 4, 4);
                Graphics.FillEllipse(sbrush, player.SecondRoad.CurPoint.X, player.SecondRoad.CurPoint.Y, 4, 4);
            }

            if (player.ThirdRoad == null) return;
            sbrush.Color = player.ThirdRoad == player.EquipedRoad ? Color.Red : Color.White;
            Graphics.DrawEllipse(new Pen(Color.White), player.ThirdRoad.CurPoint.X, player.ThirdRoad.CurPoint.Y, 4, 4);
            Graphics.FillEllipse(sbrush, player.ThirdRoad.CurPoint.X, player.ThirdRoad.CurPoint.Y, 4, 4);
        }

        public void DrawNetting() {
            Graphics.DrawImage(Pictures.netting, Netting);
        }

        public void DrawTrigon() {
            if (player.EquipedRoad != null) {
                Graphics.DrawImage(Pictures.trigon, RTrigon);
            }
        }

        public void DrawRoads() {
            try {
                if (player.FirstRoad != null && !player.FirstRoad.IsFishAttack) {
                    Graphics.DrawImage(player.FirstRoad.Image, FirstNormalRoad);
                }
                else if (player.FirstRoad != null && player.FirstRoad.IsFishAttack) {
                    Graphics.DrawImage(player.FirstRoad.Image, FirstBrokenRoad);
                }
                if (player.SecondRoad != null && !player.SecondRoad.IsFishAttack) {
                    Graphics.DrawImage(player.SecondRoad.Image, SecondNormalRoad);
                }
                else if (player.SecondRoad != null && player.SecondRoad.IsFishAttack) {
                    Graphics.DrawImage(player.SecondRoad.Image, SecondBrokenRoad);
                }
                if (player.ThirdRoad != null && !player.ThirdRoad.IsFishAttack) {
                    Graphics.DrawImage(player.ThirdRoad.Image, ThirdNormalRoad);
                }
                else if (player.ThirdRoad != null && player.ThirdRoad.IsFishAttack) {
                    Graphics.DrawImage(player.ThirdRoad.Image, ThirdBrokenRoad);
                }
            }
            catch (ArgumentNullException) { }
        }

        public void UpdateRectangles() {
            try {
                if (player.FirstRoad != null) {
                    FirstNormalRoad = new Rectangle(player.FirstRoad.RoadX,
                                                    player.FirstRoad.RoadY,
                                                    player.FirstRoad.Image.Width,
                                                    257);

                    FirstBrokenRoad = new Rectangle(player.FirstRoad.RoadX - 10,
                                                    player.FirstRoad.RoadY,
                                                    player.FirstRoad.Image.Width,
                                                    257);
                }

                if (player.SecondRoad != null) {
                    SecondNormalRoad = new Rectangle(player.SecondRoad.RoadX,
                                                     player.SecondRoad.RoadY,
                                                     player.SecondRoad.Image.Width,
                                                     257);
                    SecondBrokenRoad = new Rectangle(player.SecondRoad.RoadX - 10,
                                                     player.SecondRoad.RoadY,
                                                     player.SecondRoad.Image.Width,
                                                     257);
                }
                if (player.ThirdRoad != null) {
                    ThirdNormalRoad = new Rectangle(player.ThirdRoad.RoadX,
                                                    player.ThirdRoad.RoadY,
                                                    player.ThirdRoad.Image.Width,
                                                    257);
                    ThirdBrokenRoad = new Rectangle(player.ThirdRoad.RoadX - 10,
                                                    player.ThirdRoad.RoadY,
                                                    player.ThirdRoad.Image.Width,
                                                    257);
                }
                if (player.EquipedRoad != null) {
                    Netting = new Rectangle(player.EquipedRoad.CurPoint.X,
                                            -300,
                                            60,
                                            200);
                }
                if (player.EquipedRoad != null) {
                    RTrigon = new Rectangle(player.EquipedRoad.RoadX + 12,
                                            585,
                                            18,
                                            18);
                }
            }
            catch (NullReferenceException) {
            }
        }
    }
}