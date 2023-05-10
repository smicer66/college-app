<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="courseenrol.ascx.vb" Inherits="courseenrol"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<style>
    #FeeGridTotalCell {
    font-weight:700;
}
</style>
        <!--The CourseEnrolAction adds the offering to the basket as an Enrolment-->
    <cc1:CourseEnrolAction ID="CourseEnrolAction" runat="server" />
<br />
<h3>The following Enrolment has been added to your list of courses:</h3>
    
   <cc1:OfferingFeesDisplayAll runat="server"  />


<p>
        NOTE: This enrolment is subject to validation by the college.<br /><br /> Please ensure you have read the fees policy, which includes the refund policy, before proceeding which can be found at <a href="http://www.cityofbristol.ac.uk/about-us/college-policies/fees-policy/" target="_blank">http://www.cityofbristol.ac.uk/about-us/college-policies/fees-policy/</a></p>
    <br />
<p>
       When the course has listed entry requirements - you will need to upload evidence to support this during the process. You will be asked to do this during the online enrolment.</p>
<p> If you do not, we will be unable to confirm your enrolment so please ensure you have the evidence available to upload</p>
<br />
     <p><strong><h4>If you are not a UK national and / or you have not been living in the UK for the past 3 years – we may require additional information before confirming your place on a course.  We will contact you if we need further evidence from you.</h4></strong></p>
    <br />

    <p>
      Total courses selected: &nbsp;<span class="wglyphicon glyphicon-shopping-cart"></span><cc1:ShoppingBasketTotals ID="ShoppingBasket1"
            runat="server" HideIcon="true" />
    </p>
   
     <script language="JavaScript" src="https://secure.worldpay.com/wcc/logo?instId=1057852"></script>
        <cc1:CCCButton id="btnBack" runat="server" Text="Search for more courses" ImageResource="btnBack" LinkResource="search_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue to Checkout" ImageResource="btnContinue" 
	LinkResource="checkout_aspx" CausesValidation="true" EnableEnterKey="true"/>


