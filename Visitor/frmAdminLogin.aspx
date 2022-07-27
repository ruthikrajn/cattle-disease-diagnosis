<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/VisitorMP.Master" AutoEventWireup="true" CodeBehind="frmAdminLogin.aspx.cs" Inherits="patternPrediction.Visitor.frmAdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>Admin Login Form</span> (Input Credentials)!!</h2>
          
          <p class="infopost"></p>
           <br />

           
     <table style="width: 50%;">
         <tr>
             <td style="font-size: medium">
               <b>Login Id</b></td>
             <td>
                 &nbsp;
             <span>
                 <asp:TextBox ID="txtLoginId" runat="server" Height="25px" Width="90%"></asp:TextBox>
                 </span>
             </td>
             <td>
                 &nbsp;
             <span>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ControlToValidate="txtLoginId" CssClass="validation" 
                     ErrorMessage="Enter LoginId" ToolTip="Enter LoginId" ValidationGroup="login"></asp:RequiredFieldValidator>
                 </span>
             </td>
         </tr>
         <tr>
             <td style="font-size: medium">
               <b> Password </b></td>
             <td>
                 &nbsp;
             <span>
                 <asp:TextBox ID="txtPassword" runat="server" Height="25px" TextMode="Password" 
                     Width="90%"></asp:TextBox>
                 </span>
             </td>
             <td>
                 &nbsp;
             <span>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ControlToValidate="txtPassword" CssClass="validation" 
                     ErrorMessage="Enter Password" ToolTip="Enter Password" ValidationGroup="login"></asp:RequiredFieldValidator>
                 </span>
             </td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 <span>
                 <asp:Button ID="btnLogin" runat="server" Text="Submit" 
                     ValidationGroup="login" onclick="btnLogin_Click" />
                 </span>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>

       <br />
         <asp:Image ID="Image1" runat="server" ImageUrl="~/images/fraud3.jpg" />
        

          <br />


          </div>


    </asp:Panel>
</asp:Content>
