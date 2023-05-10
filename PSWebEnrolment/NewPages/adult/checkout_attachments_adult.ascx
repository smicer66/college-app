<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_attachments_adult.ascx.vb" Inherits="webcontrols_checkout_attachments" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<br /><br /><br />
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Emergency Contact</li>                   
                    <li>Further Details</li>
       <li>Qualifications</li>
                        <li>Employment</li>
                     <li><strong>Attachments</strong></li>
                     <li>Photo</li>
                     <li>Declarations</li>
                    </ol>
    
  <asp:ValidationSummary ID="vsAttachments" runat="server" CssClass="alert alert-danger" />

<h2>Attachments</h2>
    <p>
      <strong>* Please use this page to upload evidence to support your enrolment. You can upload a picture using your mobile phone as long as the document is legible, all files upload in this section must be in the .jpg, .png or .jpeg file formats.</strong>    
      </p>
<ul runat="server" id="ulList">
    <li>You must upload 1 proof of identity such as a national insurance (NI) card, national ID card, correspondence from your school, passport, birth certificate or driving licence</li>
    <li>If you have not lived in the UK / Ireland for the last three years you must upload any residency documents that you have which may include your passport, residence permit / card or evidence of your ‘Settled’ or ‘Pre-Settled’ residence status.  </li>
     <li>You must upload copies of certificates for any qualifications you have already achieved. If you are awaiting your results you do not need to upload them here.</li>
     <li>If you have applied for a student loan, you must upload a letter from the student loans company confirming your loan has been applied/approved.</li>
  <li >If your employer is paying your fees, you must upload a letter from your employer stating they will pay your fees or authority to invoice.</li>

</ul>
<p><strong>Failure to upload the required documents will delay or prevent your enrolment to the College.</strong></p>

<div class="container">
    <div class="row">
        <div class="col-sm-12 columns form-group">The maximum file size is up to 5 MB per file, the supported file formats allowed are jpg, png, jpeg)
            </div>

    </div>
   <div class="row">
        <div class="col-sm-3 columns form-group"><p>* Type of Evidence</p> 
            <asp:DropDownList ID="ddlTypeOfEvidence" runat="server" >
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                 <asp:ListItem Text="Certificates" Value="Certificates"></asp:ListItem>
                                  <asp:ListItem Text="Employer Letter" Value="Employer letter"></asp:ListItem>
                                  <asp:ListItem Text="Loan Letter" Value="SLC letter"></asp:ListItem>
                               <asp:ListItem Text="Proof of Identity" Value="Proof of Identity"></asp:ListItem>
                              <asp:ListItem Text="Residence status" Value="Residence status"></asp:ListItem>

                            </asp:DropDownList>
            </div>
      
               <div class="col-sm-3 columns form-group"><p>* Find File </p>
                     <cc1:CCCFileUpload ID="fuAttachment" runat="server" data-html="true"  ClientIDMode="static"  IsRequired="true"  Width="200" SupportedFileTypes=".jpg, .png, .jpeg" MaxAllowedFileSize="5000" MaxAllowedFileSizeErrorMessage="File size is larger than 5 MB" />
            </div>
               <div class="col-sm-3 columns form-group"><p>* Add file</p>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-success" CausesValidation="true" />
            </div>
       
   </div>
</div> 
<hr />
 <div class="panel panel-success"  runat="server" id="divMain">

    <!--
        Following properties are there to use in the File Upload control
        - IsRequired (To set control mandatory)
        - RequiredErrorMessage (A message to display when user is not uploading file)
        - MaxAllowedFileSize (Maximum size allowed for a file upload in KB). Use this to override value set in System Setting of same name.
        - MaxAllowedFileSizeErrorMessage  (A message to display when user has uploaded larger file than allowed)
        - SupportedFileTypes (File Types supported by the control (.jpg, .png, .xlsx)). Use this to override value set in System Setting of same name.
        - SupportedFileTypesErrorMessage (A message to display when user has uploaded file of type which is not valid)
        - HideUserInfoOnTooltip (To prevent showing of information related to file upload requirements)
        - UserInfo (User Information related to file upload requirements - if need to display at any specific location manually)
        -->
 
    <div>
        <table id="tblUploadedInfo"class="table table-striped table-bordered text-center" style="border-style: None;">
            <tbody>
                <asp:Repeater ID="rptAttachments" runat="server" OnItemCommand="rptAttachments_ItemCommand">
                    <HeaderTemplate>
                        <tr class="searchgridheader">
                            <th scope="col" style="width: 20%;">Type of Evidence</th>
         
                            <th scope="col" style="width: 15%">Attachment</th>
                            <th scope="col" style="width: 10%">Remove</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="searchgridcell text-left">
                            <td runat="server" id="row1"><%# Eval("TypeOfEvidence") %></td>
               
                            <td><%# Eval("FileName") %></td>
                            <td class="text-center">
                                <asp:Button ID="btnRemove" runat="server" Text="X" CssClass="btn btn-danger" CommandName="RemoveAttachment" CommandArgument='<%# Eval("AttachmentID") %>' OnClientClick="return confirmDeletion()" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trNoItems" runat="server" class="searchgridcell" visible="false">
                    <td colspan="4">No attachments uploaded yet
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

     <asp:HiddenField runat="server" ID="hiddenvalidator" Visible="true"/>
</div>
 
<cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_employment_adult_aspx"  />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  LinkResource="checkout_photo_adult_aspx" CausesValidation="true" />


<script type="text/javascript">
    $("#btnChooseFile").click(function () {
        $('#fuAttachment').click();
    });
    function confirmDeletion() {
        var result = confirm("Are you sure you want to delete this attachment? Press OK to continue deletion.");
        if (result) {
            return true;
        }
        return false;
    }    

    $(function () {
        $('.example-popover').popover({
            container: 'body'
        })
    })
</script>
