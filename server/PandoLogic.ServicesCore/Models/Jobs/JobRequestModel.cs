using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoLogic.ServicesCore.Models.Jobs
{
    public class JobRequestModel
    {
        public int JobId { get; set; }
        public int JobTitleId { get; set; }
        public int CategoryId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? DescriptionLength { get; set; }
        public int? EducationLevel { get; set; }
        public int Clicks { get; set; }
        public int Applicants { get; set; }
    }
}