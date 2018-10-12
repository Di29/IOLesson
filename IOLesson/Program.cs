using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/new folder/Dias/file.txt";
            //Directory.CreateDirectory(path);
            //DirectoryInfo directory = new DirectoryInfo(path);
            //var iinerDirectories = directory.GetDirectories();
            //foreach(var dir in iinerDirectories)
            //{
            //    Console.WriteLine(dir.FullName);
            //}

            //File.Create($"{path}/file.txt");

            //var drives = DriveInfo.GetDrives();
            //foreach(var drive in drives)
            //{
            //    Console.WriteLine(drive.Name);
            //}
            //FileStream fileStream = null;
            //try
            //{
            //    fileStream = new FileStream(path, FileMode.Append);
            //    fileStream.Close();
            //}
            //catch(FileNotFoundException exeption)
            //{
            //    Console.WriteLine(exeption.Message);
            //}
            //catch (IOException exeption)
            //{
            //    Console.WriteLine(exeption.Message);
            //}
            //finally
            //{
            //    fileStream.Close();
            //}

            //try
            //{
            //    using (FileStream stream = new FileStream(path, FileMode.Append))
            //    {
            //        string fileName = "blahblah.jpeg";
            //        byte[] fileInfo = Encoding.UTF8.GetBytes(fileName);
            //        stream.Write(fileInfo, 0, fileInfo.Length);
            //    }

            //    using (FileStream stream = new FileStream(path, FileMode.Open))
            //    {
            //        byte[] buffer = new byte[stream.Length];
            //        stream.Read(buffer, 0, (int)stream.Length);
            //        string result = Encoding.UTF8.GetString(buffer);
            //        Console.WriteLine(result);
            //    }
            //}
            //catch { /*....*/}

            string driveName = "";
            string DirPath1 = @"data/docs/";
            string fileName = "file.txt";

            DriveInfo[] drives = DriveInfo.GetDrives();
            
            for(int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i}.{drives[i].Name}");
            }
            Console.WriteLine("Input number of the drive where file will write:");
            string driveNumAsString = Console.ReadLine();

            int driveNum = 0;
            if(!int.TryParse(driveNumAsString, out driveNum))
            {
                Console.WriteLine("Ошибка ввода, будет произведена запись на первый указанный диск.");
                
            }
            driveName = drives[driveNum].Name;

            if (!Directory.Exists(driveName + DirPath1))
            {
                Directory.CreateDirectory(driveName + DirPath1);
            }

            try
            {
                if(!File.Exists(driveName + DirPath1 + fileName))
                {
                    File.Create(driveName + DirPath1 + fileName);
                }
                using(StreamWriter streamWriter = new StreamWriter(driveName + DirPath1 + fileName))
                {
                    string text = "Я есть Грут";
                    streamWriter.WriteLine(text);
                }

                using (StreamReader streamReader = new StreamReader(driveName + DirPath1 + fileName))
                {
                    Console.WriteLine(streamReader.ReadToEnd()); 
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
}
