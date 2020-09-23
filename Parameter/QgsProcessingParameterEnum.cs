using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrassWrapper.Parameter
{
    public class Option
    {
        public Option(string name, bool isSelected)
        {
            Name = name;
            IsSelected = IsSelected;
        }

        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class QgsProcessingParameterEnum : ParameterBase<List<int>>
    {
        public QgsProcessingParameterEnum(string[] arr) : base(arr)
        {
            Value = new List<int>() { 1, 2, 3 };
            var optionStrings = arr[3].Split(';');
            Options = new List<Option>();
            foreach (var str in optionStrings)
            {
                Options.Add(new Option(str, false));
            }
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

        public List<Option> Options { get; set; }
        public bool AllowMultiple { get; set; }

        public override string ValueAsString()
        {
            var v = Options.Where(o => o.IsSelected).Select(s => Options.IndexOf(s)).ToList();
            var str = "";
            if (v.Any())
            {
                str = v.First().ToString();
            }
            if (AllowMultiple && v.Count() > 1)
            {
                for (int i = 1; i < v.Count(); i++)
                {
                    str += $",{v[i]}";
                }
            }
            return str;
        }
    }
}