using System;
using System.Collections.Generic;

namespace Framework.Configuration.EF
{
    public partial class Configurations
    {
        public int Id { get; set; }
        public int? BlockId { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        public virtual Blocks Block { get; set; }
    }
}
