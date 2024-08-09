using Data;
using Data.Entities.PayCheck;
namespace General.Services
{
    public class PayCheckService : IPayCheckService
    {

        private readonly AppDbContext _appDbContext;

        public PayCheckService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task InsertPayCheckRecordsAsync(List<PayCheckRecord> records, string fileName, Guid companyId)
        {
            if (records == null || records.Count == 0)
            {
                throw new ArgumentException("No records to insert.");
            }


            //create Lote

            var batchPaycheck = new BatchPaycheck
            {
                FileName = fileName,
                CompanyId = companyId,
                CreatedDate = DateTime.Now,
                CreatedBy = "INGRESAR USUARIO ",
                RecordsByFile = 200,
                RecordsProcessed = 200,
                TotalHours = 350,
                TotalMoney = 1500,
                status = "OK",
            };

            await _appDbContext.BatchPaycheck.AddAsync(batchPaycheck);




            foreach (var record in records)
            {
                record.BatchPaycheckId = batchPaycheck.BatchPaycheckId;


            }


            // Add the list of records to the DbContext
            await _appDbContext.PayCheckRecords.AddRangeAsync(records);

            // Save changes to the database
            await _appDbContext.SaveChangesAsync();
        }

        private async Task<List<PayCheckRecord>> CleanRecords(List<PayCheckRecord> records)
        {


            foreach (var record in records)
            {
                //record.Money = CleanMonetaryValue(record.Money);
                record.Wk1Regular = CleanMonetaryValue(record.Wk1Regular);
                record.Wk1Overtime = CleanMonetaryValue(record.Wk1Overtime);
                record.Wk2Regular = CleanMonetaryValue(record.Wk2Regular);
                record.Wk2Overtime = CleanMonetaryValue(record.Wk2Overtime);
                //record.Rate = CleanMonetaryValue(record.Rate);
                record.RegularPay = CleanMonetaryValue(record.RegularPay);
                record.OverTime = CleanMonetaryValue(record.OverTime);
                //record.TotalPay = CleanMonetaryValue(record.TotalPay);
                record.Discount = CleanMonetaryValue(record.Discount);
                record.Miscellaneous = CleanMonetaryValue(record.Miscellaneous);
            }

            return records;
        }

        private string CleanMonetaryValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return value.Replace("$", "").Replace(" ", "");
        }

    }
}
