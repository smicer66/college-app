<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dpo.ascx.vb" Inherits="accept" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

      <script type="text/javascript">
         $(document).ready(function () {

            if ($("#<%=ddlOutomeType.ClientID%>").val() == "EDU")
            {
            $("#divEDU").show();
             }
            if ($("#<%=ddlOutomeType.ClientID%>").val() == "EMP")
            {
            $("#divInEmp").show();
             }
            if ($("#<%=ddlOutomeType.ClientID%>").val() == "NPE")
            {
            $("#divNotInEmp").show();
             }


             $('#<%= ddlOutomeType.ClientID %>').change(function () {
                 $("#divEDU").hide();
                  $("#divInEmp").hide();
                $("#divNotInEmp").hide();

                 $("#<%=ddlEdu.ClientID%>").val("")
                $("#<%=ddlInEmp.ClientID%>").val("")
                $("#<%=ddlNotInEmp.ClientID%>").val("")
           
            if ($("#<%=ddlOutomeType.ClientID%>").val() == "EDU") {
         
                     $("#divEDU").show();
                       return;
                 }
           
            if ($("#<%=ddlOutomeType.ClientID%>").val() == "EMP") {
         
                     $("#divInEmp").show();
                     return;
                 }

           
            if ($("#<%=ddlOutomeType.ClientID%>").val() == "NPE") {
         
                     $("#divNotInEmp").show();
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

                        <h3>Destination and Progression</h3>
            <p><strong> <asp:Label runat="server" id="courseLabel"></asp:Label></strong></p>
             <p>The DFE require us to collect the destination of every learner when they have completed or withdrawn from the College.</p>

<p>This is a very quick survey and you will only be asked a couple of questions. Please can you submit your response by selecting the appropriate option(s) from the drop-down list below:</p>
  <p>All fields marked as * are mandatory.</p>
             </div>
        </div>
     <div class="row">  
          <div class="col-sm-12 columns form-group"">
           <span class="textfieldlabelrequired">* Please select the appropriate destination value that applies to you following the completion/withdrawal of your course(s) at City of Bristol College</span>
                <asp:DropDownList runat="server" ID="ddlOutomeType" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Apprenticeship" Value="106"></asp:ListItem>
                    <asp:ListItem Text="Education" Value="EDU"></asp:ListItem>
             <asp:ListItem Text="In Paid Employment" Value="EMP"></asp:ListItem>
             <asp:ListItem Text="Gap Year before starting Higher Education (HE)" Value="115"></asp:ListItem>
                     <asp:ListItem Text="Not in Paid Employment" Value="NPE"></asp:ListItem>
                     <asp:ListItem Text="Other" Value="OTH"></asp:ListItem>
                       <asp:ListItem Text="Social Destination (High needs student only)" Value="SDE"></asp:ListItem>
                       <asp:ListItem Text="Voluntary Work" Value="123"></asp:ListItem>
                    </asp:DropDownList>
         </div>
        
    </div>
          <div class="row"  id="divEDU" style="display:none">
          <div class="col-sm-12 columns form-group"> 
         <span class="textfieldlabelrequired">* You have stated you are in Education, please tell us the type of Education:</span>
                        <asp:DropDownList runat="server" ID="ddlEdu" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Traineeship" Value="105"></asp:ListItem>
             <asp:ListItem Text="Supported Internship" Value="107"></asp:ListItem>
                             <asp:ListItem Text="Other Further Education (FE) (Full-time)" Value="108"></asp:ListItem>
                            <asp:ListItem Text="Other Further Education (FE) (Part-time)" Value="109"></asp:ListItem>
                             <asp:ListItem Text="Higher Education (HE)" Value="110"></asp:ListItem>
                    </asp:DropDownList>
              </div>
       
      </div>
              <div class="row"  id="divInEmp" style="display:none">
          <div class="col-sm-6 columns form-group"> 
         <span class="textfieldlabelrequired">* You have indicated you are in In Paid Employment, please tell us the type of paid employment:</span>
                        <asp:DropDownList runat="server" ID="ddlInEmp" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="In paid employment for 16 hours or more per week" Value="111"></asp:ListItem>
             <asp:ListItem Text="In paid employment for less than 16 hours per week" Value="112"></asp:ListItem>
             <asp:ListItem Text="Self-employed for 16 hours or more per week" Value="113"></asp:ListItem>
       
                            <asp:ListItem Text="Self-employed for less than 16 hours per week" Value="114"></asp:ListItem>

                    </asp:DropDownList>
              </div>    
                <div class="col-sm-6 columns form-group"> 
         <span class="textfieldlabelrequired">* Please select the closest occupation that best describes your job:</span>
                        <asp:DropDownList runat="server" ID="ddlSOC" CssClass="textfield form-control">
                              <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
                    <asp:ListItem Text="Administrative occupations" Value="11"></asp:ListItem>
                     <asp:ListItem Text="Business and public service associate professionals" Value="21"></asp:ListItem>
                     <asp:ListItem Text="Business, media and public service professionals" Value="22"></asp:ListItem>
                     <asp:ListItem Text="Caring personal service occupations" Value="23"></asp:ListItem>
                     <asp:ListItem Text="Community and civil enforcement occupations¹" Value="24"></asp:ListItem>
                     <asp:ListItem Text="Corporate managers and directors" Value="12"></asp:ListItem>
                     <asp:ListItem Text="Culture, media and sports occupations" Value="31"></asp:ListItem>
                     <asp:ListItem Text="Customer service occupations" Value="32"></asp:ListItem>
                     <asp:ListItem Text="Elementary administration and service occupations" Value="33"></asp:ListItem>
                     <asp:ListItem Text="Elementary trades and related occupations" Value="34"></asp:ListItem>
                     <asp:ListItem Text="Health and social care associate professionals" Value="35"></asp:ListItem>
                     <asp:ListItem Text="Health professionals" Value="51"></asp:ListItem>
                     <asp:ListItem Text="Leisure, travel and related personal service occupations" Value="52"></asp:ListItem>
                     <asp:ListItem Text="Other managers and proprietors" Value="53"></asp:ListItem>
                     <asp:ListItem Text="Process, plant and machine operatives" Value="54"></asp:ListItem>
                     <asp:ListItem Text="Protective service occupations" Value="41"></asp:ListItem>
                     <asp:ListItem Text="Sales occupations" Value="42"></asp:ListItem>
                     <asp:ListItem Text="Science, engineering and technology associate professionals" Value="61"></asp:ListItem>
                     <asp:ListItem Text="Science, research, engineering and technology professionals" Value="62"></asp:ListItem>
                     <asp:ListItem Text="Secretarial and related occupations" Value="63"></asp:ListItem>
                     <asp:ListItem Text="Skilled agricultural and related trades" Value="71"></asp:ListItem>
                     <asp:ListItem Text="Skilled construction and building trades" Value="72"></asp:ListItem>
                     <asp:ListItem Text="Skilled metal, electrical and electronic trades" Value="81"></asp:ListItem>
                     <asp:ListItem Text="Teaching and other educational professionals" Value="82"></asp:ListItem>
                     <asp:ListItem Text="Textiles, printing and other skilled trades" Value="91"></asp:ListItem>
                     <asp:ListItem Text="Transport and mobile machine drivers and operatives" Value="92"></asp:ListItem>


                    </asp:DropDownList>
              </div>    
      </div>


            <div class="row"  id="divNotInEmp" style="display:none">
          <div class="col-sm-12 columns form-group"> 
         <span class="textfieldlabelrequired">* You have indicated you are in Not In Paid Employment, please tell us the type of Not In Paid Employment:</span>
                        <asp:DropDownList runat="server" ID="ddlNotInEmp" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Not in paid employment, looking for work and available to start work" Value="116"></asp:ListItem>
             <asp:ListItem Text="Not in paid employment, not looking for work and/or not available to start work (including retired)" Value="117"></asp:ListItem>

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