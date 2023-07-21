using Excallibur.Domain.Common;

namespace Excallibur.Domain.Entites
{
    public class Device : AuditableEntity
    {
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DeviceVersion { get; set; }
        public string TesterId { get; set; }
        public Tester Tester { get; set; }

    }
}
