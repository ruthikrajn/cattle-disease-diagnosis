<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="frmAddVDoctors.aspx.cs" Inherits="patternPrediction.Admin.frmAddVDoctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>Add</span> V Doctors!!</h2>
          
          <p class="infopost"></p>

        
         <br />

            <table style="width: 70%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center" class="style9">
                                                   </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                   <fieldset>
                                        <legend>Name</legend>
                                        <table align="center" style="width: 100%;">
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>City</strong></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListCity" runat="server" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                          <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>ID</strong></td>
                                                <td>
                                                    <asp:TextBox ID="txtICID" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                        ControlToValidate="txtICID" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Enter ICID" ValidationGroup="a">Enter ICID</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                                        ControlToValidate="txtICID" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Only Alphabets and Numbers Allowed" 
                                                        ValidationExpression="[a-zA-Z0-9]*$" ValidationGroup="a">Only Alphabets and Numbers Allowed</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>Branch Name</strong></td>
                                                <td>
                                                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtName" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Enter Name" ValidationGroup="a">Enter Name</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    </td>
                                                <td class="style1">
                                                    </td>
                                                <td class="style1">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                        ControlToValidate="txtName" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Only Alphabetes" ValidationExpression="^[a-zA-Z ]*$" 
                                                        ValidationGroup="a">Only Alphabetes</asp:RegularExpressionValidator>
                                                </td>
                                                <td class="style1">
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>Password</strong></td>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtPassword" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Enter Password" ValidationGroup="a">Enter Password</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                        ControlToValidate="txtPassword" CssClass="validation" Display="Dynamic" 
                                                        ErrorMessage="Password Must be 8 Characters including 1 Uppercase letter, 1 Special Character and Alphanumeric Characters." 
                                                        ForeColor="#FF3300" 
                                                        ToolTip="Password Must be 8 Characters including 1 Uppercase letter, 1 Special Character and Alphanumeric Characters." 
                                                        ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" 
                                                        ValidationGroup="a">Password 
                                    Must be 8 Characters including 1 Uppercase letter, 1 Special Character and 
                                    Alphanumeric Characters.</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>Address</strong></td>
                                                <td>
                                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txtAddress" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Enter Address" ValidationGroup="a">Enter Address</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    10 Digits Allowed</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>ContactNo</strong></td>
                                                <td>
                                                    <asp:TextBox ID="txtContactNo" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtContactNo" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Enter ContactNo" ValidationGroup="a">Enter ContactNo</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                        ControlToValidate="txtContactNo" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Invalid Mobile Number" ValidationExpression="^[6-9]\d{9}$" 
                                                        ValidationGroup="a">Invalid Mobile Number</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    Gmail/Yahoo/Rediff</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    <strong>EmailId</strong></td>
                                                <td>
                                                    <asp:TextBox ID="txtEmailId" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                        ControlToValidate="txtEmailId" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Enter EmailId" ValidationGroup="a">Enter EmailId</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                        ControlToValidate="txtEmailId" CssClass="validation" ErrorMessage="*" 
                                                        ToolTip="Invalid EmailId" 
                                                        ValidationExpression=".+@(gmail|yahoo|Gmail|Yahoo|rediff|Rediff)\.com$" 
                                                        ValidationGroup="a">Invalid EmailId</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnIC" runat="server" onclick="btnIC_Click" Text="Add" 
                                                        ValidationGroup="a" Width="75px" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        </fieldset>  
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                       
                                        <br />
                                        <table style="width: 50%;">
                                            <tr>
                                                <td class="style9">
                                                     <h2 class="title"><span>View V Doctors </span></h2></td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height:400px; width:auto; overflow:auto">
                                                    <asp:Table ID="tblICs" runat="server">
                                                    </asp:Table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        <br />

    <br />




          </div>


    </asp:Panel>
</asp:Content>
