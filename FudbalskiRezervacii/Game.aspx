<%@ Page Title="Натпревари" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="FudbalskiRezervacii.Teams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 623px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1" cellspacing="10px">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;<br />
                <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Потврда на резервацијата" Visible="False" BackColor="#009933" 
                    BorderColor="#00CC00" BorderStyle="Groove" Font-Bold="True" 
                    ForeColor="#FFFFCC" />
                    &nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:Button ID="Button2" runat="server" PostBackUrl="~/Kosnicka.aspx" 
                    Text="Кошничка" BackColor="#009933" BorderColor="#00CC00" 
                    BorderStyle="Groove" Font-Bold="True" ForeColor="#FFFFCC" Visible="False" />
                    <br />
Here you can reserve your football tickets for World Cup 2014.<br />
                <br />
<asp:GridView ID="gvRss" runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" 
    ForeColor="Black" GridLines="Horizontal" PageSize="6" 
                    onselectedindexchanged="gvRss_SelectedIndexChanged" 
                    onpageindexchanging="gvRss_PageIndexChanging" 
                    onselectedindexchanging="gvRss_SelectedIndexChanging">
                    
       <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Team1" HeaderText="Тeam1" >
            <ItemStyle Font-Size="10px" ForeColor="#009933" />
            </asp:BoundField>
            <asp:BoundField DataField="Team2" HeaderText="Тeam2" >
            <ItemStyle Font-Size="10px" Height="0px" Width="0px" ForeColor="#009933" />
            </asp:BoundField>
            <asp:BoundField DataField="Stadium" HeaderText="Stadium" >
            <ItemStyle Font-Size="10px" Height="0px" Width="0px" ForeColor="#009933" />
            </asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Date" >
            <ItemStyle Font-Size="10px" Height="0px" Width="0px" ForeColor="#009933" />
            </asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" >
            <ItemStyle Font-Size="10px" Height="0px" Width="0px" ForeColor="#009933" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Matches:">
                <ItemTemplate
>
                    <table border="0" cellpadding="0" cellspacing="70px">
                        <tr>
                        
                            <td>
                                <h3 style="color:#3E7CFF"><%#Eval("Team1") %></h3>
                                <img alt="slika1" src="<%#Eval("image1") %>" />
                            </td>
                            <td >
                                <h3 style="color:#3E7CFF"><%#Eval("Team2") %></h3>
                                <img alt="slika1" src="<%#Eval("image2") %>" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 style="color:#3E7CFF">Стадион: <%#Eval("Stadium") %></h3>
                            </td>
                            <td >
                                 <h4 style="color:#3E7CFF">Град: <%#Eval("City") %></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>Датум:  <%#Eval("Date") %></td>
                            <td>
                                Време:  <%#Eval("Time") %>
                            
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="cena" HeaderText="Price: " />
            <asp:CommandField SelectText="Reserve" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#99FF66" Font-Bold="True" ForeColor="Black" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
            </td>
            <td>
                Топ 10 стрелци на првенството:<br />
                <br />
                Распределени според бројот на погодоци.<br />
&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" 
    ForeColor="Black" GridLines="Vertical" 
                    onselectedindexchanged="gvRss_SelectedIndexChanged" PageSize="15">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Име на играч      Број на Голови">
                <ItemTemplate
>
                    <table  border="0" cellpadding="0" cellspacing="10px">
                        <tr>
                            <td>
                                <h3 style="color:#3E7CFF"><%#Eval("name") %></h3>
                                 &nbsp; &nbsp;&nbsp;
                            </td>
                            <td >
                                
                                <img alt="slika1" src="<%#Eval("country") %>" /> &nbsp; &nbsp;&nbsp;
                            </td>
                       <td>
                            
                                <h4 style="color:#3E7CFF">Голови: <%#Eval("goals") %></h4> &nbsp; &nbsp;&nbsp;
                         </td>   
                        </tr>
                        
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerSettings Mode="NextPreviousFirstLast" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#33CC33" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
                </td>
        </tr>
    </table>
</asp:Content>
