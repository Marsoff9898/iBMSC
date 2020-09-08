Imports iBMSC.Editor

' In order of appearance
Public Enum ColumnType
    Measure
    SCROLLS
    BPM
    STOPS
    S1

    A1
    A2
    A3
    A4
    A5
    A6
    A7
    A8
    S2

    D1
    D2
    D3
    D4
    D5
    D6
    D7
    D8
    S3

    BGA
    LAYER
    POOR
    S4
    BGM ' Must always be the last
End Enum

Public Class ColumnList
    ' Should match the order of the enum above!
    Public column() As Column = {
                                    New Column(0, 50, "Measure", False, True, False, True, 0, 0, &HFF00FFFF, 0,
                                               &HFF00FFFF, 0),
                                    New Column(50, 60, "SCROLL", True, True, False, True, 99, 0, &HFFFF0000, 0,
                                               &HFFFF0000, 0),
                                    New Column(110, 60, "BPM", True, True, False, True, 3, 0, &HFFFF0000, 0, &HFFFF0000,
                                               0),
                                    New Column(170, 50, "STOP", True, True, False, True, 9, 0, &HFFFF0000, 0, &HFFFF0000,
                                               0),
                                    New Column(220, 5, "", False, False, False, True, 0, 0, 0, 0, 0, 0),
                                    New Column(225, 40, "A1", True, False, True, True, 9, &HFF808080, &HFF000000,
                                               &HFF909090, &HFF000000, 0),
                                    New Column(265, 42, "A2", True, False, True, True, 6, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(307, 30, "A3", True, False, True, True, 1, &HFF62B0FF, &HFF000000,
                                               &HFF6AB0F7, &HFF000000, &H140033FF),
                                    New Column(337, 42, "A4", True, False, True, True, 2, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(379, 45, "A5", True, False, True, True, 3, &HFFFFC862, &HFF000000,
                                               &HFFF7C66A, &HFF000000, &H16F38B0C),
                                    New Column(424, 42, "A6", True, False, True, True, 4, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(466, 30, "A7", True, False, True, True, 5, &HFF62B0FF, &HFF000000,
                                               &HFF6AB0F7, &HFF000000, &H140033FF),
                                    New Column(496, 42, "A8", True, False, True, True, 8, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(498, 5, "", False, False, False, True, 0, 0, 0, 0, 0, 0),
                                    New Column(503, 42, "D1", True, False, True, False, 1, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(503, 30, "D2", True, False, True, False, 2, &HFF62B0FF, &HFF000000,
                                               &HFF6AB0F7, &HFF000000, &H140033FF),
                                    New Column(503, 42, "D3", True, False, True, False, 3, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(503, 45, "D4", True, False, True, False, 4, &HFFFFC862, &HFF000000,
                                               &HFFF7C66A, &HFF000000, &H16F38B0C),
                                    New Column(503, 42, "D5", True, False, True, False, 5, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(503, 30, "D6", True, False, True, False, 8, &HFF62B0FF, &HFF000000,
                                               &HFF6AB0F7, &HFF000000, &H140033FF),
                                    New Column(503, 42, "D7", True, False, True, False, 9, &HFFB0B0B0, &HFF000000,
                                               &HFFC0C0C0, &HFF000000, &H14FFFFFF),
                                    New Column(503, 40, "D8", True, False, True, False, 6, &HFF808080, &HFF000000,
                                               &HFF909090, &HFF000000, 0),
                                    New Column(503, 5, "", False, False, False, False, 0, 0, 0, 0, 0, 0),
                                    New Column(503, 40, "BGA", True, False, False, False, 4, &HFF8CD78A, &HFF000000,
                                               &HFF90D38E, &HFF000000, 0),
                                    New Column(503, 40, "LAYER", True, False, False, False, 7, &HFF8CD78A, &HFF000000,
                                               &HFF90D38E, &HFF000000, 0),
                                    New Column(503, 40, "POOR", True, False, False, False, 6, &HFF8CD78A, &HFF000000,
                                               &HFF90D38E, &HFF000000, 0),
                                    New Column(503, 5, "", False, False, False, False, 0, 0, 0, 0, 0, 0),
                                    New Column(503, 40, "B", True, False, True, True, 1, &HFFE18080, &HFF000000,
                                               &HFFDC8585, &HFF000000, 0)
                                }

    Private _columnCount = 46
    Public Property ColumnCount As Integer
        Get
            Return _columnCount
        End Get
        Set
            _columnCount = value
            RaiseEvent OnRightBoundaryChanged(RightBoundary)
        End Set

    End Property

    Public Const idflBPM As Integer = 5

    Public Function GetBMSChannelBy(note As Note) As String
        Dim iCol = note.ColumnIndex
        Dim xVal = note.Value
        Dim xLong = note.LongNote
        Dim xHidden = note.Hidden
        Dim bmsBaseChannel As Integer = GetColumn(iCol).BmsChannel
        Dim xLandmine = note.Landmine

        If iCol = ColumnType.BPM AndAlso (xVal/10000 <> xVal\10000 Or xVal >= 2560000 Or xVal < 0) Then
            bmsBaseChannel += idflBPM
        End If

        If iCol = ColumnType.SCROLLS Then Return "SC"

        ' p1 side
        If iCol >= ColumnType.A1 And iCol <= ColumnType.A8 Then
            If xLong Then
                Return Hex(bmsBaseChannel + Convert.ToInt32("50", 16))
            End If
            If xHidden Then
                Return Hex(bmsBaseChannel + Convert.ToInt32("30", 16))
            End If
            If xLandmine Then
                Return Hex(bmsBaseChannel + Convert.ToInt32("D0", 16))
            End If

            Return Add2Zeros(bmsBaseChannel + 10)
        End If

        ' p2 side
        If iCol >= ColumnType.D1 And iCol <= ColumnType.D8 Then
            If xLong Then
                Return Hex(bmsBaseChannel + Convert.ToInt32("60", 16))
            End If
            If xHidden Then
                Return Hex(bmsBaseChannel + Convert.ToInt32("40", 16))
            End If
            If xLandmine Then
                Return Hex(bmsBaseChannel + Convert.ToInt32("E0", 16))
            End If

            Return Add2Zeros(bmsBaseChannel + 20)
        End If

        Return Add2Zeros(bmsBaseChannel)
    End Function

    Public Function GetColumnLeft(iCol As Integer) As Integer
        If iCol < ColumnType.BGM Then
            Return column(iCol).Left
        Else
            Return column(ColumnType.BGM).Left + (iCol - ColumnType.BGM)*column(ColumnType.BGM).Width
        End If
    End Function

    Public Function GetColumnRight(iCol As Integer) As Integer
        Return GetColumnLeft(iCol) + GetWidth(iCol)
    End Function

    Public Function GetWidth(iCol As Integer) As Integer
        If Not GetColumn(iCol).IsVisible Then Return 0
        If iCol < ColumnType.BGM Then
            Return column(iCol).Width
        Else
            Return column(ColumnType.BGM).Width
        End If
    End Function

    Public Function GetName(iCol As Integer) As String
        If iCol < ColumnType.BGM Then Return column(iCol).Title Else _
            Return column(ColumnType.BGM).Title & (iCol - ColumnType.BGM + 1).ToString
    End Function

    Public Function IsEnabled(iCol As Integer) As Boolean
        'If iCol < Columns.BGM Then Return col(iCol).Enabled And col(iCol).Visible Else Return col(Columns.BGM).Enabled And col(Columns.BGM).Visible
        If iCol < ColumnType.BGM Then Return column(iCol).IsEnabledAfterAll Else _
            Return column(ColumnType.BGM).IsEnabledAfterAll
    End Function

    Public Function IsColumnNumeric(iCol As Integer) As Boolean
        If iCol < ColumnType.BGM Then Return column(iCol).isNumeric Else Return column(ColumnType.BGM).isNumeric
    End Function

    Public Function IsColumnSound(iCol As Integer) As Boolean
        If iCol < ColumnType.BGM Then Return column(iCol).isSound Else Return column(ColumnType.BGM).isSound
    End Function
    Public Function IsColumnImage(ByVal iCol As Integer) As Boolean
        If iCol < ColumnType.BGM Then Return Not (column(iCol).IsNumeric Or column(iCol).IsSound) Else Return Not (column(ColumnType.BGM).IsNumeric Or column(ColumnType.BGM).IsSound)
    End Function

    Public Function GetColumn(iCol As Integer) As Column
        If iCol < ColumnType.BGM Then Return column(iCol) Else Return column(ColumnType.BGM)
    End Function

    Public Function BMSEChannelToColumnIndex(I As String, rScratch As Boolean)
        Dim Ivalue = Val(I)
        If Ivalue > 100 Then
            Return ColumnType.BGM + Ivalue - 101
        ElseIf Ivalue < 100 And Ivalue > 0 Then
            Return BMSChannelToColumn(Mid(I, 2, 2), rScratch)
        End If
        Return ColumnType.BGM ' ??? how did a negative number get here?
    End Function

    Public Function BMSChannelToColumn(I As String, rScratch As Boolean) As Integer
        Dim result As Integer = 0
        Select Case I
            Case "01" : result = ColumnType.BGM
            Case "03", "08" : result = ColumnType.BPM
            Case "09" : result = ColumnType.STOPS
            Case "SC" : result = ColumnType.SCROLLS
            Case "04" : result = ColumnType.BGA
            Case "07" : result = ColumnType.LAYER
            Case "06" : result = ColumnType.POOR

            Case "16", "36", "56", "76", "D6" : result = ColumnType.A1
            Case "11", "31", "51", "71", "D1" : result = ColumnType.A2
            Case "12", "32", "52", "72", "D2" : result = ColumnType.A3
            Case "13", "33", "53", "73", "D3" : result = ColumnType.A4
            Case "14", "34", "54", "74", "D4" : result = ColumnType.A5
            Case "15", "35", "55", "75", "D5" : result = ColumnType.A6
            Case "18", "38", "58", "78", "D8" : result = ColumnType.A7
            Case "19", "39", "59", "79", "D9" : result = ColumnType.A8

            Case "21", "41", "61", "81", "E1" : result = ColumnType.D1
            Case "22", "42", "62", "82", "E2" : result = ColumnType.D2
            Case "23", "43", "63", "83", "E3" : result = ColumnType.D3
            Case "24", "44", "64", "84", "E4" : result = ColumnType.D4
            Case "25", "45", "65", "85", "E5" : result = ColumnType.D5
            Case "28", "48", "68", "88", "E8" : result = ColumnType.D6
            Case "29", "49", "69", "89", "E9" : result = ColumnType.D7
            Case "26", "46", "66", "86", "E6" : result = ColumnType.D8

            Case Else : result = 0
        End Select
        If rScratch Then
            If result = ColumnType.A1 Then
                result = ColumnType.A8
            ElseIf result >= ColumnType.A2 AndAlso result <= ColumnType.A8 Then
                result -= 1
            End If
        End If
        Return result
    End Function

    Public Function EnabledColumnIndexToColumnArrayIndex(cEnabled As Integer) As Integer
        Dim i = 0
        Do
            If i >= ColumnCount Then Exit Do
            If Not IsEnabled(i) Then cEnabled += 1
            If i >= cEnabled Then Exit Do
            i += 1
        Loop
        Return cEnabled
    End Function

    Public Function ColumnArrayIndexToEnabledColumnIndex(cReal As Integer) As Integer
        Dim i As Integer
        For i = 0 To cReal - 1
            If Not IsEnabled(i) Then cReal -= 1
        Next
        Return cReal
    End Function

    Friend Sub RecalculatePositions()
        column(0).Left = 0

        For i = 1 To UBound(column)
            Dim lastWidth = IIf(column(i - 1).IsVisible, column(i - 1).Width, 0)
            column(i).Left = column(i - 1).Left + lastWidth
        Next
        
        RaiseEvent OnRightBoundaryChanged(RightBoundary)
    End Sub

    Public ReadOnly Property RightBoundary As Integer
        get
            Return GetColumnLeft(ColumnCount) + column(ColumnType.BGM).Width
        end get
    end property

    Friend Sub SetP2SideVisible(visible As Boolean)
        column(ColumnType.D1).IsVisible = visible
        column(ColumnType.D2).IsVisible = visible
        column(ColumnType.D3).IsVisible = visible
        column(ColumnType.D4).IsVisible = visible
        column(ColumnType.D5).IsVisible = visible
        column(ColumnType.D6).IsVisible = visible
        column(ColumnType.D7).IsVisible = visible
        column(ColumnType.D8).IsVisible = visible
        column(ColumnType.S3).IsVisible = visible
        
        RecalculatePositions()
    End Sub

    Friend Function NormalizeIndex(v As Integer) As Integer
        Return EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(v))
    End Function
    
    Public Sub SetColumnVisible(col As ColumnType, visible As Boolean)
        GetColumn(col).IsVisible = visible
        
        RecalculatePositions()
    End Sub
    
    Event OnRightBoundaryChanged(boundary As Integer)
End Class