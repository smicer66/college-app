<%@ control Language="VB"  AutoEventWireup="false" CodeFile="courseapply.ascx.vb" Inherits="courseapply"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>


<style type="text/css">
    .selected-courses {
      margin-top: 30px;
    }

    .selected-courses h2 {
      margin: 0 0 16px;
      font-size: 20px;
    }

    /* Container */
    .course-grid {
      display: grid;
      gap: 10px;
    }

    /* Each course = exactly 4 columns */
    .course-row {
      display: grid;

      grid-template-columns:
        minmax(0, 1fr)
        90px
        auto
        auto;

      gap: 12px;
      align-items: center;

      padding: 16px;

      background: #ffffff;
      border: 1px solid #e2e8f0;
      border-radius: 8px;
    }

    /* COLUMN 1 */

    .course-description {
      min-width: 0;
    }

    .course-description strong {
      display: block;

      font-size: 14px;
      line-height: 1.4;

      color: #172b4d;
    }

    .course-description span {
      display: block;

      margin-top: 4px;

      font-size: 13px;
      color: #64748b;
    }


    /* COLUMN 2 */

    .choice-column {
      display: flex;
      align-items: center;
      gap: 6px;
    }

    .choice-column label {
      font-size: 13px;
      font-weight: 600;
      color: #475569;
    }

    /* Small because only 1–9 is required */
    .choice-input {
      width: 42px;
      height: 38px;

      padding: 4px;

      text-align: center;

      font-size: 14px;
      font-weight: 600;

      border: 1px solid #cbd5e1;
      border-radius: 6px;
    }

    .choice-input:focus {
      outline: 2px solid #93c5fd;
      border-color: #2563eb;
    }


    /* COLUMNS 3 & 4 */

    .btn {
      border: 0;
      border-radius: 6px;

      padding: 10px 14px;

      font-size: 13px;
      font-weight: 600;

      cursor: pointer;
    }

    .btn-update {
      background: #2563eb;
      color: #ffffff;
    }

    .btn-update:hover {
      background: #1d4ed8;
    }

    .btn-remove {
      background: #fee2e2;
      color: #b91c1c;
    }

    .btn-remove:hover {
      background: #fecaca;
    }


    /* Status message */

    .course-message {
      min-height: 20px;
      margin-top: 10px;

      font-size: 13px;
      color: #15803d;
    }





    .guidance-grid {
      display: grid;
      grid-template-columns: 1fr;
      gap: 16px;

      width: 100%;
      margin: 24px 0;
      padding: 0px;

      background: #ffffff;
      border: 0px solid #dbe3ed;
      border-radius: 10px;

      color: #172b4d;
    }

    .guidance-grid p {
      margin: 0;
      font-size: 15px;
      line-height: 1.7;
    }

    .guidance-grid h3 {
      margin: 8px 0 0;
      font-size: 17px;
      font-weight: 700;
    }

    .guidance-grid ol {
      margin: 0;
      padding-left: 24px;
    }

    .guidance-grid li {
      margin-bottom: 10px;
      padding-left: 5px;

      font-size: 14px;
      line-height: 1.6;

      color: #475569;
    }

    .guidance-grid li:last-child {
      margin-bottom: 0;
    }

    /* Mobile */
    @media (max-width: 600px) {

      .guidance-grid {
        padding: 18px;
        gap: 14px;
      }

      .guidance-grid p {
        font-size: 14px;
      }

      .guidance-grid li {
        font-size: 13px;
      }
    }


    #stepper{
        display: none !important
    }



        /* Selected course details */
    .course-details-panel { margin: 24px 0; border: 1px solid var(--border); border-radius: 10px; overflow: hidden; background: #fff; }
    .course-details-header { padding: 24px 28px; border-left: 5px solid #450020; background: #fbf7f9; }
    .course-details-eyebrow { font-size: 12px; font-weight: 700; color: #6e3450; text-transform: uppercase; letter-spacing: .08em; margin-bottom: 8px; }
    .course-details-header h2 { margin: 0 0 10px; font-size: 23px; color: #172b4d; }
    .course-code-tag { display: inline-block; border-radius: 4px; padding: 5px 10px; background: #f0e4ea; color: #450020; font-weight: 700; font-size: 13px; }
    .course-details-grid { display: grid; grid-template-columns: repeat(2, minmax(0, 1fr)); padding: 8px 28px 16px; }
    .course-detail { padding: 19px 12px 19px 0; border-bottom: 1px solid #e2e8f0; min-width: 0; }
    .course-detail:nth-last-child(-n+2) { border-bottom: 0; }
    .course-detail-label { display: block; font-size: 13px; font-weight: 600; color: #64748b; margin-bottom: 7px; }
    .course-detail-value { display: block; font-size: 15px; font-weight: 600; color: #172b4d; line-height: 1.5; overflow-wrap: anywhere; }
    .course-details-note { padding: 15px 28px; background: #f8fafc; border-top: 1px solid #e2e8f0; color: #536987; font-size: 13px; line-height: 1.6; }
    @media (max-width: 600px) { .course-details-header { padding: 20px; } .course-details-header h2 { font-size: 20px; } .course-details-grid { grid-template-columns: 1fr; padding: 8px 20px; } .course-detail:nth-last-child(2) { border-bottom: 1px solid #e2e8f0; } .course-details-note { padding: 15px 20px; } }
</style>


    <!--The CourseApplyAction adds the offering to the basket as an application-->
    <cc1:CourseApplyAction ID="CourseApplyAction" runat="server" />
    <div class="step-content" id="step-content">
        <h1>Your Selected Course</h1>
        <section class="course-details-panel" aria-labelledby="selected-course-heading">
            <div class="course-details-header">
              
              <h2 css="" id="CourseTitleSpan" runat="server">Light Vehicle Maintenance &amp; Repair Principles L2 Certificate</h2>
              <span class="course-code-tag" id="CourseCodeSpan" runat="server">Course code: SAMPLE-LV2</span>
            </div>
            <div class="course-details-grid">
              <div class="course-detail"><span class="course-detail-label">Academic Year</span><span class="course-detail-value" id="AcademicYearSpan" runat="server">2026/27</span></div>
              <div class="course-detail"><span class="course-detail-label">Start Date</span><span class="course-detail-value" id="StartDateSpan" runat="server">September 2026 (example)</span></div>
              <div class="course-detail"><span class="course-detail-label">End Date</span><span class="course-detail-value" id="EndDateSpan" runat="server">July 2027 (example)</span></div>
              <div class="course-detail"><span class="course-detail-label">Delivery Site</span><span class="course-detail-value" id="DeliverySiteSpan" runat="server">SBSA Hengrove Site</span></div>
              <div class="course-detail"><span class="course-detail-label">Mode of Attendance</span><span class="course-detail-value" id="ModeOfAttendanceSpan" runat="server">Full-time (example)</span></div>
              <div class="course-detail"><span class="course-detail-label">Learning Aim</span><span class="course-detail-value" id="LearningAimSpan" runat="server">To be confirmed</span></div>
              <div class="course-detail"><span class="course-detail-label">Awarding Body</span><span class="course-detail-value" id="AwardingBodySpan" runat="server">To be confirmed</span></div>
            </div>
            <div class="course-details-note">Please check your course details before continuing with your application. Dates and other example values shown here may change.</div>
          </section>
    </div>
        

<div class="card-footer">
    <cc1:CCCButton id="btnBack" CssClass="btn btn-primary" runat="server" Text="Search for more courses" LinkURL="http://www.cityofbristol.ac.uk/courses/"/>
    <cc1:CCCButton ID="btnContinue" CssClass="btn btn-primary" runat="server" Text="Continue to Checkout →" LinkResource="applicationguidance_aspx" CausesValidation="true" />
</div>