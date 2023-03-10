using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Streets
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }

        public override string ToString()
        {
            return $"ID){id}\t|NAME){name}\t|COUNT){count}\n";
        }
    }
}