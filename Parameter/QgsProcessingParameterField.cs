using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterField : ParameterBase<string>
    {
        public QgsProcessingParameterField(string[] arr) : base(arr)
        {/*QgsProcessingParameterField	column	Attribute column                                	3None	4map 	5-1	6FALSE	7FALSE
           QgsProcessingParameterField	column	Attribute table column with values to interpolate	3None	4input	5-1	7FALSE	7FALSE
        */
          
            ParentLayerParameterName = string.IsNullOrEmpty(arr[3]) || arr[3] == "None" ? null:arr[3];
            DataType = (DataType)(int.Parse(arr[5])); 
            Optional = bool.Parse(arr[6].ToLower());
            DefaultToAllFields = bool.Parse(arr[7].ToLower());
        }

        public string ParentLayerParameterName { get; set; }
        public DataType DataType { get; set; } 
        public bool DefaultToAllFields { get; set; }

    }
}