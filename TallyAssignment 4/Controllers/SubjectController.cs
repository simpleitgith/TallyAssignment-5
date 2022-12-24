using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TallyAssignment_4.Models;
using TallyAssignment_4.Repositery;

namespace TallyAssignment_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectReposetory _repositoty;

        public SubjectController(ISubjectReposetory repository)
        {
            _repositoty = repository;
        }

        [HttpGet]
        public IEnumerable<Subject> GetSubjects()
        {
            return  _repositoty.GetSubjects();

        }
        [HttpGet("{id}")]
        public Subject GetSubjectById(int id)
        {
            return _repositoty.GetSubjectById(id);

        }

        [HttpPost]
        public Subject AddSubject(Subject subject)
        {
           return _repositoty.AddSubject(subject);
        }

        [HttpPut("{id}")]
        public Subject UpdateById(Subject subject)
        {
            return _repositoty.UpdateSubject(subject);
        }

        [HttpDelete("{id}")]
        public bool DeleteById(int id)
        {
           
               return _repositoty.DeleteSubject(id);
           
        }
         

    }

}
