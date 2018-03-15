using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboarding.Models
{
    [Nest.ElasticsearchType(Name = "items")]
    public class Items
    {
        public int ID { get; set; }
        public string Description { get; set; }

    }
}
