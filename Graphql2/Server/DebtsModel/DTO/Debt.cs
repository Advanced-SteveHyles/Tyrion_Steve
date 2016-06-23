using System;

namespace DebtsModel.DTO
{
    public class Debt
    {
        public double? OriginalDebt { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime? DateOfService { get; set; }
        public double? TotalCosts { get; set; }
        public double? Interest { get; set; }
        public double? Disbursements { get; set; }
        public double? PaidToDate { get; set; }
        public double? CurrentBalance { get; set; }
    }
}