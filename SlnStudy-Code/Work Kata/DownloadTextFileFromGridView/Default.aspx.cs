using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DownloadTextFileFromGridView
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {

                    conn.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_WF_AMP_APROVADOS_POR_PERIODO";

                        cmd.Parameters.AddWithValue("@initialDate", "13/10/2011");
                        cmd.Parameters.AddWithValue("@endDate", "14/10/2011");

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            // Fill the DataSet using default values for DataTable names, etc
                            var dataset = new DataSet();
                            da.Fill(dataset);

                            GridView1.DataSource = dataset;
                            GridView1.DataBind();

                            Button1.Visible = dataset.Tables[0].Rows.Count != 0;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ds = (DataSet)GridView1.DataSource;

            var sb = new StringBuilder();


            //Get the Columns Name
            AppendColumnNames(ds, sb);

            //Get each row
            AppendRows(ds, sb);

            //Write to a text file
            var mStream = WriteToStream(sb);
            var csvBytes = mStream.ToArray();


            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"", "AmpCsv.txt"));
            Response.AddHeader("Content-Length", csvBytes.Length.ToString());
            Response.BinaryWrite(csvBytes);
            Response.End();
        }

        private MemoryStream WriteToStream(StringBuilder sb)
        {
            var mStream = new MemoryStream();
            var writer = new StreamWriter(mStream);
            writer.Write(sb.ToString());
            writer.Close();
            return mStream;
        }

        private static void AppendRows(DataSet ds, StringBuilder sb)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AppendCells(sb, row);
            }
        }

        private static void AppendCells(StringBuilder sb, DataRow row)
        {
            foreach (var cell in row.ItemArray)
            {
                sb.Append(cell + ";");
            }
            sb.AppendLine();
        }

        private static void AppendColumnNames(DataSet ds, StringBuilder sb)
        {
            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                sb.Append(column.ColumnName + ";");
            }
            sb.AppendLine();
        }
    }
}