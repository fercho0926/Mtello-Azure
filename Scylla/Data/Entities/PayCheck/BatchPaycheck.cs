namespace Data.Entities.PayCheck
{
    public class BatchPaycheck : BaseAuditCode
    {
        public Guid BatchPaycheckId { get; set; }

        public string? FileName { get; set; }

        public Guid CompanyId { get; set; }

        public Company.Company Company { get; set; }

        public int RecordsByFile { get; set; }
        public int RecordsProcessed { get; set; }

        public int TotalHours { get; set; }

        public int TotalMoney { get; set; }

        public IEnumerable<PayCheckRecord> PayCheckRecord { get; set; } = new List<PayCheckRecord>();

        public string status { get; set; } // cambiar a enum



    }
}
