using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int count { get; set; }

        public override string ToString()
        {
            return $"ID){Id}\t|NAME){name}\t|COUNT){count}\n";
        }
    }
}