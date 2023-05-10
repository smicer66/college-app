<%@ control Language="VB"  AutoEventWireup="false" CodeFile="courseapply.ascx.vb" Inherits="courseapply"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/coursedisplay.ascx">Course Details</a></li>
                  <li class="active">Course Added to Basket</li>
                </ol>

    <!--The CourseApplyAction adds the offering to the basket as an application-->
    <cc1:CourseApplyAction ID="CourseApplyAction" runat="server" />
    <h3>The following Application has been added to your list of courses:</h3>
    
 <div style="width:900px;padding: 10px;border: 4px solid gray;margin: 0;" >

<asp:PlaceHolder runat="server" ID="FeesPlaceHolder">


</asp:PlaceHolder>
</div> 

<br />  
<p>
        While applying online you will not have to pay, any payment of fees will occur at the college when you enrol.
    </p>
    <p>
        NOTE: We would like to remind you that
        applying to a course does not necessarily mean you will get a place.</p>

    <br />
   
    <p>
        Total courses selected: &nbsp;<span class="wglyphicon glyphicon-shopping-cart"></span><cc1:ShoppingBasketTotals ID="ShoppingBasket1"
            runat="server" HideIcon="true" />
    </p>
    <br />
     <p><strong>Please note</strong> – any offer to do the course is based on your eligibility for funding for Further Education courses.  This is primarily based on your residency status in the UK and this will be assessed as you move through the application journey.</p>
    <br />
<div id="divStatement" runat="server" visible="false">
    <h3 >Access to HE applicants</h3>
    <div class=" form-group">
         <p>You will be required to include a personal statement (approximately one side of A4), within the application form. Please prepare this in advance before starting the application process. You will need to include: </p>
        <ol><li>Why you are applying</li><li>What you would like to study at the university, and why</li><li>Any experience you have in relation to the course, this maybe educational, voluntary and/or work based</li></ol>
   <p>Please limit your personal statement to no more than 1 A4 side.</p>

    </div>
    </div>
<div id="divSuppIntern" runat="server" visible="false">
     <h3 >Supported Internship</h3>
    <p>To be eligible to enrol on to a Supported Internship you:</p>
     <ol>
         <li>Must have an EHCP</li>
<li>Must be willing to be embedded in an external employer with support that is gradually withdrawn placed with work placement outside the college</li>
<li>Must provide at least one reference (work based if possible)</li>
<li>Must be able to use public transport independently on familiar routes</li>
<li>Must provide a personal statement, within the application form. Please prepare this in advance before starting the application process. You will need to include:</li>
<ol>
    <li>Details of work previous work experience</li>
<li>Why an internship has been applied for</li>
<li>The skills and qualities that the applicant can bring to the programme</li>
    </ol>
     </ol>
</div>

<div id="divCelta" runat="server" visible="false">
    <h3 >TEACHING ESOL / CELTA </h3>
    <div class=" form-group">
         <p>Before you begin your application, please note the following</p>
        <p>You will be required to give your reasons for wishing to take the course and outline what you hope to gain from it. You should write between 200 and 250 words. You may wish to prepare this in advance before starting the application process. You will need to include: </p>
        <ol><li>Why you are applying for this course</li><li>What you hope to gain from the course and how it will help you achieve future aspirations</li><li>Any experience you have in relation to the course, this maybe educational, voluntary and/or work based</li></ol>
   <p>You will  be required to upload a copy of your highest qualification and some photo identification such as your passport or photo driving licence.</p>
        </div>
    </div>
<br/>
        <cc1:CCCButton id="btnBack" runat="server" Text="Search for more courses" ImageResource="btnBack" LinkURL="http://www.cityofbristol.ac.uk/courses/"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue to Checkout" ImageResource="btnContinue" LinkResource="checkout_aspx" CausesValidation="true" />

