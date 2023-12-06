using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Album_Back : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownListShowAlbum.DataSourceID = "SqlDataSource1";
            if (!Page.IsPostBack) 
            {
                GridViewConn();
            }
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            // 1. 先手動新增 Uploads 資料夾
            string Address=Server.MapPath($"~/Uploads/");   //  2. 取得儲存資料夾的路徑
            if (FileUploadPhoto.HasFile)                                    //  3. 判斷控制項是否有資料
            {
                HttpPostedFile ULF = FileUploadPhoto.PostedFile;                        // 4. 創造傳送物件
                string FileName = Path.GetFileName(ULF.FileName);                     // 4-1 取得 File 名字
                string FileExtent = Path.GetExtension(ULF.FileName).ToLower();   // 4-2 取得 File 附檔名
                string FullPath = Path.Combine(Address, FileName);                     // 4-3 取得 File 完整路徑
                if (FileExtent == ".png" || FileExtent == ".jpeg")               // 如果檔案吻合圖片檔案，進入資料庫撰寫
                {
                    DbHelper helper=new DbHelper();
                    if (helper.DbConn()) 
                    {
                        int IsCover = Convert.ToInt16(CheckBoxforCover.Checked);
                        string AlbumSelect = DropDownListShowAlbum.SelectedValue;
                        string sql = "INSERT INTO Photo(PhotoLink,PhotoDesc,FK_albumid,IsCover) VALUES(@Path,@PhotoDesc,@FK_albumid,@IsCover)";
                        SqlCommand cmd =helper.DbShow(sql);
                        cmd.Parameters.AddWithValue("@Path", FullPath);                   //   存入圖片檔案位址
                        cmd.Parameters.AddWithValue("@PhotoDesc", FileName);       //   存入圖片名稱
                        cmd.Parameters.AddWithValue("@FK_albumid", AlbumSelect); //   存入第幾本相簿
                        cmd.Parameters.AddWithValue("@IsCover", IsCover);                //   存入預設不是COVER
                        int result =cmd.ExecuteNonQuery();
                        if (result == 1) 
                        {
                            FileUploadPhoto.SaveAs(FullPath);                 // 5. 將資料上傳指定的資料夾中(要使用fullPath)
                            helper.DbClose();
                            Response.Write("<script>alert('上傳成功')</script>");
                        }
                    }
                }
                else 
                {
                    Response.Write("<script>alert('檔案格式有誤，無法上傳')</script>");
                }
                LiteralTest.Text = FileName + "<br/>" + FileExtent + "<br/>" + Address + "<br/>" + FullPath+"<br/>"+ResolveUrl(FullPath);
            }                                 
            else 
            {
                Response.Write("<script>alert('未選擇檔案')</script>");
            }

        }

        protected void ButtonCreateAlbum_Click(object sender, EventArgs e)
        {
            DbHelper helper= new DbHelper();
            if (helper.DbConn()) 
            {
                string sql = "INSERT INTO Album_System(AlbumDesc) VALUES(@AlbumDesc)";
                SqlCommand cmd =helper.DbShow(sql);
                cmd.Parameters.AddWithValue("@AlbumDesc", TextBoxCreateAlbum.Text);
                int result = cmd.ExecuteNonQuery();
                if (result == 1) 
                {
                    Response.Write("<script>alert('新增相簿完成')</script>");
                }
                helper.DbClose();
            }
        }

        protected void GridViewConn() 
        {
            DbHelper helper = new DbHelper();
            if (helper.DbConn()) 
            {
                string sql = "SELECT * FROM Album_System";
                SqlCommand cmd =helper.DbShow(sql);
                SqlDataReader rd= cmd.ExecuteReader();
                if (rd.HasRows) 
                {
                    GridViewShowAlbum.DataSource = rd;
                    GridViewShowAlbum.DataBind();
                    helper.DbClose();
                }
            }
        }

        protected void GridViewShowAlbum_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewShowAlbum.EditIndex = e.NewEditIndex;
            GridViewConn();
        }

        protected void GridViewShowAlbum_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridViewShowAlbum_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewShowAlbum_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewShowAlbum.EditIndex = -1;
            GridViewConn();
        }
    }
}