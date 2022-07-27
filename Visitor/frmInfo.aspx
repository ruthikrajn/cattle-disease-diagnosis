<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/VisitorMP.Master" AutoEventWireup="true" CodeBehind="frmInfo.aspx.cs" Inherits="patternPrediction.Visitor.frmInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

     <div class="article">
          <h2><span>About Cattle</span> Diseases !!!</h2>
          
          <p class="infopost"></p>

          <p>With the rapid development of big data and artificial intelligence, data analysis and mining are becoming more and more widely used in animal husbandry. In this system, a large number of multi-source cattle electronic medical record data are collected and used the data analysis and mining technology to realize the intelligent diagnosis system for cattle diseases. Firstly, the text preprocessing technology is used to remove the repetition on the cattle electronic medical record data, remove the stop words, word segmentation etc. Finally, the Apriori algorithm is used to correlate the specific disease name and the probability of the disease, giving the corresponding treatment plan. The system can treat the diseases in time, reduce the losses of herders effectively and realize the development of scientific intelligence in animal husbandry. We can develop this concept as an real time application which is useful for veterinary doctors to handle the cattle diseases in a better way. System finds the correlation between cattle disease symptoms, disease types and treatment given using data science technique “apriori algorithm”. </p>


          <p>Manual process of identifying the cattle disease and treatment is too complex and time consuming and also expensive. These systems just collects the data, stores in database and retrieves the same in future, but no extraction of useful information which helps the medical practitioners to handle the cattle disease in a better way.</p>

          <p>In real time it is difficult to handle the cattle disease symptoms and disease types as animals cant explain their problems or pain that they are facing. In medical sector finding the cattle disease symptoms, diseases is a challenging task. Proposed system major objective is to find the cattle disease symptoms and then predicting the correlation between symptoms-diseases-treatments. As in current system it is difficult to identify the cattle disease and also its difficult to give the proper treatments.</p>

          <p>Proposed system uses data science techniques to identify the cattle disease symptoms and to predict the patterns. Proposed system used "lesk based algorithm" to identify the symptoms and then it uses data science technique "apriori algorithm" to find the patterns. System planned to build as real time application which is useful to doctors to handle the cattle disease. We use "Visual Studio" as front end technology and "SQL Server" as back end technology, as both technologies supports more libraries and tools to work with real time applications.</p>
          

           
          </div>
         

         

    </asp:Panel>
</asp:Content>
