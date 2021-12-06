using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz3_1A1B
{
    class Job
    {

        public Job(int id, string description, int min, int max)
        {
            this.Id = id;
            this.Description = description;
            this.MinLevel = min;
            this.MaxLevel = max;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }

        public override string ToString()
        {
            return this.Id + " " + this.Description + " " + this.MinLevel + " " + this.MaxLevel;
        }
    }
}
