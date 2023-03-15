using System;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Entities
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

