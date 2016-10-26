using DotSpatial.Data;
using DotSpatial.Topology;
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
                string fileName = @"C:\Users\HDSL115\Desktop\Desktop\SQL Lite\ShapeFile\hitbgt_new.shp";

                ShapeHelper helper = new ShapeHelper();
                helper.CreateShapeFromDb("hitbgt", fileName);

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"C:\Users\HDSL115\Desktop\Desktop\SQL Lite\ShapeFile\hitbgt_new.shp";

                // create a geometry (square polygon)
                List<Coordinate> vertices = new List<Coordinate>();
                vertices.Add(new Coordinate(0, 0));
                vertices.Add(new Coordinate(0, 100));
                vertices.Add(new Coordinate(100, 100));
                vertices.Add(new Coordinate(100, 0));
                Polygon geom = new Polygon(vertices);

                IFeatureSet fs = FeatureSet.Open(fileName);
                fs.FillAttributes();

                IFeature feature = fs.AddFeature(geom);

                feature.DataRow.BeginEdit();
                feature.DataRow["cadid"] = "12345";
                feature.DataRow["blk"] = "New value";
                feature.DataRow["area"] = "1";
                feature.DataRow["fmain"] = "fmain";
                feature.DataRow.EndEdit();

                fs.SaveAs(fileName, true);
                fs.Close();
                MessageBox.Show("Row inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
