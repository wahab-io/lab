using System;
using System.Collections.Generic;

namespace Lab
{
    public interface ITeach
    {
        Subject SubjectArea { get; set; }
        IEnumerable<string> ClassTitles { get; }
        void AddTitle(string newTitle);
        void RemoveTitle(string aTitle);
    }
}