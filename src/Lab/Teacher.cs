using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab
{
    public sealed class Teacher : Person
    {
        private Subject _subjectArea;
        private IList<string> _classTitles;
        public Teacher(long id) : base(id)
        {
            _subjectArea = Subject.None;
            _classTitles = new List<string>();
        }

        public Teacher(long id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {
            _subjectArea = Subject.None;
            _classTitles = new List<string>();
        }

        public Subject SubjectArea
        {
            get { return _subjectArea; }
            set
            {
                if (value == Subject.None)
                    throw new ArgumentException("Must declare subject area");
                _subjectArea = value;
            }
        }

        public IEnumerable<string> ClassTitles
        {
            get { return _classTitles; }
        }

        public void AddTitle(string newTitle)
        {
            if (string.IsNullOrEmpty(newTitle))
                throw new ArgumentNullException(nameof(newTitle));
            
            if (!_classTitles.Contains(newTitle))
                _classTitles.Add(newTitle);
        }

        public void RemoveTitle(string aTitle)
        {
            if (string.IsNullOrEmpty(aTitle))
                throw new ArgumentNullException(nameof(aTitle));
            
            if (_classTitles.Contains(aTitle))
                _classTitles.Remove(aTitle);
            else throw new InvalidOperationException($"{aTitle} does not exist!");
        }
    }
}