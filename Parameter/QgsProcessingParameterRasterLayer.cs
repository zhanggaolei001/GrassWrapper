namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterRasterLayer : ParameterBase<string>
    {
        public QgsProcessingParameterRasterLayer(string[] arr) : base(arr)
        {
            if (arr.Length > 3 && arr[3] !="None"&& string.IsNullOrEmpty(arr[3]))
            {
                DefaultValue = arr[3];
                Value = DefaultValue;
            }

            if (arr.Length > 4)
            {
                Optional = bool.Parse(arr[4].ToLower());
            }
        }
    }
}