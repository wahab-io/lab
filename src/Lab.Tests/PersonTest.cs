using System;
using Xunit;

namespace Lab.Tests
{
    internal class PersonDerived : Person
    {
        internal PersonDerived(long id) : base(id)
        {

        }

        internal PersonDerived(long id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {
            
        }
    }

    public class PersonTest
    {
        [Fact]
        public void PersonCreatedWithInvalidId()
        {
            Assert.Throws<ArgumentException>((() => {
                    var person = new PersonDerived(-1);
            }));
        }

        [Fact]
        public void PersonCreatedWithDefaultId()
        {
            Assert.Throws<ArgumentException>(() => {
                var person = new PersonDerived(default(long));
            });
        }

        [Fact]
        public void PersonCreatedWithId1()
        {
            var person = new PersonDerived(1);
            Assert.Equal(1, person.Id);
        }

        [Fact] 
        public void PersonCreatedWithIdAndName()
        {
            var person = new PersonDerived(1, "wahab", "syed");
            Assert.Equal(1, person.Id);
            Assert.Equal("wahab", person.FirstName);
            Assert.Equal("syed", person.LastName);
        }

        [Fact]
        public void PersonCreatedWithInvalidId2()
        {    
            Assert.Throws<ArgumentException>(() => {
                var person = new PersonDerived(-1, "wahab", "syed");
            });
        }

        [Fact]
        public void PersonCreatedWithDefaultId2()
        {    
            Assert.Throws<ArgumentException>(() => {
                var person = new PersonDerived(default(long), "wahab", "syed");
            });
        }

        [Fact]
        public void PersonCreatedWithInvalidFirstName()
        {    
            Assert.Throws<ArgumentNullException>(() => {
                var person = new PersonDerived(1, "", "syed");
            });
        }

        [Fact]
        public void PersonCreatedWithInvalidLastName()
        {    
            Assert.Throws<ArgumentNullException>(() => {
                var person = new PersonDerived(1, "wahab", "");
            });
        }

        [Fact]
        public void PersonTest_FirstNameEmpty()
        {
            var person = new PersonDerived(1);
            Assert.Throws<ArgumentNullException>(() => {
                person.FirstName = "";
            });
        }

        [Fact]
        public void PersonTest_LastNameEmpty()
        {
            var person = new PersonDerived(1);
            Assert.Throws<ArgumentNullException>(() => {
                person.LastName = "";
            });
        }

        [Fact]
        public void PersonTest_FirstNameCorrect()
        {
            var person = new PersonDerived(1, "wahab", "syed");
            person.FirstName = "Daniel";
            Assert.Equal("Daniel", person.FirstName);
        }

        [Fact]
        public void PersonTest_LastNameCorrect()
        {
            var person = new PersonDerived(1, "wahab", "syed");
            person.LastName = "Brown";
            Assert.Equal("Brown", person.LastName);
        }

        [Fact]
        public void PersonTest_FullName()
        {
            var person = new PersonDerived(1, "wahab", "syed");
            Assert.Equal("wahab syed", person.FullName);
        }
    }
}