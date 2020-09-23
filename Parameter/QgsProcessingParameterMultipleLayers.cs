using System;
using System.Collections.Generic;
using System.Linq;
using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    /// <summary>
    /// QgsProcessingParameterMultipleLayers:47
    /// </summary>
    public class QgsProcessingParameterMultipleLayers : ParameterBase<List<string>>
    {
        public QgsProcessingParameterMultipleLayers(string[] arr) : base(arr)
        {//3SourceType layerType	DefaultValue	Optional			
            LayerType = (SourceType)int.Parse(arr[3]);
            if (arr.Length > 4 && arr[4] != "None" && !string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = arr[4].Split(',').ToList();
                Value = DefaultValue;
                Console.WriteLine(Value.Count);
            }
            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
        }

        public SourceType LayerType { get; set; }
        public override string ValueAsString()
        {
            if (Value == null || !Value.Any())
            {
                return "";
            }
            var str = Value.First();
            if (Value.Count() > 1)
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