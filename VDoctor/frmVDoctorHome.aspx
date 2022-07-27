<%@ Page Title="" Language="C#" MasterPageFile="~/VDoctor/DoctorMP.Master" AutoEventWireup="true" CodeBehind="frmVDoctorHome.aspx.cs" Inherits="patternPrediction.VDoctor.frmVDoctorHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>Welcome</span> Incharger (V Doctor)!!</h2>
          
          <p class="infopost"></p>
                 
          <table style="width: 100%;">
             <tr>
                 <td>
                     &nbsp;
                     <asp:Label ID="lblAdminId" runat="server"></asp:Label>
                 </td>
                 <td>
                     &nbsp;
                 </td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
         </table>
         <p>Login - here doctor can get login by specifying id and password (given by admin)</p>
<p>Manage Data-set - here doctor can manage the data-set (medical data-set) of        previous years.</p>
<p>Import Excel Sheet (if data stored in excel sheet) - import data from excel sheet.</p>
<p>Prediction module - Proposed system uses data science techniques to identify the cattle disease symptoms, disease types and treatments and to predict the patterns. Proposed system uses data science technique "Eclat algorithm" to find the patterns.  The selected algorithm is an efficient algorithm in all prospects and process data faster and generates results in less time.</p>
<p>Result Analysis - here algorithms results displayed on GUI.</p>
<p>Finding Efficiency of the Algorithm</p>
<p>Change Password - here incharge can update password.</p>
<p>ogout - logout from the system.</p>
      
            <br />




          </div>


    </asp:Panel>

</asp:Content>
