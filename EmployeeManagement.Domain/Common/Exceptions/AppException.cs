namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class AppException : ApplicationException
    {
        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
}
