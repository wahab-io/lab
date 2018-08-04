using System;
using Xunit;

namespace Lab.Tests
{
    public class TeachingAssistantTest
    {
        [Fact]
        public void TeachingAssistant_WithId()
        {
            var ta = new TeachingAssistant(1);
            Assert.Equal(1, ta.Id);
            Assert.Null(ta.FirstName);
            Assert.Null(ta.LastName);
            Assert.Empty(ta.ClassTitles);
            Assert.Equal(Subject.None, ta.SubjectArea);
        }

        [Fact]
        public void TeachingAssistant_WithIdAndName()
        {
            var ta = new TeachingAssistant(1, "Wahab", "Syed");
            Assert.Equal(1, ta.Id);
            Assert.Equal("Wahab", ta.FirstName);
            Assert.Equal("Syed", ta.LastName);
            Assert.Empty(ta.ClassTitles);
            Assert.Equal(Subject.None, ta.SubjectArea);
        }

        [Fact]
        public void TeachingAssistant_SubjectArea()
        {
            var ta = new TeachingAssistant(1, "Wahab", "Syed");
            Assert.Throws<ArgumentException>(()=> 
            {
                ta.SubjectArea = Subject.None;
            });
            ta.SubjectArea = Subject.History;
            Assert.Equal(Subject.History, ta.SubjectArea);
        }

        [Fact]
        public void TeachingAssistant_ClassTitles()
        {
            var ta = new TeachingAssistant(1, "Wahab", "Syed");
            Assert.Throws<ArgumentNullException>(() => 
            {
                ta.AddTitle(string.Empty);
            });

            ta.AddTitle("101 - Introduction to Programming");
            Assert.NotEmpty(ta.ClassTitles);
            Assert.Contains("101 - Introduction to Programming", ta.ClassTitles);
            
            ta.AddTitle("201 - Introduction to Databases");
            Assert.Contains("101 - Introduction to Programming", ta.ClassTitles);            
            
            Assert.Throws<InvalidOperationException>(()=>
            {
                ta.AddTitle("301 - Introduction to Data Structures");
            });            
        }

        [Fact]
        public void TeachingAssistant_RemoveTitle()
        {
            var ta = new TeachingAssistant(1, "Wahab", "Syed");
            ta.AddTitle("101 - Introduction to Programming");
            Assert.Throws<ArgumentNullException>(() =>
            {
                ta.RemoveTitle(string.Empty);
            });
            ta.RemoveTitle("101 - Introduction to Programming");
            Assert.Empty(ta.ClassTitles);

            Assert.Throws<InvalidOperationException>(() =>
            {
                ta.RemoveTitle("101 - Introduction to Programming");
            });
        }
    }
}