namespace Data.Entities.PayCheck
{
    public class PayCheckRecord
    {
        public Guid PayCheckRecordId { get; set; }
        public Guid BatchPaycheckId { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public string? Day1 { get; set; }
        public string? Day2 { get; set; }
        public string? Day3 { get; set; }
        public string? Day4 { get; set; }
        public string? Day5 { get; set; }
        public string? Day6 { get; set; }
        public string? Day7 { get; set; }
        public string? TotalHours { get; set; }
        public string? Money { get; set; }
        public string? Wk1Regular { get; set; }
        public string? Wk1Overtime { get; set; }
        public string? Wk2Regular { get; set; }
        public string? Wk2Overtime { get; set; }
        public string? Rate { get; set; }
        public string? RegularPay { get; set; }
        public string? OverTime { get; set; }
        public string? TotalPay { get; set; }
        public string? Discount { get; set; }
        public string? Miscellaneous { get; set; }
        public string? Memo { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? ZipCode { get; set; }
    }
}
