using System;
using System.Collections.Generic;

namespace Schedule.Models.Models
{
    public partial class MigrationLog
    {
        public Guid MigrationId { get; set; }
        public DateTime CompleteDt { get; set; }
        public string ScriptChecksum { get; set; }
        public string AppliedBy { get; set; }
        public byte Deployed { get; set; }
        public string PackageVersion { get; set; }
        public string ReleaseVersion { get; set; }
        public string ScriptFilename { get; set; }
        public int SequenceNo { get; set; }
        public string Version { get; set; }
    }
}
