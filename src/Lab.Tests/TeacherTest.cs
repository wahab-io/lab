using System;
using Xunit;

namespace Lab.Tests
{
    public class TeacherTest
    {
        [Fact]
        public void Teacher_SingleParamConstructorTest()
        {
            var teacher = new Teacher(1);
            Assert.Equal(1, teacher.Id);
            Assert.Null(teacher.FirstName);
            Assert.Null(teacher.LastName);
            Assert.Equal(Subject.None, teacher.SubjectArea);
        }

        [Fact]
        public void Teacher_MultiParamConstructorTest()
        {
            var teacher = new Teacher(1, "John", "Doe");
            Assert.Equal(1, teacher.Id);
            Assert.Equal("John", teacher.FirstName);
            Assert.Equal("Doe", teacher.LastName);
            Assert.Equal(Subject.None, teacher.SubjectArea);
        }

        [Fact]
        public void Teacher_SetSubjectNoneTest()
        {
            var teacher = new Teacher(1, "John", "Doe");
            Assert.Throws<ArgumentException>(() => {
                teacher.SubjectArea = Subject.None;
            });            
        }

        [Fact]
        public void Teacher_AreaSetterTest()
        {
            var teacher = new Teacher(1, "John", "Doe");
            teacher.SubjectArea = Subject.Math;
            Assert.Equal(Subject.Math, teacher.SubjectArea);
        }

        [Fact]
        public void Teacher_AddEmptyTitleTest()
        {
            var teacher = new Teacher(1, "John", "Doe");
            Assert.Throws<ArgumentNullException>(()=> {
                teacher.AddTitle(string.Empty);
            });
        }

        [Fact]
        public void Teacher_EmptyTitles()
        {
            var teacher = new Teacher(1, "John", "Doe");
            Assert.Empty(teacher.ClassTitles);
        }

        [Fact]
        public void Teacher_AddTitleTest()
        {
            var teacher = new Teacher(1, "John", "Doe");
            teacher.AddTitle("101 - Introduction to Programming");

            Assert.NotEmpty(teacher.ClassTitles);
            Assert.Contains<string>("101 - Introduction to Programming", teacher.ClassTitles);
        }

        [Fact]
        public void Teacher_RemoveEmptyTitle()
        {
            var teacher = new Teacher(1, "John", "Doe");
            Assert.Throws<ArgumentNullException>(() => {
                teacher.RemoveTitle(string.Empty);
            });
        }

        [Fact]
        public void Teacher_RemoveTitleTest()
        {
            var teacher = new Teacher(1, "John", "Doe");
            teacher.AddTitle("101 - Introduction to Programming");
            Assert.NotEmpty(teacher.ClassTitles);
            Assert.Contains<string>("101 - Introduction to Programming", teacher.ClassTitles);
            
            teacher.RemoveTitle("101 - Introduction to Programming");
            Assert.DoesNotContain<string>("101 - Introduction to Programming", teacher.ClassTitles);
            Assert.Empty(teacher.ClassTitles);
        }

        [Fact]
        public void Teacher_RemoveInvalidTitle()
        {
            var teacher = new Teacher(1, "John", "Doe");
            teacher.AddTitle("101 - Introduction to Programming");
            Assert.Throws<InvalidOperationException>(() => {
                teacher.RemoveTitle("Something else");
            });
        }
    }
}