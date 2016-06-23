using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shape_Spatialite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateShape_Click(object sender, EventArgs e)
        {
            try
            {               
                string fileName = @"C:\Users\HDSL115\Desktop\SQL Lite\ShapeFile\hitbgt.shp";

                ShapeHelper helper = new ShapeHelper();
                helper.CreateShapeFromDb("hitbgt", fileName);

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
