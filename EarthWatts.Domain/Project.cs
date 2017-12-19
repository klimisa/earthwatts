using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthWatts.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
