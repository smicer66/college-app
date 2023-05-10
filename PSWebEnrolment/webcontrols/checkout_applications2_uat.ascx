<script type="text/javascript">

    $(document).ready(function () {
        //set initial status
        showHideDisability($('#rdoLearnDiff input:checked').val());

        $('#rdoLearnDiff input').change(function () {
            showHideDisability($(this).val());
        });


        // function to set hidden bound field for LearningDiffOrDisID and display / hide disability fields
        function showHideDisability(v) {
            $('#cboLearningDiffOrDisID').val(v);

            if (v == "1") {
                $('.disfields').show()
            }
            else {
                $('.disfields').hide()
            }
        };


    });
</script>


<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_applications2_uat.ascx.vb" Inherits="webcontrols_checkout_applications2" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br />
<br />
<ol class="breadcrumb">
    <li><a href="default.aspx">Home</a></li>
    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications.ascx">Personal Details</a></li>
    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
    <li class="active">Further Details</li>
</ol>

<div class="panel panel-success">

    <div class="panel-heading">Further Details</div>

    <asp:Label ID="Label1" Text="The following information is confidential and can help the College know that you might need financial or other support, and can help put that in place before you start your course. " runat="server">   </asp:Label>

    <br />
    <br />

    <div class="form-group">
        <span class="textfieldlabelrequired">Do you consider yourself to have a learning difficulty or disability?</span>
        <asp:RadioButtonList runat="server" ID="rdoLearnDiff" ClientIDMode="Static">
            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
            <asp:ListItem Text="No" Value="2"></asp:ListItem>
            <asp:ListItem Text="Prefer not to say" Value="9"></asp:ListItem>
        </asp:RadioButtonList>

        <cc1:StudentEnrolmentField CssClass="hide" ClientIDMode="Static" StudentEnrolmentFieldType="LearningDiffOrDisID" ID="fldLearningDiffOrDisID" runat="server" IsRequired="false" LabelWidth="600" />
    </div>


    <div class="form-group disfields">
        <span>If you chose <b>Yes</b>, what would you describe as your main learning difficulty/disability?</span>
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory1ID" runat="server" IsRequired="false" LabelWidth="0" CustomCaption=" " />
    </div>

    <br />



    <div class="form-group">
        <asp:Label ID="lblPrevSupport" Text="Have you previously received support from your school? (Yes/No) *" runat="server"></asp:Label><br />
        <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpPrevSupport" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
            <asp:ListItem Text="No" Value="False"></asp:ListItem>
        </asp:DropDownList>
    </div>


    <div class="form-group">
        <asp:Label ID="lblShareSchl" Text="Do you consent to data regarding your support needs to be shared between the College and your previous school? (Yes/No) *" runat="server"></asp:Label><br />
        <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpShareSchl" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
            <asp:ListItem Text="No" Value="False"></asp:ListItem>
        </asp:DropDownList>
    </div>


    <div class="form-group">
        <asp:Label ID="lblEHCP" Text="Do you have an Education Health and Care Plan (EHCP)? (Yes/No) *" runat="server"></asp:Label><br />
        <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpEHCP" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
            <asp:ListItem Text="No" Value="False"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CareLeaver" ID="fldCareLeaver" runat="server" IsRequired="false" LabelWidth="1100"
            CustomCaption="Tick this box if you were previously in care." Width="35" />
    </div>

    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="LookedAfter" ID="fldLookedAfter" runat="server" IsRequired="false" LabelWidth="1100"
            CustomCaption="Tick this box if you are currently looked after (in care)." Width="35" />
    </div>

    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="YoungParent" ID="StudentEnrolmentField2" runat="server" IsRequired="false" LabelWidth="1100"
            CustomCaption="Tick this box if you are young parent (under the age of 20)." Width="35" />
    </div>


    <br />
    <strong>Do you have any unspent criminal convictions, any outstanding court proceedings, or are you on any offenders register?</strong>

    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CriminalConvictionID" ID="CriminalConvictionIDField" IsRequired="true"
            runat="server" LabelWidth="200" CustomCaption=" " />

        <br />
        If you declare that you have a conviction, you will be contacted for further information. This information will help us assess any potential risks to yourself or others at college.
                    <br />
        The college has a duty of care to all its staff and students to ensure that any risk to their safety is minimised.
                    <br />
        The college reserves the right not to enrol anyone who may pose a threat or danger to the safety of its staff and students. Having a criminal record will not necessarily prevent you studying at college but will depend on the nature of the course and the circumstances of the offence. If you do not disclose a conviction, this can result in disciplinary action or  your enrolment being cancelled. 

    </div>


    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SchoolID" ID="school" runat="server" IsRequired="false" LabelWidth="300"
            CustomCaption="Previous School" />
    </div>


    <br />
</div>



<div class="panel panel-success">

    <!-- this section below was added by Rob on 3/1/17 following a request by Jana -->
    <div class="panel-heading">Ethnicity - the college is committed to equality of opportunity</div>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EthnicGroupID" ID="fldEthnicGroupID" runat="server" IsRequired="true" LabelWidth="300"
            CustomCaption="Ethnicity" />
    </div>
    <br />

</div>

<div class="panel panel-success">
    <div class="panel-heading">Residency</div>
    <div class="row">
        <div class="col-sm-12 columns form-group">
            <span class="textfieldlabelrequired">* Have you lived in the UK for the last 3 years?</span>
            <asp:DropDownList ID="selectEuro" runat="server" CssClass="textfield form-control">
                <asp:ListItem Value="">Please select...</asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>

            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EuroResidentID" ID="fldEuro" runat="server" IsRequired="false" Visible="false" />
        </div>
    </div>

    <div class="row">
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="NationalityID" ID="fldNationalityID" runat="server" IsRequired="true" LabelWidth="400" CustomCaption="* What is your nationality" />
        </div>
        <div class="col-sm-6 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CountryID" ID="StudentEnrolmentField20" runat="server" IsRequired="true" CustomCaption="* What is your home country" LabelWidth="400" />
        </div>

    </div>
    <div class="row">
        <div class="col-sm-12 columns form-group">
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentFirstLanguageID" ID="StudentEnrolmentField1" runat="server" IsRequired="true" CustomCaption="* What is your first spoken language?" LabelWidth="400" />
        </div>
    </div>

    <cc1:NonEUValidator ID="nonEUValidator1" runat="server"></cc1:NonEUValidator>


</div>
<cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="address_0_aspx" />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="checkout_parentguardian_aspx" CausesValidation="true" />
<br />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
