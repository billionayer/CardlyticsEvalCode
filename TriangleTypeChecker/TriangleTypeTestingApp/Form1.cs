using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TriangleTypeChecker.DataObjects;

namespace TriangleTypeTestingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool VerifyTokens(string[] tokens)
        {
            if(tokens == null || tokens.Length != 4)
            {
                return false;
            }
            ulong temp = 0;
            if(!ulong.TryParse(tokens[0],out temp) ||
               !ulong.TryParse(tokens[1], out temp))
            {
                return false;
            }
            TriangleTypeEnum tempTriangleType = TriangleTypeEnum.None;
            if (!Enum.TryParse(tokens[2], out tempTriangleType))
            {
                return false;
            }
            return true;
        }

        private List<Triangle> CreateTriangles(List<string[]> tokenCollection)
        {
            List<Triangle> triangles = new List<Triangle>();
            foreach(string[] tokens in tokenCollection)
            {
                triangles.Add(new Triangle(ulong.Parse(tokens[0]),
                                            ulong.Parse(tokens[1]),
                                            ulong.Parse(tokens[2])));
                   
            }
            return triangles;
        }


        private void ProcessData(string fileName)
        {
            List<string[]> lines = new List<string[]>();
            using (StreamReader reader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
            {
                string line = string.Empty;
                while(!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] tokens = line.Split(",".ToCharArray());
                    if (VerifyTokens(tokens))
                    {
                        lines.Add(tokens);
                    }
                }
                reader.Close();
            }
            List<Triangle> triangles = CreateTriangles(lines);
            TriangleTypeEnum type = triangles[3].TriangleType;
        }

        private void buttonLocateData_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            textBoxFileName.Text = openFileDialog.FileName;
        }

        private void buttonProcessData_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxFileName.Text))
            {
                MessageBox.Show("Please Load a file first.", "Processing of File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(!File.Exists(textBoxFileName.Text))
            {
                MessageBox.Show("Unable to locate file on disk", "Processing of File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                
                ProcessData(textBoxFileName.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
