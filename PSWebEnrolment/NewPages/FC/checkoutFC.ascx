<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkoutFC.ascx.vb" Inherits="checkout"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb">
                   <li><a href="#" onclick="window.history.go(-2);return false;">Course Details</a></li>
                  <li class="active">Checkout</li>
                </ol>

    <h3>
        Your Courses</h3>
    <br><br>
    <asp:PlaceHolder runat="server" ID="BasketPlaceHolder">


    </asp:PlaceHolder>



    
        <p>Summary of Courses: <span class="glyphicon glyphicon-shopping-cart" style="color:#7A7A7A" ></span><cc1:ShoppingBasketTotals CssClass="shoppingbasket" ID="ShoppingBasket2" runat="server" HideIcon="true"  /></p>
   
  <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue to Checkout" ImageResource="btnContinue" LinkResource="checkout_enrolments_FC_aspx" CausesValidation="true" />

    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
    


