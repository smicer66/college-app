<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_references.ascx.vb" Inherits="webcontrols_checkout_references" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <%--<ol class="breadcrumb" id="breadcrumbapps" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications2.ascx">Further Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_school_employer.ascx">School / Employer</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_prior_attainment.ascx">Prior Attainment</a></li>
                  <li class="active">Quals on Entry</li>
                </ol>--%>
                 <ol class="breadcrumb" id="breadcrumbenrols" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Parent / Guardian</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_school_employer.ascx">School / Employer</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_prior_attainment.ascx">Prior Attainment</a></li>
                     <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Quals on Entry</a></li>
                  <li class="active">References</li>
                </ol>

<div class="panel panel-info" id="panel1" runat="server">
    <div class="panel-heading">References</div>
     
                <p>
                Please enter the details of your referees, who we may contact in the event that you are enrolled at the college.</p>

   

    <a href="#" class="show_hide btn btn-primary">No references</a>
    <br />
<br />
    <div id="slidingdiv" class="slidingDiv" runat="server">
        <div class="table-responsive">
<table class="table text-center" id="tblReferences" runat="server">

</table></div>
    <asp:button runat="server" id="btnAdd" cssClass="btn btn-success" text="Add Row"></asp:button>

    </div>
   
    </div>

 <cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_quals_on_entry_aspx" />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"   CausesValidation="true" />
<br />

<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"  />
    
   
        <asp:HiddenField  id="NoReferences" value="false" runat="server"  ClientIDMode="static" />
     <asp:HiddenField  id="intReferenceRows" value="0" runat="server"  ClientIDMode="static" />

<script type="text/javascript">

    $(document).ready(function () {
        // Hide & show details on fees (without popping the browser window to the top on each click!)
        $(".slidingDiv").show();
        $(".show_hide").show();



        $('.show_hide').click(function (e) {
            $(".slidingDiv").slideToggle();
            var ref = (document.getElementById('NoReferences').value);
            ref = (ref == "true") ? true : false;
            document.getElementById('NoReferences').value = !ref;
            e.preventDefault();
        });
        // End hide & show

    });
</script>