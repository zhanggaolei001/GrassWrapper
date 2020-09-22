using System.Linq;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterExtent : ParameterBase<Box>
    {
        public QgsProcessingParameterExtent(string[] arr) : base(arr)
        {
            //9		QgsProcessingParameterExtent	Name	Description	DefaultValue	Optional				
            if (arr.Length > 2 && arr[2] != "None")
            {
                var b = arr[2].Split(',').Select(double.Parse).ToArray();
                DefaultValue = new Box(b[0], b[1], b[2], b[3]) ;
                Value = DefaultValue;
            }

            if (arr.Length > 3)
            {
                Optional = bool.Parse(arr[3].ToLower());
            }
        }
    }
}