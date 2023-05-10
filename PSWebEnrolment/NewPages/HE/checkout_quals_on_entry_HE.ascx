<%@ control  Language="VB"  AutoEventWireup="false" CodeFile="checkout_quals_on_entry_HE.ascx.vb" Inherits="checkout_quals_on_entry" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br />
<br />
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Emergency Contact</li>                   
                    <li>Further Details</li>
                    <li><strong>Qualifications</strong></li>
                     <li>Employment</li>
                     <li>Attachments</li>
         
                     <li>Declarations</li>
                    </ol>

<div class="panel panel-info" id="panel1" runat="server">
    <div class="panel-heading">Your Qualifications</div>
     
        <div class="container">
    <div class="row">
        <div class="col-sm-12 columns form-group"> 
             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HEQualsOnEntryID" ID="StudentEnrolmentField29" runat="server" LabelWidth="500" CustomCaption="* Select the highest qualification that you have achieved from the list below" IsRequired="True" Visible="true" />
   
            </div>
    </div>  
            </div>
    <br />
<p>If you are aged 18 or under, please list any results you already have, or if you are still at school, please enter any grade predictions you have been given to the best of your knowledge.</p>
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


 <cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" CausesValidation="true"  />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" CausesValidation="true"  />
<br />

<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"  />
    
   
        <asp:HiddenField  id="NoQuals" value="false" runat="server"  ClientIDMode="static" />
     <asp:HiddenField  id="intQualRows" value="0" runat="server"  ClientIDMode="static" />




