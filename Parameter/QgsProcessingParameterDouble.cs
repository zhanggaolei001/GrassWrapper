using System.Reflection;

namespace GrassWrapper.Parameter
{
    /// <summary>
    /// QgsProcessingParameterNumber:double
    /// </summary>
    public class QgsProcessingParameterDouble : ParameterBase<double>
    {
        public QgsProcessingParameterDouble(string[] arr) : base(arr)
        {//0 1 2:3Type	4DefaultValue	Optional	minValue	MaxValue
         //Type在工厂方法中进行处理,区分double或int.
            if (arr.Length > 4 && arr[4] != "None" && !string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = double.Parse(arr[4]);
                Value = DefaultValue;
            }
            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
            if (arr.Length > 6 && arr[6] != "None" && !string.IsNullOrEmpty(arr[6]))
            {
                MinValue = double.Parse(arr[6]);
            }
            else
            {
                MinValue = double.MinValue + 1;
            }
            if (arr.Length > 7&& arr[7]!="None")
            {
                MaxValue = double.Parse(arr[7]);
            }
            else
            {
                MaxValue = double.MaxValue - 1;
            }
        }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}