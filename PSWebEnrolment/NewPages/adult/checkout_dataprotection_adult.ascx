<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="checkout_dataprotection_adult.ascx.vb" Inherits="checkout_dataprotection"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<%@ Register Src="~/webcontrols/StudentSignature.ascx" TagPrefix="uc1" TagName="StudentSignature" %>
      <!--          <ol class="breadcrumb">
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li id="linkParent" runat="server" CausesValidation="true"><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Guardian / Emergency</a></li>                   
                    <li id="linkFurther" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <li id="lnkQuals" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Qualifications</a></li>
                     <li id="linkAttach" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                     <li id="linkDeclare">Declarations</li>
                </ol>
          -->

<script>

                 $(function () {
                     $('[data-toggle="tooltip"]').tooltip()
                 })

          </script>
<br /><br />
                <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Emergency Contact</li>                   
                    <li>Further Details</li>
       <li>Qualifications</li>
                    <li>Employment</li>
                     <li>Attachments</li>
                    <li>Photo</li>
                     <li><strong>Declarations</strong></li>
                    </ol>
  
<div class="container">
  <div class="row">
      <div class="col-sm-12 columns form-group"> 
        <h2>Contact Preferences</h2>
          </div>
  </div>
  <div class="row">
      <div class="col-sm-12 columns form-group"> 
            <p><strong>Privacy Notice issued by the Education & Skills Funding Agency</strong> - This privacy notice is issued by the Education and Skills Funding Agency (ESFA) on behalf of the Secretary of State for the Department of Education (DfE) to inform learners about the Individualised Learner Record (ILR) and how their personal information is used in the ILR. Your personal information is used by the DfE to exercise our functions under article 6(1)(e) of the UK GDPR and to meet our statutory responsibilities, including under the Apprenticeships, Skills, Children and Learning Act 2009.</p>
       <p>The ILR collects data about learners and learning undertaken. Publicly funded colleges, training organisations, local authorities, and employers (FE providers) must collect and return the data to the ESFA each year under the terms of a funding agreement, contract or grant agreement. It helps ensure that public money distributed through the ESFA is being spent in line with government targets. It is also used for education, training, employment, and well being purposes, including research. We retain ILR learner data for 3 years for operational purposes and 66 years for research purposes. For more information about the ILR and the data collected, please see the ILR specification at <a href="https://www.gov.uk/government/collections/individualised-learner-record-ilr" target="_blank">https://www.gov.uk/government/collections/individualised-learner-record-ilr</a> </p>
          <p>ILR data is shared with third parties where it complies with DfE data sharing procedures and where the law allows it. The DfE and the English European Social Fund (ESF) Managing Authority (or agents acting on their behalf) may contact learners to carry out research and evaluation to inform the effectiveness of training. In these cases, it is part of our statutory duties and we do not need your consent.</p>
        
             <p>Where sharing is not part of our statutory duties, you can give your consent to be contacted by other third parties about:</p>
 </div>
   </div>
    <div class="row">
        <div class="col-sm-6 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="RestrictedUseAllowLearningOpportunities" ID="StudentEnrolmentField15" runat="server" LabelWidth="300" IsRequired="false"  CustomCaption="Courses or learning opportunities"/>
            </div>
        <div class="col-sm-6 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="RestrictedUseAllowResearch" ID="StudentEnrolmentField18" runat="server" IsRequired="false"  CustomCaption="Surveys and research"/>
            </div>
    </div>
    <p>Using the following methods:</p>
    <div class="row">
        <div class="col-sm-4 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="RestrictedUseAllowContactByEmail" ID="StudentEnrolmentField12" runat="server" IsRequired="false" LabelWidth="400" CustomCaption="By email" />
            </div>
        <div class="col-sm-4 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="RestrictedUseAllowContactByPost" ID="StudentEnrolmentField13" runat="server" IsRequired="false" LabelWidth="400" CustomCaption="By post"  />
            </div>
        <div class="col-sm-4 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="RestrictedUseAllowContactByTelephone" ID="StudentEnrolmentField14" runat="server" IsRequired="false" LabelWidth="400" CustomCaption="By telephone"  />
            </div> 
      
    </div>
         <div class="row">
      <div class="col-sm-12 columns form-group"> 
  <p><strong>Please tick relevant boxes to give your consent.</strong></p>
          </div> 
      
    </div>
     <div class="row">
      <div class="col-sm-12 columns form-group"> 
        
<p>For more information about how your personal data is used and your individual rights, please see the DfE Personal Information Charter (<a href="https://www.gov.uk/government/organisations/department-for-education/about/personal-information-charter" target="_blank">https://www.gov.uk/government/organisations/department-for-education/about/personal-information-charter</a>) and the ESFA Privacy Notice (<a href="https://www.gov.uk/government/publications/esfa-privacy-notice" target="_blank">https://www.gov.uk/government/publications/esfa-privacy-notice</a>)</p>

<p>If you would like to get in touch with us, you can contact the DfE in the following ways:</p>
          <ul>
              <li>Using our online contact form at <a href="https://form.education.gov.uk/service/Contact_the_Department_for_Education" target="_blank">https://form.education.gov.uk/service/Contact_the_Department_for_Education</a></li>
              <li>By telephoning the DfE Helpline on 0370 000 2288</li>
              <li>Or in writing to – Data Protection Officer, Ministerial and Public Communications Division, Department for Education, Piccadilly Gate, Store Street, Manchester, M1 2WD</li>
          </ul>

<p>If you are unhappy with how we have used your personal data, you can complain to the Information Commissioner’s Office (ICO) at – Wycliffe House, Water Lane, Wilmslow, Cheshire, SK9 5AF. You can also call their helpline on 0303 123 1113 or visit <a href="https://www.ico.org.uk" target="_blank">https://www.ico.org.uk</a></p>
<h4>Learner Record Service - Ability to Share</h4>
<p>The information you supply is used by the Learning Records Service (LRS). The LRS issues Unique Learner Numbers (ULN) and creates Personal Learning records across England, Wales and Northern Ireland, and is operated by the Education and Skills Funding Agency, an executive agency of the Department for Education (DfE).For more information about how your information is processed, and to access your Personal Learning Record, please refer to: <a href="https://www.gov.uk/government/publications/lrs-privacy-notices/lrs-privacy-notice" target="_blank">https://www.gov.uk/government/publications/lrs-privacy-notices/lrs-privacy-notice</a> </p>

<h4>College Privacy Notice</h4>
<p>Generally, the information is processed as part or our public interest task of providing education to you. Further information about use of and access to your personal data, details of organisations with whom we regularly share data, information about how we retain your data, and how to change your consent to being contacted, please visit: <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank">https://www.cityofbristol.ac.uk/privacy-statement/</a></p>

<p>As Data Controller, the College may share non-sensitive personal information with other organisations as set out on its Data Protection registration and from 25 May 2018, General Data Protection Regulation. The College may share your information with other organisations for education, training, employment, research and well-being related purposes. Further details are available on the College website <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank">https://www.cityofbristol.ac.uk/privacy-statement/</a>. If at any time you wish to stop receiving these messages, please contact Student Services on 0117 312 5000 or enquiries@cityofbristol.ac.uk and change your preferences or opt-out at any time.</p>

<p>Sensitive Information: The College may use this information to ensure equality of opportunity, support your studies, minimise risk and for anonymous statistics. We are required to share it with the relevant government departments as mentioned above. We will ask you before sharing it with others.</p>

    
          <p>Where contacting you is not part of our statutory duties, you can give your consent to be contacted about:</p>
      </div>
        </div>
    <div class="row"> 
        <div class="col-sm-6 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="AcceptMarketingConsent" ID="StudentEnrolmentField1" runat="server" LabelWidth="300" IsRequired="false"  CustomCaption="Internal marketing"/>
                    </div>
              <div class="col-sm-6 columns form-group">    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="AcceptShareInfoConsent" ID="StudentEnrolmentField2" runat="server" LabelWidth="300" IsRequired="false"  CustomCaption="External marketing / share consent"/>
                    </div>
          </div>
        <p>Select how you would like to be contacted for external marketing:</p>
    <div class="row">
        <div class="col-sm-4 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="GDPRAllowContactByEmail" ID="StudentEnrolmentField3" runat="server" IsRequired="false" LabelWidth="400" CustomCaption="By email" />
            </div>
        <div class="col-sm-4 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="GDPRAllowContactByPhone" ID="StudentEnrolmentField4" runat="server" IsRequired="false" LabelWidth="400" CustomCaption="By phone"  />
            </div>
        <div class="col-sm-4 columns form-group"> <cc1:StudentEnrolmentField StudentEnrolmentFieldType="GDPRAllowContactByPost" ID="StudentEnrolmentField5" runat="server" IsRequired="false" LabelWidth="400" CustomCaption="By post"  />
            </div> 
      
    </div>
   
</div>


<div class="panel panel-info">
    <div class="panel-heading" id="dec">Declaration</div>
    <h3>Please take time to read through this declaration before proceeding</h3>

      <!--The CourseEnrolAction adds the offering to the basket as an Enrolment-->

    <ul>
    <li>I declare that the information I have disclosed is true and accurate to the best of my knowledge.</li>    
    <li>I agree to abide by City of Bristol College <a href="https://www.cityofbristol.ac.uk/about-us/college-policies/" target="_blank">Student Charter</a></li>
    <li>I have been informed of and understand the entry requirements for my course, the guided learning hours, the nature and suitability of the course, the costs involved, what it leads to and how to contact the College for support and advice services. </li> 
    <li>I understand that if the mode of delivery is disrupted due to unforeseen circumstances, the college will endeavour to continue high-quality delivery via an online or alternative learning platform. In this instance, there will be no reduction in course fees. If I do not wish to continue studying on that basis, the college would advise me of the financial implications of my discontinuing or suspending my studies.</li>
        <li>As published in the College's Fees Policy, I understand that I am responsible for any fee amounts due, and that if I stop attending before the end of the course, I will continue to be responsible for the payment of any outstanding balance that remians (in full or in part). I also confirm that I understand the refund policy as outlined in the Fees Policy. </li>
    <li>I understand that in the event of unpaid fees my details may be passed on to a Debt Collection Agency, who will act on behalf of the College for recovery.</li>
    <li>I agree to inform City of Bristol College of any relevant change of personal circumstances or change of course.</li>
    <li>I understand that any kit or learning resources provided at a reduced/zero cost to me will remain the property of City of Bristol College until such time as I complete my programme of study/course and achieve my qualification.</li>
    <li>I understand that if my Employer or Training Agent is supporting my learning progress reports may be provided to them.</li>
    <li>I am aware of the College's complaints procedure, how to access it and raise a complaint.</li>
    <li>I confirm I understand how my data is being used and my contact preferences are as above.</li>
    <li >  I confirm that all the information on this form is correct and I wish to claim fee remission for my course. I understand 
that if I have declared false information the college may act against me to reclaim the course fees and any associated 
costs.</li> 
    </ul>    
    <p>Documentation relating to the above can be found at:<a href="https://www.cityofbristol.ac.uk/about-us/college-policies/" target="_blank">https://www.cityofbristol.ac.uk/about-us/college-policies/</a> </p>
    <br />
  <!--   <div class="form-check">
  <input class="form-check-input" type="checkbox" value="" id="checkID" runat="server" >
  <label class="form-check-label" for="checkID">
   Uploaded a copy of my identity document such as birth certiifcate, passport or driving licence
  </label>
</div>                          
     <div class="form-check">
  <input class="form-check-input" type="checkbox" value="" id="checkPhoto" runat="server" >
  <label class="form-check-label" for="checkPhoto">
    Uploaded a photo of myself
  </label>
</div>
<div class="form-check">
  <input class="form-check-input" type="checkbox" value="" id="checkAch" runat="server" >
  <label class="form-check-label" for="checkAch">
    Uploaded a copy of each certificate I have achieved
  </label>
</div>
<div class="form-check" id="divEuro" runat="server" visible="false">
  <input class="form-check-input" type="checkbox" value="" id="checkUK" runat="server" >
  <label class="form-check-label" for="checkUK">
    Upoaded evidence to prove my UK /EE residency
  </label>
</div> 
      -->

         
    <p> <asp:CheckBox ID="chkConfirm" runat="server" 
            Text="- I confirm I read the declarations above and the information given in this form is correct and complete." Font-Bold="True" 
            CausesValidation="True" />
    </p>
  
 
</div>


       <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_photo_1618_aspx"  Visible="false"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnSubmit" CausesValidation="true" Visible="false"/>



<div  class="container">
      <div class="row">
               <div class="col-sm-12 columns form-group"> 
               <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HeardAboutCollegeID" ID="StudentEnrolmentField29" runat="server" LabelWidth="500" CustomCaption="* Please tell us how you heard about the College?" IsRequired="True" Visible="true" />
   
               </div>
              </div>
    <div class="row">
        <div class="col-sm-3 columns form-group">  
            <button id="mybutton" class="btn btn-lg btn-primary" type="button"    runat="server" causesvalidation="true" onserverclick="btnContinue_Click">
             <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
               Submit your details
                </button>
         <div  id="divSaver" style="display:none">
             <button id="Button1" class="btn btn-lg btn-secondary" type="button" >
             <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
               Sending your details....please wait.....
                </button>
             </div>
            </div>
       <div class="col-sm-6 columns form-group">  </div>
      </div>
  </div>
   
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

 <script type="text/javascript">  
  //   alert(($('#<%= chkConfirm.ClientID %>').is(':checked')))
  
     $('.btn-lg').on('click', function () {

         if ($(this).hasClass('disabled')) {
             return false;
         } else {
             $(this).addClass('disabled');
             $('#divSaver').show();
             return true;
         }
     });
 </script>
