using System;

namespace FlightManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() : base("Entity with search query not found.")
        {
            
        }
    }
}