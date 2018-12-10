using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
 
 public class ProjectList
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}