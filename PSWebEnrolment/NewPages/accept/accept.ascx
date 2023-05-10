<%@ Control Language="VB" AutoEventWireup="false" CodeFile="accept.ascx.vb" Inherits="accept" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

      <script type="text/javascript">
         $(document).ready(function () {

            if ($("#<%=ddlAccept.ClientID%>").val() == "2")
{
          $("#divWhy").show();
}
             $('#<%= ddlAccept.ClientID %>').change(function () {
                 $("#divWhy").hide();
        
                 $("#<%=ddlWhy.ClientID%>").val("")
           
            if ($("#<%=ddlAccept.ClientID%>").val() == "2") {
         
                     $("#divWhy").show();
                            return;
                 }

             });
         });
 
      </script>

<%--<ol class="breadcrumb" runat="server">
<li class="active">Results Day</li>
</ol>--%>

<%--<div class="stepwizard">
    <div class="stepwizard-row">
         <div class="stepwizard-step">
            <asp:Button CssClass="btn btn-default btn-circle" runat="server" ID="btnStage1" Text="1" />
            <p>Results</p>
        </div>
        <div class="stepwizard-step">
            <asp:Button CssClass="btn btn-primary btn-circle" runat="server" ID="btnStage2" Text="2" />
            <p>Profile</p>
        </div>
        <div class="stepwizard-step">
            <asp:Button CssClass="btn btn-default btn-circle" runat="server" ID="btnStage3" Text="3" />
            <p>Terms</p>
        </div>

        </div>
    </div>
       --%>
 <cc1:CourseEnquireAction ID="CourseEnquireAction" runat="server" />
<br />
<br />
<div class="container">
    <div class="row">        
  

         <div class="col-sm-12 col-md-6">

                        <h3>Accept Your Offer</h3>
            <p><strong> <asp:Label runat="server" id="courseLabel"></asp:Label></strong></p>
             <p>Congratulations in securing an offer of a place here at the City of Bristol College for September!</p>

<p>Please can you submit your response of this course offer for us to update your records by using the form below and we will be in touch via email soon in regards to enrolling.</p>
  
             </div>
        </div>
    <div class="row">     
    
         <div class="col-sm-6 columns form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="RefNo" ID="fldRefno" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="* Student ID" />
  
             </div>
                 <div class="col-sm-6 columns form-group"
              <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Email" ID="fldEmail" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="* Confirm your email" />
    
             </div>
        </div>
     <div class="row">  
          <div class="col-sm-12 columns form-group"">
           <span class="textfieldlabelrequired">* Please tell us your decision:</span>
                <asp:DropDownList runat="server" ID="ddlAccept" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Accept offer - you are my college of choice" Value="4"></asp:ListItem>
             <asp:ListItem Text="Accept Offer – I am accepting this offer and other offers elsewhere" Value="5"></asp:ListItem>
             <asp:ListItem Text="I would like to receive further information, advice and guidance about my options" Value="3"></asp:ListItem>
             <asp:ListItem Text="I would like to decline my offer" Value="2"></asp:ListItem>
                    </asp:DropDownList>
         </div>
        
    </div>
          <div class="row"  id="divWhy" style="display:none">
          <div class="col-sm-12 columns form-group"> 
         <span class="textfieldlabelrequired">Please tell us why you are declining the offer?</span>
                        <asp:DropDownList runat="server" ID="ddlWhy" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Accepted place at another training provider" Value="1"></asp:ListItem>
             <asp:ListItem Text="Obtained full time employment" Value="2"></asp:ListItem>
             <asp:ListItem Text="Obtained part-time employment" Value="3"></asp:ListItem>
                             <asp:ListItem Text="Signed up as an Apprenticeship with City of Bristol Collegep" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Signed up as an Apprenticeship with another training provider" Value="5"></asp:ListItem>
                             <asp:ListItem Text="Other" Value="6"></asp:ListItem>
                    </asp:DropDownList>
              </div>
       
      </div>
</div>
    
      <p>Please see the full <a href="http://www.cityofbristol.ac.uk/privacy-statement/">Privacy Statement</a>.</p>
  <%--  <div class=" form-group">
        <cc1:StudentEmailField StudentEnrolmentFieldType="Email" ID="StudentEnrolmentField23" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="Personal Email" Pattern="^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"  />
    </div>--%>

           
 
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" />

   <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />