﻿<%@ Page Title="" Language="C#" MasterPageFile="~/VDoctor/DoctorMP.Master" AutoEventWireup="true" CodeBehind="_EclatAlgorithm.aspx.cs" Inherits="patternPrediction.VDoctor._EclatAlgorithm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <!-- Start contact Area -->  
    <div id="about" class="about-area area-padding">
   <div class="container">
      <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="section-headline text-center">
            <h2><span>Pattern Prediction Module</span> (ECLAT Algorithm)!!</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <!-- single-well start-->
       
        <!-- single-well end-->
       
                           
                                                                       
                <h2><span></span> Pattern Prediction !!!</h2>
  <br />

    <asp:Table ID="Table4" runat="server">
    </asp:Table>
          <br />
          <asp:Table ID="Table5" runat="server">
          </asp:Table>
          <asp:Label ID="lblTreatment" runat="server"></asp:Label>
          <br />
          <br />
          <asp:Label ID="lblTime" runat="server"></asp:Label>
          <br />
    <br />
  

               
            
    <asp:Panel ID="Panel2" runat="server" Visible="False" Width="721px">
        <h2>
            <span>PATTERNS DETAILS</span> !!!</h2>
        <table style="width: 75%;">
            <tr>
                <td style="width: 351px" valign="top">
                    <strong>Distinct Items</strong></td>
                <td>
                    <strong>Dataset</strong></td>
            </tr>
             <tr>
                <td style="width: 351px" valign="top">
                    <asp:ListBox ID="lv_Items" runat="server" Height="175px" Width="211px">
                    </asp:ListBox>
                </td>
                <td style="width: 151px">
                    <asp:ListBox ID="lv_Transactions" runat="server" Height="175px" Width="324px">
                    </asp:ListBox>
                </td>
                <td style="width: 151px">
                    <asp:ListBox ID="lv_TransactionsId" runat="server" Height="175px" Width="150px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 75%;">
            <tr>
                <td>
                    <strong>Frequent Item Set (L)</strong></td>
                <td>
                    <strong>Final Output [displaying patterns]</strong></td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" Height="161px" Width="211px">
                    </asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Height="161px" Width="324px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>


        

     

        <!-- End col-->
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>

</asp:Content>
