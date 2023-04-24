namespace HM5.Server.Models.Base
{
    public class EdmEndRole
    {
        public string Role { get; set; }
        public string Type { get; set; }

        //NOTE: Game converts Many to 2, default is 0.
        public string Multiplicity { get; set; }
    }
}