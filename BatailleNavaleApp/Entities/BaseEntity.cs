﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatailleNavaleApp.Entities
{
    public class BaseEntity
    {
       [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public  Guid Id { get; set; }

    }
}
