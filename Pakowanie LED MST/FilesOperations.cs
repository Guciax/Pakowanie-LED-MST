using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    class FilesOperations
    {
        static string folderPath = "Files";
        //File struct
        // Date;serial

        public static Dictionary<string, LedsInCurrentBoxStruct> LoadBoxFromFile(string boxId)
        {
            Dictionary<string, LedsInCurrentBoxStruct> result = new Dictionary<string, LedsInCurrentBoxStruct>();
            DirectoryInfo dirNfo = new DirectoryInfo(folderPath);
            var files = dirNfo.GetFiles();
            var fileNamesList = files.Select(f => f.Name).ToList();
            if (fileNamesList.Contains(boxId))
            {
                var fileLines = File.ReadAllLines(Path.Combine(folderPath, boxId));
                foreach (var line in fileLines)
                {
                    string[] splittedLine = line.Split(';');
                    DateTime date = new DateTime();
                    if (!DateTime.TryParseExact(splittedLine[0], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out date)) continue;
                    string serial = splittedLine[1];
                    LedsInCurrentBoxStruct ledToAdd = new LedsInCurrentBoxStruct(date, serial, "", "BrakDanych", "BrakDanych");
                    if (!result.ContainsKey(serial))
                    {
                        result.Add(serial, ledToAdd);
                    }
                }
            }
            else
            {
                return null;
            }

            return result;
        }

        internal static bool CheckIfBoxExist(string boxId)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Dictionary<string, LedsInCurrentBoxStruct> result = new Dictionary<string, LedsInCurrentBoxStruct>();
            DirectoryInfo dirNfo = new DirectoryInfo(folderPath);
            var files = dirNfo.GetFiles();
            var fileNamesList = files.Select(f => f.Name).ToList();
            if (fileNamesList.Contains(boxId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SaveBoxFile(CurrentBox currentBox)
        {
            string filePath = Path.Combine(folderPath, currentBox.BoxId);
            List<string> fileLines = new List<string>();

            foreach (var pcb in currentBox.LedsInBox)
            {
                fileLines.Add(pcb.Value.Date.ToString("dd-MM-yyyy HH:mm:ss") + ";" + pcb.Value.Serial);
            }

            File.WriteAllLines(filePath, fileLines.ToArray());
        }


    }
}
