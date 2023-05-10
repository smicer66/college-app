<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_photoFC.vb" Inherits="webcontrols_checkout_photo" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>
<script>

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

</script>
<div class="progress" style="height: 20px;">
  <div class="progress-bar" role="progressbar" style="width: 90%;" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100"></div>
</div>
  <ol class="breadcrumb">
                    <li>Personal Details</li>
                    <li>Further Details</li>
      <li>Employment</li>
                    <li><strong>Photo</strong></li>
                     <li>Declarations</li>
                    </ol>
    
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
  <!--
<h2>Photo</h2>

   <p>In your photo you must:</p>
<ul> 

<li>be facing forwards and looking straight at the camera</li>
<li>have a plain expression and your mouth closed</li>
<li>have your eyes open and visible</li>
<li>not have hair in front of your eyes</li>
<li>not have a head covering (unless it’s for religious or medical reasons)</li>
<li>not have anything covering your face</li>
<li>not have any shadows on your face or behind you</li>
 <li>not have any filters applied (eg snapchat)</li>
 <li>not include friends, family, partnere, pets or other objects</li>
   </ul>
<p>Do not wear sunglasses or tinted glasses. You can wear other glasses if you need to, but your eyes must be visible without any glare or reflection.</p>

<a class="btn btn-primary" href="https://assets.publishing.service.gov.uk/government/uploads/system/uploads/attachment_data/file/303780/Photoguidance_v7.pdf" role="button" target="_blank">See example at gov.uk</a>
  <br /> <br />
      -->
<div class="container">
    <div class="row">        
    <div class="col-sm-12 col-md-6">
        <div class="panel panel-info">
            <h3>
                Upload Photo
            </h3>
             <p><strong>* You must upload a photo of yourself. You can take a picture using your phone as long as the photo is clear as shown in the image example below.</strong></p>
    <p>Up to 2 MB files accepted using format jpg, jpeg, png, gif only</p>
            <p>Please ensure the photo of yourself is upright.</p>
            <hr />
            <br />

            <div class=" form-group">
                <asp:Image runat="server" CssClass="img img-responsive" ImageUrl="~/_images/PhotoGuidance.JPG" />
               <asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.jpg,.jpeg,.gif" Width="100%" />
        </div>

    <asp:RegularExpressionValidator ID="RegExValFileUploadFileType" runat="server"
                        ControlToValidate="FileUpload1"
                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                        Font-Size="Medium"
                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
    </div>

            </div>
  </div>
    </div>

<cc1:CCCButton ID="btnBack" runat="server" Text="Back" ImageResource="btnBack"  />
<cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  CausesValidation="true" LinkResource="checkout_dataprotection_fc_aspx" />

