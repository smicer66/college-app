Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class checkout
    Inherits webenrolmentcontrolvalidate

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items

            If item.OfferingID <> -1 Then
                '  Response.Write("S")

                Dim tblOffering1 As New OfferingDataTable
                Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblOffering1)
                v.Columns.AddPKColumns()
                '   v.Columns.EnsureColumnsAreSelected(True, False, tblOffering1.WebSiteAvailabilityIDColumn, tblOffering1.CourseInformationIDColumn, tblOffering1.TotalFeeAmountColumn, tblOffering1.OfferingTypeIDColumn)
                v.Filters.SetColumnFilter(tblOffering1.OfferingIDColumn, item.OfferingID)
                tblOffering1.TableAdapter.Load(tblOffering1, v)

                With tblOffering1(0)

                    If tblOffering1.Count > 0 AndAlso tblOffering1(0).OfferingTypeID.HasValue Then
                        ' Response.Write("B")
                        Dim OfferingTypeSelect As String = .OfferingTypeID.Value.ToString

                        If OfferingTypeSelect.ToString.Length > 0 Then
                            '  Response.Write(tblOffering1(0).OfferingType)
                            '   WorkingData.EnrolmentRequestRow.StudentDetailUserDefined42 = OfferingTypeSelect

                            'ddlCourseType.SelectedValue = OfferingTypeSelect

                        End If

                    End If
                End With
            End If


        Next


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
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<div class=""list-group-item"">"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<h4 class=""list-group-item-heading"">"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl(item.Description & "</h4>"))

            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<p>" & item.ItemType & "</p>"))
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("<p>Cost:£" & item.Cost & "</p>"))
            Dim pnl As New Panel
            pnl.Visible = PaymentSubmitter.ShouldMakeNewApplicationForEachOffering


            pnl.Controls.Add(New LiteralControl("<p>Choice:"))
            Dim txt As New TextBox
            txt.ID = "txtChoice" & item.OfferingID & item.ItemType
            txt.Attributes.Add("data-offeringID", CStr(item.OfferingID))
            txt.Text = CStr(item.ChoiceNumber)
            txt.AutoPostBack = True
            txt.MaxLength = 1
            txt.Width = 20
            AddHandler txt.TextChanged, AddressOf txtChoice_TextChanged


            pnl.Controls.Add(txt)
            pnl.Controls.Add(New LiteralControl("</p>"))
            Me.BasketPlaceHolder.Controls.Add(pnl)
            Dim btn As New CCCButton
            btn.ID = "btnRemove" & item.OfferingID & item.ItemType
            btn.Attributes.Add("data-offeringID", CStr(item.OfferingID))
            btn.CommandName = "Delete"
            btn.Text = "Remove"
            AddHandler btn.Click, AddressOf btnRemove_Click
            Me.BasketPlaceHolder.Controls.Add(btn)
            Me.BasketPlaceHolder.Controls.Add(New LiteralControl("</div>"))
        Next
        Me.BasketPlaceHolder.Controls.Add(New LiteralControl("</div>"))
       

    End Sub


    Protected Sub btnRemove_Click(ByVal sender As Object, e As EventArgs)

        Dim btn As CCCButton = DirectCast(sender, CCCButton)

        Select Case btn.CommandName
            Case "Delete"
                'Remove from shopping cart
                With WorkingData.ShoppingCart
                    .Items.Remove(CInt(btn.Attributes("data-offeringID")))
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

        Dim OfferingID As Integer = CInt(txt.Attributes("data-offeringID"))
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




End Class
