using System;
using System.Collections.Generic;
using System.Text;

namespace Transversal.Models
{
    public class MessageModel
    {
        public int id { get; set; }

        public string producer { get; set; }

        public string consumer { get; set; }

        public string message { get; set; }

        public string date { get; set; }
    }
}
