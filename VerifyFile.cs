using System;
using System.IO;
using System.Net;
namespace mis221_pa5_Dnsavage
{
    public class VerifyFile
    {
        //Retrieves file names from external source
        public static void GetAllFiles(ref string[] allFiles)
        {
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead("https://gist.githubusercontent.com/Dnsavage/3df31f88d3cd2a0c04b5e500163e9f1c/raw/04de6927fbd888f60b2476786a22bea5fc15f590/textAssets.txt");
                StreamReader inFile = new StreamReader(stream);
                string line = inFile.ReadLine();
                int count = 0;
                while (line != null)
                {
                    allFiles[count] = line;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
        }
        //Retrieves the names of all missing files, if any
        public static void GetMissingFiles(string[] allFiles, ref string[] missingFiles, int NUM_FILES)
        {
            for (int i = 0; i < NUM_FILES; i++)
            {
                if (!File.Exists(allFiles[i]))
                {
                    missingFiles[i] = allFiles[i];
                }
            }
        }
        //Displays the names of all missing files, if any
        public static void DisplayMissingFiles()
        {
            const int NUM_FILES = 38;
            string[] allFiles = new string[NUM_FILES];
            string[] missingFiles = new string[NUM_FILES];
            GetAllFiles(ref allFiles);
            GetMissingFiles(allFiles, ref missingFiles, NUM_FILES);
            bool missingAsset = false;

            for (int i = 0; i < missingFiles.Length; i++)
            {
                if (missingFiles[i] != null)
                {
                    missingAsset = true;
                    break;
                }
            }
            if (missingAsset == false)
            {
                return;
            }
            else
            {
                Prompts.PromptMissingFiles();
                for (int i = 0; i < missingFiles.Length; i++)
                {
                    if (missingFiles[i] != null)
                    {
                        Console.WriteLine(missingFiles[i]);
                    }
                }
                Prompts.PromptRestoreFiles();
                Environment.Exit(0);
            }
        }
    }
}