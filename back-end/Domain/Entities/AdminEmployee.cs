using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminEmployee : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
    public enum Role
    {
        ADMIN = 0,
        EMPLOYEE = 1,
    }
    public enum Gender
    {
        MALE = 0,
        FEMALE = 1,
    }
}
