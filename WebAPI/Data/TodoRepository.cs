using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TodoRepository
    {
        public static List<Todo> Todos { get; set; }
    }
}