﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandoLogic.Core;
using PandoLogic.Core.Entities;
using PandoLogic.ServicesCore.Models.JobTitles;

namespace PandoLogic.ServicesCore.Services
{
    public interface IJobsTitleService : IBaseService<JobTitle>
    {
        Task<IEnumerable<JobTitleResponseModel>> GetAllJobTitlesAsync();
    }
}