using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.Dtos
{
    public class UserProfileDto
    {
       public Guid Id { get; set; }
        public string UserName { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ImageId { get; set; }

        public IFormFile Photo { get; set; }

        public Image Image { get; set; }

    }
}
