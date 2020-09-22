using System;
using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    /// <summary>
    ///  QgsProcessingParameterFile:69   
    /// </summary>
    public class QgsProcessingParameterFile : ParameterBase<string>
    {
        public QgsProcessingParameterFile(string[] arr) : base(arr)
        {// 3Behavior	4extension	DefaultValue	Optional	fileFilter	
            Behavior = (Behavior)System.Enum.Parse(typeof(Behavior),arr[3].Split('.')[1]);

            if (arr.Length > 4)
            {
                Extension = arr[4];
            }
            if (arr.Length > 5 && arr[5] != "None" && string.IsNullOrEmpty(arr[5]))
            {
                DefaultValue = arr[5];
                Value = DefaultValue;
            }
            if (arr.Length > 6)
            {
                Optional = bool.Parse(arr[6].ToLower());
            }

            if (arr.Length > 7)
            {
                FileFilter = arr[7];
            }

        }
        public string Extension { get; set; }
        public string FileFilter { get; set; }
        public Behavior Behavior { get; set; }

    }
}