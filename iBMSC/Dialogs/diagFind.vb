

Public Class diagFind
    ReadOnly bCol As Integer = 47
    ReadOnly msg1 As String = "Error"
    ReadOnly msg2 As String = "Invalid label."

    Public Sub New(xbCol As Integer, xmsg1 As String, xmsg2 As String)
        InitializeComponent()
        bCol = xbCol
        msg1 = xmsg1
        msg2 = xmsg2
    End Sub

    Private Sub CloseDialog(sender As Object, e As EventArgs) Handles TBClose.Click
        Me.Close()
    End Sub

    Private Sub BSAll_Click(sender As Object, e As EventArgs) Handles BSAll.Click
        For Each xCB As CheckBox In Panel1.Controls
            xCB.Checked = True
        Next
    End Sub

    Private Sub BSInv_Click(sender As Object, e As EventArgs) Handles BSInv.Click
        For Each xCB As CheckBox In Panel1.Controls
            xCB.Checked = Not xCB.Checked
        Next
    End Sub

    Private Sub BSNone_Click(sender As Object, e As EventArgs) Handles BSNone.Click
        For Each xCB As CheckBox In Panel1.Controls
            xCB.Checked = False
        Next
    End Sub

    Private Sub diagFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = MainWindow.Font
        Dim xBold As New Font(Me.Font, FontStyle.Bold)

        TBSelect.Font = xBold
        Label8.Font = xBold
        Label9.Font = xBold

        'Dim xS() As String = Form1.lpfdr
        Me.Text = MainWindow.TBFind.Text

        Label1.Text = Strings.fFind.NoteRange
        Label2.Text = Strings.fFind.MeasureRange
        Label3.Text = Strings.fFind.LabelRange
        Label4.Text = Strings.fFind.ValueRange
        Label5.Text = Strings.fFind.to_
        Label6.Text = Strings.fFind.to_
        Label7.Text = Strings.fFind.to_

        cbx1.Text = Strings.fFind.Selected
        cbx2.Text = Strings.fFind.UnSelected
        cbx3.Text = Strings.fFind.ShortNote
        cbx4.Text = Strings.fFind.LongNote
        cbx5.Text = Strings.fFind.Hidden
        cbx6.Text = Strings.fFind.Visible

        Label8.Text = Strings.fFind.Column
        BSAll.Text = Strings.fFind.SelectAll
        BSInv.Text = Strings.fFind.SelectInverse
        BSNone.Text = Strings.fFind.UnselectAll

        Label9.Text = Strings.fFind.Operation
        TBrl.Text = Strings.fFind.ReplaceWithLabel
        TBrv.Text = Strings.fFind.ReplaceWithValue
        TBSelect.Text = Strings.fFind.Select_
        TBUnselect.Text = Strings.fFind.Unselect_
        TBDelete.Text = Strings.fFind.Delete_
        TBClose.Text = Strings.fFind.Close_

        For i = 28 To bCol
            Dim xCB As New CheckBox
            With xCB
                .Appearance = Appearance.Button
                .Checked = True
                .FlatStyle = FlatStyle.System

                .Location = New Point(((i - 27) Mod 8) * 35 + 3, ((i - 27) \ 8) * 25 + 103)
                .Size = New Size(35, 25)
                .Tag = i
                .Text = "B" & (i - 26).ToString
                .TextAlign = ContentAlignment.MiddleCenter
                .UseVisualStyleBackColor = True
            End With
            Panel1.Controls.Add(xCB)
        Next

        AddHandler lr1.KeyDown, AddressOf lblKeyDown
        AddHandler lr2.KeyDown, AddressOf lblKeyDown
        AddHandler Ttl.KeyDown, AddressOf lblKeyDown
    End Sub

    Private Function ValidLabel(xStr As String) As Boolean
        xStr = UCase(Trim(xStr))

        If Len(xStr) = 0 Then Return False
        If xStr = "00" Or xStr = "0" Then Return False
        If Not Len(xStr) = 1 And Not Len(xStr) = 2 Then Return False

        Dim xI3 As Integer = Asc(Mid(xStr, 1, 1))
        If Not ((xI3 >= 48 And xI3 <= 57) Or (xI3 >= 65 And xI3 <= 90)) Then Return False
        If Len(xStr) = 2 Then
            Dim xI4 As Integer = Asc(Mid(xStr, 2, 1))
            If Not ((xI4 >= 48 And xI4 <= 57) Or (xI4 >= 65 And xI4 <= 90)) Then Return False
        End If
        Return True
        MsgBox(msg2, MsgBoxStyle.Critical, msg1)
    End Function

    Private Sub lblKeyDown(sender As Object, e As KeyEventArgs)
        If Not e.KeyCode = Keys.Enter Then Exit Sub
        ValidateLabel(sender)
    End Sub

    Private Function ValidateLabel(sender As Object) As Boolean
        Dim xBool As Boolean = ValidLabel(sender.Text)
        If Not xBool Then
            MsgBox(msg2, MsgBoxStyle.Critical, msg1)
            sender.Focus()
            sender.SelectAll()
        End If
        ValidateLabel = xBool
    End Function

    Private Sub TBSelect_Click(sender As Object, e As EventArgs) Handles TBSelect.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        MainWindow.fdrSelect(xRange,
                             mr1.Value, mr2.Value,
                             lr1.Text, lr2.Text,
                             vr1.Value * 10000, vr2.Value * 10000,
                             xCol)
    End Sub

    Private Sub TBUnselect_Click(sender As Object, e As EventArgs) Handles TBUnselect.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        MainWindow.fdrUnselect(xRange,
                               mr1.Value, mr2.Value,
                               lr1.Text, lr2.Text,
                               vr1.Value * 10000, vr2.Value * 10000,
                               xCol)
    End Sub

    Private Sub TBDelete_Click(sender As Object, e As EventArgs) Handles TBDelete.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        MainWindow.fdrDelete(xRange,
                             mr1.Value, mr2.Value,
                             lr1.Text, lr2.Text,
                             vr1.Value * 10000, vr2.Value * 10000,
                             xCol)
    End Sub

    Private Sub TBrl_Click(sender As Object, e As EventArgs) Handles TBrl.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub
        If Not ValidateLabel(Ttl) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        MainWindow.fdrReplaceL(xRange,
                               mr1.Value, mr2.Value,
                               lr1.Text, lr2.Text,
                               vr1.Value * 10000, vr2.Value * 10000,
                               xCol, Ttl.Text)
    End Sub

    Private Sub TBrv_Click(sender As Object, e As EventArgs) Handles TBrv.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        MainWindow.fdrReplaceV(xRange,
                               mr1.Value, mr2.Value,
                               lr1.Text, lr2.Text,
                               vr1.Value * 10000, vr2.Value * 10000,
                               xCol, Ttv.Value * 10000)
    End Sub
End Class
