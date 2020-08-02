using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{
    public class AddRoleModel
    {

        public AppUser User { get; set; }
        public List<MyIdentityRole> rolesForDisplay { get; set; }
        public string selectedRole { get; set; }
        public MyIdentityRole newRole { get; set; }
        
    }
}
