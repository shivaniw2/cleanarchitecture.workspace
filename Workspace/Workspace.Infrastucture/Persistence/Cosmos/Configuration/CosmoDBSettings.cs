using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Infrastucture.Persistence.Cosmos.Configuration
{
    public class CosmoDBSettings
    {
        public string EndPointUrl { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseName { get; set; }
        public List<ContainerInfo> Containers { get; set; }
    }
    public class ContainerInfo
    {
        public string Name { get; set; }
        public string PartitionKey { get; set; }
    }
}
