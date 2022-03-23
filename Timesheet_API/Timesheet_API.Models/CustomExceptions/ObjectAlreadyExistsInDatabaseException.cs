namespace Timesheet_API.Models.CustomExceptions
{
    [Serializable]
    public class ObjectAlreadyExistsInDatabaseException : Exception
    {
        public ObjectAlreadyExistsInDatabaseException()
        {

        }

        public ObjectAlreadyExistsInDatabaseException(string message) : base(message)
        {

        }

        public ObjectAlreadyExistsInDatabaseException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
