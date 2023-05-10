<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="checkout_dataprotection_apponly.ascx.vb" Inherits="checkout_dataprotection_apponly"  %>

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
                   <%-- <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_prior_attainment.ascx">Prior Attainment</a></li>--%>
                     <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Quals on Entry</a></li>
                  <li class="active">Declaration</li>
                </ol>
  
<h3>Declaration<small> Please take time to read through this declaration before proceeding</small></h3>
<%--<h4>How we use your information </h4>--%>
    <section>As Data Controller, the College will share non-sensitive personal information with other organisations as set out on its Data Protection Registration, and with parent/guardian/carer, if you have consented by giving their details. The information collected on this form that is classed as sensitive (mental and physical health, ethnicity, belief) may be used by the College for the purposes of equality of opportunity, support for your studies and to minimise risk. It may also be used anonymously for statistical purposes. As a Data Processor to the Skills Funding Agency, the College will pass some of the information, including sensitive information, to the Skills Funding Agency and the Education Funding Agency. Please see the full <a href="http://www.cityofbristol.ac.uk/privacy-statement/">Privacy Statement</a> for more information.
    </section>
    <br />
    <section>Please note that if you have not been resident in the UK/EU for the past 3 years, or have immigration restrictions on your stay in the UK, or you are a registered asylum seeker or your main purpose for being in the UK/EU is for education, you may not be eligible to enrol on this course. If you are in any doubt, please visit your nearest college site or contact us on 0117 312 5000.</section>
    <br />
    <p>
    <asp:CheckBox ID="chkConfirm" runat="server" 
            Text="I confirm that I have read the declaration above" Font-Bold="True" /></p>

     
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" CausesValidation="true" visible="false" />
    <div class="row">
       
        <div class="form-group">  
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
       <div class="form-group">  
                <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_quals_on_entry_aspx"/>
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

