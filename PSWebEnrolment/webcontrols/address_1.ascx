<%@ Control Language="VB"  AutoEventWireup="false" CodeFile="address_1.ascx.vb" Inherits="address_1"  %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

    <script type="text/javascript">
			/* Set the focus to the first input line */
			function init()
			{
				document.FlatPrompt.<%= com.qas.prowebintegration.Constants.FIELD_INPUT_LINES %>[0].focus();
			}
			
			/* Ensure at least one address line has been entered */
			function validate()
			{
				var aUserInput = document.FlatPrompt.<%= com.qas.prowebintegration.Constants.FIELD_INPUT_LINES %>;
				for (var i=0; i < aUserInput.length; i++)
				{
					if (aUserInput[i].value != "")
					{
						return true;
					}
				}
				document.FlatPrompt.<%= com.qas.prowebintegration.Constants.FIELD_INPUT_LINES %>[0].focus();
				alert("Please enter some address details.");
				return false;
			}
		</script>
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
    <table class="nomargin">
        <tr>
            <th class="banner" >
               <%-- <h2>
                    Enter Your Address (<cc1:CurrentAddressTypeText ID="CurrentAddressTypeText1" runat="server" />)
                </h2>--%>
                  <h1>Enter your address </h1>
                <p>
                    Please enter your house number and post code below (Then click continue to search
                    for your full address)</p></th><br />
                    <table>
                        <%
							dim asInputLines as string()
							asInputLines = GetInputLines()
							
							dim i as integer
							for i=0 to m_atPromptLines.Length-1

								dim sValue as string = ""
								if i < asInputLines.Length then
									sValue = asInputLines(i)
								end if%>
                        <tr>
                            <td>
                                <%= m_atPromptLines(i).Prompt %>
                            </td>
                            <td>
                            </td>
                            <td>
                                <input name="<%= com.qas.prowebintegration.Constants.FIELD_INPUT_LINES %>" size="<%= m_atPromptLines(i).SuggestedInputLength %>"
                                    type="text" value="<%= sValue %>" />
                                &nbsp; <i>(e.g.<%= m_atPromptLines(i).Example %>)</i>
                            </td>
                        </tr>
                        <%
							next i%>
                        <tr>
                            <td colspan="3">
                                <p>
                                    <asp:LinkButton ID="HyperlinkAlternate" runat="server" EnableViewState="False" Font-Size="X-Small">If you do not know the postal/ZIP code then click here.</asp:LinkButton>&nbsp;</p>
                            </td>
                        </tr>
                    </table>
                    <%
                        RenderRequestString(com.qas.prowebintegration.Constants.FIELD_DATA_ID)
                        RenderHiddenField(com.qas.prowebintegration.Constants.FIELD_COUNTRY_NAME, "United Kingdom")
                        %>
                   
        </tr>
        <tr>
            <td class="nomargin" >
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
            </td>
        </tr>
    </table>
    
 <input id="HiddenPromptSet" runat="server" name="HiddenPromptSet" type="hidden" />
                    <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" CausesValidation="false" />
                    <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" />
        <script type="text/javascript">
           init();
        </script>



