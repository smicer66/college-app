<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_enrolments2.vb" Inherits="webcontrols_checkout_enrolments2" %>

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
<div class="progress" style="height: 20px;">
  <div class="progress-bar" role="progressbar" style="width: 45%;" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100"></div>
</div>
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Guardian / Emergency</li>                   
                    <li><strong>Further Details</strong></li>
                     <li>Attachments</li>
                    <li>Photo</li>
                     <li>Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
<div class="container">
   <div class="row">
      <div class="col-sm-12 columns form-group"> 
       <h2>Residency</h2>
          </div>
  </div>


        <div class="row">
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="NationalityID" ID="fldNationalityID" runat="server"  IsRequired="true"  LabelWidth="300" CustomCaption="* What Nationality are you?" />
        </div>
       <div class="col-sm-6 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CountryID" ID="StudentEnrolmentField20" runat="server"  IsRequired="true"  LabelWidth="300" CustomCaption="* What is your Home Country?" />
        </div>

    </div>
 <div class="row">
        <div class="col-sm-12 columns form-group"> 
           <span class="textfieldlabelrequired">* Did you enter the UK from another country mainly to receive education?</span>
              <asp:DropDownList ID="selectEnterforEducation" runat="server" CssClass="textfield form-control"  >
             <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="Y">Yes</asp:ListItem>
             <asp:ListItem value="N">No</asp:ListItem>
         </asp:DropDownList>
            </div>
     </div>
           <div class="row" id="euromessage">
         <p><strong>A member of the Learner Services team may be in touch to discuss your enrolment where additional evidence is required to assess your eligibility for free tuition.</strong></p>
  </div>
 <div class="row">
        <div class="col-sm-12 columns form-group"> 
            <span class="textfieldlabelrequired">* Have you lived in the UK legally for at least the last three years ?</span>
              <asp:DropDownList ID="selectEuro" runat="server" CssClass="textfield form-control"  >
             <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="1">Yes</asp:ListItem>
             <asp:ListItem value="2">No</asp:ListItem>
         </asp:DropDownList>
       <!--       <button type="button" class="btn btn-primary" data-toggle="tooltip" data-placement="bottom" title="Do you live in the UK legally? Have you lived in the UK or an EU country for the last 3 years? If you can answer yes to both of these questions the answer to the statement is Yes">
Not sure? Hover over me
</button>-->
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EuroResidentID" ID="fldEuro" runat="server" IsRequired="false" Visible="false"  />
          </div>
     </div>
     <div class="row" id="euroFields">
         <div class="col-sm-12 columns form-group" > 
                     <span class="textfieldlabelrequired">* What date did you arrive in the UK ?</span><cc1:StudentEnrolmentField StudentEnrolmentFieldType="DateOfEntryUK"  id="fldDateEntry" runat="server" CustomCaption=" "  LabelWidth="300" Width="100"/>
        
        </div>
            
       <div class="col-sm-12 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="VisaTypeID" ID="StudentEnrolmentField100" runat="server" LabelWidth="300"  IsRequired="false" CustomCaption="* Do you have pre-settled or settled status?" />
           </div>

</div>


        <div class="row">
       <div class="col-sm-12 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentFirstLanguageID" ID="StudentEnrolmentField1" runat="server" IsRequired="true" LabelWidth="300"  CustomCaption="* What is your first spoken language?" />
           </div>
     </div>
</div>


<h2>Support Needs</h2>

<div class="container">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
          <span class="textfieldlabelrequired">* Do you consider yourself to have a learning difficulty or disability?</span>
      
            <asp:DropDownList runat="server" ID="selectLearnDiff"  CssClass="textfield form-control">
                <asp:ListItem Text="Please select..." Value=""></asp:ListItem>
                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                <asp:ListItem Text="Rather not say" Value="9"></asp:ListItem>
            </asp:DropDownList>
          <div style="display:none">
             <cc1:StudentEnrolmentField Visible="true" ClientIDMode="Static" StudentEnrolmentFieldType="LearningDiffOrDisID" ID="fldLearningDiffOrDisID" runat="server" IsRequired="false"   />
      </div>
          </div>
    </div>
    <div class="row"  id="disfields">
      <div class="col-sm-6 columns form-group"> 
             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory1ID" ID="stuDisabilityCategory1ID" runat="server" LabelWidth="300" IsRequired="false" CustomCaption="* Please specify main learning/disability" ExcludedIDValues="99"/>
              <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory2ID" runat="server" Visible="true" IsRequired="false"  LabelWidth="400" CustomCaption="And, if appropriate, a secondary learning difficulty" />
        </div>
           <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ALSRequired" runat="server" IsRequired="false" CustomCaption="If you would like us to contact you regarding any potential support requirements please tick the box below:" LabelWidth="450"/>
          </div>
      </div>

         <div class="row">
      <div class="col-sm-12 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined9"  runat="server" IsRequired="false" CustomCaption="Did you have Exam Access Arrangement at School? If Yes give details" LabelWidth="500"/>
          </div>
 <!---      <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined33" runat="server" IsRequired="false" CustomCaption="If yes, give more details" />
          </div> -->
   </div>
  <div class="row">
      <div class="col-sm-12 columns form-group"> 
                  <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined8" runat="server" IsRequired="false" CustomCaption="Have you had extra support in secondary school? If yes, give more details" LabelWidth="500"/>
          </div>
<!--       <div class="col-sm-6 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined35" runat="server" IsRequired="false" CustomCaption="If yes, give more details" />
          </div> -->
   </div>
      <div class="row">
      <div class="col-sm-12 columns form-group"> 
                  <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ReceivedFreeSchoolMeals" runat="server" IsRequired="false" CustomCaption="Have you received Free School Meals?" LabelWidth="400"/>
          </div>
<!--       <div class="col-sm-6 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined35" runat="server" IsRequired="false" CustomCaption="If yes, give more details" />
          </div> -->
   </div>
    <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" />
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  CausesValidation="true" EnableEnterKey="true" />
</div>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#euroFields").hide();
            $("#euromessage").hide();
            if ($("#<%=selectEuro.ClientID%>").val() == "2") {
                $("#euroFields").show();
                 $("#euromessage").show();
            }
            if ($("#<%=selectEnterforEducation.ClientID%>").val() == "Y") {
                 $("#euromessage").show();
            }
            $('#<%= selectEuro.ClientID %>').change(function () {
                 // $('#cboEuroResidentID').checked=false;
                if ($("#<%=selectEuro.ClientID%>").val() == "2") {
                    $("#euroFields").show();
                    $("#euromessage").show();
                    return;
                }
                else {
                    $("#euroFields").hide();
                }
            });
            $('#<%= selectEnterforEducation.ClientID %>').change(function () {
           
                if ($("#<%=selectEnterforEducation.ClientID%>").val() == "Y") {
                    $("#euromessage").show();
                    return;
                }
                else {
                    $("#euromessage").hide();
                }
            });


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