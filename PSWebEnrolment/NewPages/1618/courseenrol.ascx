<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="courseenrol.ascx.vb" Inherits="courseenrol"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

        <!--The CourseEnrolAction adds the offering to the basket as an Enrolment-->
    <cc1:CourseEnrolAction ID="CourseEnrolAction" runat="server" />
<br />
<br />
<br />
<br />
  <div class="alert alert-danger">Before you begin to complete the online enrolment form please ensure that all of your previous connections to the college website have been closed.</div>

<p><strong>Please ensure that you have the following information available to enable you to proceed with your enrolment:</strong></p>

  <ul>
      <li>Proof of identity, such as a copy of your passport, birth certificate or driving licence (you can take a picture using your phone as long as the photo adheres to the photo rules in the 'Upload Photo' section)</li>
       <li>A photo that clearly identifies you (you can take a picture using your phone as long as the photo adheres to the photo rules in the 'Upload Photo' section)</li>
      <li>Proof of residency in the United Kingdom (UK) / European Union (EU), if you have <strong>not</strong> been resident in the UK / EU for the past three continuous years</li>
  </ul>

<p><strong>Please note the following important information:</strong></p>
<ul>
    <li>All fields marked with an * are mandatory fields and must be completed</li>
    <li>When you reach the end of the enrolment form remember to click the <strong>'Submit'</strong> button, otherwise we will not receive your enrolment details</li>
    <li>If you do not upload documents such as proof of identity or your photo your enrolment will be delayed or it may not be processed</li>
    <li>The maximum file size is 5MB per file, the supported file formats allowed are jpg, png and jpeg</li>
    <li>Submitting this form does not guarantee you a place on the specific chosen course as this may be dependent on your results.  You are guaranteed a place on a course subject to validation by the college and follow up information, advice and guidance to ensure that the course is right for you and we can meet any additional needs.</li>
</ul>
   <div class="alert alert-danger"><h3>This enrolment session will expire in 40 minutes, if you exceed this time limit you will need to re-enter your enrolment information again.</h3></div>
        <cc1:CCCButton ID="btnContinue6" runat="server" Text="Continue " ImageResource="btnContinue" LinkResource="checkout_enrolments_1618_aspx" CausesValidation="true" />
