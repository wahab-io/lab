using System;

namespace Lab
{
    public abstract class Person
    {
        private long _id;
        private string _firstName;
        private string _lastName;
        protected Person(long id)
        {
            // Only positive values for id are allowed
            if (default(long) == id || id < default(long))
                throw new ArgumentException("Invalid value", nameof(id));
            _id = id;
        }

        protected Person(long id, string firstName, string lastName)
        {
            // Only positive values for id are allowed
            if (default(long) == id || id < default(long))
                throw new ArgumentException("Invalid value", nameof(id));
            _id = id;
            
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));
            _firstName = firstName;

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));
            _lastName = lastName;
        }

        public long Id 
        { 
            get { return _id; }
        }

        public string FirstName 
        { 
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                _lastName = value;
            }
        }
    }
}