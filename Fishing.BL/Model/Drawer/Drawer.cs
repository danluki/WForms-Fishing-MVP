using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Drawer {

    public class Drawer {
        public Graphics Graphics { get; set; }

        private readonly Player player = Game.Game.GetGame().Player;
        private readonly SolidBrush sbrush = new SolidBrush(Color.White);

        public Action FeedUpEnded;
        public Action DoNettingEnded;

        public Rectangle FirstNormalRoad;
        public Rectangle FirstBrokenRoad;

        public Rectangle SecondNormalRoad;
        public Rectangle SecondBrokenRoad;

        public Rectangle ThirdNormalRoad;
        public Rectangle ThirdBrokenRoad;

        public Rectangle Netting;
        public Rectangle RTrigon;
        public Rectangle FeedUpBallRectangle = new Rectangle(0, Game.Game.GameHeight, 4, 4);
        private Point FeedUpPoint;

        public Drawer() {
            player.GiveUped += Player_GiveUped;
            player.DoNetting += Player_DoNetting;
        }

        private void Player_DoNetting(GameRod rod) {
            Timer _animationTimer = new Timer() {
                Interval = 5
            };
            _animationTimer.Start();
            Netting.X = rod.RoadX;
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
            if (player.EquipedRod != null) {
                sbrush.Color = Color.DarkOliveGreen;
                Graphics.DrawEllipse(new Pen(Color.White), player.FirstRod.CurPoint.X, player.FirstRod.CurPoint.Y, 4, 4);
                Graphics.DrawEllipse(new Pen(Color.DarkOliveGreen), FeedUpBallRectangle);
                Graphics.FillEllipse(sbrush, FeedUpBallRectangle);
            }
        }

        public void DrawPoints() {
            if (player.FirstRod != null) {
                sbrush.Color = player.FirstRod == player.EquipedRod ? Color.Red : Color.White;
                Graphics.DrawEllipse(new Pen(Color.White), player.FirstRod.CurPoint.X, player.FirstRod.CurPoint.Y, 4, 4);
                Graphics.FillEllipse(sbrush, player.FirstRod.CurPoint.X, player.FirstRod.CurPoint.Y, 4, 4);
            }

            if (player.SecondRod != null) {
                sbrush.Color = player.SecondRod == player.EquipedRod ? Color.Red : Color.White;
                Graphics.DrawEllipse(new Pen(Color.White), player.SecondRod.CurPoint.X, player.SecondRod.CurPoint.Y, 4, 4);
                Graphics.FillEllipse(sbrush, player.SecondRod.CurPoint.X, player.SecondRod.CurPoint.Y, 4, 4);
            }

            if (player.ThirdRod == null) return;
            sbrush.Color = player.ThirdRod == player.EquipedRod ? Color.Red : Color.White;
            Graphics.DrawEllipse(new Pen(Color.White), player.ThirdRod.CurPoint.X, player.ThirdRod.CurPoint.Y, 4, 4);
            Graphics.FillEllipse(sbrush, player.ThirdRod.CurPoint.X, player.ThirdRod.CurPoint.Y, 4, 4);
        }

        public void DrawNetting() {
            Graphics.DrawImage(Images.podsak1, Netting);
        }

        public void DrawTrigon() {
            if (player.EquipedRod != null) {
                Graphics.DrawImage(Images.ssp, RTrigon);
            }
        }

        public void DrawRoads() {
            try {
                if (player.FirstRod != null && !player.FirstRod.IsFishAttack) {
                    Graphics.DrawImage(player.FirstRod.Image, FirstNormalRoad);
                }
                else if (player.FirstRod != null && player.FirstRod.IsFishAttack) {
                    Graphics.DrawImage(player.FirstRod.Image, FirstBrokenRoad);
                }
                if (player.SecondRod != null && !player.SecondRod.IsFishAttack) {
                    Graphics.DrawImage(player.SecondRod.Image, SecondNormalRoad);
                }
                else if (player.SecondRod != null && player.SecondRod.IsFishAttack) {
                    Graphics.DrawImage(player.SecondRod.Image, SecondBrokenRoad);
                }
                if (player.ThirdRod != null && !player.ThirdRod.IsFishAttack) {
                    Graphics.DrawImage(player.ThirdRod.Image, ThirdNormalRoad);
                }
                else if (player.ThirdRod != null && player.ThirdRod.IsFishAttack) {
                    Graphics.DrawImage(player.ThirdRod.Image, ThirdBrokenRoad);
                }
            }
            catch (ArgumentNullException) { }
        }

        public void UpdateRectangles() {
            try {
                if (player.FirstRod != null) {
                    FirstNormalRoad = new Rectangle(player.FirstRod.RoadX,
                                                    player.FirstRod.RoadY,
                                                    player.FirstRod.Image.Width,
                                                    257);

                    FirstBrokenRoad = new Rectangle(player.FirstRod.RoadX - 10,
                                                    player.FirstRod.RoadY,
                                                    player.FirstRod.Image.Width,
                                                    257);
                }

                if (player.SecondRod != null) {
                    SecondNormalRoad = new Rectangle(player.SecondRod.RoadX,
                                                     player.SecondRod.RoadY,
                                                     player.SecondRod.Image.Width,
                                                     257);
                    SecondBrokenRoad = new Rectangle(player.SecondRod.RoadX - 10,
                                                     player.SecondRod.RoadY,
                                                     player.SecondRod.Image.Width,
                                                     257);
                }
                if (player.ThirdRod != null) {
                    ThirdNormalRoad = new Rectangle(player.ThirdRod.RoadX,
                                                    player.ThirdRod.RoadY,
                                                    player.ThirdRod.Image.Width,
                                                    257);
                    ThirdBrokenRoad = new Rectangle(player.ThirdRod.RoadX - 10,
                                                    player.ThirdRod.RoadY,
                                                    player.ThirdRod.Image.Width,
                                                    257);
                }
                if (player.EquipedRod != null) {
                    Netting = new Rectangle(player.EquipedRod.CurPoint.X,
                                            -300,
                                            60,
                                            200);
                }
                if (player.EquipedRod != null) {
                    RTrigon = new Rectangle(player.EquipedRod.RoadX + 12,
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