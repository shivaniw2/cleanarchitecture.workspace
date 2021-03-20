using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Application.Workspace.Model
{
    public class WorkspaceDto: Domain.Common.BaseEntity
    {
        public WorkspaceDto()
        {
            Attributes = new List<string>();
        }
        public string  PK { get; set; }
        public string WorkspaceName { get; set; }
        public string Location { get; set; }
        public List<string> Attributes { get; private set; }
        public string WorkspaceType { get; set; }
        public string Status { get; set; }
    }
}
