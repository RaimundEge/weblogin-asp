using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace DemoASP.Pages
{
    public class RegisterModel : PageModel
    {
        public string user = "";
        public UserStore store;
        public RegisterModel(UserStore s) {
            store = s;
        } 
        public void OnGet()
        {
        }
        [HttpPost]
        public void OnPost() {
            User user = new User {
                fullname = Request.Form["fullname"],
                username = Request.Form["username"],
                password = Request.Form["password"]
            };
            if (store.getUser(user.username) == null) {
                store.registerUser(user);
                store.message = "New user registered: " + user.fullname;
            } else {
                store.message = "Username unavailable";
            }           
        }  
    }
}
