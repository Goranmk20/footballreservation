<%@ Page Title="Тимови" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="FudbalskiRezervacii.Games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
        ShowHeader="False" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" 
    ForeColor="Black" GridLines="Vertical" PageSize="6">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate
>
                    <table  border="0" cellpadding="0" cellspacing="10">
                        <tr>
                            <th>
                                <h3 style="color:#3E7CFF">Group: <%#Eval("Ime") %>    </h3>
                                
                            </th>
                            
                       <br />
                       <br />
                           <td >
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href="<%#Eval("id1") %>"><%#Eval("team1") %></a>&nbsp;&nbsp;<img alt="slika1" src="<%#Eval("im1") %>" />&nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                      
                            <td >
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href="<%#Eval("id2") %>"><%#Eval("team2") %></a>&nbsp;&nbsp;<img alt="slika1" src="<%#Eval("im2") %>" />&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                      
                            <td >
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href="<%#Eval("id3") %>"><%#Eval("team3") %></a>&nbsp;&nbsp;<img alt="slika1" src="<%#Eval("im3") %>" />&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        
                            <td >
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href="<%#Eval("id4") %>"><%#Eval("team4") %></a>&nbsp;&nbsp;<img alt="slika1" src="<%#Eval("im4") %>" />&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
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
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
</asp:Content>
