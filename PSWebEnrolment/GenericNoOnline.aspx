<%@ Page Language="vb" AutoEventWireup="false" Inherits="GenericError" CodeFile="GenericNoOnline.aspx.vb" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Web Enrolments - Application Error </title>
    <link href="content/bootstrap.min.css" rel="stylesheet" />
    <%--<script src="js/holder.js"></script>--%>
</head>
<body style="padding:20px">
    <form id="Form1" method="post" runat="server">
    <div>
        
        <div class="text-left" style="margin: 10px">
                        <img class="img-responsive errorLogo" src="_images/logo.png" alt="College Logo" width="400" height="400"/><br/>
             <svg width="10em" height="10em" viewBox="0 0 16 16" class="bi bi-emoji-frown" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
  <path fill-rule="evenodd" d="M8 15A7 7 0 1 0 8 1a7 7 0 0 0 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
  <path fill-rule="evenodd" d="M4.285 12.433a.5.5 0 0 0 .683-.183A3.498 3.498 0 0 1 8 10.5c1.295 0 2.426.703 3.032 1.75a.5.5 0 0 0 .866-.5A4.498 4.498 0 0 0 8 9.5a4.5 4.5 0 0 0-3.898 2.25.5.5 0 0 0 .183.683z"/>
  <path d="M7 6.5C7 7.328 6.552 8 6 8s-1-.672-1-1.5S5.448 5 6 5s1 .672 1 1.5zm4 0c0 .828-.448 1.5-1 1.5s-1-.672-1-1.5S9.448 5 10 5s1 .672 1 1.5z"/>
</svg>
                        <h3>
                Oh dear, it looks like your course was not found for online enrolment.</h3>
   <p>But dont worry, please contact the College admissions team at <a href="mailto:Admissions.Team@cityofbristol.ac.uk">Admissions.Team@cityofbristol.ac.uk</a> and will help you.</p>


        </div>
        <br />
        <br />
                
      <!--  <a class="btn btn-danger" href="javascript:history.back()" title="Return to previous page">Return to previous page</a> -->
    </div>
    </form>
</body>
</html>
