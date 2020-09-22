using System.Collections.Generic;
using System.Linq;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterEnum : ParameterBase<IEnumerable<int>>
    {
        public QgsProcessingParameterEnum(string[] arr) : base(arr)
        {
            Options = arr[3].Split(';');
            if (arr.Length > 4 && arr[4] != "None" && !string.IsNullOrEmpty(arr[4]))
            {
                AllowMultiple = bool.Parse(arr[4].ToLower());
            }
            if (arr.Length > 5 && arr[5] != "None" && !string.IsNullOrEmpty(arr[5]))
            {
                DefaultValue = arr[5].Split(',').Select(int.Parse);
                Value = DefaultValue;
            }
            if (arr.Length > 6)
            {
                Optional = bool.Parse(arr[6].ToLower());
            }
        }

        public IEnumerable<string> Options { get; set; }
        public bool AllowMultiple { get; set; }

    }
}