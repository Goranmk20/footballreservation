<%@ Page Title="Кошничка" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Kosnicka.aspx.cs" Inherits="FudbalskiRezervacii.Kosnicka" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <asp:Label ID="Label2" runat="server" 
        Text="Почитуван кориснику Label, вие досега резервиравте билети за следниве натпревари:"></asp:Label>
</p>
    <p>
        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
</p>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
        onrowdeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="Team1" HeaderText="Тим 1" />
            <asp:BoundField DataField="Team2" HeaderText="Тим2" />
            <asp:BoundField DataField="Date" HeaderText="Датум" />
            <asp:BoundField DataField="Stadion" HeaderText="Стадион" />
            <asp:BoundField DataField="Grad" HeaderText="Град" />
            <asp:BoundField DataField="cena" HeaderText="Цена" />
            <asp:CommandField DeleteText="Избриши колона" ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#33CC33" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</p>
</asp:Content>
