using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALessonInNestedLists
{
    /// <summary>
    /// Actor has a one to many relationship to Role
    /// </summary>
    class Actor
    {
        public string Name { get; private set; }
        public List<Role> Roles { get; set; }

        public Actor(string name)
        {
            Roles = new List<Role>();
            Name = name;
        }
    }
}
