using System.Collections.Generic;
using System.Linq;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterFeatureSource : ParameterBase<string>
    {
        public QgsProcessingParameterFeatureSource(string[] arr) : base(arr)
        {//3types	DefaultValue	Optional			
            Types = arr[3].Split(',').Select(s => (GeometryType)int.Parse(s));
            if (arr.Length > 4 && arr[4] !="None"&& string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = arr[4];
                Value = DefaultValue;
            }

            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
        }
        public IEnumerable<GeometryType> Types { get; set; }
    }
    public enum GeometryType
    {
        anygeometry = -1,
        points = 0,
        lines = 1,
        polygons = 2
    }
}