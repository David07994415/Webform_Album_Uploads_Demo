<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album_Back.aspx.cs" Inherits="WebApplication1.Album_Back" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Label ID="LabelCreateAlbum" runat="server" Text="創立相簿名稱："></asp:Label>
            <asp:TextBox ID="TextBoxCreateAlbum" runat="server" ValidationGroup="CreateAlbum"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateAlbum" runat="server" ErrorMessage="*" ValidationGroup="CreateAlbum" ControlToValidate="TextBoxCreateAlbum"></asp:RequiredFieldValidator>
            <asp:Button ID="ButtonCreateAlbum" runat="server" Text="創立" ValidationGroup="CreateAlbum" OnClick="ButtonCreateAlbum_Click" />
        </div>






        <asp:Literal ID="LiteralTest" runat="server"></asp:Literal>

        <div>
            <asp:HyperLink ID="HyperLinkFront" runat="server" NavigateUrl="~/Album_Front.aspx">回到前台</asp:HyperLink>
        </div>

        <div>
            <br />
            <br />
        </div>


        <div>
            <asp:Label ID="LabelShowAlbum" runat="server" Text="選擇上傳之相簿"></asp:Label>
            <asp:DropDownList ID="DropDownListShowAlbum" runat="server" DataSourceID="" DataTextField="AlbumDesc" DataValueField="AlbumID"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practice_Album_SystemConnectionString %>" SelectCommand="SELECT * FROM [Album_System]"></asp:SqlDataSource>
        </div>


        <div>
            <asp:FileUpload ID="FileUploadPhoto" runat="server" ValidationGroup="UploadPhoto" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUpload" runat="server" ErrorMessage="*" ValidationGroup="UploadPhoto" ControlToValidate="FileUploadPhoto"></asp:RequiredFieldValidator>
            <asp:Button ID="ButtonUpload" runat="server" Text="上傳" OnClick="ButtonUpload_Click" ValidationGroup="UploadPhoto" />
            <div>
                <asp:Label ID="LabelCover" runat="server" Text="是否為封面"></asp:Label>
                <asp:CheckBox ID="CheckBoxforCover" runat="server" />
            </div>
        </div>

        <div>
            <asp:GridView ID="GridViewShowAlbum" runat="server" AutoGenerateColumns="False" DataKeyNames="AlbumID" OnRowEditing="GridViewShowAlbum_RowEditing" OnRowUpdating="GridViewShowAlbum_RowUpdating" OnRowDeleting="GridViewShowAlbum_RowDeleting" OnRowCancelingEdit="GridViewShowAlbum_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="AlbumID" HeaderText="AlbumID" InsertVisible="False" ReadOnly="True" SortExpression="AlbumID" />
                    <asp:BoundField DataField="AlbumDesc" HeaderText="AlbumDesc" SortExpression="AlbumDesc" />
                    <asp:BoundField DataField="AlbumCreateTime" HeaderText="AlbumCreateTime" SortExpression="AlbumCreateTime" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:ImageField DataImageUrlFormatString="123">
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Practice_Album_SystemConnectionString %>" SelectCommand="SELECT * FROM [Album_System]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
