<%@ control Language="VB" AutoEventWireup="false" CodeFile="yourqualifications.ascx.vb" Inherits="yourqualifications"  %>
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


    /* Residency Status */
    .advice-box{padding:18px 20px;border:1px solid #bfdbfe;border-radius:8px;background:var(--primary-light);color:#365b91;font-size:14px;line-height:1.65;margin-bottom:22px}
    .advice-box strong{color:var(--text)}
    .date-format{margin-top:6px;color:var(--muted);font-size:12px}


    /* Qualifications */
    .section-heading-row{display:flex;align-items:flex-start;justify-content:space-between;gap:18px;margin-bottom:18px}
    .section-heading-row h2{margin:0 0 8px}
    .section-heading-row .section-help{margin-bottom:0}
    .qualification-editor{padding:20px;border:1px solid var(--border);border-radius:9px;background:#f8fafc}
    .qualification-editor .contact-grid{align-items:end}
    .qualification-actions{display:flex;justify-content:flex-end;align-items:end;height:100%}
    .qualification-table-wrap{width:100%;overflow-x:auto;border:1px solid var(--border);border-radius:9px}
    .qualification-table{width:100%;border-collapse:collapse;min-width:720px;background:#fff}
    .qualification-table th,.qualification-table td{padding:14px 16px;border-bottom:1px solid var(--border);text-align:left;font-size:14px;vertical-align:middle}
    .qualification-table th{background:#f8fafc;color:var(--text);font-weight:700}
    .qualification-table tbody tr:last-child td{border-bottom:0}
    .empty-row td{text-align:center;color:var(--muted);padding:26px 16px}
    .btn-danger{background:#fff1f2;color:#b91c1c;border:1px solid #fecdd3}
    .btn-danger:hover{background:#ffe4e6}
    .qualification-count{margin:10px 0 0;color:var(--muted);font-size:13px}
    @media(max-width:700px){
      .section-heading-row{flex-direction:column;align-items:stretch}
      .section-heading-row .btn{align-self:flex-start}
      .qualification-editor{padding:16px}
      .qualification-actions{justify-content:flex-start}
      .qualification-table-wrap{overflow-x:visible;border:0}
      .qualification-table,.qualification-table tbody,.qualification-table tr,.qualification-table td{display:block;width:100%;min-width:0}
      .qualification-table thead{display:none}
      .qualification-table tbody{display:grid;gap:12px}
      .qualification-table tr{border:1px solid var(--border);border-radius:9px;background:#fff;padding:12px}
      .qualification-table td{display:grid;grid-template-columns:120px minmax(0,1fr);gap:10px;padding:8px 4px;border:0}
      .qualification-table td::before{content:attr(data-label);font-weight:700;color:var(--text)}
      .qualification-table .empty-row td{display:block;text-align:center;padding:20px}
      .qualification-table .empty-row td::before{display:none}
    }

</style>


    <div class="step-content" id="step-content">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="We found some errors in the information you provided. Please fix these errors:" CssClass="bgError" ForeColor="" />
        </div>
        <h1>Your Qualifications</h1>
        <p class="intro">Add each qualification or subject separately.</p>
        

        <section class="form-section">
            <h2>Qualifications On Entry</h2>
            <div class="advice-box">
                <strong>Important information:</strong>
                
                Please provide details of all relevant qualifications. Where your final result is known, enter your achieved grade. If you are awaiting your finaL result, enter gour predicted grade
                Please enter only one qualification or subject per entry. You can odd further qualifications bg selecting the <strong>'Add Row'</strong> button.
            </div>

            <div class="">
            <asp:table class="table table-striped text-center" id="tblQuals" runat="server" Width="100%">
            </asp:table>
            <asp:button runat="server" id="btnAdd" cssClass="btn btn-success" text="Add Row"></asp:button>
	        <asp:button runat="server" id="btnRemove" cssClass="btn btn-success" text="Remove Row"></asp:button>
            </div>
            <p class="qualification-count" id="qualification-count">0 qualifications added</p>
        </section>
    </div>




<div class="card-footer">
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnBack" runat="server" Text="← Back" LinkResource="residencystatus_aspx" />
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" CausesValidation="True" /> 
</div>


