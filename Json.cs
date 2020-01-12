using System;
using System.IO;
using System.Collections.Generic;

namespace JsonX
{
    public class Json
    {
        private Dictionary<string,string> JsonDictionary { get; set; }

        // TODO : Complete the function below!
        // Writes the JsonDictionary into a .json file.
        private void WriteJsonFile(string toFilePathName)
        {
        }

        // Reads a text file and turns it into a dictionary of Json pieces.
        private void ReadFileToJsonDictionary(string fromFilePathName)
        {
            if (File.Exists(fromFilePathName))
            {
                using (var file = File.OpenText(fromFilePathName))
                {
                    string[] jsonComponents = file.ReadToEnd().Split(',');
                    foreach (var component in jsonComponents)
                    {
                        string[] jsonComponent = component.Split(':');
                        this.JsonDictionary[jsonComponent[0]] = jsonComponent[1];
                    }
                }
            }
        }

        // Does the whole process of turning a text file into a .json file
        public void GetThatFuckingJson(string fromFilePathName, string toFilePathName)
        {
            ReadFileToJsonDictionary(fromFilePathName);
            WriteJsonFile(toFilePathName);
        }
    }
}
