using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.DAL.Entities
{
    public abstract class User : IdentityUser
    {
        public string Name { get; set; }
        public string Image { get; set; }

    }
}
