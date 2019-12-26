using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Drawer {

    internal class Drawer {
        public Graphics Graphics { get; set; }

        private readonly Player player = Player.GetPlayer();
        private readonly SolidBrush sbrush = new SolidBrush(Color.White);

        public Action FeedUpEnded;
        public Action DoNettingEnded;

        public Rectangle FirstNormalRoad;
        public Rectangle FirstBrokenRoad;

        public Rectangle SecondNormalRoad;
        public Rectangle SecondBrokenRoad;

        public Rectangle ThirdNormalRoad;
        public Rectangle ThirdBrokenRoad;

        private Rectangle Netting;
        public Rectangle RTrigon;
        public Rectangle FeedUpBallRectangle = new Rectangle(0, Game.Game.GameHeight, 4, 4);
        private Point FeedUpPoint;

        public Drawer() {
            player.GiveUped += Player_GiveUped;
            player.DoNetting += Player_DoNetting;
        }

        private void Player_DoNetting() {
            Timer _animationTimer = new Timer() {
                Interval = 5
            };
            _animationTimer.Start();
            Netting.X = player.EquipedRoad.RoadX;
            Netting.Y = 540;
            _animationTimer.Tick += (sender, e) => {
                    if (Netting.Y > 300) {
                        Netting.Y -= 5;
                    }
                    else {
                        Netting.Y = 540;
                        DoNettingEnded?.Invoke();
                        _animationTimer.Stop();
                    }
            };
        }

        private void Player_GiveUped(Point point) {
            Timer _animationTimer = new Timer() {
                Interval = 10
            };
            _animationTimer.Start();
            _animationTimer.Tick += async (sender, e) => {
                await Task.Run(() => {
                    FeedUpBallRectangle.X = FeedUpPoint.X;
                    if (FeedUpBallRectangle.Y > FeedUpPoint.Y) {
                        FeedUpBallRectangle.Y -= 5;
                    }
                    else if (FeedUpBallRectangle.Y <= FeedUpPoint.Y) {
                        FeedUpBallRectangle.Y = Game.Game.GameHeight;
                        FeedUpEnded?.Invoke();
                        _animationTimer.Stop();
                    }
                });
            };
            FeedUpPoint = point;
        }


        public void DrawFeedUpBall() {
            if (player.EquipedRoad != null) {
                sbrush.Color = Color.DarkOliveGreen;
                Graphics.DrawEllipse(new Pen(Color.White), player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
                Graphics.DrawEllipse(new Pen(Color.DarkOliveGreen), FeedUpBallRectangle);
                Graphics.FillEllipse(sbrush, FeedUpBallRectangle);
            }
        }

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
            var timer = new Timer() {
                Interval = 25
            };
            timer.Tick += (sender, e) => {
                Netting.Y -= 10;
                Graphics.DrawImage(Images.podsak1, Netting);
            };
        }

        public void DrawTrigon() {
            if (player.EquipedRoad != null) {
                Graphics.DrawImage(Images.ssp, RTrigon);
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