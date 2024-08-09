using Data.Entities.PayCheck;
using General.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PaycheckController : BaseApiController
    {
        private readonly IPayCheckService _payCheckService;

        public PaycheckController(IPayCheckService payCheckService)
        {
            _payCheckService = payCheckService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Process the CSV file
            await NewMethod(file);

            return Ok("File processed successfully.");
        }

        private async Task NewMethod(IFormFile file)
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var csvContent = await stream.ReadToEndAsync();
                var csvLines = csvContent.Split(Environment.NewLine);
                var result = new List<PayCheckRecord>();



                // Omitir la primera línea que contiene los encabezados
                bool isFirstLine = true;


                foreach (var line in csvLines)
                {

                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }


                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var values = line.Split(',');
                        var data = new PayCheckRecord()
                        {
                            Date = DateTime.Parse(values[0]),          // Mapea la primera columna (DATE)
                            Name = values[1],                          // Map the second column (NAME)
                            Page = values[2],                          // Map the third column (PAGE)
                            Day1 = values[3],                          // Map the first day (DAY1)
                            Day2 = values[4],                          // Map the second day (DAY2)
                            Day3 = values[5],                          // Map the third day (DAY3)
                            Day4 = values[6],                          // Map the fourth day (DAY4)
                            Day5 = values[7],                          // Map the fifth day (DAY5)
                            Day6 = values[8],                          // Map the sixth day (DAY6)
                            Day7 = values[9],                          // Map the seventh day (DAY7)
                            TotalHours = values[10],                   // Map the total hours (TOTAL HR)
                            Money = values[11],                        // Map the money (MONEY)
                            Wk1Regular = values[12],                   // Map week 1 regular (WK1R)
                            Wk1Overtime = values[13],                  // Map week 1 overtime (WK1O)
                            Wk2Regular = values[14],                   // Map week 2 regular (WK2R)
                            Wk2Overtime = values[15],                  // Map week 2 overtime (WK2O)
                            Rate = values[16],                         // Map the rate (RATE)
                            RegularPay = values[17],                   // Map the regular pay (REG)
                            OverTime = values[18],                     // Map the overtime pay (OT)
                            TotalPay = values[19],                     // Map the total pay (TOTAL)
                            Discount = values[20],                     // Map the discount (DISC)
                            Miscellaneous = values[21],                // Map miscellaneous (MISCELLANEOUS)
                            Memo = values[22],                         // Map the memo (MEMO)
                            City = values[23],                         // Map the city (CITY)
                            State = values[24],                        // Map the state (ST)
                            Address1 = values[25],                     // Map address 1 (ADDRESS 1)
                            Address2 = values[26],                     // Map address 2 (ADDRESS 2)
                            ZipCode = values[27],                         // Mapea el código postal (ZIP)
                        };
                        result.Add(data);
                    }
                }

                await _payCheckService.InsertPayCheckRecordsAsync(result, file.FileName, new Guid("7E6A3E4A-C764-464D-9F1B-08DCB41D9254"));


                // Do something with the result, e.g., save to database
            }
        }
    }
}
