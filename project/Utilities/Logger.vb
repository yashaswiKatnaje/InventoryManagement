Imports System.IO

Public Class Logger
    Private Shared ReadOnly LogFilePath As String = HttpContext.Current.Server.MapPath("~/App_Data/ErrorLog.txt")

    Public Shared Sub LogException(ByVal ex As Exception)
        Dim logEntry As String = String.Format("{0}{1}Exception Message: {2}{1}Stack Trace: {3}{1}{1}",
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                    Environment.NewLine,
                                                    ex.Message,
                                                    ex.StackTrace)


        Try
            Using writer As New StreamWriter(LogFilePath, True)
                writer.WriteLine(logEntry)
            End Using
        Catch ioEx As IOException

        End Try
    End Sub
End Class
