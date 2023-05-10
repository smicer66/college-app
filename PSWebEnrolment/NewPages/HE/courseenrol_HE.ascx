<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="courseenrol_HE.ascx.vb" Inherits="courseenrol"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<!--The CourseEnrolAction adds the offering to the basket as an Enrolment-->
    <cc1:CourseEnrolAction ID="CourseEnrolAction" runat="server" />
<br /><br /><br /><br />
    

  <div class="alert alert-danger">Before you begin to complete the online enrolment form please ensure that all of your previous connections to the college website have been closed.</div>

<p><strong>Please ensure that you have the following information available to enable you to proceed with your enrolment:</strong></p>

  <ul>
      <li>Proof of identity, such as a copy of your passport, birth certificate or driving licence (you can take a picture using your phone as long as the photo adheres to the photo rules in the 'Upload Photo' section)</li>
       <li>A photo that clearly identifies you (you can take a picture using your phone as long as the photo adheres to the photo rules in the 'Upload Photo' section)</li>
      <li>Copies of certificates for any qualifications you have already achieved. If you are awaiting your results you do not need to upload them here.</li>
      <li>If you are paying using a loan, you will need to provide us with further evidence OR</li>
      <li>If your employer is paying for the fees, you will need to provide a letter from your employer giving us Authority to Invoice or a letter confirming your employer will be paying along with their billing details.</li>
        <li>Proof of residency in the United Kingdom (UK) / European Union (EU), if you have <strong>not</strong> been resident in the UK for the past three continuous years</li>
  </ul>

<p><strong>Please note the following important information:</strong></p>
<ul>
    <li>All fields marked with an * are mandatory fields and must be completed</li>
    <li>When you reach the end of the enrolment form remember to click the <strong>'Submit'</strong> button, otherwise we will not receive your enrolment details</li>
    <li>If you do not upload documents such as proof of identity or your photo your enrolment will be delayed or it may not be processed</li>
    <li>The maximum file size is 5MB per file, the supported file formats allowed are jpg, png and jpeg</li>
    <li>Submitting this form does not guarantee you a place on the course, your place on the course is subject to validation by the college and follow up information, advice and guidance to ensure that the course is right for you.</li>
</ul>
   <div class="alert alert-danger"><h3>This enrolment session will expire in 40 minutes, if you exceed this time limit you will need to re-enter your enrolment information again.</h3></div>
<p>Please ensure you have read the fees policy, which includes the refund policy, before proceeding which can be found at <a href="http://www.cityofbristol.ac.uk/about-us/college-policies/fees-policy/" target="_blank">http://www.cityofbristol.ac.uk/about-us/college-policies/fees-policy/</a></p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
         <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue to Checkout" ImageResource="btnContinue"  EnableEnterKey="true" />
