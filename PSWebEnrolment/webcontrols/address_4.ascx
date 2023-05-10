<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="address_4.ascx.vb" Inherits="address_4"  %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

           <br /><br />
                <ol class="breadcrumb" runat="server" id="breadcrumbapps">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications.ascx">Personal Details</a></li>
                  <li class="active">Address</li>
                </ol>
                <ol class="breadcrumb" runat="server" id="breadcrumbenrols">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                  <li class="active">Address</li>
                </ol>
  <asp:Panel ID="panelMain" runat="server" Width="100%">
    <h1>
        Confirm Your Address <%--(<cc1:currentaddresstypetext id="CurrentAddressTypeText1" runat="server"></cc1:currentaddresstypetext>
        )--%>
    </h1>
   </asp:Panel> 
    <asp:Panel ID="panelTerm" runat="server" Width="100%">
    <h1>
        Confirm Your Address (<cc1:currentaddresstypetext id="CurrentAddressTypeText1" runat="server"></cc1:currentaddresstypetext>
        )
    </h1>
   </asp:Panel> 
    <p>
        <asp:Literal ID="LiteralMessage" runat="server" EnableViewState="False"></asp:Literal>
        &nbsp;</p>
    <table>
        <%
							dim i as integer
							for  i = 0 to m_asAddressLines.Length-1 %>
        <tr>
            <td>
                <P><%= m_asAddressLabels(i) %></P>
            </td>
            <td width="10">
            </td>
            <td>
                <input name="<%= com.qas.prowebintegration.Constants.FIELD_ADDRESS_LINES %>" size="50"
                    type="text" value="<%= HttpUtility.HtmlEncode(m_asAddressLines(i)) %>" />
            </td>
        </tr>
        <%
							next%>
       <%-- <tr>
            <td>
                <p>
                    Country</p>
            </td>
            <td width="10">
            </td>
            <td>
                <input class="readonly" name="<%= com.qas.prowebintegration.Constants.FIELD_COUNTRY_NAME %>"
                    readonly="readonly" size="50" tabindex="-1" type="text" value="<%= GetCountryName() %>" />
            </td>
        </tr>--%>
        <%
							If Not GetRoute().Equals(com.qas.prowebintegration.Constants.Routes.Okay) Then
        %>
        <tr>
            <td>
                &nbsp;</td>
            <td width="10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="debug">
            <td colspan="3">
                <!--
                <p class="debug">
                    Integrator information: search result was
                    <%= GetRoute().ToString() %>
                    <% If Not GetErrorInfo() Is Nothing Then
											Response.Write("<br />&nbsp;" + GetErrorInfo())
										End If
                    %>
                </p>
                -->
              
            </td>
        </tr>
        <%
							End If%>
    </table>
    
        <asp:Panel ID="pnlTermTimeAddress" runat="server" Width="100%">
        <p> Do you have a different term-time address:
        <asp:RadioButtonList ID="optAnotherAddress" runat="server" ToolTip="Do you have a different term-time address:">
            <asp:ListItem Selected Value="0">My term-time Address is the same as the main 
            address</asp:ListItem>
            <asp:ListItem Value="1">I have a different term-time Address</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="optAnotherAddress"
            ErrorMessage="Please state whether you have a different term-time address or not" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></p>
                    </asp:Panel>

    <%
						' carry through values from earlier pages
						RenderRequestString(com.qas.prowebintegration.Constants.FIELD_DATA_ID)
						RenderRequestArray(com.qas.prowebintegration.Constants.FIELD_INPUT_LINES)
						RenderRequestString(FIELD_PROMPTSET)
						RenderRequestString(FIELD_PICKLIST_MONIKER)
						RenderRequestString(FIELD_REFINE_MONIKER)
						RenderRequestString(com.qas.prowebintegration.Constants.FIELD_MONIKER)
						RenderHiddenField(com.qas.prowebintegration.Constants.FIELD_ROUTE, GetRoute().ToString())
    %>
    <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
    


