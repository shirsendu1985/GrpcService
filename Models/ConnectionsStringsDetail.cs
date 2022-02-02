using System;
using System.Collections.Generic;

namespace GrpcService.Models
{
    public partial class ConnectionsStringsDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EnvironmentId { get; set; }
        public string ApplicationCode { get; set; }
        public string KeyCode { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDateUtc { get; set; }
    }
}
