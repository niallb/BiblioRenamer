/*
   Copyright 2018 Niall S F Barr

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

 */ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BiblioRenamer
{
    public partial class Form1 : Form
    {
        private string outDir;
        private bool deleteOriginal;
        private bool removeFromList;

        public Form1()
        {
            InitializeComponent();

            outDir = null;
            deleteOriginal = false;
            removeFromList = true;
            removeNameFromListToolStripMenuItem.Checked = removeFromList;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string filename = null;
            // From https://www.codeproject.com/Articles/9017/A-Simple-Drag-And-Drop-How-To-Example
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                    }
                }
                //MessageBox.Show(filename);
            }
            if ((filename != null) && (File.Exists(filename)))
            {
                int idx = listBox1.IndexFromPoint(listBox1.PointToClient(new Point(e.X, e.Y)));
                if (idx >= 0)
                {
                    listBox1.SetSelected(idx, true);
                    string ext = Path.GetExtension(filename).ToLower();
                    string outPath;
                    if (outDir != null)
                        outPath = outDir;
                    else
                        outPath = Path.GetDirectoryName(filename);
                    outPath += Path.DirectorySeparatorChar + listBox1.Items[idx].ToString() + ext;
                    MessageBox.Show(outPath);
                    if(File.Exists(outPath))
                    {
                        MessageBox.Show(outPath + "\r\nalready exists, so nothing was done.");
                    }
                    else
                    {
                        File.Copy(filename, outPath);
                        if (deleteOriginal)
                            File.Delete(filename);
                        if (removeFromList)
                            listBox1.Items.RemoveAt(idx);
                    }
                }
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            //MessageBox.Show(e.Data.ToString());
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;  
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    importBibliography(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void importBibliography(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            listBox1.Items.Clear();
            List<string> authors = new List<string>();
            List<string> filenames = new List<string>();
            string year = "";
            string title = "";
            bool canuse = false;
            for(int n=0; n<lines.Length; n++)
            {
                if(lines[n].Length == 0)
                {
                    if(canuse)
                    {
                        string fn = "";
                        if (authors.Count > 0)
                        {
                            if (authors.Count == 1)
                                fn = authors[0] + " - ";
                            else if (authors.Count == 2)
                                fn = authors[0] + " & " + authors[1] + " - ";
                            else
                                fn = authors[0] + " et al - ";
                        }
                        if (year.Length > 0)
                            fn += year + " - ";

                        if (title.Length > 0)
                            fn += title + " ";
                        if (fn.Length > 120)
                            fn = fn.Substring(0, 120);
                        filenames.Add(fn);

                    }
                    canuse = false;
                    authors.Clear();
                    year = "";
                    title = "";
                }
                else
                {
                    string type = lines[n].Substring(0, 2);
                    string value = lines[n].Substring(3).Trim();
                    switch(type)
                    {
                        case "T1":
                            title = Regex.Replace(value, @"[^\w]+", " ");
                            canuse = true;
                            break;
                        case "YR":
                            year = value;
                            break;
                        case "A1":
                            if(value.IndexOf(",")>0)
                                authors.Add(value.Substring(0, value.IndexOf(",")));
                            else
                                authors.Add(value);
                            break;
                    }
                }
            }
            filenames.Sort();
            foreach (string fn in filenames)
                listBox1.Items.Add(fn);
        }

        private void deleteOriginalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteOriginal = !deleteOriginal;
            deleteOriginalFileToolStripMenuItem.Checked = deleteOriginal;
        }

        private void removeNameFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeFromList = !removeFromList;
            removeNameFromListToolStripMenuItem.Checked = removeFromList;
        }

        private void copyToDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(copyToDirToolStripMenuItem.Checked)
            {
                copyToDirToolStripMenuItem.Checked = false;
                outDir = null;
                Text = "Bibliography File Renamer";
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "Select the directory that you want to copy renamed files to.";
                folderBrowserDialog1.ShowNewFolderButton = true;
                //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
                if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    outDir = folderBrowserDialog1.SelectedPath;
                    copyToDirToolStripMenuItem.Checked = true;
                    Text = "Bibliography File Renamer - target: " + outDir;

                }
            }
        }
    }
}
