﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs.Base
{
    public abstract class BaseDto
    {
        public Guid? Id { get; set; }
    }
}
