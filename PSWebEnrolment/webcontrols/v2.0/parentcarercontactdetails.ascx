<%@ control Language="VB" AutoEventWireup="false" CodeFile="parentcarercontactdetails.ascx.vb" Inherits="parentcarercontactdetails"  %>
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


    /* Parent / Carer Details */
    .radio-group{display:flex;flex-wrap:wrap;gap:12px 22px;min-height:44px;align-items:center}
    .radio-option{display:flex!important;align-items:center;gap:8px;margin:0!important;font-weight:400!important;color:#475569!important;cursor:pointer}
    .radio-option input{width:18px;height:18px;margin:0;accent-color:var(--primary)}
    .form-hint{margin:6px 0 0;color:var(--muted);font-size:13px;line-height:1.45}
    

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

        

        var requiredSpans = ["lblParentFirstName", "lblParentSurname", "lblPersonLivesSameAddress", "lblContact1RelationshipID", "lblParentMobileTel", "lblParentEmailAddress",
            "lblRetypeEmail", "lblDoesPCLiveInUK", "fldUKPostCode", "lblParentAddress1", "lblParentAddress3", "lblAddress4"];
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
        <h1>Your Parent/Carer Details</h1>
        <p class="intro">Please provide details for your parent or carer. Fields marked * are compulsory.</p>
        <section class="form-section">
            
            <div class="contact-grid">
                <div class="form-group">
                    
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentFirstName" ID="StudentEnrolmentField2" runat="server" IsRequired="true" LabelWidth="400" CustomCaption ="Parent/Carer first name"/>
                </div>

                <div class="form-group">
                    
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentSurname" ID="StudentEnrolmentField1" runat="server" IsRequired="true" LabelWidth="400" CustomCaption ="Parent/Carer last name"/>
                </div>

                <div class="form-group">
                    
                    <span id="lblPersonLivesSameAddress">Does this Person live at the same address as you?</span>
                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="IsLivingWithParent" AppendDataBoundItems="true" IsRequired="true" CssClass="form-control" EnableViewState="true"  AutoPostBack="True">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
                    </asp:DropDownList>
                </div>



                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Contact1RelationshipID" ID="Contact1RelationshipID" runat="server" IsRequired="true" LabelWidth="400" CustomCaption ="Relationship to you"/>
                </div>
            
            </div>
        </section>

        <section class="form-section" runat="server" visible="true" >
            <h2>Parent/Carer's Contact Details</h2>
            <p class="section-help">Please provide the best contact details for your parent or carer.</p>

            <div class="contact-grid">
            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentMobileTel" ID="StudentEnrolmentField5" runat="server" IsRequired="true" LabelWidth="400" CustomCaption ="Parent/Carer UK Mobile telephone"/>
                <label class="checkbox-row" for="pc-overseas-check">
                    <input id="pc-overseas-check" name="parentCarerOverseasNumber" type="checkbox" aria-controls="pc-overseas-group" aria-expanded="false">
                    <span>My Parent/Carer has an overseas number</span>
                </label>
            </div>

            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentPhoneNumber" ID="ParentPhoneNumber" runat="server" IsRequired="false" LabelWidth="400" CustomCaption ="Parent/Carer landline telephone"/>
            </div>

            <div class="form-group hidden" id="pc-overseas-group">
                <label for="pc-overseas-mobile">Parent/Carer Overseas Mobile telephone</label>
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudentDetailUserDefined20" ID="StudentEnrolmentField14" runat="server" IsRequired="false" LabelWidth="400" CustomCaption ="Parent/Carer landline telephone"/>
            </div>

            <div class="form-group">
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentEmailAddress" ID="ParentEmailAddress" runat="server" IsRequired="false" LabelWidth="400" CustomCaption ="Parent/Carer Email address"/>
            </div>

            <div class="form-group">
                <span for="pc-email-confirm" id="lblRetypeEmail">Retype Email</span>
                <input class="form-control" id="ParentEmailAddressConfirm" runat="server" AutoPostBack="true" name="parentCarerEmailConfirm" type="text">
                <div class="field-error" id="pc-email-match-error">The email addresses must match.</div>
            </div>

            <div class="form-group full-width" id="pcLiveInUKDiv" runat="server" visible="false">
                <span id="lblDoesPCLiveInUK">Does your parent/Carer live in the UK?</span>
                <div class="radio-group" role="radiogroup" aria-label="Does your parent or carer live in the UK?">
                    <asp:RadioButtonList runat="server" ID="pcLiveInUK" ClientIDMode="Static" RepeatDirection="Horizontal" Width="250"  AutoPostBack="True">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            </div>
        </section>

        <section class="form-section" id="pcAddressSection" runat="server" visible="false">
            <h2>Your Parent/Carer's Address</h2>
            <p class="section-help">Please provide your parent/carer's address. Fields marked * are compulsory.</p>

            <div class="form-grid">
                <div class="form-group">
                    <span class="" id="fldUKPostCode">UK Postcode</span>
                    <div class="postcode-row">
                        <input class="form-control previous-required" id="txtLookupPC" required="true" type="text" runat="server">
                        <asp:Button ID="btnFindPC" CssClass="btn btn-secondary lookup-btn" runat="server" Text="Lookup Postcode" CausesValidation="False" UseSubmitBehavior="false" />
                        <input type="hidden" runat="server" class="textfield form-control"  id="PCPostcode" title="Postcode" placeholder="Enter Postcode" />
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
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress1" ID="ParentAddress1" runat="server" IsRequired="true" LabelWidth="400" CustomCaption ="House number/name and street"/>
                </div>

                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress2" ID="ParentAddress2" runat="server" IsRequired="false" LabelWidth="400" CustomCaption ="Address line 2"/>
                </div>

                <div class="form-group">
                    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentAddress3" ID="ParentAddress3" runat="server" IsRequired="true" LabelWidth="400" CustomCaption ="Town/City"/>
                </div>

                <div class="form-group">
                    <span id="lblAddress4" class="textfieldlabelrequired" style="display:inline-block;width:400px;">County</span>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="Address4" runat="server" IsRequired="true" LabelWidth="400" CustomCaption="County" />
                </div>
            
            </div>
        </section>
    </div>







<div class="card-footer">
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnBack" runat="server" Text="← Back" LinkResource="contactdetails_aspx" />
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" CausesValidation="True" /> 
</div>