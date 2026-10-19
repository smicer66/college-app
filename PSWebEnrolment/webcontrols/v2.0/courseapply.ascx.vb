Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class courseapply
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
        'Response.Write(OfferingID)
        If OfferingID <> -1 Then
            'Response.Write(Me.OfferingID)
            Dim tblOffering As New OfferingDataTable
            Dim vOffering As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblOffering)
            vOffering.Columns.AddDBColumns(False, False)
            vOffering.Filters.SetColumnFilter(tblOffering.OfferingIDColumn, Me.OfferingID)
            tblOffering.TableAdapter.Load(tblOffering, vOffering)
            Dim lblCourseDescription As New Label
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: " & tblOffering(0).GetRowDescription & "</h4>"))
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Description: " & tblOffering(0).AcademicYearID & "," & tblOffering(0).Code & "," & tblOffering(0).Name & "</h4>"))
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<br>"))
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<h4>Course Fees</h4>"))

            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<div Class='course-grid' id='courseGrid'><div class='course-row'><div class='course-description'><strong>" & tblOffering(0).GetRowDescription & "</strong><span>This course Is taught at College Green Site</span></div><div>"))
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("</div></div>"))
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("</div>"))


            Dim tbl As New OfferingFeeDataTable
            Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tbl)
            v.Columns.AddAllColumns(False, False)
            v.Columns.EnsureColumnIsSelected(True, False, tbl.FeeTypeColumn)
            Dim col As CCC_DataView_ColumnRow = v.Columns.EnsureColumnIsSelected(True, False, tbl.AmountColumn)
            'col.TextFieldFormat = "c" 'Currency
            v.Filters.SetColumnFilter(tbl.OfferingIDColumn, OfferingID)
            v.SortOrders.SetColumnSortOrder(SortDirection.Ascending, tbl.FeeTypeColumn, False)
            tbl.TableAdapter.Load(tbl, v)
            'Commented by Tina
            'BuildGrid(tbl)

            Dim totalFees As Decimal = 0
            Try
                totalFees = CDec(tbl.Compute("SUM(Amount)", ""))
            Catch ex As Exception
            End Try
            'Me.FeesPlaceHolder.Controls.Add(New LiteralControl("<strong>Total Fees for this Course: " & String.Format("{0:c}", totalFees) & "</strong>"))

            Dim SQLDBDataReader As SqlClient.SqlDataReader
            Dim SQLDataTable As New DataTable
            Dim cmd As New SqlCommand
            Dim SQLCmd As New SqlClient.SqlConnection
            SQLCmd.ConnectionString = GetConn()
            SQLCmd.Open()
            cmd.CommandTimeout = "120"
            cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetailsV2"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = SQLCmd
            cmd.Parameters.AddWithValue("offeringid", OfferingID)
            SQLDBDataReader = cmd.ExecuteReader()
            If SQLDBDataReader.HasRows Then
                While (SQLDBDataReader.Read)
                    If CStr(SQLDBDataReader("name")).IndexOf("CELTA") > -1 Then
                        'divCelta.Visible = True
                        '  olAccessHE.Visible = True
                    End If
                    If CStr(SQLDBDataReader("name")).IndexOf("Access to HE") > -1 Then
                        'divStatement.Visible = True
                    End If
                    If CStr(SQLDBDataReader("code")).IndexOf("ATSUPINTER") > -1 _
                        Or CStr(SQLDBDataReader("code")).IndexOf("LBF1778B00-1") > -1 _
                        Or CStr(SQLDBDataReader("code")).IndexOf("LGF1081A00-1") > -1 _
                        Or CStr(SQLDBDataReader("code")).IndexOf("LPF1081A00-1") > -1 _
                        Or CStr(SQLDBDataReader("code")).IndexOf("ATSUPINTER") > -1 _
                        Or CStr(SQLDBDataReader("code")).IndexOf("LTF1081A00-1") > -1 Then
                        'divSuppIntern.Visible = True
                    End If

                    Dim formattedEndDate As String = ""
                    EndDateSpan.InnerText = Convert.ToString(SQLDBDataReader("formatedEndDate"))
                    AcademicYearSpan.InnerText = CStr(SQLDBDataReader("AcademicYearID"))
                    StartDateSpan.InnerText = Convert.ToString(SQLDBDataReader("formatedStartDate"))

                    DeliverySiteSpan.InnerText = CStr(SQLDBDataReader("DeliverySite"))
                    ModeOfAttendanceSpan.InnerText = CStr(SQLDBDataReader("AttendanceMode"))
                    LearningAimSpan.InnerText = Convert.ToString(SQLDBDataReader("LearningAimTitle"))
                    AwardingBodySpan.InnerText = Convert.ToString(SQLDBDataReader("LearningAimAwardingBody"))
                    CourseCodeSpan.InnerText = "Course code: " & CStr(SQLDBDataReader("code"))
                    CourseTitleSpan.InnerText = CStr(SQLDBDataReader("Name"))
                    If LearningAimSpan.InnerText.ToString.Length.Equals(0) Then
                        LearningAimSpan.InnerText = "Not Available"
                    End If
                    If AwardingBodySpan.InnerText.ToString.Length.Equals(0) Then
                        AwardingBodySpan.InnerText = "Not Available"
                    End If
                    If StartDateSpan.InnerText.ToString.Length.Equals(0) Then
                        StartDateSpan.InnerText = "Not Specified"
                    End If
                    If EndDateSpan.InnerText.ToString.Length.Equals(0) Then
                        EndDateSpan.InnerText = "Not Specified"
                    End If
                End While
            End If
            SQLCmd.Close()
            SQLDBDataReader.Close()
            'Response.Write(WorkingData.ShoppingCart.Items.Count)
            'Response.Redirect(GetResourceValue("applicationguidance_aspx"))
            'Context.ApplicationInstance.CompleteRequest()
        End If

    End Sub



End Class