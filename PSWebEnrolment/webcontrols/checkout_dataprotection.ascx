<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="checkout_dataprotection.ascx.vb" Inherits="checkout_dataprotection"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<%@ Register Src="~/webcontrols/StudentSignature.ascx" TagPrefix="uc1" TagName="StudentSignature" %>
<script>

                 $(function () {
                     $('[data-toggle="tooltip"]').tooltip()
                 })

</script>
<br /><br />

                <ol class="breadcrumb" id="breadcrumbapps" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <!--<li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>-->
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_school_employer.ascx">School / Employer</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_prior_attainment.ascx">Prior Attainment</a></li>
		            <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Quals on Entry</a></li>
                    <li class="active">Declaration</li>
                </ol>
                 <ol class="breadcrumb" id="breadcrumbenrols" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <!--<li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>-->
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_school_employer.ascx">School / Employer</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_prior_attainment.ascx">Prior Attainment</a></li>
		    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                  <li class="active">Declaration</li>
                </ol>


<h3>Privacy Statement – How we use your Personal Information</h3>

<h4>Learner Record Service - Ability to Share</h4>
<p>The information you supply is used by the Learning Records Service (LRS). The LRS issues Unique Learner Numbers (ULN) and creates Personal Learning records across England, Wales and Northern Ireland, and is operated by the Education and Skills Funding Agency, 
    an executive agency of the Department for Education (DfE).For more information about how your information is processed, 
    and to access your Personal Learning Record, please refer to: <a href="http://www.gov.uk/government/publications/lrs-privacy-notices" target="_blank">www.gov.uk/government/publications/lrs-privacy-notices</a>
</p>

<h3>Education and Skills Funding Agency (ESFA)</h3>
<p></p>
<p>This privacy notice is issued by the Education and Skills Funding Agency (ESFA) on behalf of the Secretary of State for the Department of Education (DfE) to inform learners about the Individualised Learner Record (ILR) and how their personal information is used in the ILR. Your personal information is used by the DfE to exercise our functions under article 6(1)(e) of the UK GDPR and to meet our statutory responsibilities, including under the Apprenticeships, Skills, Children and Learning Act 2009.<br />
   Please read the full statement here: <a href="https://guidance.submit-learner-data.service.gov.uk/22-23/ilr/ilrprivacynotice" target="_blank">https://guidance.submit-learner-data.service.gov.uk/22-23/ilr/ilrprivacynotice</a>. 
    </p>
<h3>West of England Combined Authority (WECA)</h3>
<p>Where your education is fully or part funding by WECA, they will receive your data via the Individualised Learner Record (ILR).  <br />
    Please read the full statement here: <a href="https://www.westofengland-ca.gov.uk/wp-content/uploads/2022/06/WECA-Adult-Education-Privacy-Notice-2022-23-FINAL.pdf" target="_blank">https://www.westofengland-ca.gov.uk/wp-content/uploads/2022/06/WECA-Adult-Education-Privacy-Notice-2022-23-FINAL.pdf</a>. 
</p>
<h3>City of Bristol College</h3>
<p>
    Generally, the information is processed as part of our public interest task of providing education to you. Further information about use of and access to your personal data, 
    details of organisations with whom we regularly share data, information about how we retain your data, and how to change your consent to being contacted,
     please visit: <a href="www.cityofbristol.ac.uk/privacy-statement/" target="_blank">www.cityofbristol.ac.uk/privacy-statement/</a>
    <br />
    As Data Controller, the College may share non-sensitive personal information with other organisations as set out on its Data Protection registration and from 25 May 2018, General Data Protection Regulation. The College may share your information with other organisations for education, training, employment, research and well-being related purposes. Further details are available on the College website <a href="www.cityofbristol.ac.uk/privacy-statement/" target="_blank">www.cityofbristol.ac.uk/privacy-statement/</a>. If at any time you wish to stop receiving these messages, please contact Student Services on 0117 312 5000 or <a href="mailto:enquiries@cityofbristol.ac.uk?subject=Privacy enquiry - email from website">enquiries@cityofbristol.ac.uk</a> and change your preferences or opt-out at any time.
<br />
    <i>Sensitive Information: </i>The College may use this information to ensure equality of opportunity, support your studies, minimise risk and for anonymous statistics. We are required to share it with the relevant government departments as mentioned above. We will ask you before sharing it with others.
</p>
<br />
<h3>Declaration<small> Please take time to read through this declaration before proceeding</small></h3>


    <ul>
    <li>I declare that the information I have disclosed is true and accurate to the best of my knowledge.</li>    
    <li>I agree to abide by City of Bristol College Student Charter</li>
    <li>I have been informed of and understand the entry requirements for my course, the guided learning hours, the nature and suitability of the course, the costs involved, what it leads to and how to contact the College for support and advice services. </li> 
    <li>As published in the College's Fees Policy, I understand that I am responsible for any fee amounts due, and that if I stop attending before the end of the course, I will continue to be responsible for the payment of any outstanding balance that remians (in full or in part). I also confirm that I understand the refund policy as outlined in the Fees Policy. </li>
    <li>I understand that in the event of unpaid fees my details may be passed on to a Debt Collection Agency, who will act on behalf of the College for recovery.</li>
    <li>I agree to inform City of Bristol College of any relevant change of personal circumstances or change of course.</li>
    <li>I understand that any kit or learning resources provided at a reduced/zero cost to me will remain the property of City of Bristol College until such time as I complete my programme of study/course and achieve my qualification.</li>
    <li>I understand that if my Employer or Training Agent is supporting my learning progress reports may be provided to them.</li>
    <li>I am aware of the College's complaints procedure, how to access it and raise a complaint.</li>
    <li>I confirm I understand how my data is being used and my contact preferences are as above.</li>
    </ul>    
    <p>Documentation relating to the above can be found at:<a href="www.cityofbristol.ac.uk/about-us/college-policies/" target="_blank">www.cityofbristol.ac.uk/about-us/college-policies/</a> 
    
    <br />
    </p>
 
<br />
 
    <p> <asp:CheckBox ID="chkConfirm" runat="server" 
            Text=" I confirm that I have read the declaration above" Font-Bold="True" 
            CausesValidation="True" />
    </p>

<p> The College and your tutors will contact you using a variety of methods including phone, post, email and SMS.</p>  
   
	<div class="form-group">
    <asp:Label ID="lblAcceptMarketingConsent" Text="The College may wish to contact you about other courses you may be interested in. Please select if you are happy to be contacted? (Yes/No) *" runat ="server"></asp:Label><br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpAcceptMarketingConsent" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true" Style="width: 90px;" >
    <asp:ListItem Text ="" Value =""></asp:ListItem>
    <asp:ListItem Text ="Yes" Value ="True"></asp:ListItem>
    <asp:ListItem Text ="No" Value ="False"></asp:ListItem>
    </asp:DropDownList>
    </div>

	<div class="form-group">
    <asp:Label ID="lblAcceptShareInfoConsent" Text="Are you happy to be contacted by related external agencies for surveys, research or learning opportunities? (Yes/No) *" runat ="server"></asp:Label><br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpAcceptShareInfoConsent" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true"  Style="width: 90px;">
    <asp:ListItem Text ="" Value =""></asp:ListItem>
    <asp:ListItem Text ="Yes" Value ="True"></asp:ListItem>
    <asp:ListItem Text ="No" Value ="False"></asp:ListItem>
    </asp:DropDownList>
    </div>


	<div class="form-group">
		<asp:Label ID="lblAcceptShareInfoConsentOptions" Text="Please select the methods that external agencies can contact you by:" runat ="server"></asp:Label><br />

<asp:CheckBox ID="chkPhone" runat="server" 
            Text="Phone" Font-Bold="True" 
            CausesValidation="True" />
<br/>

<asp:CheckBox ID="chkEmail" runat="server" 
            Text="Email" Font-Bold="True" 
            CausesValidation="True" />
<br/>
<asp:CheckBox ID="chkPost" runat="server" 
            Text="Post" Font-Bold="True" 
            CausesValidation="True" />


	</div>

<p>Please ensure that you use the mouse cursor to create your signature and that it is a true reflection of your signature.</p>

    <uc1:StudentSignature runat="server" ID="StudentSignature" />




    
 
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" CausesValidation="true" Visible="false"/>
   
    <br />
<br />
      
     <div  class="container">
    
    <div class="row">
        <div class="col-sm-2 columns form-group">  
               <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" />
            </div>
        <div class="col-sm-2 columns form-group">  
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
       <div class="col-sm-8 columns form-group">  </div>
      </div>
  </div>
   
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

<br />
<br />
 <script language="JavaScript" src="https://secure.worldpay.com/wcc/logo?instId=1057852"></script>


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
