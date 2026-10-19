<%@ control Language="VB"  AutoEventWireup="false" CodeFile="applicationguidance.ascx.vb" Inherits="applicationguidance"  %>
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
</style>

                <!--<ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/ApplicationGuidance.ascx">Course Details</a></li>
                  <li class="active">Course Added to Basket</li>
                </ol>-->

    <!--The CourseApplyAction adds the offering to the basket as an application-->
    
    <div class="step-content" id="step-content">
            <h1>Application Guidance</h1>
            <p class="intro" id="existingCourseIntro" runat="server" visible="false">Welcome to the application process. Please read the guidance carefully before continuing.</p>
            <p class="intro" id="emptyCourseIntro" runat="server" visible="false">Welcome to the application process.</p>
        
					
              <div class="info-box"id="infoBox" >
                <div class="info-icon">i</div>
                <div>
                  <h3>Important information</h3>
                  <p id="infoForApplication" runat="server" visible="false">
                    Make sure you have all the necessary information
                    and documents ready before you start.
                    You can not save your progress and return at any time.
                  </p>
                  <p id="infoForHowToApply" runat="server" visible="false">
                    You haven't added any courses to your application yet.
                    To start the application process, please select and
                    add at least one course.
                  </p>
                </div>
              </div>

          <!--<div id="divCelta" runat="server" visible="false">
                <h3 >TEACHING ESOL / CELTA </h3>
                <div class=" form-group">
                    <p>Before you begin your application, please note the following</p>
                    <p>You will be required to give your reasons for wishing to take the course and outline what you hope to gain from it. You should write between 200 and 250 words. You may wish to prepare this in advance before starting the application process. You will need to include: </p>
                        <ol><li>Why you are applying for this course</li><li>What you hope to gain from the course and how it will help you achieve future aspirations</li><li>Any experience you have in relation to the course, this maybe educational, voluntary and/or work based</li></ol>
                    <p>You will  be required to upload a copy of your highest qualification and some photo identification such as your passport or photo driving licence.</p>
                </div>
          </div>-->
            <div id="divStatement" runat="server" visible="false">
                <h3 >Access to HE applicants</h3>
                <div class=" form-group">
                     <p>You will be required to include a personal statement (approximately one side of A4), within the application form. Please prepare this in advance before starting the application process. You will need to include: </p>
                    <ol><li>Why you are applying</li><li>What you would like to study at the university, and why</li><li>Any experience you have in relation to the course, this maybe educational, voluntary and/or work based</li></ol>
               <p>Please limit your personal statement to no more than 1 A4 side.</p>

                </div>
            </div>
            <div id="divSuppIntern" runat="server" visible="false">
                 <h3 >Supported Internship</h3>
                <p>To be eligible to enrol on to a Supported Internship you:</p>
                 <ol>
                     <li>Must have an EHCP</li>
            <li>Must be willing to be embedded in an external employer with support that is gradually withdrawn placed with work placement outside the college</li>
            <li>Must provide at least one reference (work based if possible)</li>
            <li>Must be able to use public transport independently on familiar routes</li>
            <li>Must provide a personal statement, within the application form. Please prepare this in advance before starting the application process. You will need to include:</li>
            <ol>
                <li>Details of work previous work experience</li>
            <li>Why an internship has been applied for</li>
            <li>The skills and qualities that the applicant can bring to the programme</li>
                </ol>
                 </ol>
            </div>

            <div id="div1" runat="server" visible="false">
                <h3 >TEACHING ESOL / CELTA </h3>
                <div class=" form-group">
                     <p>Before you begin your application, please note the following</p>
                    <p>You will be required to give your reasons for wishing to take the course and outline what you hope to gain from it. You should write between 200 and 250 words. You may wish to prepare this in advance before starting the application process. You will need to include: </p>
                    <ol><li>Why you are applying for this course</li><li>What you hope to gain from the course and how it will help you achieve future aspirations</li><li>Any experience you have in relation to the course, this maybe educational, voluntary and/or work based</li></ol>
               <p>You will  be required to upload a copy of your highest qualification and some photo identification such as your passport or photo driving licence.</p>
                    </div>
                </div>
		  
            <section class="selected-courses">

                <h2>Selected Courses</h2>

                <asp:PlaceHolder runat="server" ID="FeesPlaceHolder">


                </asp:PlaceHolder>

                <div id="courseMessage" class="course-message" role="status" aria-live="polite">
                </div>

            </section>


            <div class="guidance-grid" runat="server" id="AdviceOnApplication">

              <p>
                Please read this page in full before continuing with your application,
                as you may need to provide information about:
              </p>

              <ol>
                <li>
                  Your full legal name as shown on your passport or birth certificate
                </li>
                <li>
                  Your residency status
                </li>
              </ol>

              <h3>Please note:</h3>

              <ol>
                <li>
                  Applying for a course does not guarantee that you will be offered a place.
                </li>

                <li>
                  Any offer to study is subject to you meeting the entry requirements
                  of the course and your eligibility for Further Education funding.
                </li>

                <li>
                  We will need to verify your residency status and may ask you to
                  provide supporting evidence.
                </li>

                <li>
                  All communications will refer to your first-choice course.
                  You will have opportunities to change your course choice if required.
                </li>
              </ol>

            </div>
			
        
      </div>
        

<div class="card-footer" id="footerBtns" runat="server">
    <cc1:CCCButton CssClass="btn btn-primary" id="btnBack" runat="server" Text="← Back" LinkURL="http://www.cityofbristol.ac.uk/courses/"/>
    <cc1:CCCButton CssClass="btn btn-primary" ID="btnContinue" runat="server" Text="Next →" LinkResource="personaldetails_aspx" CausesValidation="true" />
</div>