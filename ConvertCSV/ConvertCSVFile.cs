using Symptomfinder.Data;
using Symptomfinder.Models;
using System;
using System.Collections.Generic;
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
            Regex pattern = new Regex("[[{}\"\': ]");
            var Data = File.ReadAllLines(@"C:\Users\Mohammed Ali Davami\source\repos\Symptomfinder\CSV\df_diseases.csv")
                        .Skip(1)
                        .Select(column => column.Split(','))
                        .Select(column => new Symptome
                        {
                            Name = column[1],
                            Symptoms = pattern.Replace(column[3], " "),
                            Causes = pattern.Replace(column[4], " "),
                            Treatment = pattern.Replace(column[7], " "),
                        });

            return Data;
        }


        private static IEnumerable<Symptome> ReadfromCSV2File()
        {
            Regex pattern = new Regex("[[{}\": ]");
            var Data = File.ReadAllLines(@"C:\Users\Mohammed Ali Davami\source\repos\Symptomfinder\CSV\disease and symptoms.csv")
                        .Skip(1)
                        .Select(column => column.Split(','))
                        .Select(column => new Symptome
                        {
                            
                            Name = column[1],
                            Symptoms = pattern.Replace(column[2], " ").Substring(11) + 
                            ","+ pattern.Replace(column[4], " ").Substring(10) +
                            "," + pattern.Replace(column[6], " ").Substring(10) +
                            "," + pattern.Replace(column[8], " ").Substring(10),
                            Causes = string.Empty,
                            Treatment = string.Empty,
                        });

            return Data;
        }

        private static IEnumerable<Symptome> ReadfromCSV3File()
        {
            Regex pattern = new Regex("[[{}\"\': ]");
           
            var Data = File.ReadAllLines(@"C:\Users\Mohammed Ali Davami\source\repos\Symptomfinder\CSV\OHAS Dataset.csv")
                        .Skip(1)
                        .Select(column => column.Split(','))
                        .Select(column => new Symptome
                        {
                            Name = column[0],
                            Symptoms = pattern.Replace(column[2], " "),
                            Causes = "",
                            Treatment = "",
                        });

           var DataList = new List<Symptome>();
           DataList = Data.ToList();

            for(int i = 0; i < DataList.Count; i++)
            {
                for (int j = 0; j < DataList.Count; j++)
                {
                    if (DataList[i].Name.Equals(DataList[j].Name))
                    {
                      DataList[i].Symptoms += ", " + DataList[j].Symptoms;
                      DataList.Remove(DataList[j]);



                    }
                }
            }
        

            return DataList;
        }

        public static IEnumerable<Symptome> ReadfromCSVFiles()
        {
            var CombineCSV1_2 = ReadfromCSV1File().Concat(ReadfromCSV2File());

            var ResultList = CombineCSV1_2.Concat(ReadfromCSV3File());

            var DataList = new List<Symptome>();
            DataList = ResultList.ToList();

            for (int i = 0; i < DataList.Count; i++)
            {
                for (int j = 0; j < DataList.Count; j++)
                {
                    if (DataList[i].Name.Equals(DataList[j].Name))
                    {
                        DataList[i].Symptoms += DataList[j].Symptoms ;
                        DataList.Remove(DataList[j]);



                    }
                }
            }
            return DataList;
        }
    }
}
