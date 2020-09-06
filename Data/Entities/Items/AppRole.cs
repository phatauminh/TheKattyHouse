using System;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities.Items
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
