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
                            // �I�����ꂽStationPoint�̃v���p�e�B���X�V
                            StationPoints[num].x1 = property.SelectedStationPoint.x1;
                            StationPoints[num].y1 = property.SelectedStationPoint.y1;
                            StationPoints[num].x2 = property.SelectedStationPoint.x2;
                            StationPoints[num].y2 = property.SelectedStationPoint.y2;
                            StationPoints[num].title = property.SelectedStationPoint.title;

                            listBox1.Items[num] = StationPoints[num].title; // ���X�g�{�b�N�X�̕\�����X�V

                            // �摜���ĕ`��
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

        private void cSV����ToolStripMenuItem_Click(object sender, EventArgs e)
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

                        MessageBox.Show(StationInfos.Count + "���̉w����ǂݍ��݂܂����B");
                    }
                }

            }
        }

        private void sVG�쐬ToolStripMenuItem_Click(object sender, EventArgs e)
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
        // GUI�̈ٓ����ɍs���G�t�F�N�g
        // </summary>
        private void PaintImage(StationPoint sp)
        {
            //�`���Ƃ���Image�I�u�W�F�N�g���쐬����
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Image�I�u�W�F�N�g��Graphics�I�u�W�F�N�g���쐬����
            Graphics g = Graphics.FromImage(canvas);

            //Pen�I�u�W�F�N�g�̍쐬(��1�̍��F)
            //(���̏ꍇ��Pen���쐬�����ɁAPens.Black���g���Ă��ǂ�)
            Pen p = new Pen(Color.Green, 1);
            //�ʒu(10, 20)��100x80�̒����`��`��

            Brush brush = new SolidBrush(Color.FromArgb(255, Color.Green)); // �������̗ΐF
            g.FillRectangle(new SolidBrush(Color.Black), sp.x1, sp.y1, sp.x2, sp.y2);
            //���\�[�X���������

            //PictureBox1�ɕ\������
            pictureBox1.Image = canvas;
            p.Dispose();
            g.Dispose();
        }

        // <summary>
        // �ǂݍ��ݎ��Ȃ�GUI�̏��������ɌĂяo����郁�\�b�h
        // </summary>
        private void DrawImage()
        {
            //�`���Ƃ���Image�I�u�W�F�N�g���쐬����
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Image�I�u�W�F�N�g��Graphics�I�u�W�F�N�g���쐬����
            Graphics g = Graphics.FromImage(canvas);

            //Pen�I�u�W�F�N�g�̍쐬(��1�̍��F)
            //(���̏ꍇ��Pen���쐬�����ɁAPens.Black���g���Ă��ǂ�)
            Pen p = new Pen(Color.Green, 1);
            //�ʒu(10, 20)��100x80�̒����`��`��
            g.DrawRectangle(p, StationPoints[0].x1, StationPoints[0].y1, StationPoints[0].x2, StationPoints[0].y2);

            //���\�[�X���������
            p.Dispose();
            g.Dispose();

            //PictureBox1�ɕ\������
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
 
svg�t�@�C���̓ǂݍ���

�_���ւ̏����o��
�_���̎d�l�F
�ǂ��ۑ����邩



�v���[���e�[�V�����̎���




 */