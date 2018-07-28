using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab
{
    public sealed class Student : Person
    {
        private int _sumOfGrades;
        private int _totalClassesTaken;

        public Student(long id) : base(id)
        {
            _sumOfGrades = 0;
            _totalClassesTaken = 0;
        }

        public Student(long id, string firstName, string lastName) : base(id, firstName, lastName)
        {            
            _sumOfGrades = 0;
            _totalClassesTaken = 0;
        }

        public double? GPA
        {
            get 
            {
                if (_totalClassesTaken > 0)
                    return (double)_sumOfGrades / (double)_totalClassesTaken;
                return null;
            }
        }

        public void AddGrade(Grade letterGrade)
        {
            _sumOfGrades += (int)letterGrade;
            _totalClassesTaken++;
        }

        public override string ToString() => 
            $"{this.Id} : {this.FirstName} {this.LastName} : {this.GPA}";

    }
}