using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.dto.request
{
    public class CreatedUserDTO
    {
        public string name { get; set; }
        public string job { get; set; }
        public long id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
