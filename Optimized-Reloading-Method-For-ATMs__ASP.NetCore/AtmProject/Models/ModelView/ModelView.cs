using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmProject.Models.ModelView
{
    public class ModelView
    {
        
        public IFormFile file { get; set; }
        public string atmId { get; set; }

    }
}
