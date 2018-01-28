using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace DemoASP.Pages
{
    public class LoginModel : PageModel
    {
        public string user = "";
        public UserStore store;
        public LoginModel(UserStore s) {
            store = s;
        } 
        public void OnGet()
        {
            store.message = "";
        }
        [HttpPost]
        public void OnPost() {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            User user = store.getUser(username);
            if (user != null) {
                store.user = user.fullname;
                store.message = user.fullname + ": Welcome back !";
            } else {
                store.message = "Username/password not found";
            }           
        }  
    }
}
