using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailWayScaffolding
{
    public partial class Property : Form
    {
        public StationPoint SelectedStationPoint = new StationPoint();

        public Property(StationPoint item)
        {
            InitializeComponent();

            this.SelectedStationPoint = item;

            t_x1.Text = SelectedStationPoint.x1.ToString();
            t_y1.Text = SelectedStationPoint.y1.ToString();
            t_x2.Text = SelectedStationPoint.x2.ToString();
            t_y2.Text = SelectedStationPoint.y2.ToString();
            t_title.Text = SelectedStationPoint.title;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.SelectedStationPoint.x1 = float.Parse(t_x1.Text);
            this.SelectedStationPoint.y1 = float.Parse(t_y1.Text);
            this.SelectedStationPoint.x2 = float.Parse(t_x2.Text);
            this.SelectedStationPoint.y2 = float.Parse(t_y2.Text);

            this.SelectedStationPoint.title = t_title.Text;
        }
    }
}
