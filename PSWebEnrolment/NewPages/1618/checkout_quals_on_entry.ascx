<%@ control  Language="VB"  AutoEventWireup="false" CodeFile="checkout_quals_on_entry.ascx.vb" Inherits="checkout_quals_on_entry" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<!--<br />
<div class="container">
   <div class="row">
      <div class="col-sm-12 columns form-group"> 
                <asp:Label runat="server" ID="lblAge"></asp:Label>
          </div>   

   </div>
       <div class="row">
         
       <div class="col-sm-12 columns form-group"> 
<asp:Label runat="server" ID="lblAgeCourse"></asp:Label>
          </div>
       </div>
    </div>
<br />
    -->
                   <!-- <ol class="breadcrumb">
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li id="linkParent" runat="server" CausesValidation="true"><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Guardian - Emergency</a></li>                   
                    <li id="linkFurther" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <li id="lnkQuals" runat="server" >Qualifications</li>
                    <li id="linkAttach" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                     <li id="linkDeclare"><a href="webenrolment.aspx?page=~/webcontrols/checkout_dataprotection.ascx">Declarations</a></li>
                </ol>
                       -->

<script>

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

</script>
<br />
<br />
<div class="progress" style="height: 20px;">
  <div class="progress-bar" role="progressbar" style="width: 60%;" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
</div>
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Guardian / Emergency</li>                   
                    <li>Further Details</li>
                    <li><strong>Qualifications</strong></li>
                     <li>Attachments</li>
      <li>Photo</li>
                     <li>Declarations</li>
                    </ol>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"  />
<div class="container">
    <div class="well mt">
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
          <h2>Qualifications</h2>
          </div>
  </div>
      <div class="row">
        <div class="col-sm-12 columns form-group"> 
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudyElsewhere" ID="fldStudyElse" runat="server" Visible="true" LabelWidth="350" IsRequired="false"  CustomCaption="Are you planning to study (or enrolled) at any other organisation"/>
          </div>
   </div>
     <div class="row">
        <div class="col-sm-12 columns form-group"> 
                <cc1:studentenrolmentfield id="fldPrevSch" runat="server" Visible="true"  customcaption="* What was the last school or College attended?" isrequired="true" labelwidth="300" StudentEnrolmentFieldType="SchoolID" ExcludedIDValues="98" ></cc1:studentenrolmentfield>        
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12 columns form-group"> 
            <cc1:studentenrolmentfield id="fldPriorAttainmentLevelID" runat="server" customcaption="* What is your highest level of Qualification?" ExcludedIDValues="98" isrequired="true" labelwidth="300" StudentEnrolmentFieldType="PriorAttainmentLevelID"></cc1:studentenrolmentfield>
        <span id="showItem"><a class="btn btn-primary" role="button">Unsure? Click me to help you decide</a></span>
            </div>
    </div>  


<div id="priorDiv">
  
<table class="table table-striped table-bordered">
    <tr class="active"><th>Level</th><th>Qualification Equivalent<div style="float:right" ><span id="hideItem"><a class="btn btn-secondary" role="button">Hide table</a></span></div></th></tr>
    <tr><td>
        Entry Level</td><td>
            QCF qualifcations at Entry level; Certificate in Adult Literacy, Numeracy, ESOL at Entry level; RQF qualifications at Entry Level; English and Maths qualifications at Entry Level such as Functional Skills</td>
        </tr>
        <tr>
            <td>
                Level 1</td>
            <td>
                GCSE/O Level (at grades D-G or fewer than 5 at grades A-C); CSE grade 2 and 3; 1 AS Level (for AS qualifications regulated before 1 September 2015); QCF qualifications at Level 1; Foundation 14-19 Diploma; Functional Skills; Certificate in Adult Literacy, Numeracy, ESOL at Level 1; Level 1 Key Skills; Level 1 Principal Learning; Introductory Diploma; Introductory Certificate; GNVQ Foundatio;n NVQ Level 1; RQF qualifications at Level 1; Technical Awards in the Key Stage 4 Performance Tables</td>
           
        </tr>
        <tr>
            <td>
                Level 2</td>
            <td>
                GCSE/O Level (5 or more GCSEs grades A*-C); GCSE (9-1) (5 or more GCSEs grade 4 or above); 2 or 3 AS Levels (for AS qualifications regulated before 1 September 2015); CSE Grade 1 (5 or more); 1 A Level; Higher 14-19 Diploma; QCF Diploma level 2; QCF Certificate level 2 at 13 or 14 credits undertaken before 2014 to 2015; Level 2 Principal Learning; NVQ level 2; GNVQ Intermediate; Technical Certificates in the 16-19 Performance Tables; QCF Certificate level 2 at 15 credits and above; From 1 August 2015 vocational qualifications of 150 GLH or more.  
            </td>
        </tr>
        <tr>
            <td>
                Level 3</td>
            <td>
            A Levels (2 or more advanced level passes); 4 or more AS Levels (for AS qualifications regulated before 1 September 2015); QCF Diploma Level 3; QAA Access to HE; Advanced 14-19 Diploma; GNVQ Advanced; NVQ level 3; AVCE double award; Tech Levels which are in the 16-19 Performance Tables; Applied Generals which are in the 16-19 Performance Tables (from 1 August 2015); QCF Certificate at Level 3 which is 30 to 36 credits; From 1 August 2015 vocational qualifications of 300 GLH or more. 
            </td>
        </tr>
        <tr>
            <td>
                Level 4</td>
            
            <td>
               QCF Award Level 4; QCF Certificate Level 4; QCF Diploma Level 4; HNC; RQF qualification Level 4; Certificates in Higher Education
        </tr>
        <tr>
            <td>
                Level 5</td>
            
            <td>QCF Award Level 5; QCF Certificate Level 5; QCF Diploma Level 5; HND; RQF qualification Level 5; Foundation Degrees
                </td>
        </tr>
        <tr>
            <td>
                Level 6</td>
            
            <td>QCF Award Level 6; QCF Certificate Level 6; QCF Diploma Level 6; RQF qualification Level 6; Bachelor’s degrees; graduate certificates and diplomas
                </td>
        </tr>
        <tr>
            <td>
                Level 7+</td>
            
            <td>QCF Award Level 7/8; QCF Certificate Level 7/8; QCF Diploma Level 7/8; RQF qualification Level 7/8; Doctorates; Masters degree; postgraduate ceritifcates and diplomas
                </td>
        </tr>

    <tr><td colspan="3"><span id="hideItem2"><a class="btn btn-secondary" role="button">Hide table</a></span></td></tr>
    </table>
        </div>
     <br /><br />
<div id="divYourQuals" runat="server">

      <strong>Your qualifications</strong>
   <p>Please include information on qualifications you have <strong>already completed and have the results</strong> ie GCSE, NVQs, BTEC, Diplomas, A levels or any other subjects you may have studied. For any resits, enter the highest grade achieved for that qualification. </p> 
     <p>If you are awaiting your results you do not need to enter them here.</p>           <p>
                Please enter the qualifications, choosing from the drop-down lists below.</p>
        
   <!--  <div class="row"  > <div class="col-sm-3 columns form-group">Qualification </div> <div class="col-sm-22 columns form-group">Subject (if not in Qualification list)</div><div class="col-sm-2 columns form-group">Grade</div> <div class="col-sm-2 columns form-group">Predicted Grade</div> <div class="col-sm-3 columns form-group">Date awarded</div>
         </div>-->
    <div class="row"  > 
        <div class="col-sm-3 columns form-group"> <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField17" StudentQualsOnEntryRowNumber="0" CustomCaption="Qualification 1" />
            </div>
         <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField29" StudentQualsOnEntryRowNumber="0" CustomCaption="Subject (if not in list) " />
             </div>
                 <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField18" StudentQualsOnEntryRowNumber="0" CustomCaption="Grade"/>
            </div>
                 <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField19" StudentQualsOnEntryRowNumber="0" CustomCaption="Predicted Grade" />
            </div>
                 <div class="col-sm-2 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField20" StudentQualsOnEntryRowNumber="0" CustomCaption="Date Awarded (dd/mm/yy)"  />

            </div>
         </div>   
         <div class="row"  >
        <div class="col-sm-3 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="Qual" StudentQualsOnEntryRowNumber="1" CustomCaption="Qualification 2" />
            </div>
                 <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField30" StudentQualsOnEntryRowNumber="1" CustomCaption="Subject (if not in list) " />
             </div>
                 <div class="col-sm-2 columns form-group">         <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="Grade" StudentQualsOnEntryRowNumber="1" CustomCaption="Grade" />
            </div>
                 <div class="col-sm-2 columns form-group">     <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="PredGrade" StudentQualsOnEntryRowNumber="1" CustomCaption="Predicted Grade" />
            </div>
                 <div class="col-sm-2 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="DateAwarded" StudentQualsOnEntryRowNumber="1" CustomCaption="Date Awarded (dd/mm/yy)" />    
            </div>
         </div>
      <div class="row"  >
         <div class="col-sm-3 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField1" StudentQualsOnEntryRowNumber="2"  CustomCaption="Qualification 3" />
            </div>
             <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField31" StudentQualsOnEntryRowNumber="2" CustomCaption="Subject (if not in list) " />
             </div>
                 <div class="col-sm-2 columns form-group">            <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField2" StudentQualsOnEntryRowNumber="2"  CustomCaption="Grade" />
            </div>
                 <div class="col-sm-2 columns form-group">     <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField3" StudentQualsOnEntryRowNumber="2"  CustomCaption="Predicted Grade" />
            </div>
                 <div class="col-sm-2 columns form-group">           <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField4" StudentQualsOnEntryRowNumber="2"  CustomCaption="Date Awarded  (dd/mm/yy)" />
            </div>
         </div>
          <div class="row"  >
                <div class="col-sm-3 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField5" StudentQualsOnEntryRowNumber="3" CustomCaption="Qualification 4 " />
                </div>
                 <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField32" StudentQualsOnEntryRowNumber="3" CustomCaption="Subject (if not in list) " />
             </div>
                    <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField6" StudentQualsOnEntryRowNumber="3" CustomCaption="Grade" />
                </div>
                <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField7" StudentQualsOnEntryRowNumber="3" CustomCaption="Predicted Grade" />
                </div>
                 <div class="col-sm-2 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField8" StudentQualsOnEntryRowNumber="3" CustomCaption="Date Awarded  (dd/mm/yy)" />
                </div>
              </div>
            <div class="row"  >
                <div class="col-sm-3 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField9" StudentQualsOnEntryRowNumber="4" CustomCaption="Qualification 5 " />
                </div>
                   <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField33" StudentQualsOnEntryRowNumber="4" CustomCaption="Subject (if not in list) " />
             </div>
                    <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField10" StudentQualsOnEntryRowNumber="4" CustomCaption="Grade" />
                </div>
                <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField11" StudentQualsOnEntryRowNumber="4" CustomCaption="Predicted Grade" />
                </div>
                 <div class="col-sm-2 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField12" StudentQualsOnEntryRowNumber="4" CustomCaption="Date Awarded (dd/mm/yy)" />
                </div>
              </div>
              <div class="row"  >
                <div class="col-sm-3 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField13" StudentQualsOnEntryRowNumber="5" CustomCaption="Qualification 6 " />
                </div>
                     <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField34" StudentQualsOnEntryRowNumber="5" CustomCaption="Subject (if not in list) " />
             </div>
                    <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField14" StudentQualsOnEntryRowNumber="5" CustomCaption="Grade" />
                </div>
                <div class="col-sm-2 columns form-group">      <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField15" StudentQualsOnEntryRowNumber="5" CustomCaption="Predicted Grade" />
                </div>
                 <div class="col-sm-2 columns form-group">       <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField16" StudentQualsOnEntryRowNumber="5" CustomCaption="Date Awarded (dd/mm/yy)"  />
                </div>
              </div>
      <div class="row"  >
                <div class="col-sm-3 columns form-group">          <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField21" StudentQualsOnEntryRowNumber="6" CustomCaption="Qualification 7 " />
                </div>
             <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField35" StudentQualsOnEntryRowNumber="6" CustomCaption="Subject (if not in list) " />
             </div>
                    <div class="col-sm-2 columns form-group">   <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField22" StudentQualsOnEntryRowNumber="6" CustomCaption="Grade" />
                </div>
                <div class="col-sm-2 columns form-group">        <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField23" StudentQualsOnEntryRowNumber="6" CustomCaption="Predicted Grade" />
                </div>
                 <div class="col-sm-2 columns form-group">            <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField24" StudentQualsOnEntryRowNumber="6" CustomCaption="Date Awarded (dd/mm/yy)"/>
                </div>
              </div>

      <div class="row"  >
                <div class="col-sm-3 columns form-group">         <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="QualID" runat="server" id="StudentQualsOnEntryField25" StudentQualsOnEntryRowNumber="7" CustomCaption="Qualification 8 "/>
                </div>
             <div class="col-sm-3 columns form-group">  <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Subject" runat="server" id="StudentQualsOnEntryField36" StudentQualsOnEntryRowNumber="7" CustomCaption="Subject (if not in list) " />
             </div>
                    <div class="col-sm-2 columns form-group">     <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="Grade" runat="server" id="StudentQualsOnEntryField26" StudentQualsOnEntryRowNumber="7" CustomCaption="Grade" />
                </div>
                <div class="col-sm-2 columns form-group">        <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="PredictedGrade" runat="server" id="StudentQualsOnEntryField27" StudentQualsOnEntryRowNumber="7" CustomCaption="Predicted Grade"/>
                </div>
                 <div class="col-sm-2 columns form-group">        <cc1:StudentQualsOnEntryField StudentQualsOnEntryFieldType="DateAwarded" runat="server" id="StudentQualsOnEntryField28" StudentQualsOnEntryRowNumber="7" CustomCaption="Date Awarded (dd/mm/yy)" />
                </div>
              </div>

        </div>
        </div>
   
    <!--
    <asp:button runat="server" id="btnNoPriorQualifications" cssClass="show_hide btn btn-primary" text="No prior qualifications" ToolTip="Click to remove all the items listed below (And hide the list)"></asp:button>
    <br />
    <br />
    -->
   <%--  <div id="slidingdiv" class="slidingDiv" runat="server">
        <asp:table class="table table-striped text-center" id="tblQuals" runat="server">
    





        </asp:table>
    <asp:button runat="server" id="btnAdd" cssClass="btn btn-success" text="Add Row"></asp:button>

        </div>--%>
    <br /><br />
    <p><strong>Conditionality Check for English and Maths</strong></p>
            <p>Select None if you have not received your results yet.</p>
<div class="container">
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField id="fldGCSEEng" runat="server" customcaption="* GCSE English Grade" CustomFieldType="Lookup" isrequired="false" labelwidth="300" StudentEnrolmentFieldType="StudentDetailUserDefined33"></cc1:StudentEnrolmentField>
          </div>
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField id="fldGCSEMat" runat="server" customcaption="* GCSE Maths Grade" CustomFieldType="Lookup" isrequired="false" labelwidth="300" StudentEnrolmentFieldType="StudentDetailUserDefined34"></cc1:StudentEnrolmentField>
          </div>
   </div>
   <div class="row">
      <div class="col-sm-6 columns form-group"> 
                     <cc1:StudentEnrolmentField id="StudentEnrolmentField4" runat="server" customcaption="Do you have Functional Skills vL2 in English?" isrequired="False" labelwidth="300" StudentEnrolmentFieldType="StudentDetailUserDefined35" CustomFieldType="TickBox"></cc1:StudentEnrolmentField>
          </div>
      <div class="col-sm-6 columns form-group"> 
                     <cc1:StudentEnrolmentField id="StudentEnrolmentField5" runat="server" customcaption="Do you have Functional Skills vL2 in Maths?" isrequired="False" labelwidth="300" StudentEnrolmentFieldType="StudentDetailUserDefined36"  CustomFieldType="TickBox"></cc1:StudentEnrolmentField>
          </div>

    </div>
</div>
</div>


<%--Example of how to pull QualOnEntryField--%>

<%--<div class="well mt">

    <div class="form-group">

          

    </div>
</div>--%>


 <cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_enrolments2_1618_aspx" />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="checkout_attachments_1618_aspx" CausesValidation="true" EnableEnterKey="true" />
<br />

   
        <asp:HiddenField  id="NoQuals" value="false" runat="server"  ClientIDMode="static" />
     <asp:HiddenField  id="intQualRows" value="0" runat="server"  ClientIDMode="static" />


 <script type="text/javascript">
        var divToHide = $('div#priorDiv');
     var hideBtn = $('span#hideItem');
             var hideBtn2 = $('span#hideItem2');
        var showBtn = $('span#showItem');

        showBtn.click(function () {
            divToHide.show();
        });

        hideBtn.click(function () {
            divToHide.hide();
     });

             hideBtn2.click(function () {
            divToHide.hide();
        });

        $(document).ready(function () {
            //alert();
            divToHide.hide();
   <%--          $("#divYourQuals").hide();
           $('#<%= fldPriorAttainmentLevelID.ClientID %>').change(function () {
                if ($("#<%=fldPriorAttainmentLevelID.ClientID%>").val() == "99") {
                    $("#divYourQuals").hide();
                    return;
                }
                else {
                   $("#divYourQuals").show();
                }
            });--%>

        });
    </script>
 


