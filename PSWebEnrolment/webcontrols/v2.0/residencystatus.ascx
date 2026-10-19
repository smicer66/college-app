<%@ control Language="VB" AutoEventWireup="false" CodeFile="residencystatus.ascx.vb" Inherits="residencystatus"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<%----%> <script src="/js/jquery-1.10.2.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/south-street/jquery-ui.css" />
<script src="https://code.jquery.com/ui/1.12.0-rc.2/jquery-ui.min.js"></script>

  <script>
      $(function () {
          $(function () {
              $(".DateOfEntryUK").datepicker({ dateFormat: "dd M yy", changeMonth: true, changeYear: true, yearRange: (new Date().getFullYear() - 100) + ":2000", defaultDate: "-100y-m-d" })
              $(".VisaStartDate").datepicker({ dateFormat: "dd M yy", changeMonth: true, changeYear: true, yearRange: (new Date().getFullYear() - 100) + ":2000", defaultDate: "-100y-m-d" })
              $(".VisaExpiryDate").datepicker({ dateFormat: "dd M yy", changeMonth: true, changeYear: true, yearRange: (new Date().getFullYear() - 100) + ":2000", defaultDate: "-100y-m-d" })
          });
      });
  </script>

<script>

    document.addEventListener("DOMContentLoaded", function () {

        

        var requiredSpans = ["lblAreYouLivingInUK", "lblHaveUkPassport", "countryOfBirthSpan",
            "lblAlwaysLivedInUK", "lblDateOfEntry", "HaveYouLivedInUkLast3YearsDiv", "lblDoYouHaveAVisa",
            "lblVisaTypeID", "lblVisaDocumentNumber", "lblVisastartdate", "lblVisaenddate", "lblHaveEVisaShareCode",
            "lblStudentDetailUserDefined3"];
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


  <style>
    

    * {
      box-sizing: border-box;
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
  
    /* Contact Details */
    .form-section{margin-top:28px}
    .form-section+.form-section{margin-top:34px;padding-top:28px;border-top:1px solid var(--border)}
    .form-section h2{margin:0 0 8px;font-size:21px}
    .section-help{margin:0 0 20px;color:var(--muted);font-size:14px;line-height:1.6}
    .contact-grid{display:grid;grid-template-columns:repeat(2,minmax(0,1fr));gap:20px 24px}
    .form-group{min-width:0}
    .full-width{grid-column:1/-1}
    .form-group label,.field-label{display:block;margin-bottom:7px;font-size:14px;font-weight:700;color:var(--text)}
    .required{color:#b91c1c}
    .form-control{width:100%;min-height:44px;padding:10px 12px;border:1px solid #cbd5e1;border-radius:7px;background:#fff;color:var(--text);font:inherit}
    .form-control:focus{outline:3px solid #bfdbfe;border-color:var(--primary)}
    .checkbox-row{display:flex!important;align-items:flex-start;gap:9px;margin-top:10px;font-weight:400!important;color:#475569!important}
    .checkbox-row input{width:18px;height:18px;margin:1px 0 0;accent-color:var(--primary);flex:0 0 auto}
    .postcode-row{display:grid;grid-template-columns:minmax(0,1fr) auto;gap:10px;align-items:end}
    .lookup-btn{min-height:44px;white-space:nowrap;padding:10px 16px}
    .address-results{margin-top:10px}
    .field-error{display:none;margin-top:6px;color:#b91c1c;font-size:13px}
    .field-error.visible{display:block}
    .hidden{display:none!important}
    @media(max-width:700px){.contact-grid{grid-template-columns:1fr;gap:18px}.full-width{grid-column:auto}}
    @media(max-width:430px){.postcode-row{gap:7px}.lookup-btn{padding:10px 11px;font-size:12px}}


    /* Parent / Carer Details */
    .radio-group{display:flex;flex-wrap:wrap;gap:12px 22px;min-height:44px;align-items:center}
    .radio-option{display:flex!important;align-items:center;gap:8px;margin:0!important;font-weight:400!important;color:#475569!important;cursor:pointer}
    .radio-option input{width:18px;height:18px;margin:0;accent-color:var(--primary)}
    .form-hint{margin:6px 0 0;color:var(--muted);font-size:13px;line-height:1.45}


    /* Residency Status */
    .advice-box{padding:18px 20px;border:1px solid #bfdbfe;border-radius:8px;background:var(--primary-light);color:#365b91;font-size:14px;line-height:1.65;margin-bottom:22px}
    .advice-box strong{color:var(--text)}
    .date-format{margin-top:6px;color:var(--muted);font-size:12px}

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

    .radiofield input{
        float: left !important
    }
    
    .radiofield label{
        font-weight: 100 !important
    }

    .radiofield td{
        padding-top: 10px !important;
    }
</style>


    <div class="step-content" id="step-content">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="We found some errors in the information you provided. Please fix these errors:" CssClass="bgError" ForeColor="" />
        </div>
        <h1>Your Residency Status</h1>
        <p class="intro">Please answer the following questions about your UK residency.</p>
        <section class="form-section">

            <div class="form-grid">
                <div class="form-group">
                    <span class="" id="lblAreYouLivingInUK">Are you currently living in the UK?</span>
                    <asp:RadioButtonList runat="server" ID="currentlyUk" AutoPostBack="true" CssClass="radiofield" Width="150" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="No" Value="0"></asp:ListItem>        
                    </asp:RadioButtonList>
                </div>
            </div>

            <div class="form-grid" id="NotCurrentlyInUKMessage" runat="server" visible="false">
                <div class="form-group full-width">  
                    <div class="advice-box">
                        Please apply when you are in the UK. We are currently not receiving applications from outside the UK.
                    </div>
                </div>
            </div>
            <div class="form-grid pad20" runat="server" visible="false" id="livingInUKShow">
                <div class="form-group">
                    <span class="" id="lblHaveUkPassport">Do you have a UK Passport?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have a UK Passport?">
                        <asp:RadioButtonList runat="server" AutoPostBack="true" ID="ukPassport" CssClass="radiofield" Width="150" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>        
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="form-group" id="birth-country-group">
                    <span id="countryOfBirthSpan" class="textfieldlabelrequired" style="display:inline-block;width:400px;">Country of Birth</span>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="PlaceOfBirth" runat="server" IsRequired="true" LabelWidth="400" CustomCaption="Country of birth" />
                </div>

                <div class="form-group" id="alwaysLivedInUKDiv" runat="server" visible="false">
                    <span class="" id="lblAlwaysLivedInUK">Have you always lived in the UK?</span>
                        <div class="radio-group" role="radiogroup" aria-label="Have you always lived in the UK?">
                        <asp:RadioButtonList runat="server" ID="alwaysLivedInUk" AutoPostBack="true" CssClass="radiofield" Width="150" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>        
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="form-group" id="ukEntryDateDiv" runat="server" visible="false">
                    <span for="legal-first-name" id="lblDateOfEntry">What date did you enter the UK?</span>
                    <input class="form-control DateOfEntryUK" id="DateOfEntryUK" runat="server" name="DateOfEntryUK" type="text" Placeholder="DD MMM YYYY" />
                </div>

                <div class="form-group" runat="server" visible="false" id="LivedInTheUKLast3YrsDiv">
                    <span id="HaveYouLivedInUkLast3YearsDiv">Have you lived in the UK for the last 3 years?</span>
                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="EuroResidentID" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true"  AutoPostBack="True">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            
            </div>
        </section>

        <section class="form-section" runat="server" AutoPostBack="true" id="visaImmigrationDetails" visible="false">
            <h2>Visa and Immigration Details</h2>

            <div class="advice-box">
                <strong>Important information:</strong>
                If you have entered the UK from overseas, please complete further details in the section below.
                If you are not from overseas, please indicate "Not applicable" on the questions below.
            </div>

            <div class="form-grid">
                <div class="form-group full-width">
                    <span class="" id="lblDoYouHaveAVisa">Do you have a Visa?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have a Visa?">
                        <asp:RadioButtonList runat="server" AutoPostBack="true" ID="DoYouHaveAVisa" Width="450" CssClass="radiofield" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>   
                            <asp:ListItem Text="Not Applicable" Value="2"></asp:ListItem>       
                        </asp:RadioButtonList>
                </div>
            </div>
            </div>
            
            <div class="form-grid pad20" id="visaDetailsDiv" runat="server" visible="false">
                <div class="form-group" id="visa-type-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="VisaTypeID" ID="VisaTypeID" runat="server" IsRequired="true" LabelWidth="200"    CustomCaption="What type of Visa?"/>
                </div>

                <div class="form-group" id="visa-number-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="VisaDocumentNumber" ID="VisaDocumentNumber" runat="server" IsRequired="true" LabelWidth="200"    CustomCaption="Visa Number"/>
                </div>

                <div class="form-group" id="visa-start-group">
                    <span for="legal-first-name" id="lblVisastartdate">Visa start date</span>
                    <input class="form-control VisaStartDate" id="VisaStartDate" runat="server" name="VisaStartDate" type="text" Placeholder="DD MMM YYYY" />
                </div>

                <div class="form-group" id="visa-start-group">
                    <span for="legal-first-name" id="lblVisaenddate">Visa end date</span>
                    <input class="form-control VisaExpiryDate" id="VisaExpiryDate" runat="server" name="VisaExpiryDate" type="text" Placeholder="DD MMM YYYY" />
                </div>
                <div class="form-group full-width">
                    <span class="" id="lblHaveEVisaShareCode">Do you have an eVisa share code?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have an eVisa share code?">
                        <asp:RadioButtonList runat="server" AutoPostBack="true" ID="DoYouHaveAVisaShareCode" CssClass="radiofield" Width="450" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>   
                            <asp:ListItem Text="Not Applicable" Value="2"></asp:ListItem>       
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="form-group" id="shareCodeDiv" runat="server" AutoPostBack="true" visible="false">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined3" ID="StudentDetailUserDefined3" runat="server" IsRequired="true" LabelWidth="200"    CustomCaption="Share code"/>
                </div>
            </div>
        </section>
    </div>






<div class="card-footer">
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnBack" runat="server" Text="← Back" LinkResource="parentcarercontactdetails_aspx" />
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" CausesValidation="True" /> <!---->
</div>