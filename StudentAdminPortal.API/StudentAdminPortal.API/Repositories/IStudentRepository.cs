﻿using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Students>> GetStudentsAsync();
        Task<Students> GetStudentAsync(Guid studentId);

    }
}
