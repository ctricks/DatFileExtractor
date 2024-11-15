using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatReader
{
    internal class clsFunction
    {
        public bool CheckFile(string PathFile) {
            if (Directory.GetFiles(PathFile).Length > 0)
            {
                return true;
            }
            return false;
        }
        public int GetFileDat(string PathFile)
        {
            return Directory.GetFiles(PathFile,"*.dat").Length;
        }
        public string GetFileName(string PathFile)
        {
            if (Directory.GetFiles(PathFile, "*.dat").Length > 0)
            {
                return Directory.GetFiles(PathFile, "*.dat")[0].ToString();
            }
            else
            {
                return null;
            }
        }
        public string ReadDatFile(string FileToProcess)
        {
            return File.ReadAllText(FileToProcess);
        }
        public void PlacedDone(string FileToProcess)
        { 
            FileInfo FileInfo = new FileInfo(FileToProcess);

            DirectoryInfo di = new DirectoryInfo(FileToProcess);
            string DonePath = FileToProcess.Replace(di.Name, "");

            if (!Directory.Exists(DonePath + "Done\\"))
                Directory.CreateDirectory(DonePath+ "Done\\");

            string DoneDirectory = DonePath + "Done\\" + FileInfo.Name;

            if(File.Exists(DoneDirectory))
                File.Delete(DoneDirectory);

            File.Move(FileToProcess, DoneDirectory);

        }
        public void LogActivity(string FileToProcess,string ActivityName)
        {
            DirectoryInfo di = new DirectoryInfo(FileToProcess);

            if(!Directory.Exists(FileToProcess.Replace(di.Name, "") + "\\Logs\\"))
            {
                Directory.CreateDirectory(FileToProcess.Replace(di.Name, "") + "\\Logs\\");
            }

            string LogPath = FileToProcess.Replace(di.Name,"") + "\\Logs\\" + DateTime.Now.ToString("MMddyyyy") + ".log";
            File.AppendAllText(LogPath,"\n" + ActivityName);
        }
        public void ExtractMyDate(string DataContents,string FilePath)
        {
            string PatternText = string.Empty;
            string PatternFile = FilePath + "\\Pattern\\Pattern.txt";

            if (File.Exists(PatternFile))
            {
                PatternText = File.ReadAllText(PatternFile);

                if (PatternFile.Length > 0)
                {

                    string ExtractContent = Regex.Match(DataContents, PatternText, RegexOptions.Multiline).Value.ToString();
                    if (!Directory.Exists(FilePath + "\\Extract"))
                    {
                        Directory.CreateDirectory(FilePath + "\\Extract");
                    }

                    if (ExtractContent.Length > 0)
                    {
                        string SavePath = FilePath + "\\Extract\\Extract_" + DateTime.Now.ToString("MMddyyyy") + ".txt";

                        if (File.Exists(SavePath))
                            File.Delete(SavePath);

                        File.AppendAllText(SavePath, "\n" + ExtractContent);
                    }
                }else
                {
                    string SavePath = FilePath + "\\Extract\\Extract_" + DateTime.Now.ToString("MMddyyyy") + ".txt";
                    
                    if (File.Exists(SavePath))
                        File.Delete(SavePath);

                    File.AppendAllText(SavePath, "\n" + DataContents);
                }
            }
        }
    }
}
