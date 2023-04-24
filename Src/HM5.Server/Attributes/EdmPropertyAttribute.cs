namespace HM5.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EdmPropertyAttribute : Attribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }

        public EdmPropertyAttribute(string name, string type, bool nullable)
        {
            Name = name;
            Type = type;
            Nullable = nullable;
        }
    }
}
