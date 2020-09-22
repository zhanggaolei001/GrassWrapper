using System.Linq;

namespace GrassWrapper.Parameter
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
    public class QgsProcessingParameterPoint : ParameterBase<Point>
    {
        public QgsProcessingParameterPoint(string[] arr) : base(arr)
        {//3:DefaultValue	Optional				
            if (arr.Length > 3 && arr[3] != "None" && string.IsNullOrEmpty(arr[3]))
            {
                var xy = arr[3].Split(',').Select(double.Parse).ToArray();
                DefaultValue = new Point(xy[0], xy[1]);//0.0,0.0
                Value = DefaultValue;
            }

            if (arr.Length > 4)
            {
                Optional = bool.Parse(arr[4].ToLower());
            }
        }
    }
}