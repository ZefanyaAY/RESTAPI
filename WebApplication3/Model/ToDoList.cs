using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Model
{
    public class ToDoList
    {
        public int ID { get; set; } = 0;
        public string name { get; set; } = "";
        public DateTime DueDate { get; set; }
        public string descrip { get; set; } = "";
        public int Prog { get; set; }
        public bool stat { get; set; }

    }
}
