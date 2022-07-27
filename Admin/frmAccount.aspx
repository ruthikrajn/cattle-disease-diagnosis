<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="frmAccount.aspx.cs" Inherits="patternPrediction.Admin.frmAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>Update</span> Your Password!!</h2>
          
          <p class="infopost"></p>

         <br />
      <table style="width: 60%;">
          <tr>
              <td>
                 <b>Enter Old Password</b>
              </td>
              <td>
                  &nbsp;
              <span>
                  <asp:TextBox ID="txtOldPassword" runat="server" Height="25px" 
                      TextMode="Password" Width="200px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp;
              <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                      ControlToValidate="txtOldPassword" CssClass="validation" 
                      ErrorMessage="Enter OldPassword" ToolTip="Enter OldPassword" 
                      ValidationGroup="pwd"></asp:RequiredFieldValidator>
                  </span>
              </td>
          </tr>
          <tr>
              <td>
                  <b>Enter New Password</b></td>
              <td>
                  &nbsp;
              <span>
                  <asp:TextBox ID="txtNewPassword" runat="server" Height="25px" 
                      TextMode="Password" Width="200px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp;
              <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                      ControlToValidate="txtNewPassword" CssClass="validation" 
                      ErrorMessage="Enter New Password" ToolTip="Enter New Password" 
                      ValidationGroup="pwd"></asp:RequiredFieldValidator>
                  </span>
              </td>
          </tr>
          <tr>
              <td>
                  <b>Confirm Password</b></td>
              <td>
                  &nbsp;
              <span>
                  <asp:TextBox ID="txtConfirm" runat="server" Height="25px" TextMode="Password" 
                      Width="200px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp;
              <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                      ControlToValidate="txtConfirm" CssClass="validation" 
                      ErrorMessage="Enter Confirm Password" ToolTip="Enter Confirm Password" 
                      ValidationGroup="pwd"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
                      ControlToCompare="txtNewPassword" ControlToValidate="txtConfirm" 
                      CssClass="validation" ErrorMessage="mismatch" ToolTip="mismatch" 
                      ValidationGroup="pwd"></asp:CompareValidator>
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
                  <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                      Text="Update" ValidationGroup="pwd" />
                  </span>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>


    <br />
         <asp:Image ID="Image1" runat="server" ImageUrl="~/images/fraud4.jpg" 
              Width="500px" />


     <br />


          </div>


    </asp:Panel>

</asp:Content>
