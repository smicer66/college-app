<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_parent_guardian.ascx.vb" Inherits="webcontrols_checkout_parent_guardian" %>

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
<br />
<br />
<div class="progress" style="height: 20px;">
  <div class="progress-bar" role="progressbar" style="width:30%;" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100"></div>
</div>
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li><strong>Guardian / Emergency</strong></li>                   
                    <li>Further Details</li>

                     <li>Attachments</li>
                     <li>Photo</li>
                     <li >Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

<div class="container" runat="server">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
           <h2>Parent / Guardian</h2>
          </div>
  </div>
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentFirstName" ID="fldParentFirstName" runat="server" IsRequired="true" CustomCaption="* First name"/>
          </div>
       <div class="col-sm-6 columns form-group"> 
                 <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentSurname" ID="fldParentSurname" runat="server" IsRequired="true"  CustomCaption="* Family Name"/>
          </div>
   </div>
          <div class="row">
        <div class="col-sm-12 columns form-group"> 
                       <p><strong>You must provide at least one phone number below:</strong></p>
            </div>
       </div>
    <div class="row">
    <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentPhoneNumber" ID="StudentEmailField1" runat="server" IsRequired="false" LabelWidth="300" CustomCaption="* Mobile (no spaces)"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$" Placeholder="e.g. 0xxxxxxxxxx"  Title="Please enter a valid phone number" />
    
        </div>
       <div class="col-sm-6 columns form-group">
                   <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentWorkTel" ID="StudentEnrolmentField10" runat="server" LabelWidth="300"  CustomCaption="* Work Number (no spaces)" Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$" Placeholder="e.g. 0xxxxxxxxxx"  Title="Please enter a valid phone number"/>
     
    </div>
     </div>
     <div class="row">
        <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentEmailAddress" ID="StudentEnrolmentField11" runat="server" CustomCaption="* Email address" IsRequired="true" LabelWidth="400" Pattern="^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"/>
        </div>
         <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact1RelationshipID" ID="StudentEnrolmentField19" runat="server" IsRequired="true"  CustomCaption="* Relationship" />
            </div>
     </div>
      <div class="row">
        <div class="col-sm-12 columns form-group">
             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="IsLivingWithParent" ID="StudentEnrolmentField1" runat="server"   CustomCaption="I live with this person " />
 
            </div>
          </div>
     <div class="row">
      <div class="col-sm-6 columns form-group"><p>Quickly find an address by entering postcode or partial address below:</p>
<p><asp:TextBox ID="txtLookup" runat="server" CssClass="formtext" ></asp:TextBox>
<asp:Button ID="btnFind" runat="server" Text="Find" CausesValidation="False" /></p>
          <div id="divlstResult" runat="server" visible="true"><asp:ListBox ID="lstresult" runat="server"  AutoPostBack="True" Width="400"></asp:ListBox></div>
          </div>
        </div>
      <div id="divAddresslines" runat="server" visible="true">
  <div class="row">
    <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress1" ID="txtAddress1" runat="server" IsRequired="false" CustomCaption="Address Line 1" />
    </div>
        <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress2" ID="txtAddress2" runat="server" IsRequired="false"  CustomCaption="Address Line 2"  />
    </div>
</div>
  <div class="row">
        <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress3" ID="txtAddress3" runat="server" IsRequired="false"  CustomCaption="Address Line 3"  />
    </div>
        <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress4" ID="txtAddress4" runat="server" IsRequired="false"  CustomCaption="Address Line 4"  />
    </div>
      </div>
    <div class="row">
         <div class="col-sm-3 columns form-group"> 
             <label for="postcode" style="font-weight:bold ">Postcode</label><input runat="server" maxlength="9" type="text" id="postcode" class="form-control" name="pre[postalcode]" placeholder="Your postcode here..." autocomplete="off" Pattern="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$"  />
             </div>
    </div>
    </div>
    </div>


<div class="container" id="parent2panel" runat="server">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
        <h2>(Additional) Emergency contacts in case of accident or illness</h2>
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
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2PhoneNumber" ID="StudentEnrolmentField2" runat="server" LabelWidth="300" IsRequired="false"  CustomCaption="* Mobile (no spaces)"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$" Placeholder="e.g. 0xxxxxxxxxx"  Title="Please enter a valid phone number" />
       </div>
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2WorkTel" ID="StudentEnrolmentField14" runat="server" LabelWidth="3200" IsRequired="false"  CustomCaption="* Work Telephone (no spaces)"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$" Placeholder="e.g. 0xxxxxxxxxx"  Title="Please enter a valid phone number" />
       
            </div>
         </div>
           <div class="row">
            <div class="col-sm-12 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2RelationshipID" ID="StudentEnrolmentField24" runat="server" IsRequired="true"   CustomCaption="* Relationship" />
        </div>
     </div>
          <div class="row">
        <div class="col-sm-12 columns form-group">
             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="IsLivingWithParent2" ID="StudentEnrolmentField3" runat="server"   CustomCaption="I live with this person " />
 
            </div>
          </div>
</div>


        <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" />
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"   CausesValidation="true" EnableEnterKey="true" />
    <br />
              

