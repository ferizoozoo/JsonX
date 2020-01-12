using System;
using System.IO;
using System.Collections.Generic;

namespace JsonX
{
    public class Json
    {
        public Dictionary<string,string> JsonDictionary { get; private set; }  = new Dictionary<string, string>();

        // Writes the JsonDictionary into a .json file.
        private void WriteJsonFile(string toFilePathName)
        {
            int jsonDictionaryCount = this.JsonDictionary.Count;

            if (jsonDictionaryCount == 0)
                throw new Exception("The JsonDictionary is empty.");

            using (var file = new StreamWriter(toFilePathName))
            {
                // Starting curve bracket of the new json file.
                file.WriteLine("{");

                foreach (var dictionaryElement in JsonDictionary)
                {
                    string jsonElement = $"\t\"{dictionaryElement.Key}\" : \"{dictionaryElement.Value}\"";

                    // Checking if there is another field for adding a comma or not.
                    if (jsonDictionaryCount > 1)
                        jsonElement += ",";

                    file.WriteLine(jsonElement);   

                    jsonDictionaryCount--; 
                }    

                // Ending curve bracket of the new json file.
                file.WriteLine("}");
            }
        }

        // Reads a text file and turns it into a dictionary of Json pieces.
        private void ReadFileToJsonDictionary(string fromFilePathName)
        {
            if (File.Exists(fromFilePathName))
            {
                using (var file = new StreamReader(fromFilePathName))
                {
                    string[] jsonComponents = file.ReadToEnd().Trim().Split(',');

                    foreach (var component in jsonComponents)
                    {
                        string[] jsonComponent = component.Trim().Split(':');
                        this.JsonDictionary.Add(jsonComponent[0], jsonComponent[1]);
                    }
                }
            }
            else
            {
                throw new Exception("Couldn't find the file path.");
            }
        }

        // Does the whole process of turning a text file into a .json file
        public void GetThatFuckingJsonFile(string filePathName)
        {
            this.ReadFileToJsonDictionary(filePathName);
            this.WriteJsonFile($"{Path.GetFileNameWithoutExtension(filePathName)}.json");
        }
    }
}
