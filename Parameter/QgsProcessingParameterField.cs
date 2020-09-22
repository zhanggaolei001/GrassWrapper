using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterField : ParameterBase<string>
    {
        public QgsProcessingParameterField(string[] arr) : base(arr)
        {
            ParentLayerParameterName = arr[2];
            DataType = (DataType)(int.Parse(arr[3]));
            AllowMultiple = bool.Parse(arr[4].ToLower());
            Optional = bool.Parse(arr[5].ToLower());
            DefaultToAllFields = bool.Parse(arr[6].ToLower());
        }

        public string ParentLayerParameterName { get; set; }
        public DataType DataType { get; set; }
        public bool AllowMultiple { get; set; }
        public bool DefaultToAllFields { get; set; }

    }
}