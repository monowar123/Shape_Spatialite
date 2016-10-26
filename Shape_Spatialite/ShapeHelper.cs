using DotSpatial.Data;
using DotSpatial.Topology;
using DotSpatial.Topology.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Spatialite
{
    public class ShapeHelper
    {
        public void CreateShapeFromDb(string tableName, string fileName)
        {
            string query = string.Format("select st_AsBinary(the_geom) as geom, * from {0};", tableName);
            DataTable dataTable = new DataTable();
            DbHandler dbHandler = new DbHandler();
            dataTable = dbHandler.GetDataTable(query);

            IFeature feature = new Feature();
            FeatureSet fs = new FeatureSet(FeatureType.Polygon);

            //add column to the featureset datatable
            foreach (DataColumn dc in dataTable.Columns)
            {
                if (dc.ColumnName != "the_geom" && dc.ColumnName != "geom")
                {
                    fs.DataTable.Columns.Add(dc.ColumnName, dc.DataType == typeof(System.Object) ? typeof(System.String) : dc.DataType);
                }
            }

            //create feature from dataTable along with attribute value
            foreach (DataRow dr in dataTable.Rows)
            {
                Byte[] data = (Byte[])dr["geom"];
                WkbReader wkbReader = new WkbReader();
                IGeometry geometry = wkbReader.Read(data);               

                feature = fs.AddFeature(geometry);

                feature.DataRow.BeginEdit();
                foreach (DataColumn dc in fs.DataTable.Columns)
                {
                    feature.DataRow[dc.ColumnName] = dr[dc.ColumnName];
                }
                feature.DataRow.EndEdit();
            }

            fs.SaveAs(fileName, true);
            fs.Close();    
        }
    }
}
