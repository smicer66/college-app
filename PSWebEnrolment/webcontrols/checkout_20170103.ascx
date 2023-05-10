<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout.ascx.vb" Inherits="checkout"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="#" onclick="window.history.go(-2);return false;">Course Details</a></li>
                  <li class="active">Checkout</li>
                </ol>

    <h3>
        Your Courses</h3>
    <br><br>
    <asp:PlaceHolder runat="server" ID="BasketPlaceHolder">


    </asp:PlaceHolder>




        <p>Summary of Courses: <cc1:ShoppingBasketTotals ID="ShoppingBasket2" runat="server" /></p>
    <cc1:CCCButton ID="CCCButton1" runat="server" ImageURL="../_images/btnsearchagain.png"
        LinkURL="http://www.cityofbristol.ac.uk/courses/" Text="Search for more courses" />
 
    <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" 
        LinkURL="~/webenrolment.aspx?page=~/webcontrols/checkout_aspx" CausesValidation="True" 
        ImageURL="../_images/btncontinue.png" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
    


