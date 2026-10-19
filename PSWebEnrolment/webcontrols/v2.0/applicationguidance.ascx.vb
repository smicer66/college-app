Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class applicationguidance
    Inherits webenrolmentcontrolvalidate

    'Public ReadOnly Property OfferingID() As Integer
    '    Get
    '        If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("OfferingID")) Then
    '            Return -1
    '        Else
    '            Return CInt(Me.Page.Request("OfferingID"))
    '        End If
    '    End Get
    'End Property


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        'If OfferingID <> -1 Then
        '    'Response.Write(Me.OfferingID)
        '    Dim tblOffering As New OfferingDataTable
        '    Dim vOffering As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblOffering)
        '    vOffering.Columns.AddDBColumns(False, False)
        '    vOffering.Filters.SetColumnFilter(tblOffering.OfferingIDColumn, Me.OfferingID)
        '    tblOffering.TableAdapter.Load(tblOffering, vOffering)
        '    Dim lblCourseDescription As New Label
        '    'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
        '    'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: " & tblOffering(0).GetRowDescription & "</h4>"))
        '    'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: " & tblOffering(0).AcademicYearID & "," & tblOffering(0).Code & "," & tblOffering(0).Name & "</h4>"))
        '    'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
        '    'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Fees</h4>"))


        '    Dim tbl As New OfferingFeeDataTable
        '    Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tbl)
        '    v.Columns.AddAllColumns(False, False)
        '    v.Columns.EnsureColumnIsSelected(True, False, tbl.FeeTypeColumn)
        '    Dim col As CCC_DataView_ColumnRow = v.Columns.EnsureColumnIsSelected(True, False, tbl.AmountColumn)
        '    'col.TextFieldFormat = "c" 'Currency
        '    v.Filters.SetColumnFilter(tbl.OfferingIDColumn, OfferingID)
        '    v.SortOrders.SetColumnSortOrder(SortDirection.Ascending, tbl.FeeTypeColumn, False)
        '    tbl.TableAdapter.Load(tbl, v)
        '    'Commented by Tina
        '    'BuildGrid(tbl)

        '    Dim totalFees As Decimal = 0
        '    Try
        '        totalFees = CDec(tbl.Compute("SUM(Amount)", ""))
        '    Catch ex As Exception
        '    End Try
        '    'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<strong>Total Fees for this Course: " & String.Format("{0:c}", totalFees) & "</strong>"))

        '    Dim SQLDBDataReader As SqlClient.SqlDataReader
        '    Dim SQLDataTable As New DataTable
        '    Dim cmd As New SqlCommand
        '    Dim SQLCmd As New SqlClient.SqlConnection
        '    SQLCmd.ConnectionString = GetConn()
        '    SQLCmd.Open()
        '    cmd.CommandTimeout = "120"
        '    cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.Connection = SQLCmd
        '    cmd.Parameters.AddWithValue("offeringid", OfferingID)
        '    SQLDBDataReader = cmd.ExecuteReader()
        '    If SQLDBDataReader.HasRows Then
        '        While (SQLDBDataReader.Read)
        '            If CStr(SQLDBDataReader("name")).IndexOf("CELTA") > -1 Then
        '                divCelta.Visible = True
        '                '  olAccessHE.Visible = True
        '            End If
        '            If CStr(SQLDBDataReader("name")).IndexOf("Access to HE") > -1 Then
        '                divStatement.Visible = True
        '            End If
        '            If CStr(SQLDBDataReader("code")).IndexOf("ATSUPINTER") > -1 _
        '                Or CStr(SQLDBDataReader("code")).IndexOf("LBF1778B00-1") > -1 _
        '                Or CStr(SQLDBDataReader("code")).IndexOf("LGF1081A00-1") > -1 _
        '                Or CStr(SQLDBDataReader("code")).IndexOf("LPF1081A00-1") > -1 _
        '                Or CStr(SQLDBDataReader("code")).IndexOf("ATSUPINTER") > -1 _
        '                Or CStr(SQLDBDataReader("code")).IndexOf("LTF1081A00-1") > -1 Then
        '                divSuppIntern.Visible = True
        '            End If
        '        End While
        '    End If
        '    SQLCmd.Close()
        '    SQLDBDataReader.Close()
        'Else
        '    Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: ???</h4>"))
        '    Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
        '    Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Fees</h4>"))
        '    Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
        'End If
        'If OfferingID <> -1 Then
        BuildHTML()
        'End If

    End Sub


    Private Sub BuildHTML()

        '  <a href="#" class="list-group-item active">
        '    <h4 class="list-group-item-heading">List group item heading</h4>
        '    <p class="list-group-item-text">...</p>
        '  </a>
        '</div>
        'Response.Write(Me.Page.Request("OfferingID"))
        Me.FeesPlaceHolder.Controls.Clear()

        If WorkingData.ShoppingCart.Items.Count = 0 Then
            Dim siteInfo As String = "<div>If you would like to select a course, please click the <strong>search</strong> link below, find another course and apply.<br>" & "<a class="" link-underline"" href=""http://www.cityofbristol.ac.uk/courses/"">Search for a course</a></div>"
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl(siteInfo))
            AdviceOnApplication.Visible = False
            existingCourseIntro.Visible = False
            emptyCourseIntro.Visible = True
            footerBtns.Visible = False
            infoForHowToApply.Visible = True
            infoForApplication.Visible = False
        End If

        If Not IsPostBack Then
            Dim i As Byte = 1
            For Each c As ShoppingCartItem In WorkingData.ShoppingCart.Items
                c.ChoiceNumber = i
                i = CByte(i + 1)
            Next
        End If

        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
            AdviceOnApplication.Visible = True
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<div class=""course-grid"" id=""courseGrid"">"))
            existingCourseIntro.Visible = True
            emptyCourseIntro.Visible = False
            footerBtns.Visible = True
            infoForApplication.Visible = False
            infoForHowToApply.Visible = True

            Dim siteInfo As String = ""
            If item.Description.Substring(1, 1) = "A" Then
                siteInfo = "This course is taught at Ashley Down Site"
            ElseIf item.Description.Substring(1, 1) = "C" Then
                siteInfo = "This course is taught at College Green Site"
            ElseIf item.Description.Substring(1, 1) = "S" Then
                siteInfo = "This course is taught at SBSA Site"
            ElseIf item.Description.Substring(1, 1) = "C" Then
                siteInfo = "This course is taught at Parkway/Advanced Engineering Centre Site"
            ElseIf item.Description.Substring(1, 1) = "C" Then
                siteInfo = "This course is taught Offsite"
            ElseIf item.Description.Substring(1, 1) = "C" Then
                siteInfo = "This course is taught at Romney Avenue / The Galleries / Gloucester Sites"
            Else
                siteInfo = ""
            End If

            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<div class=""course-row"">"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<div class=""course-description"">"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<strong>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl(item.Description & "</strong>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<span>" + siteInfo + "</span>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("</div>"))


            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<div class=""choice-column"">"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<label for=""choice1"">Choice</label>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<asp:Panel ID=""PanelChoice"" runat=""server"" Visible='<%# PaymentSubmitter.ShouldMakeNewApplicationForEachOffering  %>'>"))
            Dim txt As New TextBox
            txt.ID = "txtChoice" & item.OfferingID & item.ItemType
            txt.Attributes.Add("OfferingID", CStr(item.OfferingID))
            txt.Text = CStr(item.ChoiceNumber)
            txt.AutoPostBack = True
            txt.MaxLength = 1
            txt.CssClass = "choice-input"

            AddHandler txt.TextChanged, AddressOf txtChoice_TextChanged
            txt.Attributes.Add("runat", "server")
            Me.FeesPlaceHolder.Controls.Add(txt)
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("</asp:Panel>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("</div>"))



            Dim btnUpdate As New CCCButton
            btnUpdate.ID = "btnUpdate" & item.OfferingID & item.ItemType
            btnUpdate.Attributes.Add("runat", "server")
            btnUpdate.Attributes.Add("OfferingID", CStr(item.OfferingID))
            btnUpdate.CommandName = "Update"
            btnUpdate.Text = "Update"
            AddHandler btnUpdate.Click, AddressOf btnUpdate_Click


            Dim dvUpdate As New Panel
            dvUpdate.Controls.Add(btnUpdate)

            Me.FeesPlaceHolder.Controls.Add(dvUpdate)


            Dim btnRemove As New CCCButton
            btnRemove.ID = "btnRemove" & item.OfferingID & item.ItemType
            btnRemove.Attributes.Add("runat", "server")
            btnRemove.Attributes.Add("OfferingID", CStr(item.OfferingID))
            btnRemove.CommandName = "Delete"
            btnRemove.Text = "Remove"
            AddHandler btnRemove.Click, AddressOf btnRemove_Click


            Dim dvRemove As New Panel
            dvRemove.Controls.Add(btnRemove)

            Me.FeesPlaceHolder.Controls.Add(dvRemove)
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("</div>"))


        Next

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


    Protected Sub btnUpdate_Click(ByVal sender As Object, e As EventArgs)

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


    Private Sub BuildGrid(ByVal tbl As OfferingFeeDataTable)
        Dim pnl As New Panel
        pnl.ID = "Panel1"
        Me.FeesPlaceHolder.Controls.Add(pnl)
        With pnl.Controls

            .Add(New LiteralControl("<table ID=""FeeGrid"" class=""table table-striped table-bordered"">")) 'Table Start
            .Add(New LiteralControl("<tr ID=""FeeGridHeaderRow"">")) 'Row Start
            .Add(New LiteralControl("<td ID=""FeeGridFeeTypeCell"">")) 'Cell Start
            .Add(New LiteralControl("<p>Fee Type&nbsp;</p>"))
            .Add(New LiteralControl("</td>")) 'Cell End

            .Add(New LiteralControl("<td ID=""FeeGridAmountCell"">")) 'Cell Start
            .Add(New LiteralControl("<p>Amount&nbsp;</p>"))
            .Add(New LiteralControl("</td>")) 'Cell End
            .Add(New LiteralControl("</tr>")) 'Row End

            For Each row As OfferingFeeRow In tbl.Rows

                .Add(New LiteralControl("<tr ID=""FeeGridRow"">")) 'Row Start
                .Add(New LiteralControl("<td ID=""FeeGridFeeTypeCell"">")) 'Cell Start
                .Add(New LiteralControl("<p>" & row.FeeType.ToString & "&nbsp;</p>"))
                .Add(New LiteralControl("</td>")) 'Cell End

                .Add(New LiteralControl("<td ID=""FeeGridAmountCell"">")) 'Cell Start
                .Add(New LiteralControl("<p>" & row.Amount.ToString & "&nbsp;</p>"))
                .Add(New LiteralControl("</td>")) 'Cell End
                .Add(New LiteralControl("</tr>")) 'Row End

            Next


            .Add(New LiteralControl("</table>")) 'Table End


        End With


    End Sub
End Class