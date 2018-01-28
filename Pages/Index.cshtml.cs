using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace DemoASP.Pages
{
    public class IndexModel : PageModel
    {
        public UserStore store;
        public IndexModel(UserStore s) {
            store = s;
        }
    }
}
