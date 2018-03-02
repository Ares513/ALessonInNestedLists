using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALessonInNestedLists
{
    /// <summary>
    /// Many to one relationship with Actor
    /// </summary>
    public class Role
    {
        public string RoleName { get; private set; }
        public string Description { get; private set; }
        public List<DateTime> Appearances { get;  set; }

        public Role(string roleName, string description)
        {
            Appearances = new List<DateTime>();
            RoleName = RoleName;
            Description = description;
        }
    }
}
