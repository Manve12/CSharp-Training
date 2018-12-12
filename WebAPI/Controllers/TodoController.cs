using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TodoController : ApiController
    {
        // api/Todo <= returns all
        public List<Todo> Get()
        {
            return TodoRepository.Todos.OrderBy(t=>t.Id).ToList(); // returns list of Todos ordered by the id
        }

        // api/Todo/{id}  <= returns with id or none
        public Todo Get(int Id)
        {
            return Get().Select(t=>t).Where(t=>t.Id == Id).FirstOrDefault(); // uses Get() method and finds the first item in the returned list by the id provided
        }

        // api/Todo/Set?description={desc}
        [HttpPost]
        public void Set(string description)
        {
            int nextId = 1;
            //calculate the next ID
            if (TodoRepository.Todos.LastOrDefault() != null)
            {
                nextId = TodoRepository.Todos.LastOrDefault().Id + 1;
            }
            //create a new todo and assign the id, description and status
            Todo newTodo = new Todo();
            newTodo.Id = nextId;
            newTodo.Description = description;
            newTodo.Complete = false;
            //add the todo into the repository
            TodoRepository.Todos.Add(newTodo);
        }

        [HttpPut]
        public void Update(int id, string description, bool status)
        {
            Delete(id); // delete the existing Todo
            //create a new Todo, assinging the id, description and the status
            Todo newTodo = new Todo();
            newTodo.Id = id;
            newTodo.Description = description;
            newTodo.Complete = status;
            //add the new todo to the repository
            TodoRepository.Todos.Add(newTodo);
        }

        // api/Todo/Delete?id={id}
        [HttpDelete]
        public void Delete(int id)
        {
            //delete a Todo from the repository by the id
            Todo todo = TodoRepository.Todos.Select(t=>t).Where(t=>t.Id == id).FirstOrDefault();
            TodoRepository.Todos.Remove(todo);
        }
    }
}
