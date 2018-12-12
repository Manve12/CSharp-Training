using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DatabaseLoader
    {
        public DatabaseLoader()
        {
            TodoRepository.Todos = new List<Todo>();

            Todo todo_1 = new Todo();
            todo_1.Id = 1;
            todo_1.Description = "Turn the lights off";
            todo_1.Complete = true;

            Todo todo_2 = new Todo();
            todo_2.Id = 2;
            todo_2.Description = "Learn how to implement WEB API ASP.NET with Angular 6/7";
            todo_2.Complete = false;

            TodoRepository.Todos.Add(todo_1);
            TodoRepository.Todos.Add(todo_2);
        }
    }
}