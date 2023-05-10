<%@ control  Language="VB"  AutoEventWireup="false" CodeFile="checkout_quals_on_entryHE.ascx.vb" Inherits="checkout_quals_on_entry" %>
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
                    <%--<li><a href="webenrolment.aspx?page=~/webcontrols/checkout_prior_attainment.ascx">Prior Attainment</a></li>--%>
                  <li class="active">Quals on Entry</li>
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
                  <li class="active">Quals on Entry</li>
                </ol>

<div class="panel panel-info" id="panel1" runat="server">
    <div class="panel-heading">Qualifications on Entry</div>
     
<p>If you are aged 18 or under, please list any results you already have, or if you are still at school, please enter any grade predictions you have been given to the best of your knowledge. This can be discussed in more detail when you come for an interview, so please do not be too concerned if you are unsure. If you haven't got your predicted grades yet just add the subjects you are studying.</p>
<p>If you are aged 19 or over and do not have your qualifications available, please list what you know about your English and Maths qualifications. 
You will have opportunity to discuss your previous qualifications when you come in to College.</p>

   

    <%--<a href="#" class="show_hide btn btn-primary">No prior qualifications</a>--%>
  
    <div id="slidingdiv" class="slidingDiv" runat="server">
<asp:table class="table table-striped text-center" id="tblQuals" runat="server">
<%--<tr><th>Qualification</th><th>Subject (if not in list)</th><th>Predicted Grade</th><th>Grade</th><th>Date Awarded</th></tr>--%>

</asp:table>
    <asp:button runat="server" id="btnAdd" cssClass="btn btn-success" text="Add Row"></asp:button>
	<asp:button runat="server" id="btnRemove" cssClass="btn btn-success" text="Remove Row"></asp:button>

    </div>
   
    </div>
<div class="panel panel-info" id="divStatement" runat="server" visible="false">
    <div class="panel-heading">Personal Statement</div>
    <div class=" form-group">
         <p>You are required to provide a personal statment to support your application. Please include: </p>
        <ol><li>Why you are applying</li><li>What you would like to study at the univerisity, and why</li><li>Any experience you have in relation to the course, this maybe educational, voluntary and/or work based</li></ol>
   <p>Please limit your personal statement to no more than 1 A4 side.</p>
        <asp:TextBox   runat="server" TextMode="MultiLine" ID="personalstatement" rows="40" Columns="100" Width="100%"
      ></asp:TextBox>
    </div>
    </div>
 <cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" CausesValidation="true"  />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" CausesValidation="true" EnableEnterKey="true" />
<br />

<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"  />
    
   
        <asp:HiddenField  id="NoQuals" value="false" runat="server"  ClientIDMode="static" />
     <asp:HiddenField  id="intQualRows" value="0" runat="server"  ClientIDMode="static" />

<script type="text/javascript">

    $(document).ready(function () {
        // Hide & show details on fees (without popping the browser window to the top on each click!)
        $(".slidingDiv").show();
        $(".show_hide").show();
        


        $('.show_hide').click(function (e) {
            $(".slidingDiv").slideToggle();
            var qual = (document.getElementById('NoQuals').value);
            qual = (qual == "true") ? true : false;
            document.getElementById('NoQuals').value = !qual;
            e.preventDefault();
        });
        // End hide & show

    });
   
</script>
