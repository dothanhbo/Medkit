using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class ChangePassword
    {
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
