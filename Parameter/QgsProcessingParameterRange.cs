namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterRange : ParameterBase<string>
    {
        public QgsProcessingParameterRange(string[] arr) : base(arr)
        {//Type	DefaultValue	Optional	
            if (arr.Length > 4&& arr[4]!="None")
            {
                DefaultValue = arr[4];
                Value = DefaultValue;
            }
            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
        }
        public string Low => (Value.Split(',')[0]);
        public string High => (Value.Split(',')[1]);
    }
}