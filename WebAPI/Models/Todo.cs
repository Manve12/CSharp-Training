using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
    }
}