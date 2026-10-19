<%@ control Language="VB" AutoEventWireup="false" CodeFile="privacynotices.ascx.vb" Inherits="privacynotices"  %>
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

    .btn {
      border: none;
      border-radius: 7px;
      padding: 13px 24px;
      font-size: 14px;
      font-weight: 700;
      cursor: pointer;
      transition: background 0.2s;
    }

    .btn-primary {
      background: var(--primary);
      color: white;
    }

    .btn-primary:hover {
      background: #1d4ed8;
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


    /* Personal Statement */
    .statement-wrap{width:100%}
    .statement-textarea{
      width:100%;
      min-height:240px;
      resize:vertical;
      padding:14px 16px;
      border:1px solid #cbd5e1;
      border-radius:8px;
      background:#fff;
      color:var(--text);
      font:inherit;
      font-size:15px;
      line-height:1.65;
    }
    .statement-textarea:focus{outline:3px solid #bfdbfe;border-color:var(--primary)}
    .statement-meta{display:flex;justify-content:space-between;gap:16px;margin-top:8px;font-size:13px;color:var(--muted)}
    .statement-meta .invalid{color:#b91c1c;font-weight:700}
    @media(max-width:600px){
      .statement-textarea{min-height:220px}
      .statement-meta{flex-direction:column;gap:4px}
    }


    /* Learning Difficulty, Disability or Health Condition */
    .condition-grid{
      display:grid;
      grid-template-columns:repeat(2,minmax(0,1fr));
      gap:12px 24px;
      margin-top:18px;
    }
    .condition-option{
      display:flex;
      align-items:flex-start;
      gap:10px;
      min-height:42px;
      padding:10px 12px;
      border:1px solid var(--border);
      border-radius:8px;
      background:#fff;
      color:#475569;
      font-size:14px;
      line-height:1.45;
      cursor:pointer;
    }
    .condition-option input{
      width:18px;
      height:18px;
      margin:1px 0 0;
      flex:0 0 auto;
      accent-color:var(--primary);
    }
    .condition-option:has(input:checked){
      border-color:#93c5fd;
      background:var(--primary-light);
    }
    @media(max-width:600px){
      .condition-grid{grid-template-columns:1fr;gap:10px}
    }


    /* Privacy Notices */
    .privacy-notice{display:grid;gap:20px}
    .privacy-block{padding:20px;border:1px solid var(--border);border-radius:9px;background:#fff}
    .privacy-block h3{margin:0 0 10px;color:var(--text);font-size:17px;line-height:1.4}
    .privacy-block p{margin:0;color:#475569;font-size:14px;line-height:1.75}
    .privacy-block p + p{margin-top:12px}
    .privacy-block a{color:var(--primary);font-weight:600;text-decoration:underline;text-underline-offset:2px;overflow-wrap:anywhere}
    .privacy-contact-list{margin:10px 0 0 20px;padding:0;color:#475569;font-size:14px;line-height:1.75}
    .privacy-address{margin-top:10px!important;padding-left:14px;border-left:3px solid #dbeafe}
    @media(max-width:600px){.privacy-block{padding:16px}}

    p{
        max-width:none  !important;
    }
</style>


    <div class="step-content" id="step-content">
        <h1>Privacy Notices</h1>
        <p class="intro">Please read about how we use your data.</p>
        <section class="form-section">
        <div class="privacy-notice">
            <article class="privacy-block">
            <h3>Learning Record Service (LRS) - Ability to Share</h3>
            <p>The information you supply is used by the LRS. The LRS issues Unique Learner Numbers (ULN) and creates Personal Learning records across England, Wales &amp; Northern Ireland, and is operated by the Department for Education (DfE) in England. For more information about how your information is processed, and to access your Personal Learning Record, please refer to: <a href="https://www.gov.uk/government/publications/lrs-privacy-notices" target="_blank" rel="noopener noreferrer">gov.uk/government/publications/lrs-privacy-notices</a>.</p>
            </article>

            <article class="privacy-block">
            <h3>Department for Education (DfE)</h3>
            <p>This privacy notice is issued on behalf of the Secretary of State for the Department of Education (DfE) to inform learners about the Individualised Learner Record (ILR) and how their personal information is used in the ILR. Your personal information is used by the DfE to exercise our functions under article 6(1)(e) of the UK GDPR and to meet our statutory responsibilities, including under the Apprenticeships, Skills, Children and Learning Act 2009. Our lawful basis for using your special category personal data is covered under Substantial Public Interest based in law (Article 9(2)(g)) of UK GDPR legislation. This processing is under Section 54 of the Further and Higher Education Act (1992).</p>
            <p>The ILR collects data about learners and learning undertaken. Publicly funded colleges, training organisations, local authorities, and employers (FE providers) must collect and return the data each year under the terms of a funding agreement, contract or grant agreement. It helps ensure that public money is being spent in line with government targets. It is also used for education, training, employment, and well-being purposes, including research.</p>
            <p>We retain your ILR learner data for 20 years for operational purposes (e.g. to fund your learning and to publish official statistics). Your personal data is then retained in our research databases until you are aged 80 years so that it can be used for long-term research purposes.</p>
            <p>For more information about the ILR and the data collected, please see the ILR specification at <a href="https://www.gov.uk/government/collections/individualised-learner-record-ilr" target="_blank" rel="noopener noreferrer">gov.uk/government/collections/individualised-learner-record-ilr</a>. ILR data is shared with third parties where it complies with DfE data sharing procedures and where the law allows it. The DfE and the English European Social Fund (ESF) Managing Authority (or agents acting on their behalf) may contact learners to carry out research and evaluation to inform the effectiveness of training.</p>
            <p>For more information about how your personal data is used and your individual rights, please see the <a href="https://www.gov.uk/government/organisations/department-for-education/about/personal-information-charter" target="_blank" rel="noopener noreferrer">DfE Personal Information Charter</a> and the <a href="https://www.gov.uk/government/publications/privacy-notice-for-key-stage-5-and-adult-education" target="_blank" rel="noopener noreferrer">DfE Privacy Notice</a>.</p>
            <p>If you would like to get in touch with us or request a copy of the personal information DfE holds about you, you can contact the DfE in the following ways:</p>
            <ol class="privacy-contact-list">
                <li>Using the <a href="https://form.education.gov.uk/service/Contact_the_Department_for_Education" target="_blank" rel="noopener noreferrer">DfE online contact form</a>.</li>
                <li>By telephoning the DfE Helpline on 0370 000 2288.</li>
                <li>In writing to: Data Protection Officer, Department for Education, 4th Floor, 2 St Paul's Place, 125 Norfolk Street, Sheffield, S1 2FJ.</li>
            </ol>
            <p>If you are unhappy with how we have used your personal data, you can complain to the Information Commissioner’s Office (ICO) at: Wycliffe House, Water Lane, Wilmslow, Cheshire, SK9 5AF. You can also call their helpline on 0303 123 1113 or visit <a href="https://ico.org.uk/" target="_blank" rel="noopener noreferrer">www.ico.org.uk</a>.</p>
            </article>

            <article class="privacy-block">
            <h3>City of Bristol College</h3>
            <p>Generally, the information is processed as part of our public interest task of providing education to you. For further information about use of and access to your personal data, details of organisations with whom we regularly share data, information about how long we retain your data, and how to change your consent to being contacted, please visit: <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank" rel="noopener noreferrer">cityofbristol.ac.uk/privacy-statement</a>.</p>
            <p>As Data Controller, the College may share non-sensitive personal information with other organisations as set out on its Data Protection registration and from 25 May 2018, General Data Protection Regulation. The College may share your information with other organisations for education, training, employment, research and well-being related purposes. Further details are available on the <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank" rel="noopener noreferrer">College privacy statement</a>.</p>
            <p>If at any time you wish to stop receiving these messages, please contact Student Services on 0117 312 5000 or <a href="mailto:enquiries@cityofbristol.ac.uk">enquiries@cityofbristol.ac.uk</a> and change your preferences or opt-out at any time.</p>
            <p><strong>Sensitive information:</strong> The College may use this information to ensure equality of opportunity, support your studies, minimise risk and for anonymous statistics. We are required to share it with the relevant government departments as mentioned above. We will ask you before sharing it with others.</p>
            </article>
        </div>
        </section>
    </div>



<div class="card-footer">
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnBack" runat="server" Text="← Back" LinkResource="previousconvictions_aspx" />
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" LinkResource="contactdetails_aspx" CausesValidation="True" /> <!---->
</div>
