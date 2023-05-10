Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class courseenquire
    Inherits webenrolmentcontrolvalidate

    Public ReadOnly Property OfferingID() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("OfferingID")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("OfferingID"))
            End If
        End Get
    End Property


    Protected Overrides Sub OnLoad(e As EventArgs)

        MyBase.OnLoad(e)

        If OfferingID <> -1 Then
            'Added by Tina
            WorkingData.ShoppingCart.Items.Clear()
            '
            Dim tblOffering As New OfferingDataTable
	    Dim vOffering as CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblOffering)
	    vOffering.Columns.AddDBColumns(False, False)
	    vOffering.Filters.SetColumnFilter(tblOffering.OfferingIDColumn, Me.OfferingID)
            tblOffering.TableAdapter.Load(tblOffering, vOffering)
            Dim lblCourseDescription As New Label
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: " & tblOffering(0).GetRowDescription & "</h4>"))

            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Fees</h4>"))


            Dim tbl As New OfferingFeeDataTable
            Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tbl)
            v.Columns.AddAllColumns(False, False)
            v.Columns.EnsureColumnIsSelected(True, False, tbl.FeeTypeColumn)
            Dim col As CCC_DataView_ColumnRow = v.Columns.EnsureColumnIsSelected(True, False, tbl.AmountColumn)
            'col.TextFieldFormat = "c" 'Currency
            v.Filters.SetColumnFilter(tbl.OfferingIDColumn, OfferingID)
            v.SortOrders.SetColumnSortOrder(SortDirection.Ascending, tbl.FeeTypeColumn, False)
            tbl.TableAdapter.Load(tbl, v)

            BuildGrid(tbl)

            Dim totalFees As Decimal = 0
            Try
                totalFees = CDec(tbl.Compute("SUM(Amount)", ""))
            Catch ex As Exception
            End Try
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<strong>Total Fees for this Course: " & String.Format("{0:c}", totalFees) & "</strong>"))

        Else
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: ???</h4>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Fees</h4>"))
            Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
        End If
        'Added by Tina
        Response.Redirect(GetResourceValue("checkout_aspx"), False)
        '
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
