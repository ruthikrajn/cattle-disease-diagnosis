<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/VisitorMP.Master" AutoEventWireup="true" CodeBehind="_Prediction.aspx.cs" Inherits="patternPrediction.Visitor._Prediction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>Cattle Disease</span> Prediction!!</h2>
          
          <p class="infopost"></p>

         <br />
         <h3><strong>Symptoms:</strong> mouth-flow-foam, appetite-loss, muscle-tremor, manic-restlessness, bobbing-head, mouth-color-pale, Breast-enlargement-injury, 
                                        Vaginal-stench, Abnormal-tongue, Low-urine, yellow-urine, Wound-infection-pain, Abnormal-temperature, 
                                        abnormal-breathing, Abnormal-mouth-color, foreign-matter-feces, Ruminant-anomaly, Depressed</h3>

                                        <br />
      <table style="width: 80%;">
          <tr>
              <td>
                 <b>Enter Symptoms</b></td>
              <td>
                  &nbsp;
              <span>
                  <asp:TextBox ID="txtSymptoms" runat="server" Height="150px" 
                      TextMode="MultiLine" Width="450px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp;
              <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                      ControlToValidate="txtSymptoms" CssClass="validation" 
                      ErrorMessage="Enter Symptoms" ToolTip="Enter Symptoms" 
                      ValidationGroup="pwd"></asp:RequiredFieldValidator>
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
                      Text="Predict" ValidationGroup="pwd" />
                  </span>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>


          <br />
          <h2>Disease Name:</h2>
          <asp:Label ID="lblTreatment" runat="server"></asp:Label>


    <br />


     <br />


          </div>


    </asp:Panel>
</asp:Content>
