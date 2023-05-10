<%@ Control Language="VB" AutoEventWireup="false" CodeFile="org.ascx.vb" Inherits="orgs" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>



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
    <p>By fully completing and submitting this form, it will allow the College to process your enquiry promptly.</p>
    <p>Following receipt of your information, one of our Business Development Managers will contact you to guide you through the process to successfully get your new Apprentice in place.</p>
    <br />
    <p>Please note all questions marked * are required fields.</p>
    <div class="row">        
  

         <div class="col-sm-12 col-md-6">

                        <h3>Employer Details</h3>
            <p><strong> <asp:Label runat="server" id="courseLabel"></asp:Label></strong></p>
          
             </div>
        </div>
    <div class="row">  
          <div class="col-sm-4 columns form-group"">
                  <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EmployerName"  ID="Field_employername" runat="server" IsRequired="true" LabelWidth="200"
           CustomCaption="*Employer Name" CssClass="textfieldlabelrequired" />
              </div>
            <div class="col-sm-4 columns form-group"">
  <cc1:StudentEnrolmentField width="150" CustomCaption="* Annual Payroll Value" StudentEnrolmentFieldType="StudentDetailUserDefined44" IsRequired="true" ID="StudentEnrolmentField19" runat="server"  Pattern="^\d+$"/>
         </div>
        <div class="col-sm-4 columns form-group"> 
                 <cc1:StudentEnrolmentField width="80" CustomCaption="* Number of employees" IsRequired="true" StudentEnrolmentFieldType="StudentDetailUserDefined33"  ID="StudentEnrolmentField1" runat="server"  Pattern="^\d+$"/>
  </div>
        </div>
              <div class="row">
                     <div class="col-sm-4 columns form-group">  
                   <span class="textfieldlabelrequired">* Your primary business sector</span>
                <asp:DropDownList runat="server" ID="ddlCategory1" CssClass="textfield form-control">
                    <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
                    <asp:ListItem Text="Accounting & Finance" Value="26"></asp:ListItem>
                    <asp:ListItem Text="Animal Care" Value="36"></asp:ListItem>
                    <asp:ListItem Text="Business & Customer Service" Value="18"></asp:ListItem>
                    <asp:ListItem Text="Catering & Hospitality" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Childcare" Value="16"></asp:ListItem>
                    <asp:ListItem Text="Community" Value="44"></asp:ListItem>
                    <asp:ListItem Text="Construction - Building Trades" Value="34"></asp:ListItem>
                    <asp:ListItem Text="Construction - Electrical" Value="32"></asp:ListItem>
                    <asp:ListItem Text="Construction - Plumbing" Value="33"></asp:ListItem>
                    <asp:ListItem Text="Creative & Design" Value="22"></asp:ListItem>
                    <asp:ListItem Text="Education / Learning" Value="38"></asp:ListItem>
                    <asp:ListItem Text="Engineering & Manufacturing" Value="24"></asp:ListItem>
                    <asp:ListItem Text="Government" Value="40"></asp:ListItem>
                    <asp:ListItem Text="Hair & Beauty" Value="20"></asp:ListItem>
                    <asp:ListItem Text="Health & Social Care" Value="15"></asp:ListItem>
                    <asp:ListItem Text="Human Resources" Value="35"></asp:ListItem>
                    <asp:ListItem Text="ICT" Value="23"></asp:ListItem>
                    <asp:ListItem Text="Management & Leadership" Value="27"></asp:ListItem>
                    <asp:ListItem Text="Marketing" Value="28"></asp:ListItem>
                    <asp:ListItem Text="Medical" Value="42"></asp:ListItem>
                    <asp:ListItem Text="Motor Vehicle" Value="25"></asp:ListItem>
                    <asp:ListItem Text="NHS" Value="41"></asp:ListItem>
                    <asp:ListItem Text="Real Estate" Value="39"></asp:ListItem>
                    <asp:ListItem Text="Security" Value="48"></asp:ListItem>
                    <asp:ListItem Text="Sport" Value="46"></asp:ListItem>
                    <asp:ListItem Text="Supporting Teaching & Learning" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Transport" Value="45"></asp:ListItem>
                    <asp:ListItem Text="Travel & Tourism" Value="47"></asp:ListItem>
                    <asp:ListItem Text="Warehousing & Storage" Value="30"></asp:ListItem>
                    <asp:ListItem Text="Other Sector" Value="31"></asp:ListItem>

                    </asp:DropDownList>
                         </div>
       <div class="col-sm-4 columns form-group">    
           <span class="textfieldlabelrequired">Your seconday business sector, if applies</span>
                <asp:DropDownList runat="server" ID="ddlCategory2" CssClass="textfield form-control">
                    <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
                    <asp:ListItem Text="Accounting & Finance" Value="26"></asp:ListItem>
                    <asp:ListItem Text="Animal Care" Value="36"></asp:ListItem>
                    <asp:ListItem Text="Business & Customer Service" Value="18"></asp:ListItem>
                    <asp:ListItem Text="Catering & Hospitality" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Childcare" Value="16"></asp:ListItem>
                    <asp:ListItem Text="Community" Value="44"></asp:ListItem>
                    <asp:ListItem Text="Construction - Building Trades" Value="34"></asp:ListItem>
                    <asp:ListItem Text="Construction - Electrical" Value="32"></asp:ListItem>
                    <asp:ListItem Text="Construction - Plumbing" Value="33"></asp:ListItem>
                    <asp:ListItem Text="Creative & Design" Value="22"></asp:ListItem>
                    <asp:ListItem Text="Education / Learning" Value="38"></asp:ListItem>
                    <asp:ListItem Text="Engineering & Manufacturing" Value="24"></asp:ListItem>
                    <asp:ListItem Text="Government" Value="40"></asp:ListItem>
                    <asp:ListItem Text="Hair & Beauty" Value="20"></asp:ListItem>
                    <asp:ListItem Text="Health & Social Care" Value="15"></asp:ListItem>
                    <asp:ListItem Text="Human Resources" Value="35"></asp:ListItem>
                    <asp:ListItem Text="ICT" Value="23"></asp:ListItem>
                    <asp:ListItem Text="Management & Leadership" Value="27"></asp:ListItem>
                    <asp:ListItem Text="Marketing" Value="28"></asp:ListItem>
                    <asp:ListItem Text="Medical" Value="42"></asp:ListItem>
                    <asp:ListItem Text="Motor Vehicle" Value="25"></asp:ListItem>
                    <asp:ListItem Text="NHS" Value="41"></asp:ListItem>
                    <asp:ListItem Text="Real Estate" Value="39"></asp:ListItem>
                    <asp:ListItem Text="Security" Value="48"></asp:ListItem>
                    <asp:ListItem Text="Sport" Value="46"></asp:ListItem>
                    <asp:ListItem Text="Supporting Teaching & Learning" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Transport" Value="45"></asp:ListItem>
                    <asp:ListItem Text="Travel & Tourism" Value="47"></asp:ListItem>
                    <asp:ListItem Text="Warehousing & Storage" Value="30"></asp:ListItem>
                    <asp:ListItem Text="Other Sector" Value="31"></asp:ListItem>

                    </asp:DropDownList>
       
           </div>
         </div>
              
             <div class="row"  >
          <div class="col-sm-12 columns form-group"> 
         <span class="textfieldlabelrequired">* Are you a registered company with <a href="https://www.gov.uk/government/organisations/companies-house" target="_blank">Companies House</a></span>
                        <asp:DropDownList runat="server" ID="ddlCompHouse" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
             <asp:ListItem Text="No" Value="2"></asp:ListItem>

                    </asp:DropDownList>
              </div>
       
      </div>
              <div class="row" id="divCompHouse" style="display:none">
      <div class="col-sm-12 columns form-group"> 
                <cc1:StudentEnrolmentField CustomCaption="* Company Registration Number" LabelWidth="400" StudentEnrolmentFieldType="StudentDetailUserDefined45" ID="StudentEnrolmentField8" runat="server"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?#(\d{4}|\d{3}))?$"/>
         
      </div>
               
   </div>

          <div class="row">
       <div class="col-sm-4 columns form-group"> 
  
   <cc1:StudentEnrolmentField CustomCaption="Business email" StudentEnrolmentFieldType="ParentEmailAddress" ID="StudentEnrolmentField3" runat="server"  Pattern="^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"/>
    
           </div>
      <div class="col-sm-4 columns form-group"> 
                <cc1:StudentEnrolmentField CustomCaption="Business telephone" StudentEnrolmentFieldType="Tel2" ID="StudentEnrolmentField4" runat="server"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?#(\d{4}|\d{3}))?$"/>
         
      </div>
                <div class="col-sm-4 columns form-group"> 
                <cc1:StudentEnrolmentField CustomCaption="Business website" StudentEnrolmentFieldType="StudentDetailUserDefined31" ID="StudentEnrolmentField6" runat="server"   />
         
      </div>
   </div>
         
 
          <h3>Employer Contact Details</h3>
      <div class="row">
      <div class="col-sm-6 columns form-group"><p>Quickly find your business address, enter postcode or partial address below:</p>
<p><asp:TextBox ID="txtLookup" runat="server" CssClass="formtext" ></asp:TextBox>
<asp:Button ID="btnFind" runat="server" Text="Find" CausesValidation="False" /></p>
          <div id="divlstResult" runat="server" visible="true"><asp:ListBox ID="lstresult" runat="server"  AutoPostBack="True" Width="75%"></asp:ListBox></div>
          </div>
        </div>
  <div id="divAddresslines" runat="server" visible="true">
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
          <cc1:StudentEnrolmentField runat="server" ID="txtAddress1" StudentEnrolmentFieldType="Address1" IsRequired="true" CustomCaption="* Address line 1"/>
          </div>
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField runat="server" ID="txtAddress2" StudentEnrolmentFieldType="Address2" CustomCaption="Address line 2"/>
          </div>
   </div>
  
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
          <cc1:StudentEnrolmentField runat="server" ID="txtAddress3" StudentEnrolmentFieldType="Address3" IsRequired="false" CustomCaption="Address line 3"/>
          </div>
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField runat="server" ID="txtAddress4" StudentEnrolmentFieldType="Address4" CustomCaption="Address line 4" />
          </div>
   </div>
    <div class="row">
         <div class="col-sm-6 columns form-group"> 
             <label for="postcode" style="font-weight:bold ">* Postcode</label><input runat="server" maxlength="9" type="text" id="postcode" class="form-control" name="pre[postalcode]" placeholder="Your postcode here..." autocomplete="off" pattern="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$" />
             </div>
        </div>
      <p></p>
     <div class="row">
    <div class="col-sm-6 columns form-group">     
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="FirstForename" ID="fldFirstName" runat="server" IsRequired="true" LabelWidth="400" CustomCaption="* Main contact firstname" I/>
     </div>
        <div class="col-sm-6 columns form-group">       
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname" ID="fldSurname" runat="server" IsRequired="true"  LabelWidth="400"  CustomCaption="* Main contact surname " />
     </div>
                 <div class="col-sm-6 columns form-group">       
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="knownas" ID="StudentEnrolmentField9" runat="server" IsRequired="true"  LabelWidth="400"  CustomCaption="* Job Title " />
     </div>
    </div>
         <div class="row">
        <div class="col-sm-12 columns form-group"> 
             <cc1:StudentEmailField StudentEnrolmentFieldType="Email" ID="fldEmail" runat="server" IsRequired="true"  LabelWidth="400" CustomCaption="* Main contact email" Pattern="^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"  />
            </div>
       </div>
           <div class="row">
       <div class="col-sm-12 columns form-group">  <p><strong>You must provide at least one phone number below:</strong></p>
           </div>
         </div>
    <div class="row">
       <div class="col-sm-6 columns form-group"> 
  
   <cc1:StudentEnrolmentField CustomCaption="* Main contact mobile" StudentEnrolmentFieldType="MobileTel" LabelWidth="400"   ID="StudentEnrolmentField2" runat="server"  Pattern="^(07[\d]{8,12}|447[\d]{7,11})$"/>
    
           </div>
      <div class="col-sm-6 columns form-group"> 
                <cc1:StudentEnrolmentField CustomCaption="* Main contact telephone" StudentEnrolmentFieldType="Tel" LabelWidth="400" ID="StudentEnrolmentField5" runat="server"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?#(\d{4}|\d{3}))?$"/>
         
      </div>
   </div>

 
      
      <h3>Health and Safety</h3>
      <p> </p>
      <div class="row"  >
          <div class="col-sm-12 columns form-group"> 
         <span class="textfieldlabelrequired">* Can you confirm you have in place suitable and sufficient insurance in respect to learners (employers' liability, public liability and other e.g. driving) and as legally required?</span>
                        <asp:DropDownList runat="server" ID="ddlInsure" CssClass="textfield form-control">
                        <asp:ListItem Text="Choose..." Value="" ></asp:ListItem>
            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
             <asp:ListItem Text="No" Value="2"></asp:ListItem>

                    </asp:DropDownList>
              </div>
       
      </div>
      <div class="row" >
        <div class="col-sm-12 columns form-group"><strong>Employers Liability Insurance</strong></div>
          </div>
           <div class="row" >
          <div class="col-sm-4 columns form-group">    <cc1:StudentEnrolmentField CustomCaption="* Company insurance name" StudentEnrolmentFieldType="StudentDetailUserDefined40" LabelWidth="400"   ID="StudentEnrolmentField13" runat="server"  IsRequired="true" />

              </div>
                    <div class="col-sm-4 columns form-group">    <cc1:StudentEnrolmentField CustomCaption="* Policy Number" StudentEnrolmentFieldType="StudentDetailUserDefined41" LabelWidth="400"   ID="StudentEnrolmentField14" runat="server" IsRequired="true"  />

              </div>
                    <div class="col-sm-4 columns form-group">    <cc1:StudentEnrolmentField CustomCaption="* Expiry date" StudentEnrolmentFieldType="StudentDetailUserDefined11" LabelWidth="400" width="150"  ID="StudentEnrolmentField15" HTML5InputType="date"  runat="server" IsRequired="true" />

              </div>
          </div>
        <div class="row" >
        <div class="col-sm-12 columns form-group"><strong>Public Liability Insurance</strong></div>
          </div>
           <div class="row" >
          <div class="col-sm-4 columns form-group">    <cc1:StudentEnrolmentField CustomCaption="* Company insurance name" StudentEnrolmentFieldType="StudentDetailUserDefined42" LabelWidth="400"   ID="StudentEnrolmentField16" runat="server" IsRequired="true"  />

              </div>
                    <div class="col-sm-4 columns form-group">    <cc1:StudentEnrolmentField CustomCaption="* Policy Number" StudentEnrolmentFieldType="StudentDetailUserDefined43" LabelWidth="400"   ID="StudentEnrolmentField17" runat="server"  IsRequired="true" />

              </div>
                    <div class="col-sm-4 columns form-group">    <cc1:StudentEnrolmentField CustomCaption="* Expiry date" StudentEnrolmentFieldType="StudentDetailUserDefined12" LabelWidth="400"  width="150"  ID="StudentEnrolmentField18" runat="server" HTML5InputType="date" IsRequired="true"  />

              </div>
          </div>
</div>
    
    <h3>College Privacy Notice</h3>
<p>Generally, the information is processed as part of our public interest task of providing training to your apprentice. Further information about use of and access to your personal data, details of organisations with whom we regularly share data, information about how we retain your data, and how to change your consent to being contacted, please visit: <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank">https://www.cityofbristol.ac.uk/privacy-statement/</a></p>

<p>As Data Controller, the College may share non-sensitive personal information with other organisations as set out on its Data Protection registration and from 25 May 2018, General Data Protection Regulation. The College may share your information with other organisations for education, training, employment, research and well-being related purposes. Further details are available on the College website <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank">https://www.cityofbristol.ac.uk/privacy-statement/</a>. If at any time you wish to stop receiving these messages, please contact Student Services on 0117 312 5000 or enquiries@cityofbristol.ac.uk and change your preferences or opt-out at any time.</p>

<p>Sensitive Information: The College may use this information to ensure equality of opportunity, support training, minimise risk and for anonymous statistics. We are required to share it with the relevant government departments as mentioned above. We will ask you before sharing it with others.</p>


        <p><strong>We will contact you by email/telephone in regards to your apprenticeship and to keep you updated on progress. We may also contact you by email/telephone in regards to our statutory duties. </strong></p>
   <p>You can also give your consent for using your email for:</p>
     
    <div class="row"> 
        <div class="col-sm-3 columns form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="AcceptMarketingConsent" ID="StudentEnrolmentField7" runat="server" LabelWidth="300" IsRequired="false"  CustomCaption="College marketing"/>
                    </div>
              <div class="col-sm-3 columns form-group">    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="AcceptShareInfoConsent" ID="StudentEnrolmentField10" runat="server" LabelWidth="300" IsRequired="false"  CustomCaption="External marketing / sharing consent"/>
                    </div>
          </div>
     <p>Documentation relating College policies can be found at:<a href="https://www.cityofbristol.ac.uk/about-us/college-policies/" target="_blank">https://www.cityofbristol.ac.uk/about-us/college-policies/</a> </p>
   
      <div class="row">
               <div class="col-sm-12 columns form-group"> 
               <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HeardAboutCollegeID" ID="StudentEnrolmentField29" runat="server" LabelWidth="500" CustomCaption="* Please tell us how you heard about the College?" IsRequired="True" Visible="true" />
   
               </div>
              </div>
        <p> <asp:CheckBox ID="chkConfirm" runat="server" 
            Text="- I confirm I have read the above Privacy Notice and the information given in this form is correct and complete." Font-Bold="True" 
            CausesValidation="True" />
    </p>
           
</div> 

        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnSubmit" CausesValidation="true" Visible="false"/>


<div  class="container">

    <div class="row">
        <div class="col-sm-3 columns form-group">  
            <button id="mybutton" class="btn btn-lg btn-primary" type="button"   runat="server" causesvalidation="true" onserverclick="btnContinue_Click">
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
       <div class="col-sm-6 columns form-group">  </div>
      </div>
  </div>
   
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

 <script type="text/javascript">  
  //   alert(($('#<%= chkConfirm.ClientID %>').is(':checked')))
  

    if ($("#<%=ddlCompHouse.ClientID%>").val() == "1")
     {
          $("#divCompHouse").show();
       }
        $('#<%= ddlCompHouse.ClientID %>').change(function () {
            $("#divCompHouse").hide();

           
    if ($("#<%=ddlCompHouse.ClientID%>").val() == "1") {
         
                $("#divCompHouse").show();
                    return;
            }

        });

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
