using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using GrassWrapper.Parameter;

namespace GrassWrapper
{
    public class GrassCommand
    {
        public GrassCommand(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Name = lines[0];
            Description = lines[1];
            Group = lines[2];
            Parameters = new List<IParameter>();
            for (int i = 3; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    Console.WriteLine(lines[i]);
                }
                else
                {
                    Parameters.Add(ParameterFactory.CreateParameter(lines[i]));
                }

            }
        }
        [Description("执行算法所调用的grass命令的名称(例如v.buffer)")]
        public string Name { get; set; }
        //显示给用户的算法名称。这通常与GRASS命令相同，但可能有所不同
        [Description("显示给用户的算法名称")]
        public string Description { get; set; }
        [Description("命令组名称")]
        public string Group { get; set; }

        public List<IParameter> Parameters { get; set; }
        public override string ToString()
        {
            var commandStr = Name;
            foreach (var parameter in Parameters)
            {
                commandStr += $" {parameter.ToString()}";
            }
            return commandStr;
        }
    }
}