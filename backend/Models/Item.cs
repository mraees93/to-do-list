using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Item
    {
        public int ItemId {get; set;}
        public string Name {get; set;} = null!;
        public string? Description {get; set;}
        public int Priority {get; set;}
    }
}