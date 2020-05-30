using Fishing.BL;
using Fishing.BL.Controller;
using Fishing.BL.Model.Drawer;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using Fishing.BL.View;
using Fishing.View.GUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.Presenter {

    //<summary>
    //Реализует основную логику процесса рыбалки
    //</summary>
    public class LvlPresenter : BasePresenter {
        private const int NoWaterArea = 560;
        private const int MaxBarValue = 1000;
        private const int RoadDefaultY = 350;
        private const int RoadMaxY = 357;
        private readonly IGameForm view;
        private readonly IGUIPresenter gui;
        private readonly Drawer _drawer;
        private readonly Player _player = Game.GetGame().Player;

        public Lvl CurLvl { get; set; }

        public LvlPresenter(IGameForm view, IGUIPresenter v, Lvl curLVL) {
            this.CurLvl = curLVL;
            curLVL.AddFishes();
            curLVL.SetDeep();
            this.view = view;
            this.gui = v;
            view.Presenter = this;
            view.BackImage = CurLvl.BackgroundImage;
            _drawer = new Drawer();
            _player.CurrentLevel = CurLvl;
            v.LocationNameLabelText = curLVL.ToString();

            _drawer.FeedUpEnded += Drawer_FeedUpEnded;
            _drawer.DoNettingEnded += Drawer_DoNettingEnded;
            view.RepaintScreen += View_RepaintScreen;
            view.FormMouseClick += View_MouseLeftClick;
            view.KeyDOWN += View_KeyDOWN;
            view.KeyUP += View_KeyUP;
            view.MainTimerTick += View_MainTimerTick;
            view.FormClose += View_FormClose;
            view.DecSacietyTimerTick += View_DecSacietyTimerTick;
        }

        private void Drawer_FeedUpEnded() {
            _player.IsFeedingUp = false;
            SoundsPlayer.PlayFeedUpSound();
        }
        private void Drawer_DoNettingEnded() {
            _player.IsNettingFish = false;
            if (IsFishAbleToGoIntoFpond()) {
                _player.ResetRod(_player.EquipedRod);
                gui.ResetBarValues();

                gui.CheckNeedsAndClearEventBox();
                _player.AddFishToPond();
                view.CreateCurrentFish(_player.EquipedRod.Fish);
                gui.AddRoadToGUI(_player.EquipedRod);
            }
        }

        private void View_DecSacietyTimerTick(object sender, EventArgs e) {
            _player.DecSatiety(5);
        }

        private void View_FormClose(object sender, EventArgs e) {
            GameLoader.GetLoader().SavePlayer();
            End();
        }

        private void View_MainTimerTick(object sender, EventArgs e) {
            try {
                if (_player.EquipedRod != null) {
                    SetSounderCord(_player.EquipedRod.CurPoint);
                    if (_player.EquipedRod.IsFishAttack) {
                        gui.LureDeepValue = _player.EquipedRod.CurrentDeep;
                        AutoDecBarValues();
                        if (gui.FLineBarValue > MaxBarValue - 5) {
                            _player.Statistic.AddEventToHistory(new FLineTornEvent());
                            _player.TornFLine();

                            gui.ResetBarValues();

                            SoundsPlayer.PlayTornSound();
                        }
                        if (gui.RoadBarValue > MaxBarValue - 5) {
                            _player.BrokeRoad();
                            _player.Statistic.AddEventToHistory(new RoadBrokenEvent());

                            gui.ResetBarValues();
                        }
                    }
                    if (_player.FirstRod != null && _player.FirstRod.IsFishAttack) {
                        _player.FirstRod.CurPoint.Y += _player.FirstRod.Fish.Power.Y;
                        _player.FirstRod.CurPoint.X += _player.FirstRod.Fish.Power.X;
                        CheckBorders(_player.FirstRod.CurPoint, _player.FirstRod);
                    }
                    if (_player.SecondRod != null && _player.SecondRod.IsFishAttack) {
                        _player.SecondRod.CurPoint.Y += _player.SecondRod.Fish.Power.Y;
                        _player.SecondRod.CurPoint.X += _player.SecondRod.Fish.Power.X;
                        CheckBorders(_player.SecondRod.CurPoint, _player.SecondRod);
                    }
                    if (_player.ThirdRod != null && _player.ThirdRod.IsFishAttack) {
                        _player.ThirdRod.CurPoint.Y += _player.ThirdRod.Fish.Power.Y;
                        _player.ThirdRod.CurPoint.X += _player.ThirdRod.Fish.Power.X;
                        CheckBorders(_player.ThirdRod.CurPoint, _player.ThirdRod);
                    }
                    if (_player.EquipedRod.CurPoint.Y >= NoWaterArea) {
                        _player.EquipedRod.IsBaitInWater = false;
                    }
                    view.UpdateForm();
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.G:
                    SetSounderCord(_player.EquipedRod.CurPoint);
                    _player.EquipedRod.IsBaitMoving = true;
                    if (_player.EquipedRod.IsFishAttack) {
                        _player.EquipedRod.Image = _player.EquipedRod.GImage;
                        _player.WindingSpeed = _player.EquipedRod.Assembly.Reel.Power;
                    }
                    else {
                        _player.WindingSpeed = 1;
                    }
                    DoWiring();
                    IncFLineBarValues();
                    break;

                    case Keys.H:
                    if (_player.EquipedRod.IsFishAttack) {
                        _player.EquipedRod.Image = _player.EquipedRod.HImage;
                        _player.WindingSpeed = 2;
                        _player.EquipedRod.CurPoint.Y += _player.WindingSpeed;
                        IncRoadBarValues();
                    }
                    break;

                    case Keys.Space:
                    if (IsFishAbleToGoIntoFpond()) {
                        _player.IsNettingFish = true;
                        _player.StartNetting(_player.EquipedRod);
                    }
                    break;

                    case Keys.U:
                    _player.GiveUp(_player.EquipedRod);
                    break;

                    case Keys.T:
                    if (_player.EquipedRod.IsFishAttack == false) {
                        MakeCast(_player.EquipedRod.LastCastPoint);
                    }
                    break;

                    case Keys.D1:
                    _player.SetEquipedRoad(1);
                    gui.AddRoadToGUI(_player.EquipedRod);
                    break;

                    case Keys.D2:
                    _player.SetEquipedRoad(2);
                    gui.AddRoadToGUI(_player.EquipedRod);
                    break;

                    case Keys.D3:
                    _player.SetEquipedRoad(3);
                    gui.AddRoadToGUI(_player.EquipedRod);
                    break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyUP(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.G:
                    if (_player.EquipedRod.IsFishAttack) {
                        _player.EquipedRod.Image = _player.EquipedRod.GImage;
                    }
                    _player.EquipedRod.IsBaitMoving = false;
                    _player.EquipedRod.RoadY -= 7;
                    break;

                    case Keys.H:
                    if (_player.EquipedRod.IsFishAttack) {
                        _player.EquipedRod.Image = _player.EquipedRod.GImage;
                    }
                    break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_MouseLeftClick(object sender, MouseEventArgs e) {
            var (isIntersect, road) = IsPointIntersectWithRoadRect(view.CurPoint);
            if (isIntersect) {
                _player.SetEquipedRoad(road);
                gui.AddRoadToGUI(_player.EquipedRod);
            }
            if (!isIntersect && !_player.EquipedRod.IsFishAttack) {
                MakeCast(view.CurPoint);
            }
            if (e.Button != MouseButtons.Right) return;
            if (isIntersect) {
                if (_player.FirstRod == _player.EquipedRod) {
                    _player.FirstRod?.RemoveFromLocation();
                    _player.FirstRod = null;
                }
                if (_player.SecondRod == _player.EquipedRod) {
                    _player.SecondRod?.RemoveFromLocation();
                    _player.SecondRod = null;
                }
                if (_player.ThirdRod == _player.EquipedRod) {
                    _player.ThirdRod?.RemoveFromLocation();
                    _player.ThirdRod = null;
                }
            }
        }

        #region Painting

        private void View_RepaintScreen(object sender, PaintEventArgs e) {
            try {
                _drawer.Graphics = e.Graphics;
                _drawer.UpdateRectangles();
                _drawer.DrawRoads();
                _drawer.DrawPoints();
                if (_player.IsFeedingUp) {
                    _drawer.DrawFeedUpBall();
                }
                if (_player.IsNettingFish) {
                    _drawer.DrawNetting();
                }
                if (_player.EquipedRod != null) {
                    _drawer.DrawTrigon();
                }
            }
            catch (NullReferenceException) { }
        }

        #endregion Painting

        #region Cast

        private void MakeCast(Point point) {
            if (_player.IsPlayerAbleToFishing()) {
                SetSounderCord(point);
                _player.EquipedRod.CurLVL = CurLvl;
                if (!_player.EquipedRod.IsFishAttack) {
                    CheckBorders(point, _player.EquipedRod);
                    _player.EquipedRod.IsBaitInWater = true;
                    _player.EquipedRod.IsBaitMoving = false;
                    _player.EquipedRod.StartBaitTimer();
                    _player.EquipedRod.RoadX = _player.EquipedRod.CurPoint.X;
                    _player.EquipedRod.LastCastPoint = point;

                    SoundsPlayer.PlayCastSound();
                }

                if (_player.EquipedRod.IsFishAttack) return;
                _player.EquipedRod.RoadY = RoadDefaultY;

                try {
                    if (_player.EquipedRod.Assembly.FishBait != null) return;
                    _player.EquipedRod.CurPoint.Y = 0;
                    MessageBox.Show(Messages.NO_LURE_EQUIPED);
                }
                catch (NullReferenceException) {
                    _player.EquipedRod.CurPoint.Y = 0;
                }
            }
            else {
                MessageBox.Show(@"Игрок не готов к рыбалке");
            }
        }

        #endregion Cast

        private void DoWiring() {
            if (_player.EquipedRod.RoadY != RoadMaxY) {
                _player.EquipedRod.RoadY += 7;
            }
            _player.WindingSpeed = _player.EquipedRod.IsFishAttack ? _player.EquipedRod.Assembly.Reel.Power : 1;
            _player.EquipedRod.CurPoint.Y += Game.GetGame().Player.WindingSpeed;
        }

        private void AutoDecBarValues() {
            if (gui.FLineBarValue > 0) {
                gui.IncrementFLineBarValue(-3);
            }
            if (gui.RoadBarValue > 0) {
                gui.IncrementRoadBarValue(-3);
            }
        }

        private void SetSounderCord(Point point) {
            for (var y = 0; y < CurLvl.Height; y++) {
                for (var x = 0; x < CurLvl.Widgth; x++) {
                    var r = new Rectangle(CurLvl.DeepArray[x, y].Location,
                                          new System.Drawing.Size(LabelInfo.Width, LabelInfo.Height));
                    if (r.IntersectsWith(new Rectangle(point, new System.Drawing.Size(1, 1)))) {
                        Sounder.GetSounder().Column = y;
                        Sounder.GetSounder().Row = x;
                        _player.EquipedRod.CurrentDeep = Convert.ToInt32(CurLvl.DeepArray[x, y].Text);
                        gui.LureDeepValue = _player.EquipedRod.CurrentDeep;
                    }
                }
            }
        }

        #region IncrementBarValues

        private void IncFLineBarValues() {
            if (gui.RoadBarValue > 0) {
                gui.IncrementRoadBarValue(-(_player.EquipedRod.RoadIncValue));
            }
            if (gui.FLineBarValue < MaxBarValue) {
                gui.IncrementFLineBarValue(_player.EquipedRod.FlineIncValue);
            }
        }

        private void IncRoadBarValues() {
            if (gui.RoadBarValue < MaxBarValue) {
                gui.IncrementRoadBarValue(_player.EquipedRod.RoadIncValue);
            }
            if (gui.FLineBarValue > 0) {
                gui.IncrementFLineBarValue(-(_player.EquipedRod.FlineIncValue));
            }
        }

        #endregion IncrementBarValues

        #region CheckRoadsIntersect

        private (bool IsIntersec, GameRod Road) IsPointIntersectWithRoadRect(Point p) {
            var size = new System.Drawing.Size(1, 1);
            if (_drawer.FirstNormalRoad.IntersectsWith(new Rectangle(p, size)) ||
                _drawer.FirstBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (_player.EquipedRod != _player.FirstRod) {
                    gui.AddRoadToGUI(_player.EquipedRod);
                }
                return (true, _player.FirstRod);
            }
            if (_drawer.SecondNormalRoad.IntersectsWith(new Rectangle(p, size)) ||
                _drawer.SecondBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (_player.EquipedRod != _player.SecondRod) {
                    gui.AddRoadToGUI(_player.EquipedRod);
                }
                return (true, _player.SecondRod);
            }
            if (_drawer.ThirdNormalRoad.IntersectsWith(new Rectangle(p, size)) ||
                _drawer.ThirdBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (_player.EquipedRod != _player.ThirdRod) {
                    gui.AddRoadToGUI(_player.EquipedRod);
                }
                return (true, _player.ThirdRod);
            }
            return (false, null);
        }

        #endregion CheckRoadsIntersect

        private void CheckBorders(Point point, GameRod road) {
            if (point.Y >= CurLvl.DeepArray[0, 0].Location.Y) {
                road.CurPoint.Y = point.Y;
            }
            else {
                road.CurPoint.Y = CurLvl.DeepArray[0, 0].Location.Y + 3;
            }
            if (point.X >= CurLvl.DeepArray[0, 0].Location.X) {
                road.CurPoint.X = point.X;
            }
            if (point.X >= CurLvl.DeepArray[CurLvl.Widgth - 1, 0].Location.X) {
                road.CurPoint.X = CurLvl.DeepArray[CurLvl.Widgth - 1, 0].Location.X;
            }
        }

        private bool IsFishAbleToGoIntoFpond() {
            return _player.EquipedRod.IsFishAttack &&
                   _player.EquipedRod.CurPoint.Y >= NoWaterArea;
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}