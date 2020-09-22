using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterVectorDestination : ParameterBase<string>
    {
        public QgsProcessingParameterVectorDestination(string[] arr) : base(arr)
        {//3SourceType	4DefaultValue	5Optional	6createByDefault

            if (arr.Length > 3)
            {
                if (int.TryParse(arr[3], out var val))
                {
                    Type = (SourceType)val;
                }
                else
                {
                    Type = (SourceType)System.Enum.Parse(typeof(SourceType), arr[3].Split('.')[1]);
                }
            }

            if (arr.Length > 4 && arr[4] != "None" && !string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = arr[4];
                Value = DefaultValue;
            }

            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
            if (arr.Length > 6)
            {
                CreateByDefault = bool.Parse(arr[6].ToLower());
            }
        }
        public SourceType Type { get; set; }
        public bool CreateByDefault { get; set; }
    }
}