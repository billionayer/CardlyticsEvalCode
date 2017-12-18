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

namespace LinkedListTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IntegerLinkedList = new MyLinkList<long>();
            StringLinkedList = new MyLinkList<string>();
        }

        private MyLinkList<long> IntegerLinkedList;
        private MyLinkList<string> StringLinkedList;
        private bool bIntegerOrString = true;

        #region Private Methods
        private void ClearList()
        {
            IntegerLinkedList.Clear();
            StringLinkedList.Clear();
        }
        private void LoadData(string fileName)
        {
            string rawData = string.Empty;
            try
            {
                ClearList();
                bool bIntegerOrString = (cmbTypes.Text == "integer");
                long lineNumber = 1;
                using (StreamReader reader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    string line = string.Empty;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (bIntegerOrString)
                        {
                            IntegerLinkedList.Push(long.Parse(line));
                        }
                        else
                        {
                            StringLinkedList.Push(line);
                        }
                        //Add line number to text from file so we can easily reference the line in the text box.
                        rawData += string.Format("{0}: {1}{2}", lineNumber++, line, Environment.NewLine);

                    }
                    reader.Close();
                }
                txtRawData.Text = rawData;
                txtNumEntries.Text = ((lineNumber == 1) ? 1 : lineNumber - 1).ToString();
                
            }
            catch (IOException ex)
            {
                ClearList();
                throw new IOException(string.Format("Unable to acccess {0}.{1}Reason: {2}", fileName, Environment.NewLine, ex.Message));
            }
            catch (Exception ex)
            {
                ClearList();
                throw ex;
            }
        }
        private void ProcessData(string fileName)
        {
            LoadData(fileName);
        }
        #endregion


        #region Event Handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbTypes.SelectedIndex = 0;
            cmbSearchType.SelectedIndex = 0;

        }

        private void buttonProcessData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFileName.Text))
            {
                MessageBox.Show("Please Load a file first.", "Processing of File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!File.Exists(textBoxFileName.Text))
            {
                MessageBox.Show("Unable to locate file on disk", "Processing of File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                ProcessData(textBoxFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bIntegerOrString = (cmbTypes.Text == "integer");
        }

        private void buttonLocateData_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            textBoxFileName.Text = openFileDialog.FileName;
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ulong itemNumber = 0;
            if(!ulong.TryParse(txtItemNumber.Text, out itemNumber))
            {
                MessageBox.Show("Please enter a valid non-negative number into the Item Number field.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemNumber.Focus();
                txtItemNumber.SelectAll();
                return;
            }

            MyLinkListSearchDirection searchType = (cmbSearchType.Text == "ASC") ? MyLinkListSearchDirection.Ascending : MyLinkListSearchDirection.Descending;
            string searchDataResult = "Unable to find entry.  Item Number is out of range.";

            if (bIntegerOrString)
            {
                if(IntegerLinkedList.IsEmpty)
                {
                    MessageBox.Show("Please load a file with integer data.", "Integer Data Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MyLinkedListItem<long> item = IntegerLinkedList.FindItem(itemNumber, searchType);
                if(item != null)
                {
                    searchDataResult = string.Format("Integer data found at position {0} from {1} of linked list.{2}Value: {3}", itemNumber,
                    (searchType == MyLinkListSearchDirection.Ascending) ? "front" : "back", Environment.NewLine, item.Value);

                }
            }
            else
            {
                if (StringLinkedList.IsEmpty)
                {
                    MessageBox.Show("Please load a file with string data.", "String Data Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MyLinkedListItem<string> item = StringLinkedList.FindItem(itemNumber, searchType);
                if (item != null)
                {
                    searchDataResult = string.Format("String data found at position {0} from {1} of linked list.{2}Value: {3}", itemNumber,
                    (searchType == MyLinkListSearchDirection.Ascending) ? "front" : "back", Environment.NewLine, item.Value);

                }
            }
            txtFoundData.Text = searchDataResult;
        }
    }
}
