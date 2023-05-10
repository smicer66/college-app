<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_enrolments2_adult.vb" Inherits="webcontrols_checkout_enrolments2" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<script>

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

</script>

<br />
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Emergency contact</li>                   
                    <li><strong>Further Details</strong></li>
       <li>Qualifications</li>
                  <li>Employment</li>
                     <li>Attachments</li>
                          <li>Photo</li>
                     <li>Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
<div class="container">
   <div class="row">
      <div class="col-sm-12 columns form-group"> 
       <h2>Residency</h2>
          </div>
  </div>
 <div class="row">
        <div class="col-sm-12 columns form-group"> 
            <span class="textfieldlabelrequired">* Have you lived in the UK for the last 3 years?</span>
              <asp:DropDownList ID="selectEuro" runat="server" CssClass="textfield form-control" >
             <asp:ListItem value="">Please select...</asp:ListItem>
             <asp:ListItem value="1">Yes</asp:ListItem>
             <asp:ListItem value="2">No</asp:ListItem>
         </asp:DropDownList>
             
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EuroResidentID" ID="fldEuro" runat="server" IsRequired="false" Visible="false"  />
          </div>
     </div>
       
    <div class="row">
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="NationalityID" ID="fldNationalityID" runat="server"  IsRequired="true"  LabelWidth="400" CustomCaption="* What is your nationality" />
        </div>
       <div class="col-sm-6 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CountryID" ID="StudentEnrolmentField20" runat="server"  IsRequired="true"  CustomCaption="* What is your home country"  LabelWidth="400"/>
        </div>

    </div>
        <div class="row">
       <div class="col-sm-12 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentFirstLanguageID" ID="StudentEnrolmentField1" runat="server" IsRequired="true" CustomCaption="* What is your first spoken language?"  LabelWidth="400"/>
           </div>
     </div>
</div>


<h2>Support Needs</h2>
<div class="container">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
          <span class="textfieldlabelrequired">* Do you consider yourself to have a learning difficulty or disability?</span>
      
            <asp:DropDownList runat="server" ID="selectLearnDiff"  CssClass="textfield form-control" >
                <asp:ListItem Text="Please select..." Value=""></asp:ListItem>
                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                <asp:ListItem Text="Rather not say" Value="9"></asp:ListItem>
            </asp:DropDownList>
          <div style="display:none">
             <cc1:StudentEnrolmentField Visible="true" ClientIDMode="Static" StudentEnrolmentFieldType="LearningDiffOrDisID" ID="fldLearningDiffOrDisID" runat="server" IsRequired="false"   />
      </div>
          </div>
    </div>
    <div class="row"  id="disfields">
    
      <div class="col-sm-6 columns form-group"> 

             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory1ID" ID="stuDisabilityCategory1ID" runat="server"  LabelWidth="500" IsRequired="false" CustomCaption="* Please specify main learning/disability" ExcludedIDValues="99"/>
              <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory2ID" runat="server" Visible="true"   IsRequired="false"  LabelWidth="500" CustomCaption="And, if appropriate, a secondary learning difficulty" />
        </div>
           <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ALSRequired" runat="server" IsRequired="false"   CustomCaption="Do you need to speak to us in regards to any support requirements?" LabelWidth="500"/>
          </div>

    
        <div class="row">
      <div class="col-sm-12 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityNotes" runat="server" IsRequired="false" CustomCaption="Please use this space below to make us aware of any other conditions, issues or additional requirements you may have." LabelWidth="700" />
          </div>
    </div>
  
    <p>Someone from the ALS Team will get in touch with you if you have indicated you require assistance.</p>
   
 
</div>
       <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" />
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  CausesValidation="true" EnableEnterKey="true" />
    </div>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#disfields").hide();
        if ($("#<%=selectLearnDiff.ClientID%>").val() == "1") {
                $("#disfields").show();
            }
            $('#<%= selectLearnDiff.ClientID %>').change(function () {
              //  $('#cboLearningDiffOrDisID').val($(this).val());
            if ($("#<%=selectLearnDiff.ClientID%>").val() == "1") {
                    $("#disfields").show();
                    return;
                }
                else {
                    $("#disfields").hide();
                }
            });
        });
    </script>