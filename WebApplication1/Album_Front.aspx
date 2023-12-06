<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album_Front.aspx.cs" Inherits="WebApplication1.Album_Front" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--            DataSourceID="SqlDataSource1" --%>
            <asp:Repeater ID="RepeaterTest" runat="server" DataSourceID="">
                <ItemTemplate>
                    <div>
                        <img src='Uploads/<%# Eval("PhotoDesc") %>' alt='<%# Eval("PhotoID") %>' width="200" height="100" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practice_Album_SystemConnectionString %>" ProviderName="<%$ ConnectionStrings:Practice_Album_SystemConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Photo]"></asp:SqlDataSource>--%>
        </div>
        <div>
            <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Album_Back.aspx">回到後台</asp:HyperLink>
        </div>

        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div>
                    <img src='Uploads/<%# Eval("PhotoDesc") %>' alt='<%# Eval("PhotoID") %>' width="200" height="100" />
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                               <div>
                   <p>相簿名稱：<%# Eval("AlbumDesc") %></p>
               </div>

               <div>
                   <img src='Uploads/<%# Eval("PhotoDesc") %>' alt='' width="200" height="100" />
               </div>

               <div>
                   <p>封面名稱：<%# Eval("PhotoDesc") %></p>
               </div>

            </ItemTemplate>
        </asp:Repeater>
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <div>
                    <p>相簿名稱：<%# Eval("AlbumDesc") %></p>
                </div>

                <div>
                    <img src='Uploads/<%# Eval("PhotoDesc") %>' alt='' width="200" height="100" />
                </div>

                <div>
                    <p>封面名稱：<%# Eval("PhotoDesc") %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>

    </form>
</body>
</html>
