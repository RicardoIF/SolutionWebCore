﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApp.Entities
{
    public partial class UserPermission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}