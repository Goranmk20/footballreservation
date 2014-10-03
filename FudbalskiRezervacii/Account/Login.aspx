<%@ Page Title="Најавување" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="test.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Најави се</h2>
    <p>
        Најави се со своето корисничко име и лозинка. Доколку немаш корисничка сметка 
        тогаш треба да се регистрирате.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Регистрирај се </asp:HyperLink> доколку немаш корисничка сметка.
    </p>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
    RenderOuterTable="false" onauthenticate="LoginUser_Authenticate" 
    onloggedin="LoginUser_LoggedIn" 
        FailureText="Вашето најавување беше неуспешно. Ве молиме пробајте пак.">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Информации за корисникот:</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Корисничко име:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="Корисничкото име е задолжително!" ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Лозинка:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Лозинката е задолжителна:" ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Задржи ме најавен</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                        Text="Најави се" ValidationGroup="LoginUserValidationGroup" 
                        onclick="LoginButton_Click"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
