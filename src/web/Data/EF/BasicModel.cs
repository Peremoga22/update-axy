using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class BasicModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsImported { get; set; }
        public bool NeedToReimport { get; set; }
        public DateTime ImportDate { get; set; }
    }
}
