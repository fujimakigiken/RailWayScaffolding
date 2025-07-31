using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayScaffolding
{
    class SVGCreator
    {
        public ViewBox initViewBox = null;
        public Stem initStem = new Stem();
        public GTag initGTag = new GTag();
        public StationStruct initStationStruct = new StationStruct();
        public RectStruct initRectStruct = new RectStruct();

        public List<StationInfo> stationInfos = new List<StationInfo>();
        public float EkikanParameter = 30.0f; // Default value, can be set from outside

        public List<string> rectList = new List<string>();
        public List<string> stationText = new List<string>();

        //public string stylesheet = "    <style>\r\n      .st0 {\r\n        fill: #00a0e9;\r\n        stroke: #231815;\r\n      }\r\n\r\n      .st0, .st1 {\r\n        stroke-miterlimit: 10;\r\n      }\r\n\r\n      .st2, .st1 {\r\n        fill: #fff;\r\n      }\r\n\r\n      .st3 {\r\n        font-family: ArialMT, Arial;\r\n      }\r\n\r\n      .st4, .st5 {\r\n        isolation: isolate;\r\n      }\r\n\r\n      .st5 {\r\n        fill: #231815;\r\n        font-size: 12px;\r\n      }\r\n\r\n      .st6 {\r\n        font-family: KozGoPr6N-Regular-90ms-RKSJ-H, 'Kozuka Gothic Pr6N';\r\n      }\r\n\r\n      .st1 {\r\n        stroke: #53b332;\r\n      }\r\n    </style>";
        public SVGCreator(List<StationInfo> stationInfos, float EkikanParameter) 
        {
            this.stationInfos = stationInfos;
            this.EkikanParameter = EkikanParameter;

            initViewBox = new ViewBox();

            GetParameter();
        }

        public void GetParameter()
        {
            using(var sr = new StreamReader("scaffolding.conf"))
            {
                string config = sr.ReadToEnd();

                string[] lines = config.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    if (line.StartsWith("stylesheet="))
                    {
                        try
                        {
                            initViewBox.stylesheets = line.Substring("stylesheet=".Length).Trim();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error parsing stylesheet: " + ex.Message);
                        }
                    }
                    else if (line.StartsWith("viewBox="))
                    {
                        // ここでviewBoxの値を取得して使用することができます
                        // 例: string viewBox = line.Substring("viewBox=".Length).Trim();
                        string[] parts = line.Substring("viewBox=".Length).Trim().Split(',');
                        if (parts.Length == 4)
                        {
                            initViewBox.x1 = int.Parse(parts[0]);
                            initViewBox.y1 = int.Parse(parts[1]);
                            initViewBox.x2 = int.Parse(parts[2]);
                            initViewBox.y2 = int.Parse(parts[3]);

                            // ViewBoxのインスタンスを作成するなど、必要な処理を行います
                        }
                    }
                    else if (line.StartsWith("stemX="))
                    {
                        // ここでstemXの値を取得して使用することができます
                        // 例: float stemX = float.Parse(line.Substring("stemX=".Length).Trim());
                        initStem.x = float.Parse(line.Substring("stemX=".Length).Trim());
                    }
                    else if (line.StartsWith("stemY="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStem.y = float.Parse(line.Substring("stemY=".Length).Trim());
                    }
                    else if (line.StartsWith("stemWidth="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStem.width = float.Parse(line.Substring("stemWidth=".Length).Trim());
                    }
                    else if (line.StartsWith("stemHeight="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStem.height = float.Parse(line.Substring("stemHeight=".Length).Trim());
                    }
                    else if (line.StartsWith("stationStructX="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStationStruct.x = int.Parse(line.Substring("stationStructX=".Length).Trim());
                    }
                    else if (line.StartsWith("stationStructY="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStationStruct.y = int.Parse(line.Substring("stationStructY=".Length).Trim());
                    }
                    else if (line.StartsWith("stationStructTransformX="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStationStruct.transformX = float.Parse(line.Substring("stationStructTransformX=".Length).Trim());
                    }
                    else if (line.StartsWith("stationStructTransformY="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStationStruct.transformY = float.Parse(line.Substring("stationStructTransformY=".Length).Trim());
                    }
                    else if (line.StartsWith("rectStructTransformX="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.transformX = float.Parse(line.Substring("rectStructTransformX=".Length).Trim());
                    }
                    else if (line.StartsWith("rectStructTransformY="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.transformY = float.Parse(line.Substring("rectStructTransformY=".Length).Trim());
                    }
                    else if (line.StartsWith("rectStructX="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.x = int.Parse(line.Substring("rectStructX=".Length).Trim());
                    }
                    else if (line.StartsWith("rectStructY="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.y = int.Parse(line.Substring("rectStructY=".Length).Trim());
                    }
                    else if (line.StartsWith("rectStructWidth="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.width = float.Parse(line.Substring("rectStructWidth=".Length).Trim());
                    }
                    else if (line.StartsWith("rectStructHeight="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.height = float.Parse(line.Substring("rectStructHeight=".Length).Trim());
                    }
                    else if (line.StartsWith("gtagIdName="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initGTag.idName = line.Substring("gtagIdName=".Length).Trim();
                    }
                    else if (line.StartsWith("stationStructIdName="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initStationStruct.idName = line.Substring("stationStructIdName=".Length).Trim();
                    }
                    else if (line.StartsWith("rectStructIdName="))
                    {
                        // ここでstemYの値を取得して使用することができます
                        // 例: float stemY = float.Parse(line.Substring("stemY=".Length).Trim());
                        initRectStruct.idName = line.Substring("rectStructIdName=".Length).Trim();
                    }
                }
            }
        }

        public void StationRect()
        {
            float addValueY = EkikanParameter;

            for (int i = 0; i < stationInfos.Count; i++)
            {
                var y = initRectStruct.transformY + (addValueY * i);
                string model = string.Format("<rect id=\"{0}{1}\" class=\"st1\" x=\"{2}\" y=\"{3}\" width=\"{4}\" height=\"{5}\"/>", initRectStruct.idName, i, initRectStruct.transformX, y, initRectStruct.width, initRectStruct.height);
                rectList.Add(model);
            }
        }

        public void StationText()
        {
            float addValueY = EkikanParameter;

            for (int i = 0; i < stationInfos.Count; i++)
            {
                var y = 161.22f + (addValueY * i);
                string model = string.Format("<text id=\"{0}{1}\" class=\"st5\" transform=\"translate(182.43 {2})\"><tspan class=\"st6\" x=\"13.34\" y=\"0\">{3}</tspan></text>", initStationStruct.idName, i, y, stationInfos[i].stationName);
                stationText.Add(model);
            }
        }

        public void SVHBuild(string outFileName)
        {
            string svgHeaderBefore = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<svg id=\"_レイヤー_1\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" viewBox=\"{0} {1} {2} {3}\">\r\n  <defs>", initViewBox.x1, initViewBox.y1, initViewBox.x2, initViewBox.y2);
            string svgHeaderAfter = "</defs>";
            string stem = string.Format("<rect class=\"st0\" x=\"{0}\" y=\"{1}\" width=\"{2}\" height=\"{3}\"/>", initStem.x, initStem.y, initStem.width, initStem.height);
            string svgEnd = "</svg>";

            StringBuilder svgContent = new StringBuilder();

            for (int i = 0; i < rectList.Count; i++)
            {
                string crlf = "\n";
                string gStartMarker = string.Format("<g id=\"{0}{1}\" class=\"st4\">", initGTag.idName, i);
                string gEndMarker = "</g>";

                svgContent.Append(gStartMarker + crlf);
                svgContent.Append(rectList[i] + crlf);
                svgContent.Append(stationText[i] + crlf);
                svgContent.Append(gEndMarker + crlf);
            }

            using (var sw = new StreamWriter(outFileName))
            {
                sw.WriteLine(svgHeaderBefore);
                sw.WriteLine(initViewBox.stylesheets);
                sw.WriteLine(svgHeaderAfter);
                sw.WriteLine(stem);
                sw.WriteLine(svgContent.ToString());
                sw.WriteLine(svgEnd);
            }
        }
    }
}
