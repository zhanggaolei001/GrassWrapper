namespace GrassWrapper.Parameter
{
    /// <summary>
    /// QgsProcessingParameterFolderDestination
    /// </summary>
    public class QgsProcessingParameterFolderDestination : ParameterBase<string>
    {
        public QgsProcessingParameterFolderDestination(string[] arr) : base(arr)
        {//DefaultValue	Optional				
            if (arr.Length > 3 && arr[3] !="None" && string.IsNullOrEmpty(arr[3]))
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