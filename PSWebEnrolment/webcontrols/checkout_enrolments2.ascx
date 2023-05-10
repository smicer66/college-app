<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_enrolments2.vb" Inherits="webcontrols_checkout_enrolments2" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>    
                     <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>                  
                  <li class="active">Further Details</li>
                </ol>
   
<div class="panel panel-danger">
<div class="panel-heading">Contact Details - continued</div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="MobileTel" ID="fldMobile" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="Mobile *" />
    </div>
     <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel" ID="fldHomeTelephone" runat="server"  LabelWidth="200" CustomCaption="Home telephone" />
  </div>
 <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel1" ID="fldWorkTelephone" runat="server"  LabelWidth="200" CustomCaption="Work telephone" />
  </div>
    <div class=" form-group">
        <cc1:StudentEmailField StudentEnrolmentFieldType="Email" ID="StudentEmailField1" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="Email *" />
    </div>
  <div class="panel-heading">Residence</div>
    <div><strong>NOTE: you may be required to provide further documentary evidence of your status in the UK</strong></div>
    <br />


 
                 <div class="form-group">
           <span class="textfieldlabelrequired">* Did you enter the UK from another country mainly to receive education?</span>
              <asp:DropDownList ID="selectEnterforEducation" runat="server" CssClass="textfield form-control"  >
             <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="Y">Yes</asp:ListItem>
             <asp:ListItem value="N">No</asp:ListItem>
         </asp:DropDownList>
            </div>
      <div class="row" id="euromessage">
          <div class="form-group"> 
          <span class="textfieldlabelrequired">A member of the Learner Services team may be in touch to discuss your enrolment where additional evidence is required to assess your eligibility for free tuition.</span>
  </div>
          </div>
     <div class="form-group"> 
            <span class="textfieldlabelrequired">* Have you lived in the UK legally for at least the last three years ?</span>
              <asp:DropDownList ID="selectEuro" runat="server" CssClass="textfield form-control" >
             <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="1">Yes</asp:ListItem>
             <asp:ListItem value="2">No</asp:ListItem>
         </asp:DropDownList>
             
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EuroResidentID" ID="fldEuro" runat="server" IsRequired="false" Visible="false"  />
          </div>
          <div class="row" id="euroFields">
          <div class="form-group">
                     <span class="textfieldlabelrequired">* What date did you arrive in the UK ?</span><cc1:StudentEnrolmentField StudentEnrolmentFieldType="DateOfEntryUK"  id="fldDateEntry" runat="server" CustomCaption=" "  LabelWidth="300" Width="100"/>
        
        </div>
            
        <div class="form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="VisaTypeID" ID="StudentEnrolmentField100" runat="server" LabelWidth="300"  IsRequired="false" CustomCaption="* Do you have pre-settled or settled status?" />
           </div>

</div>
     <div class="form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="NationalityID" ID="fldNationalityID" runat="server"  IsRequired="true"  LabelWidth="400" CustomCaption="* What is your nationality" />
        </div>
       <div class="form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CountryID" ID="StudentEnrolmentField20" runat="server"  IsRequired="true"  CustomCaption="* What is your home country"  LabelWidth="400"/>
        </div>
     <div class="form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentFirstLanguageID" ID="StudentEnrolmentField1" runat="server" IsRequired="true" CustomCaption="* What is your first spoken language?"  LabelWidth="400"/>
           </div>

      
    <div class="form-group">
    <!--<asp:Label ID="lblCriminal" Text="Do you have any unspent criminal convictions, any outstanding court proceedings, or are you on any offenders register?*" runat ="server">   </asp:Label>-->
        <strong>Do you have any unspent criminal convictions, any outstanding court proceedings, or are you on any offenders register?</strong>

    <br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpCriminal" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true" >
    <asp:ListItem Text ="" Value =""></asp:ListItem>
    <asp:ListItem Text ="Yes" Value ="2"></asp:ListItem>
    <asp:ListItem Text ="No" Value ="3"></asp:ListItem>
    </asp:DropDownList>

<br />
        If you declare that you have a conviction, you will be contacted for further information. This information will help us assess any potential risks to yourself or others at college.
                    <br />
        The college has a duty of care to all its staff and students to ensure that any risk to their safety is minimised.
                    <br />
        The college reserves the right not to enrol anyone who may pose a threat or danger to the safety of its staff and students. Having a criminal record will not necessarily prevent you studying at college but will depend on the nature of the course and the circumstances of the offence. If you do not disclose a conviction, this can result in disciplinary action or  your enrolment being cancelled. 


    </div>
    
</div>

<div class="panel panel-danger">
    <div class="panel-heading">Emergency contact 1</div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact1"  ID="fldEmergencyContactName" runat="server" IsRequired="True" LabelWidth="200" CustomCaption ="Name *"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact1RelationshipID"  ID="fldRelationship" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Relationship" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact1Tel"  ID="fldTelephone1" runat="server" IsRequired="True" LabelWidth="200" CustomCaption ="Telephone *" />
    </div>
     <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact1EmailAddress"  ID="fldEmail1" runat="server" IsRequired="false" LabelWidth="200"  CustomCaption ="Email"/>
    </div>
    <br />
    <div class="panel-heading">Emergency contact 2</div>
     <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2"   ID="fldEmergencyContactName1" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Name" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2RelationshipID"  ID="fldRelationship1" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Relationship" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2Tel"  ID="fldTelephone2" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Telephone"/>
    </div>
     <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact2EmailAddress"  ID="fldEmail2" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Email" />
    </div>
</div>




        <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="address_0_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="checkout_parent_guardian" CausesValidation="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />




    <script type="text/javascript">
        $(document).ready(function () {
            $("#euroFields").hide();
            $("#euromessage").hide();
            if ($("#<%=selectEuro.ClientID%>").val() == "2") {
                $("#euroFields").show();
           //      $("#euromessage").show();
            }
            if ($("#<%=selectEnterforEducation.ClientID%>").val() == "Y") {
            //     $("#euromessage").show();
            }
            $('#<%= selectEuro.ClientID %>').change(function () {
                 // $('#cboEuroResidentID').checked=false;
                if ($("#<%=selectEuro.ClientID%>").val() == "2") {
                    $("#euroFields").show();
                 //   $("#euromessage").show();
                    return;
                }
                else {
                    $("#euroFields").hide();
                }
            });
            $('#<%= selectEnterforEducation.ClientID %>').change(function () {
           
                if ($("#<%=selectEnterforEducation.ClientID%>").val() == "Y") {
              //      $("#euromessage").show();
                    return;
                }
                else {
                    $("#euromessage").hide();
                }
            });


       


        });
    </script>