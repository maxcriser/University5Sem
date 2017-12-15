using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CRCCalculation
{
    public partial class Form1 : Form
    {
        public static string SAVED_FILE_NAME = "D:\\crc_calculation.txt";
        public static string SAVED_FILE_NAME_SELF_CHECK = "D:\\crc_calculation_self_check.txt";
        public static string EXE_FILE_DIRECTORY = "D:\\GitHubProjects\\University5Sem\\CRCCalculation\\CRCCalculation\\CRCCalculation\\bin\\Debug";

        public Form1()
        {
            InitializeComponent();
            processSelfCheck();
        }

        private void processSelfCheck()
        {
            if (isCorrectCrc(SAVED_FILE_NAME_SELF_CHECK, getFilesArrayByDirectory(EXE_FILE_DIRECTORY)))
            {
                showToast("Selfcheck is correct");
            }
            else
            {
                showToast("Selfxcheck is incorrect");
            }
        }

        private string[] getFilesArrayByDirectory(string pDirectory)
        {
            return Directory.GetFiles(pDirectory, "*.*", System.IO.SearchOption.AllDirectories);
        }

        private string[] getFilesArray()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedFolderTextView.Text = fbd.SelectedPath;

                    return Directory.GetFiles(fbd.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);
                }
                else
                {
                    return null;
                }
            }
        }

        private String getCRCOfFile(string pFileName)
        {
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;

            try
            {
                foreach (byte b in crc32.ComputeHash(File.ReadAllBytes(pFileName))) hash += b.ToString("x2").ToLower();
            }
            catch
            {
                // if we use it for project we hav exception
            }

            return hash;
        }

        private Dictionary<string, string> getCrcOfDirectory(string[] pArrayOfFileNames)
        {
            Dictionary<string, string> mapList = new Dictionary<string, string>();

            for (int position = 0; position < pArrayOfFileNames.Length; position++)
            {
                string fileName = pArrayOfFileNames[position];

                mapList.Add(fileName, getCRCOfFile(fileName));
            }

            return mapList;
        }

        private void processCRCCalculation(string[] pArrayOfFileNames, string pFileName)
        {
            writeToFile(getCrcOfDirectory(pArrayOfFileNames), pFileName);
        }

        private void writeToFile(Dictionary<string, string> pMapList, string pFileName)
        {
            string path = pFileName;

            try
            {
                File.WriteAllText(path, String.Empty);
            }
            catch
            {
                // nothing, its just first creation
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                for (int i = 0; i < pMapList.Count; i++)
                {
                    sw.WriteLine(pMapList.Keys.ElementAt(i));
                    sw.WriteLine(pMapList.Values.ElementAt(i));
                }
            }
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            processCRCCalculation(getFilesArray(), SAVED_FILE_NAME);
        }

        private Dictionary<string, string> getSavedCrcStatus(string pDirectory)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] lines = System.IO.File.ReadAllLines(pDirectory);

            for (int i = 0; i < lines.Length; i++)
            {
                result.Add(lines[i], lines[++i]);
            }

            return result;
        }

        private Boolean isCorrectCrc(string pDirectory, string[] pFiles)
        {
            Dictionary<string, string> currentCompareVersion = getCrcOfDirectory(pFiles);
            Dictionary<string, string> savedCompareVersion = getSavedCrcStatus(pDirectory);

            return currentCompareVersion.SequenceEqual(savedCompareVersion);
        }

        private void showToast(string pText)
        {
            MessageBox.Show(pText, "Result", MessageBoxButtons.OK);
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            if (isCorrectCrc(SAVED_FILE_NAME, System.IO.Directory.GetFiles(selectedFolderTextView.Text, "*.*", System.IO.SearchOption.AllDirectories)))
            {
                showToast("Correct");
            }
            else
            {
                showToast("Incorrect");
            }
        }

        private void selftCheck_Click(object sender, EventArgs e)
        {
            processCRCCalculation(getFilesArrayByDirectory(EXE_FILE_DIRECTORY), SAVED_FILE_NAME_SELF_CHECK);

            Application.Exit();
        }
    }
}
