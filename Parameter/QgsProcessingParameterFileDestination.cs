namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterFileDestination : ParameterBase<string>
    {
        //QgsProcessingParameterFileDestination|output|Packed archive|Pack files (*.pack)|output.pack|False
        public QgsProcessingParameterFileDestination(string[] arr) : base(arr)
        {//3extension	DefaultValue	Optional			
            Extension = arr[3];
            if (arr.Length > 4 && arr[4] !="None"&& !string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = arr[4];
                Value = DefaultValue;
            }

            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
        }

        public string Extension { get; set; }
    }
}