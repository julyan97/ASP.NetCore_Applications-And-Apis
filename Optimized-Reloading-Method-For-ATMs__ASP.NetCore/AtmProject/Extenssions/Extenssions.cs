using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmProject.Extenssions
{
    public static class Extenssions
    {
        public static List<string> ReadAsList(this IFormFile file)
        {
            var list = new List<string>();
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    list.Add(reader.ReadLine());
            }
            return list;
        }
    }
}
