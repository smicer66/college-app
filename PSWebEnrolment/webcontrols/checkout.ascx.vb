

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class checkout
    Inherits webenrolmentcontrolvalidate

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)


        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            divPay.Visible = True
        Else
            divPay.Visible = False
        End If

        If Not IsPostBack Then
            Dim i As Byte = 1
            For Each c As ShoppingCartItem In WorkingData.ShoppingCart.Items
                c.ChoiceNumber = i
                i = CByte(i + 1)
            Next
        End If

        BuildHTML()

        If WorkingData.ShoppingCart.Items.Count = 0 Then
            btnContinue.Enabled = False
            btnContinue.Text = "Home (No courses selected)"
            btnContinue.LinkURL = GetResourceValue("search_aspx")
        End If
        'Added by Tina
        If WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") And WorkingData.ShoppingCart.Items.Count = 1 Then
            selectUrl()
        End If
        '
    End Sub

    Private Sub BuildHTML()

        '  <a href="#" class="list-group-item active">
        '    <h4 class="list-group-item-heading">List group item heading</h4>
        '    <p class="list-group-item-text">...</p>
        '  </a>
        '</div>
        Me.BasketPlaceHolder.Controls.Clear()

        Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<div class=""list-group"">"))
        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items

            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<a class=""list-group-item"">"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<h4 class=""list-group-item-heading"">"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl(item.Description & "</h4>"))

            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<p>" & item.ItemType & "</p>"))
            If (item.ItemType.Equals("Enrolment")) Then
                Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<p>Cost:£" & item.Cost & "</p>"))
            End If
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<asp:Panel ID=""PanelChoice"" runat=""server"" Visible='<%# PaymentSubmitter.ShouldMakeNewApplicationForEachOffering  %>'>"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<p>Choice:"))
            Dim txt As New TextBox
            txt.ID = "txtChoice" & item.OfferingID & item.ItemType
            txt.Attributes.Add("OfferingID", CStr(item.OfferingID))
            txt.Text = CStr(item.ChoiceNumber)
            txt.AutoPostBack = True
            txt.MaxLength = 1
            txt.Width = 20
            AddHandler txt.TextChanged, AddressOf txtChoice_TextChanged
            txt.Attributes.Add("runat", "server")

            Me.BasketPlaceHolder.Controls.Add(txt)
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("</p>"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("</asp:Panel>"))
            Dim btn As New CCCButton
            btn.ID = "btnRemove" & item.OfferingID & item.ItemType
            btn.Attributes.Add("runat", "server")
            btn.Attributes.Add("OfferingID", CStr(item.OfferingID))
            btn.CommandName = "Delete"
            btn.Text = "Remove"
            AddHandler btn.Click, AddressOf btnRemove_Click
            Me.BasketPlaceHolder.Controls.Add(btn)
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("</a>"))
        Next
        Me.BasketPlaceHolder.Controls.Add(New LiteralControl("</div>"))
       
    End Sub


    Protected Sub btnRemove_Click(ByVal sender As Object, e As EventArgs)

        Dim btn As CCCButton = DirectCast(sender, CCCButton)

        Select Case btn.CommandName
            Case "Delete"
                'Remove from shopping cart
                With WorkingData.ShoppingCart
                    .Items.Remove(CInt(btn.Attributes("OfferingID")))
                End With

                'Recalculate Choices
                Dim i As Byte = 1
                For Each c As ShoppingCartItem In WorkingData.ShoppingCart.Items
                    c.ChoiceNumber = i
                    i = CByte(i + 1)
                Next

                'Render changes
                BuildHTML()


        End Select
    End Sub

    Protected Sub txtChoice_TextChanged(sender As Object, e As EventArgs)
        Dim txt As TextBox = TryCast(sender, TextBox)
        Dim NewChoice As Byte = 1
        Try
            NewChoice = CByte(txt.Text)
        Catch ex As Exception
        End Try
        'Find item

        Dim OfferingID As Integer = CInt(txt.Attributes("OfferingID"))
        For Each Item As ShoppingCartItem In WorkingData.ShoppingCart.Items
            If Item.OfferingID = OfferingID Then
                Item.ChoiceNumber = NewChoice
            End If
        Next
    End Sub

    Public Overrides Sub ValidateControl()
        If WorkingData.ShoppingCart Is Nothing OrElse WorkingData.ShoppingCart.Items.Count = 0 Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "You must have at least 1 course in your basket."
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

    End Sub

    Protected Sub img_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnContinue.Click
        Dim redirectString As String = String.Empty
        Dim redirectStringFC As String = String.Empty
        Me.ValidateControl()


        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
            Response.Write(WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment"))
            If item.OfferingID > 0 Then

                Dim SQLDBDataReader As SqlClient.SqlDataReader
                Dim SQLDataTable As New DataTable
                Dim cmd As New SqlCommand
                Dim SQLCmd As New SqlClient.SqlConnection
                SQLCmd.ConnectionString = GetConn()
                SQLCmd.Open()
                cmd.CommandTimeout = "120"
                cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = SQLCmd
                cmd.Parameters.AddWithValue("offeringid", item.OfferingID)
                SQLDBDataReader = cmd.ExecuteReader()
                If SQLDBDataReader.HasRows Then
                    While (SQLDBDataReader.Read)
                        'for adult english and maths
                        If CStr(SQLDBDataReader("fundingid")).IndexOf("99") > -1 Then
                            '  Response.Write("AAA")
                            If Not IsDBNull(SQLDBDataReader("recruitmentmethod")) Then
                                If CStr(SQLDBDataReader("recruitmentmethod")).IndexOf("Direct Enrol") > -1 Then

                                    '  Response.Write("BBB")

                                    ' redirectStringFC = GetResourceValue("checkout_enrolments_FC_aspx")
                                End If
                            End If

                        End If


                    End While
                End If
                SQLCmd.Close()
                SQLDBDataReader.Close()
            End If
        Next

        If Me.Page.IsValid Then


            If _
                WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") And
                WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                redirectString = GetResourceValue("checkout_enrolments_aspx")
                'NOTE: All fields required by applications are also captured by enrolments
            ElseIf _
                WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") And
                WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then

                redirectString = GetResourceValue("checkout_enrolments_aspx")
            ElseIf _
                WorkingData.ShoppingCart.ContainsItemsOfType("Application") And
                WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then

                redirectString = GetResourceValue("checkout_applications_aspx")
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                redirectString = GetResourceValue("checkout_enrolments_aspx")
                'redirectString = GetResourceValue("checkout_enrolments_FC_aspx")
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                redirectString = GetResourceValue("checkout_applications_aspx")
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
                redirectString = GetResourceValue("checkout_enquiries_aspx")
            Else

                redirectString = GetResourceValue("search_aspx")
            End If

            'Response.Redirect(redirectStringFC)

            If redirectStringFC = "" Then

                Response.Redirect(redirectString)
            Else

                Response.Redirect(redirectStringFC)
            End If

        End If

    End Sub
    ''' <summary>
    ''' Added by Tina to redirect avoiding basket click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub selectUrl()
        Dim redirectString As String = String.Empty
        Me.ValidateControl()
        Page.Validate()
        If Me.Page.IsValid Then
            If _
                WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") And _
                WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                redirectString = GetResourceValue("checkout_enrolments_aspx")
                'NOTE: All fields required by applications are also captured by enrolments
            ElseIf _
                WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") And _
                WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then

                redirectString = GetResourceValue("checkout_enrolments_aspx")
            ElseIf _
                WorkingData.ShoppingCart.ContainsItemsOfType("Application") And _
                WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then

                redirectString = GetResourceValue("checkout_applications_aspx")
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                redirectString = GetResourceValue("checkout_enrolments_aspx")
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                redirectString = GetResourceValue("checkout_applications_aspx")
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
                redirectString = GetResourceValue("checkout_enquiries_aspx")
            Else

                redirectString = GetResourceValue("search_aspx")
            End If


            Response.Redirect(redirectString)

        End If
    End Sub


    
End Class
