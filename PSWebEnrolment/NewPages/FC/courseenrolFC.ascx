<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="courseenrolFC.ascx.vb" Inherits="courseenrol"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<style>
    #FeeGridTotalCell {
    font-weight:700;
}
</style>
<br />
        <!--The CourseEnrolAction adds the offering to the basket as an Enrolment-->
    <cc1:CourseEnrolAction ID="CourseEnrolAction" runat="server" />
<h3>The following Enrolment has been added to your list of courses:</h3>

   <cc1:OfferingFeesDisplayAll runat="server"  />
<p>
        NOTE: This enrolment is subject to validation by the college.<br /><br /> Please ensure you have read the fees policy, which includes the refund policy, before proceeding which can be found at <a href="#" target="_blank">fees-policy</a></p>
    <br />
<p>
    <h4>
    
</h4>
    <div class="panel panel-info" runat="server">
    <div class="panel-heading"><h4>Please have your bank card ready, as this online enrolment can only be completed if payment has been received in full, failure to do this will result in your enrolment being rejected.</h4></div>
  
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue to Checkout" ImageResource="btnContinue" LinkResource="checkout_fc_aspx" CausesValidation="true" />
              </div>
