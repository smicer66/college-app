<%@ control Language="VB" AutoEventWireup="false" CodeFile="checkout_applications.ascx.vb" Inherits="checkout_applications"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<%-- <script src="/js/jquery-1.10.2.js"></script>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/south-street/jquery-ui.css" />

  <script>
      $(function () {
          $(function () {
              $("#txtDateOfBirth").datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, yearRange: "1930:2000" })
          });
      });
  </script>--%>

<br /><br />
                <ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                  <li class="active">Personal Details</li>
                </ol>

  

<div class="panel panel-success" runat="server" id="divALevels" visible="false">
    <div class="panel-heading">A Level Subject Choices</div>
    <p>You have selected an A-Level Pathway, please choose 3 A-Levels subjects below that interest you the most. You will have chance to discuss the options that you have submitted at your Course Information Meetings and will have the opportunity to change if needed.</p>
              <div class="form-group"> 
         <span class="textfieldlabelrequired">* Choice 1</span>
                        <asp:DropDownList runat="server" ID="ddlAlevel_one" CssClass="textfield form-control">
                    </asp:DropDownList>
              </div>
         <div class="form-group"> 
         <span class="textfieldlabelrequired">* Choice 2</span>
                        <asp:DropDownList runat="server" ID="ddlAlevel_two" CssClass="textfield form-control">
                    </asp:DropDownList>
              </div>
         <div class="form-group"> 
         <span class="textfieldlabelrequired">* Choice 3</span>
                        <asp:DropDownList runat="server" ID="ddlAlevel_three" CssClass="textfield form-control">
                    </asp:DropDownList>
              </div>
    </div>


<div class="panel panel-success">
    <div class="panel-heading">About you</div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Title" ID="StudentEnrolmentField7" runat="server" IsRequired="true" LabelWidth="200" AutoFocus="true" CustomCaption="Title *"  ExcludedIDValues="Br,Dr,Mast,Prof,Revd,Sr" />
    </div>
    <div>Legal Name(as Passport/Birth Certificate)</div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname" ID="fldSurname" runat="server" IsRequired="true" LabelWidth="200"    CustomCaption="Surname/family name *"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="FirstForename" ID="StudentEnrolmentField1" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="First name(s) *" />
    </div>    
    <div class=" form-group">
        <cc1:StudentEnrolmentField id="datepicker" runat="server" IsRequired="true" StudentEnrolmentFieldType="DateOfBirth"  LabelWidth="250" ClientIDMode="Static" CustomFieldType="Date" CustomCaption="Date of birth (dd/mm/yyyy) *" Placeholder="dd/mm/yyyy"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Sex" ID="StudentEnrolmentField4" runat="server" LabelWidth="200" CustomCaption="Sex *" IsRequired="true" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel" ID="StudentEnrolmentField5" runat="server"  LabelWidth="200" CustomCaption="Home tel" Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$" Placeholder="e.g. 0xxxxxxxxxx"  Title="Please enter a valid phone number"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="MobileTel"  ID="fldMobile" runat="server" IsRequired="true"  LabelWidth="200" CustomCaption="Mobile * (eg. 07841123456)" Pattern="^(07[\d]{8,12}|447[\d]{7,11})$" Placeholder="e.g. 0xxxxxxxxxx" Title ="Please enter a valid mobile number"/>
    </div>
     <div class="form-group">
    <asp:Label ID="lblWhatsApp" Text="Do you use WhatsApp *" runat ="server"></asp:Label><br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="fldWhatsApp" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true"  >
    <asp:ListItem Text ="" Value =""></asp:ListItem>
    <asp:ListItem Text ="Yes" Value ="Y"></asp:ListItem>
    <asp:ListItem Text ="No" Value ="N"></asp:ListItem>
    </asp:DropDownList>
    </div>
    <div class=" form-group">
        <cc1:StudentEmailField StudentEnrolmentFieldType="Email" ID="StudentEnrolmentField3" runat="server" IsRequired="true" LabelWidth="200" HTML5InputType="email" Placeholder="e.g. name@domain.com" CustomCaption="Email *" Pattern="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"/>
    </div>
   
    
    <%--<asp:CheckBox ID="chkMailingList" runat="server"  Text="Would you like to join our mailing list ?" Font-Bold="True"   />--%>
    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SentMarketingInfo" ID="fldMarketingInfo" runat="server" IsRequired="false" LabelWidth="1100"
            CustomCaption="We would like to keep your contact details so we can inform you of any news, courses or events that you may be interested in. If you are happy for us to contact you in the future, please tick this box."  Width="35" />
            <br /><br /> 
              <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HeardAboutCollegeID" ID="fldHeardAboutCollegeID" runat="server" IsRequired="false" LabelWidth="300"
            CustomCaption="How did you hear about the college?" />
    </div>
   <%-- <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="UniqueLearnerNo"  ID="fldUniqueLearnerNumber" runat="server" IsRequired="false" LabelWidth="300"   CustomCaption="Unique Learner Number(ULN) if known"/>
    </div>--%>
    
</div>


<%--<div class="panel panel-success">
    <div class="panel-heading">Photo</div>
    <p>If you would like to upload a photo, you can do that here. </p>
    <div class=" form-group">
    <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
    </div>--%>



        <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="address_0_aspx" CausesValidation="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

