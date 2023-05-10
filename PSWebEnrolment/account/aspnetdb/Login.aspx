<%@ Page Language="VB"  MasterPageFile="~/UserControlMasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">

    
<br /><br />
<ol class="breadcrumb">
    <li><a href="/default.aspx">Home</a></li>
    <li class="active">Login</li>
</ol>

 <script src="js/jquery.js"></script> 
    <link href="_css/bootstrap.min.css" rel="stylesheet" />
    <link href="_css/custom.css" rel="stylesheet" />


 <script src="/js/jquery-1.10.2.js"></script>


<br /><br />

    
<div class="panel panel-info">
    <div class="panel-heading">Login Page</div>
        <div class="container">         
            
             
    <div class="form-group">
        <asp:Login ID="Login1" runat="server"
            DestinationPageUrl="~/webenrolment.aspx?page=~/webcontrols/search.ascx" LoginButtonStyle-CssClass="btn btn-primary btn-block" TextBoxStyle-CssClass="form-control" LabelStyle-CssClass="label2 textfieldlabelrequired">

        </asp:Login>

    </div>
        <p><a href="RecoverPassword.aspx">I've forgotten my password</a></p>
        </div></div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ValidationGroup="Login1" />


<style>
    .label2 {display:inline-block;width:200px;}
</style> 


</asp:Content>