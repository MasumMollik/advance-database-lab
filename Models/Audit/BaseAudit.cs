using System;

namespace PerformanceCalculator.Models.Audit
{
    public class BaseAudit
    {
        public Guid Id { get; set; }
        public string AuditData { get; set; }
    }
}