namespace GrassWrapper.Parameter
{
    /// <summary>
    /// QgsProcessingParameterNumber:int
    /// </summary>
    public class QgsProcessingParameterInt : ParameterBase<int>
    {
        public QgsProcessingParameterInt(string[] arr) : base(arr)
        {//0 1 2 3:Type	4DefaultValue	Optional	minValue	MaxValue
            //Type在工厂方法中进行处理,区分double或int.
            if (arr.Length > 4 && arr[4] != "None" && !string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = int.Parse(arr[4]);
                Value = DefaultValue;
            }
            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
            if (arr.Length > 6 && arr[6] != "None" && !string.IsNullOrEmpty(arr[6]))
            {
                MinValue = int.Parse(arr[6]);
            }
            else
            {
                MinValue = int.MinValue + 1;
            }
            if (arr.Length > 7 && arr[7] != "None" && !string.IsNullOrEmpty(arr[6]))
            {
                MaxValue = int.Parse(arr[7]);
            }
            else
            {
                MaxValue = int.MaxValue - 1;
            }
        }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}