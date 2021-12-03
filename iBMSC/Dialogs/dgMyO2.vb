Public Class dgMyO2
    Structure Adj
        Public Measure As Integer
        Public ColumnIndex As Integer
        Public ColumnName As String
        Public Grid As String
        Public LongNote As Boolean
        Public Hidden As Boolean
        Public AdjTo64 As Boolean
        Public D64 As Integer
        Public D48 As Integer
    End Structure

    Private Aj(-1) As Adj

    Private Sub fMyO2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = MainWindow.Refer.Font
        vBPM.Value = MainWindow.Refer.THBPM.Value
    End Sub

    Private Sub AddAdjItem(ByVal xAj As Adj, ByVal Index As Integer)
        lResult.Rows.Add()
        Dim xRow As Integer = lResult.Rows.Count - 1
        lResult.Item(0, xRow).Value = Index
        lResult.Item(1, xRow).Value = xAj.Measure
        lResult.Item(2, xRow).Value = xAj.ColumnName
        lResult.Item(3, xRow).Value = xAj.Grid
        lResult.Item(4, xRow).Value = xAj.LongNote
        lResult.Item(5, xRow).Value = xAj.Hidden
        lResult.Item(6, xRow).Value = xAj.AdjTo64
        lResult.Item(7, xRow).Value = xAj.D64
        lResult.Item(8, xRow).Value = xAj.D48
    End Sub

    Private Sub bApply1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bApply1.Click
        MainWindow.Refer.MyO2ConstBPM(vBPM.Value * 10000)
    End Sub

    Private Sub bApply2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bApply2.Click
        Dim xStrItem() As String = MainWindow.Refer.MyO2GridCheck()
        ReDim Aj(UBound(xStrItem))

        lResult.Rows.Clear()
        For xI1 As Integer = 0 To UBound(Aj)
            Dim xW() As String = Split(xStrItem(xI1), "_")
            With Aj(xI1)
                .Measure = Val(xW(0))
                .ColumnIndex = Val(xW(1))
                .ColumnName = xW(2)
                .Grid = xW(3)
                .LongNote = Val(xW(4))
                .Hidden = Val(xW(5))
                .AdjTo64 = Val(xW(6))
                .D64 = Val(xW(7))
                .D48 = Val(xW(8))
            End With

            AddAdjItem(Aj(xI1), xI1)
        Next
    End Sub

    Private Sub bApply3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bApply3.Click
        MainWindow.Refer.MyO2GridAdjust(Aj)
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub lResult_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lResult.CellEndEdit
        If e.ColumnIndex <> 6 Then Return
        If e.RowIndex < 0 Then Return
        Aj(Val(lResult.Item(0, e.RowIndex).Value)).AdjTo64 = lResult.Item(6, e.RowIndex).Value
    End Sub
End Class
