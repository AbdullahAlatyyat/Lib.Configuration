using System;
using System.Collections.Generic;

namespace Framework.Configuration.EF
{
    public partial class Blocks
    {
        public Blocks()
        {
            Configurations = new HashSet<Configurations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Configurations> Configurations { get; set; }
    }
}
