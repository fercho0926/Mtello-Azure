namespace General.Models.PayCheck
{
    public class CsvRecord
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public double? Day1 { get; set; }
        public double? Day2 { get; set; }
        public double? Day3 { get; set; }
        public double? Day4 { get; set; }
        public double? Day5 { get; set; }
        public double? Day6 { get; set; }
        public double? Day7 { get; set; }
        public double? TotalHr { get; set; }
        public decimal? Money { get; set; }
        public string Wk1R { get; set; }
        public string Wk1O { get; set; }
        public string Wk2R { get; set; }
        public string Wk2O { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Reg { get; set; }
        public decimal? Ot { get; set; }
        public decimal? Total { get; set; }
        public string Disc { get; set; }
        public string Miscellaneous { get; set; }
        public string Memo { get; set; }
        public string City { get; set; }
        public string St { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }

    }
}
