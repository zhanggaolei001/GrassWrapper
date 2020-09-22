namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterCrs : ParameterBase<string>
    {  //todo:double还可能是int,需要测试是否满足要求.
        public QgsProcessingParameterCrs(string[] arr) : base(arr)
        {//8		QgsProcessingParameterCrs	Name	Description	DefaultValue	Optional				
            if (arr.Length > 2 && arr[2] != "None" && string.IsNullOrEmpty(arr[2]))
            {
                DefaultValue = arr[2];
                Value = DefaultValue;
            }

            if (arr.Length > 3)
            {
                Optional = bool.Parse(arr[3].ToLower());
            }
        }
    }
}