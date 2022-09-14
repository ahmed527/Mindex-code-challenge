using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public Guid? Id { get; set; }
        public Employee? Employee { get; set; } = null;
        public double? Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
