﻿namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {

        }

    }
}
