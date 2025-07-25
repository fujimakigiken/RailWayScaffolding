namespace RailWayScaffolding
{
    public partial class Form1 : Form
    {
        public List<StationInfo> StationInfos = new List<StationInfo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void cSVÇ©ÇÁToolStripMenuItem_Click(object sender, EventArgs e)
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

                        MessageBox.Show(StationInfos.Count + "åèÇÃâwèÓïÒÇì«Ç›çûÇ›Ç‹ÇµÇΩÅB");
                    }
                }

            }
        }

        private void sVGçÏê¨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var saveFileDialog = new SaveFileDialog())
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
    }
}
