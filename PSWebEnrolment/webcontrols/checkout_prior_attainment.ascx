<%@ control Language="VB" AutoEventWireup="false" CodeFile="checkout_prior_attainment.vb" Inherits="checkout_prior_attainment"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb" id="breadcrumbapps" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications2.ascx">Further Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>                 
                  <li class="active">Prior Attainment</li>
                </ol>
                <ol class="breadcrumb" id="breadcrumbenrols" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <!--<li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>-->
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_school_employer.ascx">School / Employer</a></li>
                  <li class="active">Prior Attainment</li>
                </ol>

<div class="panel panel-info" id="panel1" runat="server">
    <div class="panel-heading">Prior Attainment Level</div>
    <%--<div class=" form-group">
    <cc1:studentenrolmentfield id="fldSchool" runat="server" customcaption="Present or most recent school/college"
          labelwidth="300" StudentEnrolmentFieldType="SchoolID"  ></cc1:studentenrolmentfield>          
    </div>--%>
    <div class=" form-group">
    <cc1:StudentEnrolmentField  id="fldhighestQualification"  runat="server" customcaption="What is your highest level of Qualification? *"
         isrequired="true" labelwidth="300" StudentEnrolmentFieldType ="PriorAttainmentLevelID" ></cc1:studentEnrolmentField>
    </div>
    
    <p>
        Use the following table to help you pick the correct qualification level...</p>
<table class="table table-striped table-bordered">
    <tr class="active"><th>Level</th><th>Qualification Equivalent (incorporating NQF and QCF and RQF)</th></tr>
    <tr><td>
        Entry Level (code 7, 9)</td>
<td>
            QCF qualifications at Entry level, Certificate in Adult Literacy, Numeracy, ESOL at Entry level RQF qualifications at Entry Level, English and Maths qualifications at Entry Level such as Functional Skills, Essential Digital Skills qualification</td><td>&nbsp;</td></tr>
        <tr>
            <td>
                Level 1 (code 1)</td>
            <td>
                GCSE/O Level (at grades D-G or fewer than 5 at grades A-C), CSE grade 2 and 3, 1 AS Level (for AS qualifications regulated before 1 September 2015), QCF 		qualifications at Level 1, Foundation 14-19 Diploma, Functional Skills Certificate in Adult Literacy, Numeracy, ESOL at Level 1, Level 1 Key Skills, Level 1 		Principal Learning, Introductory Diploma, Introductory Certificate, GNVQ Foundation, NVQ Level 1, RQF qualifications at Level 1, Technical Awards in the Key 				Stage 4 Performance Tables, Essential Digital Skills qualifications 
            </td>
           
        </tr>
        <tr>
            <td>
                Full Level 2(code 2)</td>
            <td>
                GCSE/O Level (5 or more GCSEs grades A*-C), GCSE (9-1) (5 or more GCSEs grade 4 or above), 2 or 3 AS Levels (for AS qualifications regulated before 1 September 			2015), CSE Grade 1 (5 or more), 1 A Level, Higher 14-19 Diploma, QCF Diploma level 2, QCF Certificate level 2 at 13 or 14 credits undertaken before 2014 to 				2015, Level 2 Principal Learning, NVQ level 2, GNVQ Intermediate, Technical Certificates in the 16-19 Performance Tables, QCF Certificate level 2 at 15 credits 			and above, From 1 August 2015 vocational qualifications of 150 GLH or more. These are on the level 2 and level 3 legal entitlement qualification list.
            </td>
            
        </tr>
        <tr>
            <td>
                Full Level 3 (code 3)</td>
            <td>
                A Levels (2 or more advanced level passes), 4 or more AS Levels (for AS qualifications regulated before 1 September 2015), QCF Diploma Level 3, QAA Access to 		HE, Advanced 14-19 Diploma, GNVQ Advanced, NVQ level 3, AVCE double award, Tech Levels which are in the 16-19 Performance Tables, Applied Generals which are in 		the 16-19 Performance Tables (from 1 August 2015), QCF Certificate at Level 3 which is 30 to 36 credits, From 1 August 2015 vocational qualifications of 300 GLH 		or more, These are on the level 2 and level 3 legal entitlement qualification list.
            </td>
        </tr>
        <tr>
            <td>
                Level 4</td>
            <td>
                QCF Award / Certificate / Diploma at Level 4, HNC, RQF qualifications Level 4, Certificates of higher education</td>
        </tr>
        <tr>
            <td>
                Level 5</td>
            <td>
                QCF Award / Certificate / Diploma at Level 5, HND, RQF qualifications Level 5, Foundation degrees
                </td>
        </tr>
	<tr>
            <td>
                Level 6</td>
            <td>
                QCF Award / Certificate / Diploma at Level 6, RQF qualifications Level 6, Bachelor's degrees, graduate certificates and diplomas
                </td>
        </tr>
    	<tr>
            <td>
                Level 7+</td>
            <td>
               QCF Award / Certificate / Diploma at Level 7 / 8, RQF qualifications Level 7 / 8, Doctorates, Masters degrees, postgraduate certificates and diplomas
                </td>
        </tr>
    </table>


     <br />
               <div  id="div_english_maths" runat="server">
           <div class="panel-heading" >English & Maths</div>
    <asp:Label runat="server" ID="qualsPara" Visible="true"></asp:Label>
   <p>Please pick the relevant options from the dropdown:</p>
        <div class="col-sm-6 columns form-group">
                <span class="textfieldlabelrequired">* Maths</span>
                <asp:DropDownList runat="server" ID="ddlMath" CssClass="textfield form-control">
                <asp:ListItem value="">Please select...</asp:ListItem>
                <asp:ListItem Text="I declare I DO NOT have Maths Grade 4 or Grade C and above" Value="No"></asp:ListItem>
                 <asp:ListItem Text="I declare I do have have Maths Grade 4 or Grade C and above" Value="Yes"></asp:ListItem>
      
            </asp:DropDownList>
        </div>
                     <div class="col-sm-6 columns form-group">
                <span class="textfieldlabelrequired">* English</span>
                <asp:DropDownList runat="server" ID="ddlEng" CssClass="textfield form-control">
                <asp:ListItem value="">Please select...</asp:ListItem>
                <asp:ListItem Text="I declare I DO NOT have English Grade 4 or Grade C and above" Value="No"></asp:ListItem>
                 <asp:ListItem Text="I declare I do have have English Grade 4 or Grade C and above" Value="Yes"></asp:ListItem>
      
            </asp:DropDownList>
     
        </div>
          
      <p>This information will be verified against your Personal Learning Record which is held with the Learning Records 
Service. Failure to give the correct information will result in your claim for any free tuition being refused and the College 
requesting payment for the full cost of the course.</p>
</div>
    


</div>
<cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_school_employer_aspx" CausesValidation="false"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="checkout_attachments_aspx" CausesValidation="true" EnableEnterKey="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />


