<%@ control Language="VB" AutoEventWireup="false" CodeFile="personaldetails.ascx.vb" Inherits="personaldetails"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<%----%> <script src="/js/jquery-1.10.2.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/south-street/jquery-ui.css" />
<script src="https://code.jquery.com/ui/1.12.0-rc.2/jquery-ui.min.js"></script>
  <script>
      $(function () {
          $(function () {
              $(".dateOfBirth").datepicker({ dateFormat: "dd M yy", changeMonth: true, changeYear: true, yearRange: "1930:2013", defaultDate: "-16y-m-d" })
          });
      });
  </script>

    <style>
    /*:root {
      --primary: #2563eb;
      --primary-light: #eff6ff;
      --success: #16a34a;
      --text: #172b4d;
      --muted: #64748b;
      --border: #e2e8f0;
      --background: #f5f7fb;
      --white: #ffffff;
    }*/

    * {
      box-sizing: border-box;
    }

    body {
      margin: 0;
      font-family: Ryker, Arial, sans-serif;
      background: var(--background);
      color: var(--text);
      overflow-x: hidden;
    }

    button {
      font: inherit;
    }

    .container {
      width: 100%;
      max-width: 1400px;
      margin: 0 auto;
      padding: 32px 24px;
    }

    /* Breadcrumbs */

    .breadcrumbs {
      display: flex;
      flex-wrap: wrap;
      gap: 10px;
      align-items: center;
      font-size: 14px;
      margin-bottom: 32px;
      color: var(--muted);
    }

    .breadcrumbs a {
      color: #536987;
      text-decoration: none;
    }

    .breadcrumbs .separator {
      color: #94a3b8;
    }

    .breadcrumbs .active {
      font-weight: 700;
      color: var(--text);
    }

    /* Progress tracker */

    

    /* Main card */

    .card {
      background: var(--white);
      border: 1px solid var(--border);
      border-radius: 12px;
      padding: 40px;
      box-shadow: 0 4px 20px rgba(15, 23, 42, 0.04);
    }

    .card h1 {
      margin: 0 0 12px;
      font-size: clamp(24px, 3vw, 32px);
      line-height: 1.25;
    }

    .intro {
      font-size: 16px;
      color: #536987;
      line-height: 1.7;
      margin: 0 0 24px;
      max-width: 850px;
    }

    /* Information box */

    .info-box {
      display: flex;
      align-items: flex-start;
      gap: 14px;
      padding: 20px;
      border: 1px solid #bfdbfe;
      border-radius: 8px;
      background: #eff6ff;
      margin-top: 28px;
    }

    .info-icon {
      flex: 0 0 auto;
      width: 28px;
      height: 28px;
      display: flex;
      align-items: center;
      justify-content: center;
      border-radius: 50%;
      background: var(--primary);
      color: white;
      font-weight: 700;
    }

    .info-box h3 {
      margin: 0 0 8px;
      font-size: 16px;
    }

    .info-box p {
      margin: 0;
      font-size: 14px;
      line-height: 1.6;
      color: #365b91;
    }

    /* Content */

    .step-content {
      min-height: 260px;
    }

    .step-content h2 {
      font-size: 23px;
      margin: 0 0 16px;
    }

    .step-content p {
      color: #536987;
      line-height: 1.7;
      max-width: 850px;
    }

    .step-content ul {
      color: #536987;
      line-height: 1.8;
      padding-left: 20px;
    }

    /* Footer navigation */

    .card-footer {
      display: flex;
      align-items: center;
      justify-content: space-between;
      gap: 16px;
      border-top: 1px solid var(--border);
      margin-top: 32px;
      padding-top: 24px;
    }



    .btn-secondary {
      background: #eef2f7;
      color: #64748b;
    }

    .btn-secondary:hover:not(:disabled) {
      background: #e2e8f0;
    }

    .btn:disabled {
      opacity: 0.5;
      cursor: not-allowed;
    }

    .progress-text {
      font-size: 13px;
      color: var(--muted);
      text-align: center;
    }

    /* Tablet */

    @media (max-width: 1100px) {
      .stepper {
        grid-template-columns: repeat(6, minmax(0, 1fr));
        row-gap: 24px;
      }

      .step::before {
        display: none;
      }

      .step-label {
        font-size: 12px;
      }
    }

    /* Mobile */

    @media (max-width: 600px) {
      .container {
        padding: 20px 12px;
      }

      .breadcrumbs {
        margin-bottom: 20px;
        font-size: 12px;
        gap: 6px;
      }

      .stepper {
        display: flex;
        flex-direction: column;
        gap: 0;
        margin-bottom: 24px;
      }

      .step {
        display: flex;
        align-items: center;
        gap: 14px;
        text-align: left;
        padding: 9px 12px;
        border-radius: 8px;
        min-height: 48px;
      }

      .step::before {
        display: none;
      }

      .step-number {
        flex: 0 0 32px;
        width: 32px;
        height: 32px;
        margin: 0;
      }

      .step-label {
        padding: 0;
        font-size: 13px;
        line-height: 1.4;
        overflow-wrap: anywhere;
      }

      .step.active {
        background: var(--primary-light);
      }

      .card {
        padding: 24px 18px;
        border-radius: 10px;
      }

      .card h1 {
        font-size: 25px;
      }

      .intro {
        font-size: 14px;
      }

      .info-box {
        padding: 16px;
        gap: 10px;
      }

      .step-content {
        min-height: 220px;
      }

      .step-content h2 {
        font-size: 21px;
      }

      .card-footer {
        flex-wrap: wrap;
      }

      .progress-text {
        order: 3;
        flex-basis: 100%;
      }

      .btn {
        padding: 12px 18px;
      }
    }

    /* Personal Details form */
    .form-section { margin-top: 28px; padding-top: 24px; border-top: 1px solid var(--border); }
    .form-section:first-of-type { margin-top: 8px; }
    .form-section h2 { margin: 0 0 20px; font-size: 21px; color: var(--text); }
    .form-grid { display: grid; gap: 20px 24px; }
    .form-group { min-width: 0; }
    .form-group.full-width { grid-column: 1 / -1; }
    .form-group label, .field-label { display:block; margin-bottom:7px; font-size:14px; font-weight:700; color:var(--text); }
    .form-control { width:100%; min-width:0; height:44px; padding:10px 12px; border:1px solid #cbd5e1; border-radius:7px; background:#fff; color:var(--text); font:inherit; }
    .form-control:focus { outline:3px solid #bfdbfe; outline-offset:1px; border-color:var(--primary); }
    .checkbox-row { display:flex; align-items:flex-start; gap:9px; margin-top:9px; font-size:13px; color:#475569; }
    .checkbox-row input { width:17px; height:17px; margin-top:1px; flex:0 0 auto; accent-color:var(--primary); }
    .conditional-field[hidden] { display:none !important; }
    .field-hint { margin:6px 0 0; font-size:12px; color:var(--muted); }
    @media (max-width: 600px) { .form-grid { grid-template-columns:1fr !important; gap:17px; } .form-group.full-width { grid-column:auto; } .form-control { font-size:16px; } }
    .form-grid { grid-template-columns: repeat(2, minmax(0, 1fr)); }


    .bgError{
        color: #721c24; !important;
        background-color: #f8d7da !important;
        border: 1px solid #f5c6cb;
        position: relative;
        padding: .75rem 1.25rem;
        margin-bottom: 1rem;
        border: 1px solid transparent;
        border-radius: .25rem;
        font-weight: bold !important;
    }

    .bgError ul li{
        font-weight: 100 !important;
    }

    .error{
        display: none !important;
    }

    .pad20{
        padding-top: 20px !important;
    }

    span {
        font-weight: 100 !important
    }
  </style>


    
<script>

    const toggle = (controlId, groupId) => {
        const control = document.getElementById(controlId), group = document.getElementById(groupId);
        if (!control || !group) return;
        const apply = () => { group.hidden = control.type === "checkbox" ? !control.checked : control.value !== "other"; };
        control.addEventListener("change", apply); apply();
    };

    function t() {
        toggle("different-first-name", "known-first-group");
        toggle("different-last-name", "known-last-group");
    }

    t();


    document.addEventListener("DOMContentLoaded", function () {

        var select = document.querySelector('.sex select');
        select.options[1].text = "Female";
        select.options[2].text = "Male";

        var selectPronoun = document.querySelector('.PreferredPronouns select');
        for (var i = 0; i < selectPronoun.options.length; i++) {
            var t = selectPronoun.options[i].text.split(' - ');
            //console.log(t)
            selectPronoun.options[i].text = t.length == 1 ? t[0] : t[1];

        }


        var primaryLanguage = document.querySelector('.StudentFirstLanguageID select');
        for (var i = 0; i < selectPronoun.options.length; i++) {
            var t = selectPronoun.options[i].text.split(' - ');
            //console.log(t)
            selectPronoun.options[i].text = t.length == 1 ? t[0] : t[1];

        }

        var requiredSpans = ["lblTitle", "lblFirstForename", "lblSurname", "lblDateOfBirth", "lblSex", "lblPreferredPronounID", "lblEthnicGroupID", "lblEmail", "lblEmailRetype",
            "lblStudentFirstLanguageID", "lblMobileTel", "lblDateofBirth", "lblCountryID"];
        requiredSpans.forEach(id => {
            const element = document.getElementById(id);

            if (element) {
                element.insertAdjacentHTML(
                    "beforeend",
                    ' <span style="color:red;">*</span>'
                );
            }
        });
    })

</script>


<div class="step-content" id="step-content">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="We found some errors in the information you provided. Please fix these errors:" CssClass="bgError" ForeColor="" />
    </div>
    <h1>Personal Details</h1>
    <p class="intro">Please provide your personal details.</p>
    <section class="form-section" aria-labelledby="personal-heading">
        <h2 id="personal-heading">Your Personal details</h2>
        <div class="form-grid">  
            <div class=" form-group" id="Div1">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Title" ID="Title" runat="server" IsRequired="false" LabelWidth="200" CustomCaption="Title" />
            </div>
        </div>
        <div class="form-grid pad20">  
            <div class="clear form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="FirstForename" ID="StudentEnrolmentField1" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="Legal first name" />
                <label class="checkbox-row">
                    <asp:checkbox id="KnownAsFirstName" runat="server" Text="" AutoPostBack="True" />
                    <span>I am known by a different first name</span>
                </label>
            </div>  
            <div class=" form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname" ID="fldSurname" runat="server" IsRequired="true" LabelWidth="200"    CustomCaption="Legal last name"/>
                <label class="checkbox-row">
                    <asp:checkbox id="KnownAsLastName" runat="server" Text=""  AutoPostBack="True" /> 
                    <span>I am known by a different last name</span>
                </label>
            </div>  
            <div class=" form-group" id="knownFirstGroup" runat="server" visible="false">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="knownas" ID="knownas" runat="server" IsRequired="false" LabelWidth="200" CustomCaption="Known as first name" />
            </div>  
            <div class=" form-group" id="knownLastGroup" runat="server" visible="false">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined5" ID="StudentEnrolmentField12" runat="server" IsRequired="false" LabelWidth="200"    CustomCaption="Known as last name"/>
            </div>
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="OtherForenames" ID="OtherForenames" runat="server" IsRequired="false" LabelWidth="200" CustomCaption="Legal Middle name(s)"/>
            </div>
            <div class="form-group">
                <span for="legal-first-name" id="lblDateofBirth">Date of birth</span>                
                <input class="form-control dateOfBirth" id="datepicker" runat="server" name="DateOfBirth" type="text" Placeholder="DD MMM YYYY" />
                <p class="field-hint" runat="server" id="ageParagraph"></p>
            </div>
            <div class="form-group sex">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Sex" ID="fldSex" runat="server"  IsRequired="true" CustomCaption="Biological sex"/>
            </div>
            <div class="form-group PreferredPronouns">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="PreferredPronounID" ID="PreferredPronouns" LabelWidth="200" runat="server"  IsRequired="true" CustomCaption="Preferred pronouns"/>
            </div>
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EthnicGroupID" ID="EthnicGroupID" runat="server"  IsRequired="true" CustomCaption="Ethnicity"/>
            </div>
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentFirstLanguageID" LabelWidth="200" ID="StudentFirstLanguageID" runat="server"  IsRequired="true" CustomCaption="Primary language"/>
            </div>
            <div class="form-group conditional-field full-width" id="other-language-group" hidden>
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined1" ID="StudentDetailUserDefined1" runat="server"  IsRequired="false" CustomCaption="Please specify primary language"/>
            </div>
        </div>
    </section>
    <section class="form-section" aria-labelledby="education-heading">
        <h2 id="education-heading">Your Education</h2>
        <div class="form-grid">
            <div class="form-group">
                <cc1:StudentEnrolmentField AutoPostBack="True" StudentEnrolmentFieldType="SchoolID" ID="SchoolID" runat="server"  IsRequired="true" CustomCaption="Previous school"/>
            </div>
            <div class="form-group conditional-field" id="otherSchoolGroupDiv" visible="false" runat="server">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined4" ID="StudentDetailUserDefined4" runat="server"  IsRequired="false" LabelWidth="300" CustomCaption="Enter school name and town"/>
            </div>
        </div>
    </section>
</div>



<div class="card-footer">
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnBack" runat="server" Text="← Back" LinkResource="checkout_aspx" />
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" LinkResource="contactdetails_aspx" CausesValidation="True" /> 
</div>

