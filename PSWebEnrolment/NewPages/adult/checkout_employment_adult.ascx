<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_employment_adult.ascx.vb" Inherits="webcontrols_checkout_employment" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<br /><br />
                <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Emergency contact</li>                   
                    <li>Further Details</li>
                     <li>Qualifications</li>
                     <li><strong>Employment</strong></li>
                     <li>Attachments</li>
                    <li>Photo</li>
                     <li>Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

    
       <script type="text/javascript">
         $(document).ready(function () {

                 
            $("#divEmp").hide();
       //    $("#divEmployerName").hide();  //030821
       

         if ($("#<%=selectEmployed.ClientID%>").val() == "10") {
                     $("#divEmploymentLength").show();
                     $("#divEmploymentIntensity").show();
                  
                 }
                 else if (($("#<%=selectEmployed.ClientID%>").val() == "11") || $("#<%=selectEmployed.ClientID%>").val() == "12") {
                $("#divUnEmploymentLength").show();
             }
             $('#<%= selectEmployed.ClientID %>').change(function () {
                 $("#divEmploymentLength").hide();
                 $("#divEmploymentIntensity").hide();
               //  $("#divEmployerName").hide();
                 $("#divUnEmploymentLength").hide();
                //   $("#divEmployerDet1").hide();
                 $("#<%=selectEmploymentLength.ClientID%>").val("")
                 $("#<%=selectEmploymentIntensity.ClientID%>").val("")
                 $("#<%=selectLengthUnemployed.ClientID%>").val("")
                  $("#<%=selectBenefits.ClientID%>").val("")
                 if ($("#<%=selectEmployed.ClientID%>").val() == "10") {
                     $("#divEmploymentLength").show();
                     $("#divEmploymentIntensity").show();
            //            $("#divEmployerName").show();
                 //    $("#divEmployerDet1").show();
                     return;
                 }
                 else if (($("#<%=selectEmployed.ClientID%>").val() == "11") || $("#<%=selectEmployed.ClientID%>").val() == "12") {
                     $("#divUnEmploymentLength").show();
                     return;
                 }
             });

         });
 
       </script>
        <h2>Employment Status</h2>
    <div class="container">
      
  
     
      <div class="row">

         <%-- Example of field pulled from cc1:StudentEmploymentHistory (Auto Maps to ProSol field) --%>

  <%--        <h4>Employment</h4>   
    
      <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="alert-danger" />

    <div class=" form-group">
         <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="EmploymentStatusID" ID = "Field_EmploymentStatusID" runat="server" IsRequired="True" LabelWidth="200"
           CustomCaption="Employment Status" ClientIDMode="Static" 
             ExcludedIDValues="98" />

    </div>

            <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="EmploymentStatusID" ID = "Field_EmploymentStatusID" runat="server" IsRequired="True" LabelWidth="200"
           CustomCaption="Employment Status" ClientIDMode="Static" 
             ExcludedIDValues="98" />
            <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="EmploymentIntensityID" ID = "StudentEmploymentHistoryField1" runat="server" IsRequired="True" LabelWidth="200"
           CustomCaption="Employment Intensity" ClientIDMode="Static" 
             ExcludedIDValues="98"/>
            <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="LengthOfEmploymentID" ID = "StudentEmploymentHistoryField2" runat="server" IsRequired="True" LabelWidth="200"
           CustomCaption="Employment Length" ClientIDMode="Static" 
             ExcludedIDValues="98" />--%>

        <div class="col-sm-12 columns form-group"> 
             <span class="textfieldlabelrequired">* Please tell us your employment status</span>
             <asp:DropDownList ID="selectEmployed" runat="server"   CssClass="textfield form-control" EnableViewState="true">
             <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="10">In paid employment</asp:ListItem>
            <asp:ListItem value="11">Not in paid employment, looking for work and available to start work</asp:ListItem>
            <asp:ListItem value="12">Not in paid employment, not looking for work and/or not available to start work</asp:ListItem>
             </asp:DropDownList>
          </div>
      </div>
    <!-- START YES Employed - These are all related to YES employed -->


      <div class="row"  id="divEmploymentLength" style="display:none">
          <div class="col-sm-3 columns form-group"> 
         <span class="textfieldlabelrequired">Are you self Employed?</span>
        <asp:RadioButtonList runat="server" ID="rdoSelfEmp" CssClass="textfield form-control radiofield" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
            <asp:ListItem Text="No" Value="0"></asp:ListItem>        
        </asp:RadioButtonList>
              </div>
        <div class="col-sm-3 columns form-group"> 
              <span class="textfieldlabelrequired">* Length of time in employment</span>
             <asp:DropDownList ID="selectEmploymentLength" runat="server"   CssClass="textfield form-control" EnableViewState="true">
             <asp:ListItem value="">Please select...</asp:ListItem>
                 <asp:ListItem value="1">Upto 3 months</asp:ListItem>
             <asp:ListItem value="2">4-6 months</asp:ListItem>
            <asp:ListItem value="3">7-12 months</asp:ListItem>
                 <asp:ListItem value="4">Over 12 months</asp:ListItem>
             </asp:DropDownList>
          </div>
            <div class="col-sm-3 columns form-group"> 
              <span class="textfieldlabelrequired">* Hours per week</span>
             <asp:DropDownList ID="selectEmploymentIntensity" runat="server"   CssClass="textfield form-control" EnableViewState="true">
             <asp:ListItem value="">Please select...</asp:ListItem>
                 <asp:ListItem value="5">Employed for 0 to 10 hours per week</asp:ListItem>
             <asp:ListItem value="6">Employed for 11 to 20 hours per week</asp:ListItem>
            <asp:ListItem value="7">Employed for 21 to 30 hours per week</asp:ListItem>
                 <asp:ListItem value="8">Employed for 31+ hours per week</asp:ListItem>
             </asp:DropDownList>
          </div>
          <div  class="col-sm-3 columns form-group">
               <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel2" ID="StudentEnrolmentField1" runat="server" LabelWidth="300" CustomCaption="Your work telephone?" IsRequired="false"  />
      
          </div>
      </div>
     <div class="row"  id="divEmploymentIntensity" style="display:none">
      
              <div class="col-sm-4 columns form-group"> 
                 <span class="textfieldlabelrequired">* Employed From date</span>
            <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="DateFrom"  ID="StudentEmploymentHistoryField2" runat="server" IsRequired="false" Width="150" CustomFieldType="Date"
           CustomCaption=" " />
          </div>
 
    
      </div>

  
     
   <div class="row"  id="divUnEmploymentLength" style="display:none">
        <div class="col-sm-3 columns form-group"> 
              <span class="textfieldlabelrequired">* Length of time unemployed</span>
             <asp:DropDownList ID="selectLengthUnemployed" runat="server"  CssClass="textfield form-control" EnableViewState="true">
             <asp:ListItem value="">Please select...</asp:ListItem>
                 <asp:ListItem value="1">Less than 6 months</asp:ListItem>
             <asp:ListItem value="2">6-11 months</asp:ListItem>
            <asp:ListItem value="3">12-23 months</asp:ListItem>
                 <asp:ListItem value="4">24-25 months</asp:ListItem>
                          <asp:ListItem value="5">Over 36 months</asp:ListItem>
             </asp:DropDownList>
          </div>
               <div class="col-sm-3 columns form-group"> 
              <span class="textfieldlabelrequired">* Do you receive any benefits?</span>
             <asp:DropDownList ID="selectBenefits" runat="server"  CssClass="textfield form-control" EnableViewState="true">
            <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="01">I am in receipt of Jobseekers’ Allowance</asp:ListItem>
             <asp:ListItem value="05">I am in receipt of Employment and Support Allowance in a Work Related Activity Group</asp:ListItem>
             <asp:ListItem value="04">I am in receipt of Universal Credit </asp:ListItem>
             <asp:ListItem value="06">I am receiving another state benefit not listed above</asp:ListItem>
                    <asp:ListItem value="99">Not in receipt of benefits</asp:ListItem>
         </asp:DropDownList>
                   </div>
          
      </div>
    </div>
      
<!--
  <asp:button runat="server" id="btnNoPreviousEmployment" cssClass="show_hide btn btn-primary" text="No previous employment" ToolTip="Click to remove all the items listed below (And hide the list)"></asp:button>
    <br />
    -->
 <cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_quals_on_entry_adult_aspx" />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  CausesValidation="true" />
<br />

