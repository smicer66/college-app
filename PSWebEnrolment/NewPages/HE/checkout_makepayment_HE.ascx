<%@ control Language="VB"  AutoEventWireup="false" CodeFile="checkout_makepayment_HE.ascx.vb" Inherits="checkout_makepayment"  %>

<br /><br />
               

    &nbsp;
<cc1:PaymentSubmitter id="PaymentSubmitter1" runat="server" DisplayTextForNoCost="Thank you, processing your information..." MessageDisplayDelayTime="5000"></cc1:PaymentSubmitter>

<%--Enable this one for custom emails and/or overriding some of the methods such as GetCapitaV2Reference or GetFundCode--%>
<%--<cc2:CustomPaymentSubmitter id="PaymentSubmitter2" runat="server" DisplayTextForNoCost="Thank you, processing your information..." DisplayTextForWorldPayTransfer="Thank you, you are now being forwarded to WorldPay to complete this transaction..." MessageDisplayDelayTime="5000"></cc2:CustomPaymentSubmitter>--%>
    
    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%" ForeColor="Red">
    <p style="color:red">
        NOTE: Scripts do not appear to be allowed to run in your browser, this will most
        likely prevent submission to World Pay.</p>
    </asp:Panel>
    


