<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_parent_guardian_HE.ascx.vb" Inherits="webcontrols_checkout_parent_guardian" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<script>

$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})

</script>
<!--
<br />
<div class="container">
   <div class="row">
      <div class="col-sm-12 columns form-group"> 
                <asp:Label runat="server" ID="lblAge"></asp:Label>
          </div>   

   </div>
       <div class="row">
         
       <div class="col-sm-12 columns form-group"> 
<asp:Label runat="server" ID="lblAgeCourse"></asp:Label>
          </div>
       </div>
    </div>
<br />
    -->
<!--
      <ol class="breadcrumb">
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li>Guardian - Emergency</li>                   
                    <li id="linkFurther" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <li id="lnkQuals" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Qualifications</a></li>
                     <li id="linkAttach" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                     <li id="linkDeclare"><a href="webenrolment.aspx?page=~/webcontrols/checkout_dataprotection.ascx">Declarations</a></li>
                </ol>
    -->
<br /><br />
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li><strong>Emergency Contact</strong></li>                   
                    <li>Further Details</li>
                    <li>Qualifications</li>
                   <li>Employment / Fees</li>
                     <li>Attachments</li>
                     <li>Photo</li>
                     <li >Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

<div class="container" id="parent2panel" runat="server">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
        <h2>Emergency contacts in case of accident or illness</h2>
          <p>Applies to all students - the College has a legitimate interest in ensuring the health and safety of all our students. The details of your emergency contact are detailed here.  The named person(s) will only be contacted for emergency purposes in the immediate health or safety interests of you as a student.  You must keep these details up to date and you must inform the individual(s) that you have disclosed their details to College.   </p>
    
          </div>
  </div>

     <div class="row">
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2FirstName" ID="StudentEnrolmentField9" runat="server" IsRequired="true"  CustomCaption="* First name"/>
        </div>
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2Surname" ID="StudentEnrolmentField12" runat="server" IsRequired="true"  CustomCaption="* Family name"/>
        </div>
    </div>
              <div class="row">
        <div class="col-sm-12 columns form-group"> 
                       <p><strong>You must provide at least one phone number below:</strong></p>
            </div>
       </div>
     <div class="row">
  <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2PhoneNumber" ID="StudentEnrolmentField2" runat="server" LabelWidth="200" IsRequired="false"  CustomCaption="* Mobile" Pattern="^(07[\d]{8,12}|447[\d]{7,11})$" />
     </div>
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2WorkTel" ID="StudentEnrolmentField14" runat="server" LabelWidth="200" IsRequired="false"  CustomCaption="* Work Number" Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?#(\d{4}|\d{3}))?$" />
     
            </div>
         </div>
           <div class="row">
                            <div class="col-sm-4 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2EmailAddress" ID="StudentEnrolmentField3" runat="server" IsRequired="false"   CustomCaption="Email Address" />
        </div>
               <div class="col-sm-4 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2RelationshipID" ID="StudentEnrolmentField24" runat="server" IsRequired="true"   CustomCaption="* Relationship" />
        </div>
                <div class="col-sm-4 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="IsLivingWithParent" ID="StudentEnrolmentField1" runat="server" IsRequired="false"   CustomCaption="I live with this person" />
        </div>
     </div>
</div>


        <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_enrolments_HE_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"   CausesValidation="true" EnableEnterKey="true" />
    <br />
              

