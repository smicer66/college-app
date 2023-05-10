<%@ Control Language="VB" AutoEventWireup="false" CodeFile="response.ascx.vb" Inherits="accept" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<%--      <script type="text/javascript">
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
 
      </script>--%>

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

                        <h3>Enrolment</h3>
            <p><strong> <asp:Label runat="server" id="courseLabel"></asp:Label></strong></p>
             <p>Congratulations in securing an offer of a place here at the City of Bristol College for September!</p>

<p>Please let us know how you wish to enrol by submitting your response below.</p>
  
             </div>
        </div>
   
     <div class="row">  
          <div class="col-sm-12 columns form-group"">
           <span class="textfieldlabelrequired">* How do you wish to enrol?</span>
                <asp:DropDownList runat="server" ID="ddlResponse" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Enrol online" Value="1"></asp:ListItem>
             <asp:ListItem Text="Enrol in person by visiting one of our campuses" Value="2"></asp:ListItem>
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