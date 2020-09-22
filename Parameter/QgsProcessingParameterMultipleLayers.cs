using System;
using System.Collections.Generic;
using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    /// <summary>
    /// QgsProcessingParameterMultipleLayers:47
    /// </summary>
    public class QgsProcessingParameterMultipleLayers : ParameterBase<IEnumerable<string>>
    {
        public QgsProcessingParameterMultipleLayers(string[] arr) : base(arr)
        {//3SourceType layerType	DefaultValue	Optional			
            LayerType = (SourceType)int.Parse(arr[3]);
            if (arr.Length > 4 && arr[4] !="None"&& !string.IsNullOrEmpty(arr[4]))
            {
                DefaultValue = arr[4].Split(',');
                Value = DefaultValue;
            }
            if (arr.Length > 5)
            {
                Optional = bool.Parse(arr[5].ToLower());
            }
        }

        public SourceType LayerType { get; set; }
    }
}