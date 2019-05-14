using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.Entity.Identity
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Üyelik Tarihi
        /// </summary>
        public DateTime Tarih { get; set; } = DateTime.Now;
    }
}
