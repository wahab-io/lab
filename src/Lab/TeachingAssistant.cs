using System;
using System.Collections.Generic;

namespace Lab
{
    public sealed class TeachingAssistant : Student, ITeach
    {
        private Subject _subjectArea;
        private IList<string> _classTitles;

        public TeachingAssistant(long id) : base(id)
        {
            _subjectArea = Subject.None;
            _classTitles = new List<string>();
        }

        public TeachingAssistant(long id, string firstName, string lastName) 
            : base(id, firstName, lastName)
        {
            _subjectArea = Subject.None;
            _classTitles = new List<string>();
        }

        public Subject SubjectArea 
        { 
            get => _subjectArea;
            set
            {
                if (value == Subject.None)
                    throw new ArgumentException("Must declare subject area");
                _subjectArea = value;
            }
        }

        public IEnumerable<string> ClassTitles => _classTitles;

        public void AddTitle(string newTitle)
        {
            if (string.IsNullOrEmpty(newTitle))
                throw new ArgumentNullException(nameof(newTitle));

            if (_classTitles.Count == 2)
                throw new InvalidOperationException("Teaching assistant is not allowed more that 2 titles");
            
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