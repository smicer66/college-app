<%@ Control Language="VB" AutoEventWireup="false"  CodeFile="checkout_enrolments.ascx.vb" Inherits="webcontrols_checkout_enrolments" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<script>

$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})

</script>


<style>

    .hideLabelSpan span:first-of-type {
  
        display: none !important;

}


</style>


<!--
<br />
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
 --> <cc1:CourseEnrolAction ID="CourseEnrolAction" runat="server" Visible="false"/>
   
   <cc1:OfferingFeesDisplayAll runat="server" Visible="false" />
<!--
                <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li id="linkParent" runat="server" CausesValidation="true"><a href="webenrolment.aspx?page=~/webcontrols/checkout_parent_guardian.ascx">Guardian / Emergency</a></li>                   
                    <li id="linkFurther" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                    <li id="linkQuals" runat="server" ><a id="aQuals" runat="server" href="webenrolment.aspx?page=~/webcontrols/checkout_quals_on_entry.ascx">Qualifications</a></li>
                     <li id="linkAttach" runat="server" ><a href="webenrolment.aspx?page=~/webcontrols/checkout_attachments.ascx">Attachments</a></li>
                     <li id="linkDeclare" runat="server"><a href="webenrolment.aspx?page=~/webcontrols/checkout_dataprotection.ascx">Declarations</a></li>
                    </ol>
    -->
<br />
<br />
<div class="progress" style="height: 20px;">
  <div class="progress-bar" role="progressbar" style="width: 15%;" aria-valuenow="15" aria-valuemin="0" aria-valuemax="100"></div>
</div>
                <ol class="breadcrumb">
                    <li><strong>Personal Details</strong></li>
                    <li>Guardian / Emergency</li>                   
                    <li>Further Details</li>
                     <li>Attachments</li>
                    <li>Photo</li>
                     <li>Declarations</li>
                    </ol>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

    


<div class="container">
   <div class="row">
      <div class="col-sm-12 columns form-group"> 
        <h2>Personal Details</h2><p>Please note all fields marked with <strong>*</strong> are required. </p>
          </div>
  </div>
  <div class="row" id="divRefno" runat="server" visible="false">
      <div class="col-sm-12 columns form-group"> 
    <h4>If you have already applied to the College or studied at the College as a student, your ID is <strong><asp:Label ID="lblRefno" runat="server"></asp:Label></strong> </h4>
          </div>
  </div>
      <div class="row">
      <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Title" ID="StudentEnrolmentField1" runat="server" IsRequired="true"   CustomCaption="* Title" />
          </div>
    
   </div>
    <div class="row">
    <div class="col-sm-6 columns form-group">     
            <cc1:StudentEnrolmentField StudentEnrolmentFieldType="FirstForename" ID="fldFirstName" runat="server" IsRequired="true"  CustomCaption="* First Name"/>
     </div>
        <div class="col-sm-6 columns form-group">       
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname" ID="fldSurname" runat="server" IsRequired="true"  CustomCaption="* Family Name"/>
     </div>
    </div>
  <div class="row">
      <div class="col-sm-6 columns form-group">            
                <cc1:StudentEnrolmentField StudentEnrolmentFieldType="OtherForenames" ID="StudentEnrolmentField7" runat="server" IsRequired="false"  CustomCaption="Middle name"/>
          </div>
      <div class="col-sm-6 columns form-group">  
          <cc1:StudentEnrolmentField StudentEnrolmentFieldType="knownas" ID="StudentEnrolmentField8" runat="server" IsRequired="false"  LabelWidth="400" CustomCaption="Preferred name (Not nickname or shortened name)" />   
          </div>
   </div>
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
          <cc1:StudentEnrolmentField id="datepicker" runat="server" IsRequired="true" StudentEnrolmentFieldType="DateOfBirth"  CustomCaption="* Date of birth"/>
          </div>
      <div class="col-sm-6 columns form-group">            
                 <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Sex" ID="StudentEnrolmentField6" runat="server"  IsRequired="true" CustomCaption="* Legal Sex"/>
          </div>
   </div>
  <div class="row">
      <div class="col-sm-12 columns form-group"> 
            <span>City of Bristol College values everyone as an individual, celebrates diversity, and is committed to equality of opportunity.
The information you provide will be treated confidentially.</span> 
           <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EthnicGroupID" ID="fldEthnicGroupID" runat="server" IsRequired="true"  ExcludedIDValues="99" CustomCaption="* Ethnicity" />
          </div>
    
   </div>


<!--
<div class="container">
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
          </div>
       <div class="col-sm-6 columns form-group"> 
          </div>
   </div>
</div>
    -->
  <div class="row">
      <div class="col-sm-12 columns form-group"> 
<h4>Address details (where you will live while on this course)</h4>
            </div>
   </div>


    <div class="row">
      <div class="col-sm-6 columns form-group"><p>Quickly find your address, enter postcode or partial address below:</p>
<p><asp:TextBox ID="txtLookup" runat="server" CssClass="formtext" ></asp:TextBox>
<asp:Button ID="btnFind" runat="server" Text="Find" CausesValidation="False" /></p>
          <div id="divlstResult" runat="server" visible="true"><asp:ListBox ID="lstresult" runat="server"  AutoPostBack="True" Width="400"></asp:ListBox></div>
          </div>
        </div>
  <div id="divAddresslines" runat="server" visible="true">
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
          <cc1:StudentEnrolmentField runat="server" ID="txtAddress1" StudentEnrolmentFieldType="Address1" CustomCaption="* Address Line 1"/>
          </div>
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField runat="server" ID="txtAddress2" StudentEnrolmentFieldType="Address2" CustomCaption="Address Line 2"/>
          </div>
   </div>
  
  <div class="row">
      <div class="col-sm-6 columns form-group"> 
          <cc1:StudentEnrolmentField runat="server" ID="txtAddress3" StudentEnrolmentFieldType="Address3" IsRequired="false" CustomCaption="Address Line 3"/>
          </div>
       <div class="col-sm-6 columns form-group"> 
           <cc1:StudentEnrolmentField runat="server" ID="txtAddress4" StudentEnrolmentFieldType="Address4" CustomCaption="Address Line 4" />
          </div>
   </div>
    <div class="row">
         <div class="col-sm-12 columns form-group"> 
             <label for="postcode" style="font-weight:bold ">* Postcode</label><input runat="server" maxlength="9" type="text" id="postcode" class="form-control" name="pre[postalcode]" placeholder="Your postcode here..." autocomplete="off" pattern="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$" />
             </div>
           
    </div>
      </div>
     <div class="row">
       <div class="col-sm-12 columns form-group">  <p><strong>You must provide at least one phone number below:</strong></p>
           </div>
         </div>
    <div class="row">
       <div class="col-sm-6 columns form-group"> 
  
   <cc1:StudentEnrolmentField CustomCaption="* Mobile (no spaces)" StudentEnrolmentFieldType="MobileTel" ID="StudentEnrolmentField2" runat="server"  Pattern="^(07[\d]{8,12}|447[\d]{7,11})$"/>
   <!--    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-placement="bottom" title="The format of the mobile must be beginning 07, with no spaces and 11 digits in length eg 07771900900">
Hover over me for Mobile format
</button>
           -->
           </div>
      <div class="col-sm-6 columns form-group"> 
                <cc1:StudentEnrolmentField CustomCaption="* Home Phone (no spaces)" LabelWidth="350" StudentEnrolmentFieldType="Tel" ID="StudentEnrolmentField5" runat="server"  Pattern="^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"/>
    <!--        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-placement="bottom" title="The format of the home telephone must be a UK standard number begining with 0, with no spaces eg 01273800900">
Hover over me for Telephone format
</button> 
          -->
      </div>
   </div>
      <div class="row">
        <div class="col-sm-12 columns form-group"> 
             <cc1:StudentEmailField StudentEnrolmentFieldType="Email" ID="fldEmail" runat="server" IsRequired="true"  CustomCaption="* Email" Pattern="^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"  />
            </div>
       </div>
      <div class="row">
          <div class="col-sm-12 columns form-group"> 
              <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HouseholdSituation1ID" ID="StudentEnrolmentField33"  runat="server" IsRequired="true"  ExcludedIDValues="98" LabelWidth="200" CustomCaption="* Your Household situation" />
          </div>
     </div>
    <div class="row">
      <div class="col-sm-12 columns form-group"> 
                <p>City of Bristol College is committed to supporting care leavers and 'looked after Young People' and therefore encourage candidates from these groups to study with us, we can offer support and guidance to individuals from these groups from our student support and welfare teams. At City of Bristol College we deem a care leaver as any student who has spent 13 weeks or more in the care of the local authority (e.g. foster care or children’s home) between their 14th and 16th birthday, were privately fostered until the age of 16 or who were ‘looked after children’ until they were subject of a Special Guardianship Order.</p>
       </div>
     </div>


      <div class="row">
         <div class="col-sm-12 columns form-group"> 
             <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CareLeaver" ID="StudentEnrolmentField3" runat="server"  LabelWidth="320" IsRequired="false" CustomCaption="Tick if you are you living in care or classed as a care leaver?"/>
          </div>
          </div>
          <div class="row">
         <div class="col-sm-12 columns form-group"> 
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="YoungCarer" ID="StudentEnrolmentField4" runat="server" LabelWidth="300" IsRequired="false" CustomCaption="Tick if you are a young carer"/>
             </div>
               </div>
        <div class="row">
         <div class="col-sm-4 columns form-group"> 
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="YoungParent" ID="StudentEnrolmentField9" runat="server" LabelWidth="300" IsRequired="false" CustomCaption="Tick if you are a young parent"/>
             </div>
   </div>

    
          
      <div class="row">
            <div class="col-sm-12 columns form-group"> 
                <br />
<p><strong>Do you have any unspent criminal convictions, any outstanding court proceedings, or are you on any offenders register?</strong>                </p>
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CriminalConvictionID" ID="StudentEnrolmentField11" runat="server" IsRequired="true" LabelWidth="300" CssClass="hideLabelSpan"   CustomCaption="test " />

                <br />
        If you declare that you have a conviction, you will be contacted for further information. This information will help us assess any potential risks to yourself or others at college.
                    <br />
        The college has a duty of care to all its staff and students to ensure that any risk to their safety is minimised.
                    <br />
        The college reserves the right not to enrol anyone who may pose a threat or danger to the safety of its staff and students. Having a criminal record will not necessarily prevent you studying at college but will depend on the nature of the course and the circumstances of the offence. If you do not disclose a conviction, this can result in disciplinary action or  your enrolment being cancelled. 


        </div>
      </div>
    <br />
      <div class="row">
            <div class="col-sm-6 columns form-group"> 
               
                </div>
   </div>
    </div>



      <!--  <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_aspx"/> -->
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" CausesValidation="true" EnableEnterKey="true" />



