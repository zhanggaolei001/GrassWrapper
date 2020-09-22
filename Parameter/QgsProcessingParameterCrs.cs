namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterCrs : ParameterBase<string>
    {  //todo:double还可能是int,需要测试是否满足要求.
        public QgsProcessingParameterCrs(string[] arr) : base(arr)
        {//8		QgsProcessingParameterCrs	Name	Description	DefaultValue	Optional				
            if (arr.Length > 3 && arr[3] != "None" && !string.IsNullOrEmpty(arr[3]))
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