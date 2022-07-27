<%@ Page Title="" Language="C#" MasterPageFile="~/VDoctor/DoctorMP.Master" AutoEventWireup="true" CodeBehind="frmAccount.aspx.cs" Inherits="patternPrediction.VDoctor.frmAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>Update</span> Your Password!!</h2>
          
          <p class="infopost"></p>

        

        <br />
      <table style="width: 95%;">
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
                  &nbsp;</td>
              <td>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                      ControlToValidate="txtNewPassword" CssClass="validation" Display="Dynamic" 
                      ErrorMessage="Password Must be 8 Characters including 1 Uppercase letter, 1 Special Character and Alphanumeric Characters." 
                      ForeColor="#FF3300" 
                      ToolTip="Password Must be 8 Characters including 1 Uppercase letter, 1 Special Character and Alphanumeric Characters." 
                      ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" 
                      ValidationGroup="pwd">Password 
                                    Must be 8 Characters including 1 Uppercase letter, 1 Special Character and 
                                    Alphanumeric Characters.</asp:RegularExpressionValidator>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <b>Confirm Password</b></td>
              <td>
                  &nbsp; <span>
                  <asp:TextBox ID="txtConfirm" runat="server" Height="25px" TextMode="Password" 
                      Width="200px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp; <span>
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
              <td class="style1">
                  </td>
              <td class="style1">
                  <span>
                  <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                      Text="Update" ValidationGroup="pwd" />
                  </span>
              </td>
              <td class="style1">
                  </td>
          </tr>
      </table>







    <br />



          </div>


    </asp:Panel>

</asp:Content>
