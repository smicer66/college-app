<%@ control Language="VB" AutoEventWireup="false" CodeFile="contactdetails.ascx.vb" Inherits="contactdetails"  %>
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

    .form-group label, .field-label {
        display: block;
        margin-bottom: 7px;
        font-size: 14px;
        font-weight: 700;
        color: var(--text);
    }

    .listbox option{
        padding: 10px !important
    }



  </style>

    
<script>

    const toggle = (controlId, groupId) => {
        const control = document.getElementById(controlId), group = document.getElementById(groupId);
        if (!control || !group) return;
        const apply = () => { group.hidden = control.type === "checkbox" ? !control.checked : control.value !== "other"; };
        control.addEventListener("change", apply); apply();
    };

    


    document.addEventListener("DOMContentLoaded", function () {

        

        var requiredSpans = ["lblTel", "lblEmail", "lblRetypeYourEmail", "lblCountryID", "lblUkPostCode", "lblAddress1", "lblAddress3", "lblAddress4",
            "lblPreviousUKPostCode", "lblPreviousAddress4",
            "lblStudentDetailUserDefined13", "lblStudentDetailUserDefined15", "lblStudentDetailUserDefined16"];
        requiredSpans.forEach(id => {
            const element = document.getElementById(id);

            if (element) {
                element.insertAdjacentHTML(
                    "beforeend",
                    ' <span style="color:red;">*</span>'
                );
            }
        });


        document.querySelectorAll("input").forEach(function (input) {
            input.setAttribute("autocomplete", "off");
        }); 
    })

</script>


    <div class="step-content" id="step-content">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="We found some errors in the information you provided. Please fix these errors:" CssClass="bgError" ForeColor="" />
        </div>
        <h1>Contact Details</h1>
        <p class="intro">Please provide your current contact details. Fields marked * are compulsory.</p>
        <section class="form-section">
            <div class="contact-grid">
            <div class="form-group">
                
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel" ID="fldUKMobile" runat="server" IsRequired="true" LabelWidth="200"    CustomCaption="UK mobile telephone"/>

                <label class="checkbox-row">
                    <asp:checkbox id="OverseasCheck" runat="server" Text="" AutoPostBack="True" />
                    <span>My number is an overseas number</span>
                </label>
            </div>
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel2" ID="fldHomeLandlineTel" runat="server" IsRequired="false" LabelWidth="400"    CustomCaption="Home landline telephone"/>
            </div>
            <div class="form-group" runat="server" visible="false" id="OverseasGroupDiv">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined7" ID="StudentEnrolmentField8" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="Overseas mobile number"/>
            </div>
        </div>
        <div class="contact-grid pad20">
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Email" ID="fldContactEmail" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="Your email address"/>
            </div>
            <div class="form-group">
                <span for="confirm-email" id="lblRetypeYourEmail">Retype your email</span>
                <input class="form-control" runat="server" AutoPostBack="true" id="ConfirmEmail" type="text">
            </div>
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CountryID" ID="CountryID" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="Which country do you live in"/>
            </div>
            </div>
        </section>

        <section class="form-section" id="UKAddressSection" runat="server" visible="false">
            <h2>Your UK Address</h2>
            <div class="form-grid">
                <div class="form-group">
                    <span class="" id="lblUkPostCode">UK Postcode</span>
                    <div class="postcode-row">
                        <input class="form-control previous-required" id="txtLookup" runat="server" type="text">
                        <asp:Button ID="btnFind" CssClass="btn btn-secondary lookup-btn" runat="server" Text="Lookup Postcode" CausesValidation="False" UseSubmitBehavior="false" />
                        <input type="hidden" runat="server" class="textfield form-control"  id="postcode" title="Postcode" placeholder="Enter Postcode" />
                    </div>
                </div>
            </div>
            <div class="form-grid"> 
                <div class="form-group full-width">
                    <div class="address-results" runat="server" visible="false" id="currentResults"><span>Select an address</span>
                        <asp:ListBox ID="lstresult" runat="server" CssClass="listbox textfield form-control" Width="100%" Height="200"></asp:ListBox>
                        <asp:Button ID="btnFetchAddress" CssClass="btn btn-secondary lookup-btn" runat="server" Text="Fetch Address" CausesValidation="False" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            
            <div class="form-grid pad20">
                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Address1" ID="Address1" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="House number/name and street"/>
                </div>
                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Address2" ID="Address2" runat="server" IsRequired="false" LabelWidth="400"    CustomCaption="Address line 2"/>
                </div>
                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Address3" ID="Address3" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="Town/City"/>
                </div>
                <div class="form-group">
                    <span id="lblAddress4" class="textfieldlabelrequired" style="display:inline-block;width:400px;">County</span>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="Address4" runat="server" IsRequired="true" LabelWidth="400" CustomCaption="County" />
                </div>
                <div class="form-group full-width">
                    <label class="checkbox-row">
                        <asp:checkbox id="PreviousAddressCheckbox" runat="server" Text="" AutoPostBack="True" />
                        <span>I have lived at a different address in the last 2 years</span>
                    </label>
                </div>
            </div>
        </section>

        <section class="form-section" id="PreviousAddressSection" runat="server" visible="false">
            <h2>Your Previous UK Address</h2>
            <div class="form-grid">
                <div class="form-group">
                    <span class="" id="lblPreviousUKPostCode">UK Postcode</span>
                    <div class="postcode-row">
                    <input class="form-control previous-required" id="txtLookupPrevious" type="text" runat="server">
                    <asp:Button CssClass="btn btn-secondary lookup-btn" ID="btnFindPrevAddress" runat="server" Text="Lookup Postcode" CausesValidation="False" UseSubmitBehavior="false" />
                    <input type="hidden" runat="server" class="textfield form-control"  id="postCodePrevious" title="Postcode" placeholder="Enter Postcode" />
                        
                    </div>
                </div>
            </div>
            <div class="form-grid"> 
                <div class="form-group full-width">
                    <div class="address-results" runat="server" visible="false" id="previousAddressDiv"><span>Select an address</span>
                        <asp:ListBox ID="lstresultPrevious" runat="server" CssClass="listbox textfield form-control" Width="100%" Height="200"></asp:ListBox>
                        <asp:Button ID="btnFetchAddressPrevious" CssClass="btn btn-secondary lookup-btn" runat="server" Text="Fetch Address" CausesValidation="False" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            <div class="form-grid pad20">
                <div class="form-group">
                    <cc1:StudentEnrolmentField CssClass StudentEnrolmentFieldType="StudentDetailUserDefined13" ID="PreviousAddress1" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="House number/name and street"/>
                </div>
                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined14" ID="PreviousAddress2" runat="server" IsRequired="false" LabelWidth="400"    CustomCaption="Address line 2"/>
                </div>
                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined15" ID="PreviousAddress3" runat="server" IsRequired="true" LabelWidth="400"    CustomCaption="Town/City"/>
                </div>
                <div class="form-group">
                    <span id="lblPreviousAddress4" class="textfieldlabelrequired" style="display:inline-block;width:400px;">County</span>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="StudentDetailUserDefined16" runat="server" IsRequired="true" LabelWidth="400" CustomCaption="County" />
                </div>
            </div>
        </section>
    </div>


<div class="card-footer">
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnBack" runat="server" Text="← Back" LinkResource="personaldetails_aspx" />
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" CausesValidation="True" />
</div>