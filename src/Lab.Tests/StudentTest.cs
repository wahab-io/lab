using System;
using Xunit;

namespace Lab.Tests
{
    public class StudentTest
    {
        [Fact]
        public void StudentGPAEqual0()
        {
            var student = new Student(1, "wahab", "syed");
            Assert.Equal(0F, student.GPA);
        }

        [Fact]
        public void StudentGPAEqual3_4()
        {
            var student = new Student(1, "wahab", "syed");
            student.AddGrade(75);
            student.AddGrade(85);
            student.AddGrade(95);
            Assert.Equal(3.4F, student.GPA);
        }

        [Fact]
        public void StudentTest_InvalidGradeInput()
        {
            var student = new Student(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                student.AddGrade(-1);
            });
        }

        [Fact]
        public void StudentToString()
        {
            var student = new Student(1, "wahab", "syed");
            Assert.Equal("1 : wahab syed : 0.0", student.ToString());
        }
    }
}