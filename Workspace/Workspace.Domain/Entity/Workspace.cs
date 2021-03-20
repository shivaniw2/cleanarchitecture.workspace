using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Domain.Common;
using Workspace.Domain.Enum;

namespace Workspace.Domain.Entity
{
    public class Workspace : BaseEntity
    {
        public Workspace()
        {
            Attributes = new List<string>();
        }
        public string WorkspaceName { get; set; }
        public string Location { get; set; }
        public List<string> Attributes { get; private set; }
        public WorkspaceType WorkspaceType { get; set; }
        public string Status { get; set; }
    }
}
