using System;
using System.Collections.Generic;
using System.Linq;
using GrassWrapper.Enum;

namespace GrassWrapper.Parameter
{
    public interface IParameter
    {
        string Name { get; set; }
        string Description { get; set; }
        bool Optional { get; set; }
        bool IsAdvancedParameter { get; set; }
        string TypeString { get; set; }
    }
    //Hardcoded:15
    //QgsProcessingParameterMultipleLayers:47
    //QgsProcessingParameterBoolean:171
    //QgsProcessingParameterRasterDestination:228 
    //QgsProcessingParameterFolderDestination:13
    //QgsProcessingParameterRasterLayer:357
    //QgsProcessingParameterRange:15
    //QgsProcessingParameterFile:69 
    //QgsProcessingParameterString:169
    //QgsProcessingParameterFileDestination:78
    //QgsProcessingParameterEnum:125
    //QgsProcessingParameterPoint:13 
    //QgsProcessingParameterFeatureSource:118
    //QgsProcessingParameterVectorDestination:94 
    //QgsProcessingParameterCrs:5 
    //QgsProcessingParameterField:26 
    //QgsProcessingParameterExtent:2
    //QgsProcessingOutputString:1 
    //QgsProcessingParameterString:1



    public abstract class ParameterBase<T> : IParameter
    {
        private T _value;

        protected ParameterBase(string[] arr)
        {
            TypeString = arr[0].Replace("*", "");
            IsAdvancedParameter = arr[0].StartsWith("*");
            var name = arr[1];
            if (arr[0].StartsWith("*"))
            {
                IsAdvancedParameter = true;
                name = name.Substring(1);
            }
            var description = arr[2];
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAdvancedParameter { get; set; }

        public string TypeString { get; set; }

        //public string TypeString { get; set; } 
        public bool Optional { get; set; }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public T DefaultValue { get; set; }

        public virtual string ValueAsString()
        {
            if (Value == null)
            {
                return "";
            }
            return Value.ToString();
        }

        public override string ToString()
        {
            var value = ValueAsString();
            return string.IsNullOrWhiteSpace(value) ? "" : $"{Name}={value}";
        }
    }

    public static class ParameterFactory
    {
        public static IParameter CreateParameter(string line)
        {
            var arr = line.Split('|');
            var typeString = arr[0].Replace("*", "");
            switch (typeString)
            {
                case "Hardcoded":
                    return new Hardcoded(arr[1]);
                case "QgsProcessingParameterMultipleLayers":
                    return new QgsProcessingParameterMultipleLayers(arr);
                case "QgsProcessingParameterBoolean":
                    return new QgsProcessingParameterBoolean(arr);
                case "QgsProcessingParameterRasterDestination":
                    return new QgsProcessingParameterRasterDestination(arr);
                case "QgsProcessingParameterFolderDestination":
                    return new QgsProcessingParameterFolderDestination(arr);
                case "QgsProcessingParameterRasterLayer":
                    return new QgsProcessingParameterRasterLayer(arr);
                case "QgsProcessingParameterRange":
                    return new QgsProcessingParameterRange(arr);
                case "QgsProcessingParameterFile":
                    return new QgsProcessingParameterFile(arr);
                case "QgsProcessingParameterString":
                    return new QgsProcessingParameterString(arr);
                case "QgsProcessingParameterFileDestination":
                    return new QgsProcessingParameterFileDestination(arr);
                case "QgsProcessingParameterEnum":
                    return new QgsProcessingParameterEnum(arr);
                case "QgsProcessingParameterPoint":
                    return new QgsProcessingParameterPoint(arr);
                case "QgsProcessingParameterFeatureSource":
                    return new QgsProcessingParameterFeatureSource(arr);
                case "QgsProcessingParameterVectorDestination":
                    return new QgsProcessingParameterVectorDestination(arr);
                case "QgsProcessingParameterCrs":
                    return new QgsProcessingParameterCrs(arr);
                case "QgsProcessingParameterField":
                    return new QgsProcessingParameterField(arr);
                case "QgsProcessingParameterExtent":
                    return new QgsProcessingParameterExtent(arr);
                case "QgsProcessingOutputString":
                    return new QgsProcessingOutputString(arr);
                case "QgsProcessingParameterNumber":
                    if (arr[3].EndsWith("Double"))
                    {
                        return new QgsProcessingParameterDouble(arr);
                    }
                    else
                    {
                        return new QgsProcessingParameterInt(arr);
                    }
                default:
                    Console.WriteLine(line);
                    throw new Exception(line + ":无法被识别");
            }

            return null;
        }

    }

    public class Box
    {
        public Box(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
    }
}