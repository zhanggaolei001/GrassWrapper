namespace GrassWrapper.Parameter
{
    /// <summary>
    ///  
    ///  QgsProcessingParameterRasterDestination:228
    /// </summary>
    public class QgsProcessingParameterRasterDestination : ParameterBase<string>
    {
        public QgsProcessingParameterRasterDestination(string[] arr) : base(arr)
        {//3DefaultValue	Optional
            if (arr.Length > 3 && arr[3] !="None"&& !string.IsNullOrEmpty(arr[3]))
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