using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallyAssignment_4.Controllers;
using TallyAssignment_4.Models;
using TallyAssignment_4.Repositery;

namespace XUnitSubjectTests
{
    public class SubjectControllerTests
    {
        private readonly Mock<ISubjectReposetory> mockSubject;
        public SubjectControllerTests()
        {
            mockSubject = new Mock<ISubjectReposetory>();
        }
        [Fact]
        public void GetSubjects_SubjectList()
        {
            //arrange
            var subjectList = GetSubjectsData();
            mockSubject.Setup(s => s.GetSubjects()).Returns(subjectList);
            var subjectController = new SubjectController(mockSubject.Object);

            //act
            var subjectResult = subjectController.GetSubjects();

            //assert
            Assert.NotNull(subjectResult);
            Assert.Equal(GetSubjectsData().Count(), subjectResult.Count());
            Assert.True(subjectList.Equals(subjectResult));
            Assert.Equal(GetSubjectsData().ToString(), subjectResult.ToString());
        }

        [Fact]
        public void GetSubjectById_ReturnSubject()
        {
            var subjectList = GetSubjectsData();
            mockSubject.Setup(s => s.GetSubjectById(2)).Returns(subjectList[1]);
            var subjectController = new SubjectController(mockSubject.Object);

            var subjectResult = subjectController.GetSubjectById(2);

            Assert.NotNull(subjectResult);
            Assert.Equal(subjectList[1].SubjectId, subjectResult.SubjectId);
            Assert.True(subjectList[1].SubjectId == subjectResult.SubjectId);
        }

        [Theory]
        [InlineData("Science")]
        public void CheckSubjectExistByPassingSubjectName_Subject(string subName)
        {
            var subjectList = GetSubjectsData();
            mockSubject.Setup(s => s.GetSubjects()).Returns(subjectList);
            var subjectController = new SubjectController(mockSubject.Object);

            var subjectResult = subjectController.GetSubjects();
            var expectedSubjectName = subjectResult.ToList()[1].SubjectName;

            Assert.Equal(subName, expectedSubjectName);
        }

        [Fact]
        public void CheckAddSubject_Subject()
        {
            var subjectList = GetSubjectsData();
            mockSubject.Setup(s => s.AddSubject(subjectList[1])).Returns(subjectList[1]);
            var subjectController = new SubjectController(mockSubject.Object);

            var subjectResult = subjectController.AddSubject(subjectList[1]);

            Assert.NotNull(subjectResult);
            Assert.Equal(subjectList[1].SubjectId, subjectResult.SubjectId);
            Assert.True(subjectList[1].SubjectId == subjectResult.SubjectId);
        }

        [Fact]
        public void CheckDeleteSubject_Subject()
        {
            mockSubject.Setup(s => s.DeleteSubject(1)).Returns(true);
            var subjectController = new SubjectController(mockSubject.Object);

            var subjectResult = subjectController.DeleteById(1);

            Assert.True(subjectResult);
        }

        private List<Subject> GetSubjectsData()
        {
            List<Subject> subjectsData = new List<Subject>()
            {
                new Subject()
                {
                    SubjectId = 1,
                    SubjectName = "Social",
                    MaxMarks = 100,
                    MarksObtained = 92,
                    StudentId = 1
                },
                new Subject()
                {
                    SubjectId = 2,
                    SubjectName = "Science",
                    MaxMarks = 100,
                    MarksObtained = 84,
                    StudentId = 1
                },
                new Subject()
                {
                    SubjectId = 3,
                    SubjectName = "Maths",
                    MaxMarks = 100,
                    MarksObtained = 78,
                    StudentId = 1
                },
            };
            return subjectsData;
        }
    }
}

