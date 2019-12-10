using Fishing.BL.Model.Drawer;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using Fishing.BL.Resources.Sounds;
using Fishing.BL.View;
using Fishing.View.GUI;
using Saver.BL.Controller;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Fishing.BL.Controller;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.Presenter;

namespace Fishing.Presenter {

    public class LvlPresenter : BasePresenter {
        private const int NoWaterArea = 570;

        private readonly IGameForm view;
        private readonly IGUIPresenter gui;
        private readonly Drawer _drawer;
        private readonly Player _player = Player.GetPlayer();

        public Lvl CurLvl { get; set; }

        public LvlPresenter(IGameForm view, IGUIPresenter v, Lvl curLVL) {
            this.CurLvl = curLVL;
            curLVL.AddFishes();
            curLVL.SetDeep();
            this.view = view;
            this.gui = v;
            view.LVLPresenter = this;
            view.BackImage = CurLvl.Image;
            _drawer = new Drawer();

            view.RepaintScreen += View_RepaintScreen;
            view.FormMouseClick += View_MouseLeftClick;
            view.KeyDOWN += View_KeyDOWN;
            view.KeyUP += View_KeyUP;
            view.MainTimerTick += View_MainTimerTick;
            view.FormClose += View_FormClose;
            view.DecSacietyTimerTick += View_DecSacietyTimerTick;
        }

        private void View_DecSacietyTimerTick(object sender, EventArgs e) {
            _player.DecSatiety(5);
            gui.EatingBarValue = _player.Satiety;
        }

        private void View_FormClose(object sender, EventArgs e) {
            BaseController.GetController().SavePlayer();
            this.End();
        }

        private void View_MainTimerTick(object sender, EventArgs e) {
            try {
                SetSounderCord(_player.EquipedRoad.CurPoint);
                if (_player.EquipedRoad.IsFishAttack) {
                    gui.LureDeepValue = _player.EquipedRoad.CurrentDeep;
                    AutoDecBarValues();
                    if (gui.FLineBarValue > 990) {
                        _player.AddEventToHistory(new FLineTornEvent());
                        _player.TornFLine();

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;

                        SoundsPlayer.PlayTornSound();
                    }
                    if (gui.RoadBarValue > 990) {
                        _player.BrokeRoad();
                        _player.AddEventToHistory(new RoadBrokenEvent());

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;
                    }
                }
                if (_player.FirstRoad != null && _player.FirstRoad.IsFishAttack) {
                    _player.FirstRoad.CurPoint.Y += _player.FirstRoad.Fish.Power.Y;
                    _player.FirstRoad.CurPoint.X += _player.FirstRoad.Fish.Power.X;
                    CheckBorders(_player.FirstRoad.CurPoint, _player.FirstRoad);
                }
                if (_player.SecondRoad != null && _player.SecondRoad.IsFishAttack) {
                    _player.SecondRoad.CurPoint.Y += _player.SecondRoad.Fish.Power.Y;
                    _player.SecondRoad.CurPoint.X += _player.SecondRoad.Fish.Power.X;
                    CheckBorders(_player.SecondRoad.CurPoint, _player.SecondRoad);
                }
                if (_player.ThirdRoad != null && _player.ThirdRoad.IsFishAttack) {
                    _player.ThirdRoad.CurPoint.Y += _player.ThirdRoad.Fish.Power.Y;
                    _player.ThirdRoad.CurPoint.X += _player.ThirdRoad.Fish.Power.X;
                    CheckBorders(_player.ThirdRoad.CurPoint, _player.ThirdRoad);
                }
                if (_player.EquipedRoad.CurPoint.Y >= NoWaterArea) {
                    _player.EquipedRoad.IsBaitInWater = false;
                }
                view.UpdateForm();
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.G:
                    _player.EquipedRoad.CurrentDeep = Convert.ToInt32(gui.DeepValue);
                    _player.EquipedRoad.IsBaitMoving = true;
                    if (_player.EquipedRoad.IsFishAttack) {
                        _player.EquipedRoad.Image = _player.EquipedRoad.GImage;
                        _player.WindingSpeed = _player.EquipedRoad.Assembly.Reel.Power;
                    }
                    else {
                        Player.GetPlayer().WindingSpeed = 1;
                    }
                    DoWiring();
                    IncFLineBarValues();
                    break;

                    case Keys.H:
                    if (_player.EquipedRoad.IsFishAttack) {
                        _player.EquipedRoad.Image = _player.EquipedRoad.HImage;
                        _player.WindingSpeed = 2;
                        _player.EquipedRoad.CurPoint.Y += _player.WindingSpeed;
                        IncRoadBarValues();
                    }
                    break;

                    case Keys.Space:
                    if (IsFishAbleToGoIntoFpond()) {
                        _player.EquipedRoad.Image = Roads.road;
                        _player.EquipedRoad.FLineIncValue = 0;
                        _player.EquipedRoad.RoadIncValue = 0;

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;

                        gui.CheckNeedsAndClearEventBox();
                        _player.AddFishToPond();
                        _drawer.DrawNetting();
                        view.CreateCurrentFish(_player.EquipedRoad.Fish);
                        gui.AddRoadToGUI(_player.EquipedRoad);
                    }
                    break;

                    case Keys.T:
                    if (_player.EquipedRoad.IsFishAttack == false) {
                        MakeCast(_player.EquipedRoad.LastCastPoint);
                    }
                    break;

                    case Keys.D1:
                    _player.SetEquipedRoad(1);
                    gui.AddRoadToGUI(_player.EquipedRoad);
                    break;

                    case Keys.D2:
                    _player.SetEquipedRoad(2);
                    gui.AddRoadToGUI(_player.EquipedRoad);
                    break;

                    case Keys.D3:
                    _player.SetEquipedRoad(3);
                    gui.AddRoadToGUI(_player.EquipedRoad);
                    break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyUP(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.G:
                    if (_player.EquipedRoad.IsFishAttack) {
                        _player.EquipedRoad.Image = _player.EquipedRoad.GImage;
                    }
                    _player.EquipedRoad.IsBaitMoving = false;
                    _player.EquipedRoad.RoadY -= 7;
                    break;

                    case Keys.H:
                    if (_player.EquipedRoad.IsFishAttack) {
                        _player.EquipedRoad.Image = _player.EquipedRoad.GImage;
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
                gui.AddRoadToGUI(_player.EquipedRoad);
            }
            if (!isIntersect && !_player.EquipedRoad.IsFishAttack) {
                MakeCast(view.CurPoint);
            }
            if (e.Button != MouseButtons.Right) return;
            if (isIntersect) {
                _player.EquipedRoad = null;
            }
        }

        #region Painting
        private void View_RepaintScreen(object sender, PaintEventArgs e) {
            try {
                _drawer.Graphics = e.Graphics;
                _drawer.UpdateRectangles();
                _drawer.DrawRoads();
                _drawer.DrawPoints();
                if (_player.EquipedRoad != null) {
                    _drawer.DrawTrigon();
                }
                if (IsFishAbleToGoIntoFpond()) {
                    _drawer.DrawNetting();
                }
            }
            catch (NullReferenceException) { }
        }


        #endregion
        #region Cast
        private void MakeCast(Point point) {
            if (_player.IsPlayerAbleToFishing()) {
                _player.EquipedRoad.CurLVL = CurLvl;
                SetSounderCord(point);

                if (!_player.EquipedRoad.IsFishAttack) {
                    CheckBorders(point, _player.EquipedRoad);
                    _player.EquipedRoad.IsBaitInWater = true;
                    _player.EquipedRoad.IsBaitMoving = false;
                    _player.EquipedRoad.StartBaitTimer();
                    _player.EquipedRoad.RoadX = _player.EquipedRoad.CurPoint.X;
                    _player.EquipedRoad.LastCastPoint = point;

                    SoundsPlayer.PlayCastSound();
                }

                if (_player.EquipedRoad.IsFishAttack) return;
                _player.EquipedRoad.RoadY = 350;
                try {
                    if (_player.EquipedRoad.Assembly.FishBait != null) return;
                    _player.EquipedRoad.CurPoint.Y = 0;
                    MessageBox.Show(Messages.NO_LURE_EQUIPED);
                }
                catch (NullReferenceException) {
                    _player.EquipedRoad.CurPoint.Y = 0;
                }
            }
            else {
                MessageBox.Show(@"Игрок не готов к рыбалке");
            }
        }
        #endregion
        
        private void DoWiring() {
            if (_player.EquipedRoad.RoadY != 357) {
                _player.EquipedRoad.RoadY += 7;
            }
            _player.WindingSpeed = _player.EquipedRoad.IsFishAttack ? _player.EquipedRoad.Assembly.Reel.Power : 1;
            _player.EquipedRoad.CurPoint.Y += Player.GetPlayer().WindingSpeed;
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
                    var r = new Rectangle(CurLvl.DeepArray[x, y].Location, new System.Drawing.Size(40, 23));
                    if (!r.IntersectsWith(new Rectangle(point, new System.Drawing.Size(1, 1)))) continue;
                    Sounder.GetSounder().Column = y;
                    Sounder.GetSounder().Row = x;
                    _player.EquipedRoad.CurrentDeep = Convert.ToInt32(CurLvl.DeepArray[x, y].Text);
                    gui.LureDeepValue = _player.EquipedRoad.CurrentDeep;
                }
            }
        }

        #region IncrementBarValues

        private void IncFLineBarValues() {
            if (gui.RoadBarValue > 0) {
                gui.IncrementRoadBarValue(-(_player.EquipedRoad.RoadIncValue));
            }
            if (gui.FLineBarValue < 1000) {
                gui.IncrementFLineBarValue(_player.EquipedRoad.FLineIncValue);
            }
        }

        private void IncRoadBarValues() {
            if (gui.RoadBarValue < 1000) {
                gui.IncrementRoadBarValue(_player.EquipedRoad.RoadIncValue);
            }
            if (gui.FLineBarValue > 0) {
                gui.IncrementFLineBarValue(-(_player.EquipedRoad.FLineIncValue));
            }
        }

        #endregion

        #region CheckRoadsIntersect
        private (bool IsIntersec, GameRoad Road) IsPointIntersectWithRoadRect(Point p) {
            var size = new System.Drawing.Size(1, 1);
            if (_drawer.FirstNormalRoad.IntersectsWith(new Rectangle(p, size)) || _drawer.FirstBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (_player.EquipedRoad != _player.FirstRoad) {
                    gui.AddRoadToGUI(_player.EquipedRoad);
                }
                return (true, _player.FirstRoad);
            }
            if (_drawer.SecondNormalRoad.IntersectsWith(new Rectangle(p, size)) || _drawer.SecondBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (_player.EquipedRoad != _player.SecondRoad) {
                    gui.AddRoadToGUI(_player.EquipedRoad);
                }
                return (true, _player.SecondRoad);
            }

            if (!_drawer.ThirdNormalRoad.IntersectsWith(new Rectangle(p, size)) &&
                !_drawer.ThirdBrokenRoad.IntersectsWith(new Rectangle(p, size))) return (false, null);
            if (_player.EquipedRoad != _player.ThirdRoad) {
                gui.AddRoadToGUI(_player.EquipedRoad);
            }
            return (true, _player.ThirdRoad);

        }


        #endregion
        
        private void CheckBorders(Point point, GameRoad road) {
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

        private bool IsFishAbleToGoIntoFpond()
        {
            return _player.EquipedRoad.IsFishAttack && _player.EquipedRoad.CurPoint.Y >= NoWaterArea;
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}