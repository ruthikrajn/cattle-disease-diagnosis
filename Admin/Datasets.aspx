<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="Datasets.aspx.cs" Inherits="patternPrediction.Admin.Datasets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2>Training Datasets!!</h2>
          
          <p class="infopost"></p>

         <br />


			
   <div style="height:550px; width:auto; overflow:auto">
<asp:GridView ID="GridView1" runat="server" BackColor="White" 
         BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" BorderStyle="None">

    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle ForeColor="#000066" 
        HorizontalAlign="Left" BackColor="White" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />

</asp:GridView>

</div>




     <br />


          </div>


    </asp:Panel>
</asp:Content>
