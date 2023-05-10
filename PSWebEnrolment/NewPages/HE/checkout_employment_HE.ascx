<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_employment_HE.ascx.vb" Inherits="webcontrols_checkout_employment" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<br /><br />
                <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Emergency contact</li>                   
                    <li>Further Details</li>
                     <li><strong>Employment</strong></li>
                     <li>Attachments</li>
                    <li>Photo</li>
                     <li>Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

    
       <script type="text/javascript">
         $(document).ready(function () {

            $("#divpay").hide();
            $("#divloan").hide();             
            $("#divEmp").hide();
       //    $("#divEmployerName").hide();  //030821
           $("#divEmployerDet1").hide();
             $("#divLoanQuestions").hide();
             if ($("#<%=ddlFee.ClientID%>").val() == "1") {
                     $("#divpay").show();
                 }
            if ($("#<%=ddlFee.ClientID%>").val() == "H")  {
                $("#divloan").show();
                $("#divLoanQuestions").show();
             }
            if ($("#<%=ddlFee.ClientID%>").val() == "H1")  {
                $("#divloan").show();
                $("#divLoanQuestions").show();
             }
            if ($("#<%=ddlFee.ClientID%>").val() == "H2")  {
                $("#divloan").show();
                $("#divLoanQuestions").show();
             }
             if ($("#<%=ddlFee.ClientID%>").val() == "3")  {
                $("#divEmp").show();

                       // $("#divEmployerName").show();  //030821
                       //  $("#divEmployerDet1").show();
             }
           
           $('#<%= ddlFee.ClientID %>').change(function () {
            $("#divpay").hide();
            $("#divloan").hide();             
            $("#divEmp").hide();
  $("#divLoanQuestions").hide();
            //     $("#divEmployerName").hide();   //030821
              //  $("#divEmployerDet1").hide();
              //student
                if ($("#<%=ddlFee.ClientID%>").val() == "1") {
                     $("#divpay").show();
                     $("#divloan").hide();             
                    $("#divEmp").hide();
                }
                //loan
                if ($("#<%=ddlFee.ClientID%>").val() == "H") {
                        $("#divpay").hide();
                     $("#divloan").show();             
                    $("#divEmp").hide();
                     $("#divLoanQuestions").show();
                    return;
                }
                //loan
                if ($("#<%=ddlFee.ClientID%>").val() == "H1") {
                        $("#divpay").hide();
                     $("#divloan").show();             
                    $("#divEmp").hide();
                     $("#divLoanQuestions").show();
                    return;
                }
                //loan
                if ($("#<%=ddlFee.ClientID%>").val() == "H2") {
                        $("#divpay").hide();
                     $("#divloan").show();             
                    $("#divEmp").hide();
                     $("#divLoanQuestions").show();
                    return;
                }
                //employer
                if ($("#<%=ddlFee.ClientID%>").val() == "3") {
                        $("#divpay").hide();
                     $("#divloan").hide();             
                    $("#divEmp").show();
                   //     $("#divEmployerName").show(); //030821
                    //     $("#divEmployerDet1").show();
                    return;
                }
            });
         if ($("#<%=selectEmployed.ClientID%>").val() == "10") {
                     $("#divEmploymentLength").show();
                     $("#divEmploymentIntensity").show();
                    //    $("#divEmployerName").show(); 
                    //     $("#divEmployerDet1").show();
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
               <div class="col-sm-12 columns form-group"> 
                   <p>How to pay – fees are normally paid in full at the time of enrolment or evidence of funding must be provided. Please ensure you have read the fees policy, which includes the refund policy, before proceeding which can be found at <a href="http://www.cityofbristol.ac.uk/about-us/college-policies/fees-policy/" target="_blank">http://www.cityofbristol.ac.uk/about-us/college-policies/fees-policy/</a></p>

               </div>
              </div>
     <div class="row">
 <div class="col-sm-12 columns form-group"> <span class="textfieldlabelrequired">* Who is paying the annual fee?</span>
<asp:DropDownList runat="server" ID="ddlFee" CssClass="textfield form-control">
    <asp:ListItem value="">Please select...</asp:ListItem>
    <asp:ListItem Text="I am paying my own fees*" Value="1"></asp:ListItem>
     <asp:ListItem Text="Student Loan - my application has been submitted and is being processed*" Value="H"></asp:ListItem>
         <asp:ListItem Text="Student Loan - my application has been submitted and has been approved*" Value="H1"></asp:ListItem>
    <asp:ListItem Text="Student Loan - I have not yet applied for a Student Loan but intend to*" Value="H2"></asp:ListItem>
     <asp:ListItem Text="My employer is paying my fees*" Value="3"></asp:ListItem>
        

</asp:DropDownList>
     </div> 
         </div>
        <div class="row" id="divpay" >
 <div class="col-sm-12 columns form-group"><strong>*If you are paying, we will call you for payment. I understand that I am responsible for declaring the above information for subsequent years of this course. I also understand that I am liable for those fees. </strong>
     </div></div>
        <div class="row" id="divloan" >
 <div class="col-sm-12 columns form-group"><strong>*If you are paying using a loan, you will need to provide us with further evidence. I understand that I am responsible for declaring the above information for subsequent years of this course. I also understand that I am liable for those fees. </strong>
 <p>         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined11" ID="fldslc" runat="server" IsRequired="false" LabelWidth="600" CustomCaption="Do you have reference from the Student Loan Company (eg SLC/SSN Ref/Customer Ref)?"/>
  </p>    
 </div>

        </div>
                <div class="row" id="divEmp">
 <div class="col-sm-12 columns form-group"><strong>*If your employer is paying for the fees, you will need to provide a letter from your employer giving us Authority to Invoice or a letter confirming your employer will be paying along with their billing details. I understand that I am responsible for declaring the above information for subsequent years of this course. I also understand that I or my employer are liable for those fees. </strong>
     </div></div>

         <div class="row" id="divLoanQuestions" style="display:none">
         
             </div>
           <div class="row" id="divEmployerName" style="display:none">
      
           
         <div class="col-sm-4 columns form-group"> 
        
                 <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="EmployerName"  ID="Field_employername" runat="server" IsRequired="false" LabelWidth="200"
           CustomCaption="*Employer Name" CssClass="textfieldlabelrequired" />
 
          </div>
             <div class="col-sm-4 columns form-group"> 
         
                 <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="ContactTel"  ID="StudentEmploymentHistoryField3" runat="server" IsRequired="false" LabelWidth="200"
           CustomCaption="*Telephone"  CssClass="textfieldlabelrequired"/>
 
          </div>
            <div class="col-sm-4 columns form-group"> <cc1:StudentEmploymentHistoryField StudentEmploymentHistoryFieldType="Email"  ID="StudentEmploymentHistoryField4" runat="server" IsRequired="false" LabelWidth="200"
           CustomCaption="*Email"  CssClass="textfieldlabelrequired"/>
      </div>
         </div>
          
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
               <div class="col-sm-4 columns form-group"> 
     
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SocioEconomicClassID" ID="StudentEnrolmentField30" runat="server" LabelWidth="500" CustomCaption="*Which best describes your occupation?" IsRequired="false"  CssClass="textfieldlabelrequired" />
        
          </div>
         <div class="col-sm-4 columns form-group"> 
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SOCOccupationID" ID="StudentEnrolmentField9" runat="server" LabelWidth="500" CustomCaption="*What industry do you work in?" IsRequired="false"  CssClass="textfieldlabelrequired"/>

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
        <h2>Qualifications</h2>
             <div class="row">
               <div class="col-sm-12 columns form-group"> 
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HEQualsOnEntryID" ID="StudentEnrolmentField29" runat="server" LabelWidth="500" CustomCaption="* Select the highest qualification that you have achieved from the list below" IsRequired="True" Visible="true" />
   
               </div>
              </div>
    </div>
      
<!--
  <asp:button runat="server" id="btnNoPreviousEmployment" cssClass="show_hide btn btn-primary" text="No previous employment" ToolTip="Click to remove all the items listed below (And hide the list)"></asp:button>
    <br />
    -->
 <cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_enrolments2_he_aspx" />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  CausesValidation="true" />
<br />

