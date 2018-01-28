using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace DemoASP.Pages
{
    public class ContentModel : PageModel
    {
        public string user = "";
        public UserStore store;
        public ContentModel(UserStore s) {
            store = s;
        }
    }
}
