using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RailWayScaffolding.Form1;

namespace RailWayScaffolding
{
    public class StationInfo
    {
        public int id { get; set; }
        public string stationName { get; set; }
        public float kiro { get; set; }

        public StationInfo()
        {
        }
        public StationInfo(int id, string stationName, float kiro)
        {
            this.id = id;
            this.stationName = stationName;
            this.kiro = kiro;
        }
    }

    public class  ViewBox
    {
        public string stylesheets { set; get; }
        public int x1 { set; get; }
        public int x2 { set; get; }

        public int y1 { set; get; }
        public int y2 { set; get; }

        public ViewBox()
        {
        }
    }
    public class  Stem
    {
        public float x { set; get; }
        public float y { set; get; }
        public float width { set; get; }
        public float height { set; get; }

        public Stem() { }
    }
    public class  GTag
    {
        public string idName { get; set; }

        public GTag() { }
    }
    public class StationStruct
    {
        public int x { get; set; }
        public int y { get; set; }

        public float transformX { get; set; }

        public float transformY { get; set; }

        public string idName { get; set; }

        public StationStruct() { }
    }
    public class RectStruct
    {
        public int x { get; set; }
        public int y { get; set; }
        public float transformX { get; set; }
        public float transformY { get; set; }
        public float width { get; set; }
        public float height { get; set; }

        public string idName { get; set; }
        public RectStruct() { }
    }

    public class  StationPoint
    {
        public string title { set; get; } = "Station Point";
        public float x1 { set; get; }
        public float x2 { set; get; }
        public float y1 { set; get; }
        public float y2 { set; get; }

        public bool focus { set; get; } = false;

        public bool grabObject { set; get; } = false;

        public StationPoint() { }

        public void SetNewPoint(float x1, float x2, float y1, float y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public void GetNowPoint(out float x1, out float x2, out float y1, out float y2)
        {
            x1 = this.x1;
            x2 = this.x2;
            y1 = this.y1;
            y2 = this.y2;
        }
    }
}
