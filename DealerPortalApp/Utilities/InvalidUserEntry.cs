namespace DealerPortalApp.Utilities
{
    public class InvalidUserEntry:Exception
    {
        string message = "";
        public InvalidUserEntry()
        {
            message = "no data or list found as of now please add";
        }
        public override string Message => message;
    }
}
