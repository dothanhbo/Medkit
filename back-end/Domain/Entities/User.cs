using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public UserGender Gender { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        public Guid ProductId { get; set; }
        public UserStatus Status { get; set; }
    }
    public enum UserStatus
    {
        ACTIVE = 0,
        BANNED = 1,
    }
    public enum UserGender
    {
        Male = 0,
        Female = 1,
    }
}
