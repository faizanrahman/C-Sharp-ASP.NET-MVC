using System;
using System.Collections.Generic;
namespace DojoLeague.Models
{
    public class ninjas
    {
        public int id{get;set;}
        public string name{get;set;}
        public int level{get;set;}
        public string description{get;set;}
        public int dojos_id{get;set;}
        public dojos dojo {get;set;}
        
    }
}