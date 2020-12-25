using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoLogic.ServicesCore.Models.JobTitles
{
    public class JobTitleResponseModel
    {
        public int JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public int CategoryId { get; set; }
    }
}