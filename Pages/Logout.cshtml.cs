using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace DemoASP.Pages
{
    public class LogoutModel : PageModel
    {
        public UserStore store;
        public LogoutModel(UserStore s) {
            store = s;
        } 
        public void OnGet() {
            store.user = "";
            store.message = "You have been logged out";
        }  
    }
}
