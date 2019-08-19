using Configs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Configs.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employees employee { get; set; }
        public string PageTitle { get; set; }
    }
}
