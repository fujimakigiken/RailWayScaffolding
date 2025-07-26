using System.Diagnostics;
using System.Windows.Forms;

namespace RailWayScaffolding
{
    public partial class Form1 : Form
    {
        public List<StationInfo> StationInfos = new List<StationInfo>();
        public List<StationPoint> StationPoints = new List<StationPoint>();

        public Form1()
        {
            InitializeComponent();

            listBox1.Click += (sender, e) =>
            {
                if (listBox1.SelectedItem != null)
                {
                    var selectedTitle = listBox1.SelectedItem.ToString();
                    var selectedPoint = StationPoints.FirstOrDefault(sp => sp.title == selectedTitle);

                    if (selectedPoint != null)
                    {
                        int num = listBox1.SelectedIndex;

                        var property = new Property(StationPoints[num]);

                        property.ShowDialog();

                        if (property.DialogResult == DialogResult.OK)
                        {
                            // 選択されたStationPointのプロパティを更新
                            StationPoints[num].x1 = property.SelectedStationPoint.x1;
                            StationPoints[num].y1 = property.SelectedStationPoint.y1;
                            StationPoints[num].x2 = property.SelectedStationPoint.x2;
                            StationPoints[num].y2 = property.SelectedStationPoint.y2;
                            StationPoints[num].title = property.SelectedStationPoint.title;

                            listBox1.Items[num] = StationPoints[num].title; // リストボックスの表示を更新

                            // 画像を再描画
                            PaintImage(StationPoints[num]);
                        }
                    }
                }
            };

            StationPoints.Add(new StationPoint { x1 = 100, y1 = 100, x2 = 200, y2 = 200, title = "kon0" });
            StationPoints.Add(new StationPoint { x1 = 101, y1 = 101, x2 = 201, y2 = 201, title = "kon1" });
            StationPoints.Add(new StationPoint { x1 = 102, y1 = 102, x2 = 202, y2 = 202, title = "kon2" });
            StationPoints.Add(new StationPoint { x1 = 103, y1 = 103, x2 = 203, y2 = 203, title = "kon3" });
            StationPoints.Add(new StationPoint { x1 = 104, y1 = 104, x2 = 204, y2 = 204, title = "kon4" });
            StationPoints.Add(new StationPoint { x1 = 105, y1 = 105, x2 = 205, y2 = 205, title = "kon5" });
            StationPoints.Add(new StationPoint { x1 = 106, y1 = 106, x2 = 206, y2 = 206, title = "kon6" });
            StationPoints.Add(new StationPoint { x1 = 107, y1 = 107, x2 = 207, y2 = 207, title = "kon7" });
            StationPoints.Add(new StationPoint { x1 = 108, y1 = 108, x2 = 208, y2 = 208, title = "kon8" });
            StationPoints.Add(new StationPoint { x1 = 109, y1 = 109, x2 = 209, y2 = 209, title = "kon9" });

            InitListBox();

            DrawImage();
        }

        private void cSVからToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var sr = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            if (parts.Length == 3 && int.TryParse(parts[0], out int id) && float.TryParse(parts[2], out float kiro))
                            {
                                var stationInfo = new StationInfo(id, parts[1], kiro);
                                StationInfos.Add(stationInfo);
                            }
                        }

                        MessageBox.Show(StationInfos.Count + "件の駅情報を読み込みました。");
                    }
                }

            }
        }

        private void sVG作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SVG files (*.svg)|*.svg|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var svg = new SVGCreator(StationInfos);
                    svg.StationRect();
                    svg.StationText();
                    svg.SVHBuild(saveFileDialog.FileName);
                }
            }
        }

        // <summary>
        // GUIの異動時に行うエフェクト
        // </summary>
        private void PaintImage(StationPoint sp)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //Penオブジェクトの作成(幅1の黒色)
            //(この場合はPenを作成せずに、Pens.Blackを使っても良い)
            Pen p = new Pen(Color.Green, 1);
            //位置(10, 20)に100x80の長方形を描く

            Brush brush = new SolidBrush(Color.FromArgb(255, Color.Green)); // 半透明の緑色
            g.FillRectangle(new SolidBrush(Color.Black), sp.x1, sp.y1, sp.x2, sp.y2);
            //リソースを解放する

            //PictureBox1に表示する
            pictureBox1.Image = canvas;
            p.Dispose();
            g.Dispose();
        }

        // <summary>
        // 読み込み時などGUIの初期化時に呼び出されるメソッド
        // </summary>
        private void DrawImage()
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //Penオブジェクトの作成(幅1の黒色)
            //(この場合はPenを作成せずに、Pens.Blackを使っても良い)
            Pen p = new Pen(Color.Green, 1);
            //位置(10, 20)に100x80の長方形を描く
            g.DrawRectangle(p, StationPoints[0].x1, StationPoints[0].y1, StationPoints[0].x2, StationPoints[0].y2);

            //リソースを解放する
            p.Dispose();
            g.Dispose();

            //PictureBox1に表示する
            pictureBox1.Image = canvas;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var pointX = e.X;
            var pointY = e.Y;

            var pointX2 = 100;
            var pointY2 = 100;

            StationPoints[0].x1 = pointX;
            StationPoints[0].y1 = pointY;
            StationPoints[0].x2 = pointX2;
            StationPoints[0].y2 = pointY2;


            foreach (var item in StationPoints)
            {
                if (item.x1 <= pointX && item.x2 + item.x1 >= pointX2)
                {
                    if (item.y1 <= pointY && item.y2 + item.y1 >= pointY2)
                    {
                        PaintImage(StationPoints[0]);
                    }
                }
            }
        }

        public void InitListBox()
        {
            listBox1.Items.Clear();
            foreach (var item in StationPoints)
            {
                listBox1.Items.Add(item.title);
            }
        }
    }
}

/*
 
svgファイルの読み込み

論理への書き出し
論理の仕様：
どう保存するか



プレゼンテーションの実装




 */