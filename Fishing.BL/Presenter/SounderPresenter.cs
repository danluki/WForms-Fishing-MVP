using Fishing.BL.Model.Game;
using Fishing.BL.View;
using System;
using System.Drawing;
using System.Windows.Forms;
using Fishing.BL.Model.LVLS;
using Fishing.Presenter;

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
                float drawX = 0;
                for (var i = 0; i < CurLVL.Height - 1; i++) {
                    var drawX2 = drawX + (Sounderwidth / (CurLVL.Height - 1));
                    g.DrawLine(new Pen(Color.White, 2), drawX, Convert.ToSingle(CurLVL.DeepArray[Sounder.GetSounder().Row, i].Text) / 10, drawX2,
                        Convert.ToSingle(CurLVL.DeepArray[Sounder.GetSounder().Row, i + 1].Text) / 10);
                    drawX = drawX2;
                }
                DrawPoint(g);
            }
            catch (NullReferenceException) { }
        }

        private void DrawPoint(Graphics g) {
            var player = Player.GetPlayer();
            var height = 23 * CurLVL.Height;
            if (height >= Sounderwidth) {
            }
            if (height < Sounderwidth) {
            }
            var x = Sounder.GetSounder().Column * (Sounderwidth / CurLVL.Height);
            g.DrawEllipse(new Pen(Color.Black), x, player.EquipedRoad.CurrentDeep / 10 - 4, 4, 4);
        }

        public override void Run()
        {
            
        }

        public override void End()
        {
            
        }
    }
}