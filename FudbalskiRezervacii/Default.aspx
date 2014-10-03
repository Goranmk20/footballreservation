<%@ Page Title="Домашна страница" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FudbalskiRezervacii._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    .style2
    {
        width: 338px;
    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Добредојдовте на нашата ASP.NET веб-апликација.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </h2>
    <h2>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" 
            Text="Ве молиме најавете се!"></asp:Label>
        &nbsp;
        <asp:Button ID="Button1" runat="server" CssClass="menu" 
            PostBackUrl="~/Kosnicka.aspx" Text="Кошничка" Visible="False" 
            BackColor="#3366FF" BorderColor="#3333CC" BorderStyle="Ridge" Font-Bold="True" 
            ForeColor="#FFFFCC" />
            </h2>
    <h2>
        Тука можете да резервирате билети за фудбалски натпревари од Светското Првенство во Бразил, 2014.
    </h2>
    <table class="style1">
        <tr>
           <td class="style2">
           Досегашни резултати од првенството:<br />
&nbsp;<asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
        ShowHeader="False" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" 
    ForeColor="Black" GridLines="None" AllowPaging="True" 
                   onpageindexchanged="gvResult_PageIndexChanged" 
                   onpageindexchanging="gvResult_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate
>
                    <table  border="0" cellpadding="0" cellspacing="20px">
                        <tr >
                            <td>
                                <h3 style="color:#3E7CFF"><%#Eval("Team1") %></h3>
                                <img alt="slika1" src="<%#Eval("image1") %>" />
                                
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;<h4 style="color:#3E7CFF"><%#Eval("Result") %></h4>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td >
                                <h3 style="color:#3E7CFF"><%#Eval("Team2") %></h3>
                                <img alt="slika1" src="<%#Eval("image2") %>" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <h4 style="color:#3E7CFF">Датум: <%#Eval("Date") %></h4>
                            </td>
                    
                        </tr>
                        <tr>
                            <td colspan="2" >
                                <div style="color:#3E7CFF">Стадион: <%#Eval("Stadium") %>   --  </div>
                            </td>
                            <td >
                                 <div style="color:#3E7CFF">   Град: <%#Eval("City") %></div>
                            </td>
                            
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
           </td>
          
            <td>
                 
                Овде може да ги прочитате последните вести од Светското првенство во&nbsp; 
                Бразил 2014:<br />
&nbsp;<asp:GridView ID="gvRss" runat="server" AutoGenerateColumns="False" 
        ShowHeader="False" AllowPaging="True" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" 
    ForeColor="Black" GridLines="None" PageSize="7" 
                    onpageindexchanging="gvRss_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate
>
                    <table  border="0" cellpadding="0" cellspacing="10">
                        <tr>
                            <td colspan="2">
                                <a href="<%#Eval("Link") %>"><h3 style="color:#3E7CFF"><%#Eval("Title") %></h3></a>
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <%#Eval("Date") %>
                                <p><%#Eval("Description") %></p>
                        </tr>
                        
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
                
                </td>
       </tr>
      
    </table>
    

</asp:Content>
