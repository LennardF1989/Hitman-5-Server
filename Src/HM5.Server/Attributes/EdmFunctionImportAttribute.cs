namespace HM5.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EdmFunctionImportAttribute : Attribute
    {
        public string Name { get; set; }
        public string HttpMethod { get; set; }
        public string ReturnType { get; set; }

        public EdmFunctionImportAttribute(string name, string httpMethod, string returnType)
        {
            Name = name;
            HttpMethod = httpMethod;
            ReturnType = returnType;
        }
    }
}
