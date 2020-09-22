namespace GrassWrapper.Parameter
{
    public class Hardcoded :IParameter
    {
        public Hardcoded(string content)
        {
            Content = content;
        }
        public string Content { get; set; }
        public override string ToString()
        {
            return Content;
        }

        public string Name { get; set; } = "Hardcoded has no Name";
        public string Description { get; set; } = "Hardcoded has no Description";
        public bool Optional { get; set; }
        public bool IsAdvancedParameter { get; set; } 
    }
}