using System;
using System.IO;
using System.Text;

namespace CSV_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var path = ".";

            string datum = DateTime.Now.ToString("yyyyMMddHHmmss");

            var fullPath = Path.GetFullPath(path);

            string[] files = Directory.GetFiles(fullPath, "*.csv", SearchOption.TopDirectoryOnly);

            string csvheader = $"Document_Category,Batch_ID,Delete,Worker_ID,Pay_Group,Period_End_Date,Payment_Date,Check_Number,Net_Amount,Currency,Display_Date,File_Name{Environment.NewLine}";

            //Document_Category	Batch_ID	Delete	Worker_ID	Pay_Group	Period_End_Date	Payment_Date	Check_Number	Gross_Amount	Net_Amount	Currency	Display_Date	File_Name



            var fileName = fullPath + "1315_Sage_Payslip_" + datum + ".csv";

            string storage = fullPath + "/Merged";

            if (!Directory.Exists(storage))
            {
                Directory.CreateDirectory(storage);
            }

            using (var output = File.Create(fullPath + "/Merged/1315_Sage_Payslip_" + datum + ".csv"))
            {
                StreamWriter sw = new StreamWriter(output);

                sw.WriteLine(csvheader);
                sw.Flush();

                foreach (var file in files)
                {

                    using (var data = File.OpenRead(file))
                    {
                        sw.WriteLine("");
                        sw.Flush();
                        data.CopyTo(output);
                        
                        Console.WriteLine("Daten erfolgreich kopiert!");
                        

                    }
                }
            }

            Console.ReadLine();
        }
    }
}
