using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Students>>(students));

        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //Fetch single student details
            var student = await studentRepository.GetStudentAsync(studentId);

            //return student
            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Students>(student));
        }
    }
}
