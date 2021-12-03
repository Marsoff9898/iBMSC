Imports System.IO

Namespace My
    Partial Friend Class MyApplication

        Dim DirectoryPath = Directory.GetParent(System.Windows.Forms.Application.ExecutablePath)

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim xRes As MsgBoxResult = MsgBox("An unhandled exception has occurred in the application: " & vbCrLf &
                                       e.Exception.Message & vbCrLf &
                                       vbCrLf &
                                       "Click Yes to save a back-up, click No otherwise, or click Cancel to ignore this exception and continue.",
                                       MsgBoxStyle.YesNoCancel + MsgBoxStyle.Critical,
                                       "Unhandled Exception")
            If xRes = MsgBoxResult.Cancel Then e.ExitApplication = False
            If xRes = MsgBoxResult.Yes Then
                Dim xFN As String
                Dim xDate As Date = DateTime.Now
                With xDate
                    xFN = "\AutoSave_" & .Year & "_" & .Month & "_" & .Day & "_" & .Hour & "_" & .Minute & "_" & .Second & "_" & .Millisecond & ".IBMSC"
                End With

                'File.WriteAllText(DirectoryPath & xFN, Form1.ExceptionSave, False)
                MainWindow.Refer.ExceptionSave(DirectoryPath & xFN)
                MsgBox("A back-up has been saved to " & DirectoryPath & xFN, MsgBoxStyle.Information)
            End If
        End Sub
    End Class

End Namespace

