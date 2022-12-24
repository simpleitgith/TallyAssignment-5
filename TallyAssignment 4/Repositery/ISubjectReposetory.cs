using TallyAssignment_4.Models;

namespace TallyAssignment_4.Repositery
{
    public interface ISubjectReposetory
    {
        public IEnumerable<Subject> GetSubjects();
        public Subject GetSubjectById(int id);
        public Subject AddSubject(Subject subject);
        public Subject UpdateSubject(Subject subject);
        public bool DeleteSubject(int id);
    }
}
