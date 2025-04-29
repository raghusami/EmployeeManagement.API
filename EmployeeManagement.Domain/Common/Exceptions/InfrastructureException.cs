namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class InfrastructureException : ApplicationException
    {
        public InfrastructureException(string message, Exception inner = null) : base(message)
        {
            if (inner != null) this.Data["Inner"] = inner.Message;
        }
    }
}
