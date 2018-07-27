using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab
{
    public sealed class Student : Person
    {
        private List<int> _grades;

        public Student(long id) : base(id)
        {
            _grades = new List<int>();
        }

        public Student(long id, string firstName, string lastName) : base(id, firstName, lastName)
        {            
            _grades = new List<int>();
        }

        public float GPA
        {
            get 
            {
                if (_grades.Count == 0)
                    return 0F;
                
                float sum = 0, total = 100 * _grades.Count;
                foreach (var grade in _grades)
                {
                    sum += grade;
                }
                return sum / total * 4;
            }
        }

        public void AddGrade(int grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade));
            _grades.Add(grade);
        }

        public override string ToString()
        {
            return $"{this.Id} : {this.FirstName} {this.LastName} : {GPA:0.0#}";
        }

    }
}