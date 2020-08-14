using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        //Data List ToDo ID For identity, Stat For Marking Scheadule
        List<ToDoList> ListToDo = new List<ToDoList>()
        {
            new ToDoList(){ID = 1, name = "Project K", DueDate = new DateTime(2020, 3, 15), descrip = "Make user INterface for Project K", Prog = 40, stat= true},
            new ToDoList(){ ID = 2, name = "Project AAA",DueDate = new DateTime(2020, 7, 25), descrip="AAA", Prog = 40,stat= false },
            new ToDoList(){ ID = 3, name = "Project C", DueDate = new DateTime(2020, 6, 1), descrip = "Test", Prog = 40,stat= true },
            new ToDoList(){ ID = 4, name = "Project F", DueDate = new DateTime(2020, 8, 21), descrip = "Test", Prog = 40,stat= false },
             new ToDoList(){ID = 5, name = "Project AQ", DueDate = new DateTime(2020, 8, 5), descrip = "Test", Prog = 40,stat= true},
             new ToDoList(){ID = 6, name = "Project 44", DueDate = new DateTime(2020, 9, 28), descrip = "Test", Prog = 40,stat= false },
        };
        //Get All Data Search by ID
        [HttpGet]
        public IActionResult get()
        {
           if(ListToDo.Count == 0)
            {
                return NotFound("No List Found"); //IF System not Found the Data that match with request

            }
            return Ok(ListToDo);
        }
        //Get Spesific Data From listItem Search by ID
        [HttpGet("GetToDo")]
        public IActionResult Get(int ID)
        {
            var SpecToDo = ListToDo.SingleOrDefault(x => x.ID == ID);
            if(ListToDo == null)
            {
                return NotFound("No List Found"); //IF System not Found the Data that match with request

            }
            return Ok(SpecToDo);
        
        }
        //Save New Shecadule or Save Edited Scheadule
        [HttpPost]
        public IActionResult Save(ToDoList SaveToDo)
        {
            ListToDo.Add(SaveToDo);
            if (ListToDo.Count == 0)
            {
                return NotFound("No Scheadule Found"); //IF System not Found the Data that match with request

            }
            return Ok(ListToDo);

        }

        //Delete all info Shecadule 
        [HttpDelete]
        public IActionResult DeleteToDo(int ID)
        {
            var DeleteToDo = ListToDo.SingleOrDefault(x => x.ID == ID);
            if (ListToDo == null)
            {
                return NotFound("Scheadule Not Found"); //IF System not Found the Data that match with request

            }
            ListToDo.Remove(DeleteToDo);
            if (ListToDo.Count == 0)
            {
                return NotFound("No Scheadule Found"); //IF System not Found the Data that match with request

            }
            return Ok(ListToDo);
        }

    }
}