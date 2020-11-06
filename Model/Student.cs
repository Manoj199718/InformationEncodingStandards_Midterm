using Assignment3.Model.Utilities;
using System;
using Assignment3.Model;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic;

namespace Assignment3.Model
{
    public class Student
    {
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string _DateOfBirthString;
        public string DateOfBirthString
        {
            get
            {
                return _DateOfBirthString;

            }
            set
            {
                _DateOfBirthString = value;
                DateTime datetime;
                if (DateTime.TryParse(_DateOfBirthString, out datetime) == true)
                {
                    DateofBirth = datetime;
                }
            }
        }
        private string _DateOfBirth;
        private string age;

        /// <summary>
        /// DateOfBirth stored in local DateTime format (see culture setting i.e. 12/31/2020 is Month/Day/Year)
        /// </summary>
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value;

                //Convert DateOfBirth to DateTime
                DateTime dtOut;
                DateTime.TryParse(_DateOfBirth, out dtOut);
                DateOfBirthDT = dtOut;
            }
        }
        public string ImageData { get; set; }



        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }


        public DateTime DateOfBirthDT { get; internal set; }
        public DateTime DateofBirth { get; set; }





        //public void FromDirectory(string direct)
        //{
        //    string[] directoryPart = direct.Split(" ", StringSplitOptions.None);
        //    StudentCode = directoryPart[0];
        //    FirstName = directoryPart[1];
        //    LastName = directoryPart[2];

        //}
        public string BCode { get; set; }
        public string BFname { get; set; }
        public string LFname { get; set; }
        public string BaseDate { get; set; }
        public string Bimage { get; set; }

        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);         //Converts the data(full name) into sequence of bytes.

            return Convert.ToBase64String(bytearray);                 //Converts the bytes to Base64 and returns the data.
        }



        public void FromCsv(string csvDataLine)
        {
            string[] CsvDataLineParts = csvDataLine.Split(",", StringSplitOptions.None);
            StudentCode = CsvDataLineParts[0].TrimStart();
            BCode = Student.StringToBase64(StudentCode);
            FirstName = CsvDataLineParts[1];
            BFname = Student.StringToBase64(FirstName);
            LastName = CsvDataLineParts[2];
            LFname = Student.StringToBase64(LastName);
            DateOfBirthString = CsvDataLineParts[3];
            BaseDate = Student.StringToBase64(DateOfBirthString);
            ImageData = CsvDataLineParts[4];
            Bimage = Student.StringToBase64(ImageData);




            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "200467080.dat"), true))
            {

                outputFile.WriteLine(BCode + "," + BFname + "," + LFname + "," + BaseDate + "," + Bimage);

            }


            string localUploadFilePath = @"C:\Users\Owner\Desktop\200467080.dat";
            string remoteUploadFileDestination = " /200467080 Manoj Gottumukkala/200467080.dat";

            Console.WriteLine(FTP.UploadFile(localUploadFilePath, Constants.FTP.BaseUrl + remoteUploadFileDestination));










        }

       
        public override string ToString()
        {
            return $"{BCode},{BFname},{LFname},{BaseDate}";

        }


        public string ToCSV()
        {
            string result = $"{BCode},{BFname},{LFname},{DateOfBirthString}";
            return result;
        }





    }



}
