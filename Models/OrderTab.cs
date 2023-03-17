using System;
using System.Collections.Generic;
using System.Text;

namespace Такси.Models
{
    public class OrderTab
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }

        public string ToWhere { get; set; }

    }
}
