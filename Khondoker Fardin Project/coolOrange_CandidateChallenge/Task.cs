using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coolOrange_CandidateChallenge
{
    public class Task : IPriority, IComplexity
    {
        string Name;
        string Priority;
        int Complexity;

        public Task(string name, string priority, int complexity)
        {
            Name = name;
            Priority = priority;
            Complexity = complexity;
        }

        void IPriority.SetPriority()
        {
            Priority = "asdf";
        }
    }
}
