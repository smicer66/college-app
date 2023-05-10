<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_school_employer.ascx.vb" Inherits="webcontrols_checkout_school_employer" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<%--<script src="/js/jquery-1.10.2.js"></script>


  <script>
      $(function () {
          $(function () {
              $("#txtSchoolAttendedFrom").datepicker({ dateFormat: "dd/mm/yy" , changeMonth: true, changeYear: true })
              $("#txtSchoolAttendedTo").datepicker({ dateFormat: "dd/mm/yy" , changeMonth: true, changeYear: true })
          });
      });
  </script>
--%>

<br /><br />
                <ol class="breadcrumb"  id="breadcrumbapps" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications2.ascx">Further Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>
                  <li class="active">School / Employer</li>
                </ol>

                  <ol class="breadcrumb"  id="breadcrumbenrols" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>      
		<!--<li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>-->              
                  <li class="active">School / Employer</li>
                </ol>

 
 <asp:Panel ID= "pnlSchool" Visible="true"   runat = "server">
    <div id="schoolpanel" runat="server" class="panel panel-info">
     <a href="#" class="show_hide1"><div class="panel-heading">School Details</div></a>
<div class="slidingDiv1">
    <div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SchoolID" ID="fldSchoolID" runat="server" IsRequired="false" LabelWidth="300"
            CustomCaption="Last school/college attended" />
    </div>
    <div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SchoolAttendedFrom" ID="StudentEnrolmentField1" runat="server" IsRequired="false" LabelWidth="300"
           CustomFieldType="Date" CustomCaption="Date From" ClientIDMode="Static" HTML5InputType ="date"  Placeholder ="dd/mm/yyyy" />
    </div>
    <div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SchoolAttendedTo" ID="StudentEnrolmentField2" runat="server" IsRequired="false" LabelWidth="300"
           CustomFieldType="Date" CustomCaption="Date To" ClientIDMode="Static" HTML5InputType ="date" Placeholder ="dd/mm/yyyy" />
    </div>
</div>
</div>
</asp:Panel> 

<br /><br />

<div id="employerpanel" runat="server" class="panel panel-info" ClientIDMode="static">
     <a href="#" class="show_hide2"><div class="panel-heading">Employment Details</div></a>
<div class="slidingDiv2">
    <%--<div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerID" ID="fldEmployerID" runat="server" IsRequired="false" LabelWidth="300"
           CustomCaption="Current Employer" ClientIDMode="Static" />
    </div>
    <div id="empnote" runat="server" class="alert alert-info">If you can't find your employer in the list, you can enter the name here instead</div>--%>
    <div>If you are employed or self-employed please provide contact details for your organisation:</div>
    <hr />
   
    <div class=" form-group">        
    <asp:Label ID="lblEmploymentStatus" Text="Employment Status *" runat ="server"></asp:Label><br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpEmpStatus" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true" Autopostback ="true" >
    <asp:ListItem Text ="" Value =""></asp:ListItem>
    <asp:ListItem Text ="Self Employed" Value ="9"></asp:ListItem> 
    <asp:ListItem Text ="In Paid Employment" Value ="10"></asp:ListItem>
    <asp:ListItem Text ="Unemployed, looking for work and available to start work" Value ="11"></asp:ListItem>
    <asp:ListItem Text ="Unemployed, not looking for work and/or not available to start work" Value ="12"></asp:ListItem>
    </asp:DropDownList>

    </div>  

    <asp:Panel ID= "pnlUnEmploymentDetails" Visible="false"   runat = "server">   
    <div class=" form-group">
     <cc1:StudentEmploymentHistoryField ID="fldLengthofUnEmployment" StudentEmploymentHistoryFieldType ="LengthOfUnemploymentID"  runat="server" IsRequired="false" LabelWidth="300" CustomCaption="Length of Unemployment"/>         
    </div>  
    <div class=" form-group">
     <cc1:StudentEmploymentHistoryField ID="fldUnEmploymentDateFrom" StudentEmploymentHistoryFieldType ="DateFrom"   runat="server" IsRequired="false" LabelWidth="300" CustomCaption="Date From" CustomFieldType ="Date"/>              
    </div>
    </asp:Panel> 
      
    <asp:Panel ID= "pnlEmployed" Visible="false"   runat = "server">    
    <div class=" form-group">
     <cc1:StudentEmploymentHistoryField ID="fldLengthofEmployment" StudentEmploymentHistoryFieldType ="LengthOfEmploymentID"  runat="server" IsRequired="false" LabelWidth="300" CustomCaption="Length of Employment"/>         
    </div> 
    <div class=" form-group">
     <cc1:StudentEmploymentHistoryField ID="fldEmploymentIntensity" StudentEmploymentHistoryFieldType ="EmploymentIntensityID"  runat="server" IsRequired="false" LabelWidth="300" CustomCaption="Employment Intensity *"/>         
    </div>  
    <div class=" form-group">
     <cc1:StudentEmploymentHistoryField ID="fldDateFrom" StudentEmploymentHistoryFieldType ="DateFrom"   runat="server" IsRequired="false" LabelWidth="300" CustomCaption="Date From" CustomFieldType ="Date"/>              
    </div>
    </asp:Panel> 
    <asp:Panel ID= "pnlEmployerDetails" Visible="false"   runat = "server">
    <%--<div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerName" ID="fldEmployerName" runat="server" IsRequired="false" LabelWidth="300"
           CustomCaption="Organisation/company name" ClientIDMode="Static"/>
    </div>--%>
    

    
    <%--<div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerAddress1" ID="StudentEnrolmentField4" runat="server" IsRequired="false" LabelWidth="300"
           CustomCaption="Address" />
    </div>--%>
   <%-- <div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerAddress2" ID="StudentEnrolmentField5" runat="server" IsRequired="false" LabelWidth="300"
           CustomCaption=" " />
    </div>--%>

   <%--<div class=" form-group">
         <label for="employerpostcode" style="width:300px;font-weight:normal; ">Postcode</label><input type="text" class="form-control" runat="server"  id="employerpostcode" title="Postcode" placeholder="Enter Postcode" />
    </div>--%>
    <%--<div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerTel"  ID="StudentEnrolmentField9" runat="server" IsRequired="false" LabelWidth="300"
           CustomCaption="Telephone number" />
    </div>--%>
    <%--<div class=" form-group">
         <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerEmail" ID="StudentEnrolmentField8" runat="server" IsRequired="false" LabelWidth="300"
           CustomCaption="Organisation email address" />
    </div>--%>
    </asp:Panel>
   
    
</div>
</div>



 <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_enrolments2_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="checkout_priorattainment_aspx" CausesValidation="true" EnableEnterKey="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />




<script type="text/javascript">

    $(document).ready(function () {

        $(".slidingDiv1").show();
        $(".slidingDiv2").show();
        $(".show_hide1").show();
        $(".show_hide2").show();

        $('.show_hide1').click(function () {
            $(".slidingDiv1").slideToggle();
        });

        $('.show_hide2').click(function () {
            $(".slidingDiv2").slideToggle();
        });

        
       // $('#cboEmployerID').change(function () {
       //     var value = $("#cboEmployerID option:selected").val();

        //    if (value>0) {
       //         $('#txtEmployerName').prop('disabled', 'true');            
       //     };
       // });

        $(".select").keydown(function (event) {
            if (event.which != 46) // not delete key
                return;
            var sel = $(this);
            var val = sel.val();
            if (val != "")
                sel.find("option[value=" + val + "]").remove();
        });



    });

</script>
