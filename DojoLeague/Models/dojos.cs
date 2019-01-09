using System;
using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class dojos
    {
        public int id{get;set;}
        public string name{get;set;}
        public string location{get;set;}
        public string description{get;set;}
        public IEnumerable<ninjas> ninjas { get; set; }
        public dojos() {
            ninjas = new List<ninjas>();
        }
    }
}