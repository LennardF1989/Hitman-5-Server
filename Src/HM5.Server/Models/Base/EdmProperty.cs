namespace HM5.Server.Models.Base
{
    public class EdmProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }

        //NOTE: Game checks for string-value "true"
        public bool Nullable { get; set; }
    }
}