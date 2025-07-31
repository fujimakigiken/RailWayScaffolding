using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayScaffolding
{
    class HTMLCreator : SVGCreator
    {
        public HTMLCreator(List<StationInfo> stationInfos, float EkikanParameter) : base(stationInfos, EkikanParameter)
        {
            this.stationInfos = stationInfos;
            this.EkikanParameter = EkikanParameter;

            initViewBox = new ViewBox();

            GetParameter();
        }
        protected string GetFileExtension()
        {
            return ".html";
        }
        protected string GetFileHeader()
        {
            return "<!DOCTYPE html>\n<html>\n<head>\n<title>SVG Content</title>\n</head>\n<body>\n";
        }
        protected string GetFileFooter()
        {
            return "</body>\n</html>";
        }

        public string MakeJavaScriptCodeGetElementByID()
        {
            string separater = string.Empty;

            var tmpPointName = "point";
            var tmpAreaName = "area";
            var tmpStationName = "station";

            StringBuilder sb = new StringBuilder();

            int i = 0;

            separater = "/********************************************************/\n/*AutoGeneratoCode by FujimakiGiken*/\n/*StationPoint Gui-Joint-Setting*/\n/********************************************************/\n\n";
            sb.Append(separater);

            foreach (var item in stationInfos)
            {
                sb.Append($"const {tmpPointName}_{item.stationNameRomanCharacter} = document.getElementById('{tmpPointName}{i++}');\n");
            }

            i = 0;

            separater = "\n/********************************************************/\n/*AutoGeneratoCode by FujimakiGiken*/\n/*StationArea Gui-Joint-Setting*/\n/********************************************************/\n\n";
            sb.Append(separater);

            foreach (var item in stationInfos)
            {
                sb.Append($"const {tmpAreaName}_{item.stationNameRomanCharacter} = document.getElementById('{tmpAreaName}{i++}');\n");
            }

            i = 0;

            separater = "\n/********************************************************/\n/*AutoGeneratoCode by FujimakiGiken*/\n/*StationTitle Gui-Joint-Setting*/\n/********************************************************/\n\n";
            sb.Append(separater);

            foreach (var item in stationInfos)
            {
                sb.Append($"const {tmpStationName}_{item.stationNameRomanCharacter} = document.getElementById('{tmpStationName}{i++}');\n");
            }

            separater = "\n/********************************************************/\n/*AutoGeneratoCode by FujimakiGiken*/\n/*StationTitle Gui-Joint-Setting*/\n/********************************************************/\n\n";
            sb.Append(separater);

            sb.Append($"let {tmpPointName} = new Array();\n\n");

            i = 0;

            foreach (var item in stationInfos)
            {
                sb.Append($"{tmpPointName}[{i++}] = {tmpPointName}_{item.stationNameRomanCharacter};\n");
            }

            separater = "\n/********************************************************/\n/*AutoGeneratoCode by FujimakiGiken*/\n/*StationTitle Gui-Joint-Setting*/\n/********************************************************/\n\n";
            sb.Append(separater);

            sb.Append($"let {tmpAreaName} = new Array();\n\n");

            i = 0;

            foreach (var item in stationInfos)
            {
                sb.Append($"{tmpAreaName}[{i++}] = {tmpAreaName}_{item.stationNameRomanCharacter};\n");
            }

            separater = "\n/********************************************************/\n/*AutoGeneratoCode by FujimakiGiken*/\n/*StationTitle Gui-Joint-Setting*/\n/********************************************************/\n\n";
            sb.Append(separater);

            sb.Append($"let {tmpStationName} = new Array();\n\n");

            i = 0;

            foreach (var item in stationInfos)
            {
                sb.Append($"{tmpStationName}[{i++}] = {tmpStationName}_{item.stationNameRomanCharacter};\n");
            }

            using (var sr = new StreamReader("E:\\work\\aMap\\tmpScript.js", Encoding.UTF8))
            {
                var existingContent = sr.ReadToEnd();
                {
                    sb.Append("\n\n");
                    sb.Append(existingContent);
                }
            }

            return sb.ToString();
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
                sw.WriteLine(GetFileHeader());
                sw.WriteLine("    <h1>Railway Line</h1>\r\n<label for=\"colorPicker\">色を選んでください:</label>\r\n<input type=\"color\" id=\"colorPicker\" name=\"colorPicker\" value=\"#ff0000\">\r\n");
                sw.WriteLine(svgHeaderBefore);
                sw.WriteLine(initViewBox.stylesheets);
                sw.WriteLine(svgHeaderAfter);
                sw.WriteLine(stem);
                sw.WriteLine(svgContent.ToString());
                sw.WriteLine(svgEnd);
                sw.WriteLine("<script>" + "\n");
                sw.WriteLine(MakeJavaScriptCodeGetElementByID());
                sw.WriteLine("</script>" + "\n");
                sw.WriteLine(GetFileFooter());
            }
        }
    }
}
