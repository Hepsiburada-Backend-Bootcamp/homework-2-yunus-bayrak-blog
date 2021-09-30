using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Domain.Entities
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string MainDetail { get; set; }
        public string Detail { get; set; }
        public string MainImagePath { get; set; }
        public string ImagePath { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }
    }
}
