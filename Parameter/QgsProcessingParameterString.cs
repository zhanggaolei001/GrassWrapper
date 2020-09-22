namespace GrassWrapper.Parameter
{
    /// <summary>
    /// QgsProcessingParameterString:169
    /// </summary>
    public class QgsProcessingParameterString : ParameterBase<string>
    {    public QgsProcessingParameterString(string[] arr) : base(arr)
        {//DefaultValue	multiLine	Optional

            if (arr.Length > 3 && arr[3] !="None"&& !string.IsNullOrEmpty(arr[3]))
            {
                DefaultValue = arr[3];
                Value = DefaultValue;
            }
            if (arr.Length > 4)
            {
                MultiLine = bool.Parse(arr[4].ToLower());
            }
            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            } 
        }

        public bool MultiLine { get; set; }  
    }
}