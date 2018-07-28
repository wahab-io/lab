using System;
using Xunit;

namespace Lab.Tests
{
    public class StudentTest
    {
        [Fact]
        public void StudentGPANull()
        {
            var student = new Student(1, "wahab", "syed");            
            Assert.Null(student.GPA);
        }

        [Fact]
        public void StudentCreatedWithId()
        {
            var student = new Student(1);
            Assert.Equal(1, student.Id);
            Assert.Null(student.GPA);
        }

        [Fact]
        public void StudentGPAEqual3()
        {
            var student = new Student(1, "wahab", "syed");
            student.AddGrade(Grade.A);
            student.AddGrade(Grade.B);
            student.AddGrade(Grade.C);
            Assert.Equal(3, student.GPA);
        }

        [Fact]
        public void StudentToString()
        {
            var student = new Student(1, "wahab", "syed");
            student.AddGrade(Grade.A);
            Assert.Equal("1 : wahab syed : 4", student.ToString());
        }
    }
}