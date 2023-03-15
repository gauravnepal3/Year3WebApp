using System;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public DateTime JoinDate { get; set; }
        public string Designation { get; set; }
    }
}

