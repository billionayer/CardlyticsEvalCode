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
using TriangleTypeChecker.BusinessServices;

namespace TriangleTypeChecker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Private Methods
       
        private void PopulateGrid(TriangleTests tests)
        {
            if(tests == null || tests.Count == 0)
            {
                gridView.DataSource = CreateEmptyDataTable();
                return;
            }
            gridView.DataSource = CreateDataTable(tests);
            FormatGrid();
        }

        private DataTable CreateEmptyDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("TestID", typeof(int)));
            table.Columns.Add(new DataColumn("SideA", typeof(ulong)));
            table.Columns.Add(new DataColumn("SideB", typeof(ulong)));
            table.Columns.Add(new DataColumn("SideC", typeof(ulong)));
            table.Columns.Add(new DataColumn("IsValidTriangle", typeof(bool)));
            table.Columns.Add(new DataColumn("ExpectedType", typeof(TriangleTypeEnum)));
            table.Columns.Add(new DataColumn("ResultType", typeof(TriangleTypeEnum)));
            table.Columns.Add(new DataColumn("Result Notes", typeof(string)));
            return table;
        }

        private DataTable CreateDataTable(TriangleTests tests)
        {

            DataTable table = CreateEmptyDataTable();
            foreach(TriangleTest test in tests)
            {
                DataRow row = table.NewRow();
                row["TestID"] = test.TestID;
                row["SideA"] = test.TestTriangle.SideA;
                row["SideB"] = test.TestTriangle.SideB;
                row["SideC"] = test.TestTriangle.SideC;
                row["IsValidTriangle"] = test.TestTriangle.IsValidTriangle;
                row["ExpectedType"] = test.ExpectedTriangleType;
                row["ResultType"] = test.TestTriangle.TriangleType;
                row["Result Notes"] = test.TestTriangle.ReasonTriangleIsInvalid;
                table.Rows.Add(row);
            }
            return table;
        }
        
        private void ProcessData(string fileName)
        {
            try
            {
                TriangleTests tests = new TriangleTests();
                tests.Load(fileName);
                PopulateGrid(tests);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers
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
        #endregion
        
        private void FormatGrid()
        {
            foreach(DataGridViewRow row in gridView.Rows)
            {
                if (row.IsNewRow)
                    continue;
                bool Valid = (bool)row.Cells["IsValidTriangle"].Value;
                Color defaultBackColor = row.DefaultCellStyle.BackColor;
                Color defaultForeColor = row.DefaultCellStyle.ForeColor;

                row.DefaultCellStyle.BackColor = (Valid) ? defaultBackColor : Color.Yellow;


                TriangleTypeEnum expected = (row.Cells["ExpectedType"].Value == null) ? TriangleTypeEnum.NONE :
                    (TriangleTypeEnum) row.Cells["ExpectedType"].Value;
                TriangleTypeEnum resultType = (row.Cells["ResultType"].Value == null) ? TriangleTypeEnum.NONE :
                    (TriangleTypeEnum)row.Cells["ResultType"].Value;
                if (expected != resultType)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["Result Notes"].Value += " Types do not match.";
                }
            }
        }
    }
}
