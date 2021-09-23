﻿#nullable disable

namespace DeliverIT.Models.DatabaseModels
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}