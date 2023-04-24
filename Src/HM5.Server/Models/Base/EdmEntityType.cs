namespace HM5.Server.Models.Base
{
    public class EdmEntityType
    {
        public string Name { get; set; }
        public List<string> Key { get; set; }
        public List<EdmProperty> Properties { get; set; }
        //NavigationProperties
    }
}