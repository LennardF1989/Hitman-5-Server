namespace HM5.Server.Models.Base
{
    public class EdmFunctionImport
    {
        public string Name { get; set; }
        public string HttpMethod { get; set; }
        public string ReturnType { get; set; }
        public List<SFunctionParameter> Parameters { get; set; }
    }
}