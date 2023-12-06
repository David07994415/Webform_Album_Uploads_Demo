using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Album_Front : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderPhoto();
            RenderAlbum();
            RenderAlbum2();
        }
        protected void RenderPhoto() 
        {
            DbHelper helper= new DbHelper();
            if (helper.DbConn()) 
            {
                string sql = "SELECT * FROM Photo";
                SqlCommand cmd =helper.DbShow(sql);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) 
                {
                    RepeaterTest.DataSource = reader;
                    RepeaterTest.DataBind();
                }
                helper.DbClose();
            }
        }
        protected void RenderAlbum()
        {
            DbHelper helper = new DbHelper();
            if (helper.DbConn())
            {
                string sql = "WITH RankedData AS (\r\n    SELECT\r\n        IsCover,\r\n        FK_albumid,\r\n\t\tPhotoDesc,\r\n        ROW_NUMBER() OVER (PARTITION BY FK_albumid ORDER BY IsCover DESC) AS RowNum\r\n    FROM\r\n        Photo)\r\nSELECT A.AlbumID, A.AlbumDesc, R.PhotoDesc, R.IsCover, R.FK_albumid\r\nFROM Album_System as A\r\nJOIN RankedData as R on R.FK_albumid=A.AlbumID\r\nWHERE R.RowNum = 1 and R.IsCover=1";
                SqlCommand cmd = helper.DbShow(sql);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ListView1.DataSource = reader;
                    ListView1.DataBind();
                }
                helper.DbClose();
            }
        }

        protected void RenderAlbum2()
        {
            DbHelper helper = new DbHelper();
            if (helper.DbConn())
            {
                string sql = "WITH RankedData AS (\r\n    SELECT\r\n        IsCover,\r\n        FK_albumid,\r\n\t\tPhotoDesc,\r\n        ROW_NUMBER() OVER (PARTITION BY FK_albumid ORDER BY IsCover DESC) AS RowNum\r\n    FROM\r\n        Photo)\r\nSELECT A.AlbumID, A.AlbumDesc, R.PhotoDesc, R.IsCover, R.FK_albumid\r\nFROM Album_System as A\r\nJOIN RankedData as R on R.FK_albumid=A.AlbumID\r\nWHERE R.RowNum = 1 and R.IsCover=1";
                SqlCommand cmd = helper.DbShow(sql);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
                helper.DbClose();
            }
        }


    }
}