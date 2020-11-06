using System;
using Assignment3.Model.Utilities;
using Assignment3.Model;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> directories = FTP.GetDirectory(Constants.FTP.BaseUrl);
            List<Student> students = new List<Student>();
            var direct = "200467080 Manoj Gottumukkala";
            //List<Product> products = new List<Product>();
            //Product product = new Product();
            //product.Data();

            foreach (var directory in directories)
                
            {
                if (directory == direct)
                {
                    Student student = new Student();
                    string remoteDownloadFilePath = "/200467080 Manoj Gottumukkala/info.csv";
                    //Path to a valid folder and the new file to be saved
                    string localDownloadFileDestination = @"C:\Users\Owner\Desktop\info.csv";
                    Console.WriteLine(FTP.DownloadFile(Constants.FTP.BaseUrl + remoteDownloadFilePath, localDownloadFileDestination));
                    var fileBytes = FTP.DownloadFileBytes(Constants.FTP.BaseUrl + "/" + directory + "/info.csv");
                    //var fileBytes = FTP.DownloadFileBytes(@"C:\Users\Owner\Desktop\FTP files\info.csv");
                    string infoCsvData = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                    string[] lines = infoCsvData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    student.FromCsv(lines[1]);
                    Console.WriteLine(student);
                    students.Add(student);

                    //Byte[] bytes = File.ReadAllBytes(@"C:\Users\Owner\Desktop\FTP files\info.csv");
                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    //Console.WriteLine(base64String);
                    ////String file = Convert.ToBase64String(bytes);

                }
            }

                  


        }
    }

}
