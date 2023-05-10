<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="courseapps.ascx.vb" Inherits="courseenrol"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

        <!--The CourseEnrolAction adds the offering to the basket as an Enrolment-->
    <cc1:CourseApplyAction ID="CourseApplyAction" runat="server" />
<br />
<br />
<br />
<br />
  <div class="alert alert-danger">Before you begin to complete the online form please ensure that all of your previous connections to the college website have been closed.</div>


<p><strong>Please note the following important information:</strong></p>
<ul>
    <li>All fields marked with an * are mandatory fields and must be completed</li>
    <li>When you reach the end of the  form remember to click the <strong>'Submit'</strong> button, otherwise we will not receive your  details</li>  
</ul>
   <div class="alert alert-danger"><h3>This session will expire in 40 minutes, if you exceed this time limit you will need to re-enter your information again.</h3></div>
        <cc1:CCCButton ID="btnContinue6" runat="server" Text="Continue " ImageResource="btnContinue" LinkResource="checkout_enrolments_Apps_aspx" CausesValidation="true" />
