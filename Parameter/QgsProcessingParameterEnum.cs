using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrassWrapper.Parameter
{
    public class QgsProcessingParameterEnum : ParameterBase<List<int>>
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
                DefaultValue = arr[5].Split(',').Select(int.Parse).ToList();
                Value = DefaultValue;
            }
            if (arr.Length > 6)
            {
                Optional = bool.Parse(arr[6].ToLower());
            }
        }

        public IEnumerable<string> Options { get; set; }
        public bool AllowMultiple { get; set; }

        public override string ValueAsString()
        {
            if (Value == null || !Value.Any())
            {
                return "";
            }
            var str = Value.First().ToString();
            if (AllowMultiple && Value.Count() > 1)
            {
                for (int i = 1; i < Value.Count(); i++)
                {
                    str += $",{Value[i]}";
                }
            }
            return str;
        }

    }
}