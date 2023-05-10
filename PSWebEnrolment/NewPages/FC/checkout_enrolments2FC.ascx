<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_enrolments2FC.ascx.vb" Inherits="webcontrols_checkout_enrolments2" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<script>

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

</script>
<!--<br />
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
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Guardian - Emergency</a></li>                   
                    <li>Further Details</li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Qualifications</a></li>
 
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                     <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_dataprotection.ascx">Declarations</a></li>
                </ol>
    -->
<br />
<br />
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li><strong>Further Details</strong></li>
                      <li>Employment Details</li>
                    <li>Attachments</li>
                        <li>Photo</li>
                      <li>Declarations</li>
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
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2MobileTel" ID="StudentEnrolmentField2" runat="server" LabelWidth="200" IsRequired="false"  CustomCaption="* Mobile" Pattern="^(07[\d]{8,12}|447[\d]{7,11})$" />
      <button type="button" class="btn btn-primary" data-toggle="tooltip" data-placement="bottom" title="The format of the mobile must be beginning 07, with no spaces and 11 digits in length eg 07771900900">
Hover over me for Mobile format
</button>    </div>
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2PhoneNumber" ID="StudentEnrolmentField14" runat="server" LabelWidth="200" IsRequired="false"  CustomCaption="* Home Telephone" Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$" />
       <button type="button" class="btn btn-primary" data-toggle="tooltip" data-placement="bottom" title="The format of the home telephone must be a UK standard number begining with 0, with no spaces eg 01273800900">
Hover over me for Telephone format
</button> 
            </div>
         </div>
           <div class="row">
            <div class="col-sm-12 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2RelationshipID" ID="StudentEnrolmentField24" runat="server" IsRequired="true"   CustomCaption="* Relationship" />
        </div>
     </div>
    <p>The named person(s) will only be contacted for emergency purposes in the immediate health or safety interests of you as a student.  You must keep these details up to date and you must inform the individual(s) that you have disclosed their details to College.</p>
</div>

<h2>Learning Difficulties / Disabilities </h2>

<div class="container">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
          <span class="textfieldlabelrequired">* Do you have any learning / disabilities?</span>
      
            <asp:DropDownList runat="server" ID="selectLearnDiff"  CssClass="textfield form-control" >
                <asp:ListItem Text="Please select..." Value=""></asp:ListItem>
                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                <asp:ListItem Text="Rather not say" Value="9"></asp:ListItem>
            </asp:DropDownList>
          <div style="display:none">
             <cc1:StudentEnrolmentField Visible="true" ClientIDMode="Static" StudentEnrolmentFieldType="LearningDiffOrDisID" ID="fldLearningDiffOrDisID" runat="server" IsRequired="false"   />
                 <cc1:StudentEnrolmentField Visible="true" ClientIDMode="Static" StudentEnrolmentFieldType="ALSRequired" ID="StudentEnrolmentField1" runat="server" IsRequired="false" DefaultValue="0"  />
    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EuroResidentID" runat="server" Visible="false" IsRequired="false"  LabelWidth="300" CustomCaption="And, if appropriate, a secondary learning difficulty" DefaultValue="1" />
              </div>
          </div>
    </div>
    <div class="row"  id="disfields">
      <div class="col-sm-12 columns form-group"> 
             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory1ID" ID="stuDisabilityCategory1ID" runat="server" LabelWidth="300" IsRequired="false" CustomCaption="* Please specify main learning/disability" ExcludedIDValues="99"/>
              <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory2ID" runat="server" Visible="false" IsRequired="false"  LabelWidth="300" CustomCaption="And, if appropriate, a secondary learning difficulty" />
             
     
          </div>
      </div>
   

 </div>


       <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_enrolments_FC_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" CausesValidation="true" LinkResource="checkout_employment_FC_aspx" />

    <script type="text/javascript">
        $(document).ready(function () {


           $("#disfields").hide();
        if ($("#<%=selectLearnDiff.ClientID%>").val() == "1") {
                $("#disfields").show();
            }
            $('#<%= selectLearnDiff.ClientID %>').change(function () {
              //  $('#cboLearningDiffOrDisID').val($(this).val());
            if ($("#<%=selectLearnDiff.ClientID%>").val() == "1") {
                    $("#disfields").show();
                    return;
                }
                else {
                    $("#disfields").hide();
                }
            });


        });
    </script>