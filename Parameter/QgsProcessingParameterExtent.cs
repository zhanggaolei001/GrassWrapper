using System.Linq;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterExtent : ParameterBase<Box>
    {
        public QgsProcessingParameterExtent(string[] arr) : base(arr)
        {
            //9		QgsProcessingParameterExtent	Name	Description	DefaultValue	Optional				
            if (arr.Length > 3 && arr[3] != "None"&&!string.IsNullOrEmpty(arr[3]))
            {
                var b = arr[3].Split(',').Select(double.Parse).ToArray();
                DefaultValue = new Box(b[0], b[1], b[2], b[3]) ;
                Value = DefaultValue;
            }

            if (arr.Length > 4)
            {
                Optional = bool.Parse(arr[4].ToLower());
            }
        }
    }
}