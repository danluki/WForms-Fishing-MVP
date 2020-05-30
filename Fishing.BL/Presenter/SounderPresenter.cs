using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS;
using Fishing.BL.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL.Presenter {

    public class SounderPresenter : BasePresenter {
        private const float Sounderwidth = 372f;
        private readonly ISounder _view;
        public Lvl CurLVL { get; set; }

        public SounderPresenter(ISounder view, Lvl lvl) {
            CurLVL = lvl;
            _view = view;
            view.SounderPaint += SounderPanel_Paint;
        }

        private void SounderPanel_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            try {
                var player = Game.GetGame().Player;
                var height = Game.GameHeight - CurLVL.DeepTiesStartY;
                var beforeDeep = Game.GameHeight - (Game.GameHeight - CurLVL.DeepTiesStartY);
                float coef = 0f;
                if (height > Sounderwidth) {
                    coef = Sounderwidth / height;
                }
                if (height < Sounderwidth) {
                    coef = Sounderwidth / height;
                }
                var drawX = 0f;
                for (var i = 0; i < CurLVL.Height - 1; i++) {
                    var drawX2 = (CurLVL.DeepArray[Sounder.GetSounder().Row, i].Bottom - beforeDeep) * coef;
                    g.DrawLine(new Pen(Color.White, 2), drawX, Convert.ToSingle(CurLVL.DeepArray[Sounder.GetSounder().Row, i].Text) / 10, drawX2,
                        Convert.ToSingle(CurLVL.DeepArray[Sounder.GetSounder().Row, i + 1].Text) / 10);
                    drawX = drawX2;
                }
                g.DrawLine(new Pen(Color.White, 2), drawX, Convert.ToSingle(CurLVL.DeepArray[Sounder.GetSounder().Row, CurLVL.Height - 1].Text) / 10, Sounderwidth, 0);
                DrawPoint(g);
            }
            catch (NullReferenceException) { }
        }

        private void DrawPoint(Graphics g) {
            var player = Game.GetGame().Player;
            var height = Game.GameHeight - CurLVL.DeepTiesStartY;
            var beforeDeep = Game.GameHeight - (Game.GameHeight - CurLVL.DeepTiesStartY);
            float coef = 0f;
            if (height > Sounderwidth) {
                coef = Sounderwidth / height;
            }
            if (height < Sounderwidth) {
                coef = Sounderwidth / height;
            }
            if (player.EquipedRod != null) {
                var x = (player.EquipedRod.CurPoint.Y - beforeDeep) * coef;
                g.DrawEllipse(new Pen(Color.Black), x, player.EquipedRod.CurrentDeep / 10 - 4, 4, 4);
            }
        }

        public override void Run() {
        }

        public override void End() {
        }
    }
}