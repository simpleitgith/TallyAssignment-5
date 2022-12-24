using Microsoft.EntityFrameworkCore;
using TallyAssignment_4.Models;

namespace TallyAssignment_4.Repositery
{

    public class SubjectReposetory : ISubjectReposetory
    {
        private readonly StudentDbContext _dbContext;
        public SubjectReposetory(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Subject AddSubject(Subject subject)
        {
            var result = _dbContext.subjects.Add(subject);
            _dbContext.SaveChanges();
            return result.Entity;

            
        }

        public bool DeleteSubject(int id)
        {
            var filtredData = _dbContext.subjects.FirstOrDefault(s => s.SubjectId == id);
            if (filtredData != null)
            {
                var result = _dbContext.Remove(filtredData);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Subject GetSubjectById(int id)
        {
            return _dbContext.subjects.Where(s => s.SubjectId == id).FirstOrDefault();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _dbContext.subjects.ToList();
        }

        public Subject UpdateSubject(Subject subject)
        {
            var result = _dbContext.subjects.Update(subject);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
