namespace HM5.Server.Mvc
{
    public class ModelStateException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public ModelStateException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
