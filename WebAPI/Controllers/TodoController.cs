﻿using System;
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
        // returns list depending on the ordering passed in, if none passed in, it will return ordered by the id
        public List<Todo> Get(string orderBy = "")
        {
            if (orderBy == "desc")
            {
                return TodoRepository.Todos.OrderByDescending(t => t.Id).ToList(); // returns list of Todos ordered descending by the id
            }
            else if (orderBy == "asc")
            {
                return TodoRepository.Todos.OrderBy(t => t.Id).ToList(); // returns list of Todos ordered descending by the id
            }
            else if (orderBy == "complete")
            {
                return TodoRepository.Todos.OrderBy(t => t.Id).Where(t => t.Complete == true).ToList(); // returns list of Todos ordered by complete as true
            }
            else if (orderBy == "uncomplete")
            {
                return TodoRepository.Todos.OrderBy(t => t.Id).Where(t => t.Complete == false).ToList(); // returns list of Todos ordered by complete as false
            }

            return TodoRepository.Todos.OrderBy(t => t.Id).ToList(); // returns list of Todos ordered by the id
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
            int nextId = TodoRepository.Todos.Count() + 1;
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
