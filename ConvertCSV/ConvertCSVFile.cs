using Microsoft.VisualBasic.FileIO;
using Symptomfinder.Data;
using Symptomfinder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Symptomfinder.ConvertCSV
{
    public class ConvertCSVFile
    {

        private static IEnumerable<Symptome> ReadfromCSV1File()
        {
           
            List<Symptome> Symptomes = new List<Symptome>();
            Regex pattern = new Regex("[^0-9a-zA-Z]+");
            int symptomenr = 0;
            var Data = File.ReadAllLines(@"C:\Users\Mohammed Ali Davami\source\repos\Symptomfinder\CSV\df_diseases.csv")
                        .Skip(1)
                        .Select(column => column.Split(','));
  
            foreach (String[] lines in Data)
            {
                Symptomes.Add(new Symptome
                {
                    Name = pattern.Replace(lines[1], " "),
                });
                foreach (string stringlines in lines[3..])
                {
                    Symptomes[symptomenr].SymptomInformation += pattern.Replace(stringlines, " ");
                }
                symptomenr += 1;
            }
           
      
            return Symptomes;
        }


        private static IEnumerable<Symptome> ReadfromCSV2File()
        {

            List<Symptome> Symptomes = new List<Symptome>();
      
            int symptomenr = 0;
            Regex pattern1 = new Regex("[^0-9a-zA-Z]+");
            Regex pattern2 = new Regex(@"[\d-]");
            var Data = File.ReadAllLines(@"C:\Users\Mohammed Ali Davami\source\repos\Symptomfinder\CSV\disease and symptoms.csv")
                        .Skip(1)
                        .Select(column => column.Split(','));


     
            foreach (String[] lines in Data)
            {
                Symptomes.Add(new Symptome
                {
                    Name = pattern1.Replace(lines[1], " "),
                });
                foreach (string stringlines in lines[3..])
                {
                    var editedtext = pattern1.Replace(stringlines, " ").Replace("symptoms", " ");
                    Symptomes[symptomenr].SymptomInformation += pattern2.Replace(editedtext, " ");
                }
                symptomenr += 1;
            }


            return Symptomes;

        }

        private static IEnumerable<Symptome> ReadfromCSV3File()
        {
            Regex pattern = new Regex("[^0-9a-zA-Z]+");
           
            var Data = File.ReadAllLines(@"C:\Users\Mohammed Ali Davami\source\repos\Symptomfinder\CSV\OHAS Dataset.csv")
                        .Skip(1)
                        .Select(column => column.Split(','))
                        .Select(column => new Symptome
                        {
                            Name = column[0],
                            SymptomInformation = pattern.Replace(column[2], " "),
                        });

           var DataList = new List<Symptome>();
           DataList = Data.ToList();

            for(int i = 0; i < DataList.Count; i++)
            {
                for (int j = 0; j < DataList.Count; j++)
                {
                    if (DataList[i].Name.Equals(DataList[j].Name))
                    {
                      DataList[i].SymptomInformation += ", " +DataList[j].SymptomInformation;
                      DataList.Remove(DataList[j]);



                    }
                }
            }
        

            return DataList;
        }

        public static IEnumerable<Symptome> ReadfromCSVFiles()
        {
            var ResultList1 = ReadfromCSV1File().Concat(ReadfromCSV3File());

             var ResultList = ResultList1.Concat(ReadfromCSV2File());

            //var ResultList = ReadfromCSV3File();

            var DataList = ResultList.ToList();

            for (int i = 0; i < DataList.Count; i++)
            {
                for (int j = 0; j < DataList.Count; j++)
                {
                    if (DataList[i].Name.Equals(DataList[j].Name))
                    {
                        DataList[i].SymptomInformation += ", " + DataList[j].SymptomInformation;
                        DataList.Remove(DataList[j]);



                    }
                }
            }
            return DataList;
        }
    }
}
