namespace HM5.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SFunctionParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public SFunctionParameterAttribute(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}