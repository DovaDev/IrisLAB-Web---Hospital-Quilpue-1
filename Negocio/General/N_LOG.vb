Imports System.Web
Imports System.IO
Imports System.Text
Public Class N_Log
    Dim fileRoot As String = "C:\"
    Private filePath As String = ""

    ''' <summary>
    ''' Ruta absoluta de guardado del archivo con respecto a la carpeta raíz del proyecto
    ''' </summary>
    ''' <returns></returns>
    Public Property Path() As String
        Get
            Return filePath
        End Get
        Set(ByVal value As String)
            filePath = value.Replace("/", "\")

            Dim arrDir As String() = filePath.Split("\")
            Dim Folder_Dir As String = ""

            For i = 0 To (arrDir.Count - 1)
                Select Case i
                    Case Is = (arrDir.Count - 1)
                        Exit For
                    Case Else
                        If (Trim(arrDir(i)) <> "") Then
                            Folder_Dir &= "\" & arrDir(i)
                        End If
                End Select
            Next i

            If (Directory.Exists(fileRoot & "/" & Folder_Dir) = False) Then
                Directory.CreateDirectory(fileRoot & "/" & Folder_Dir)
            End If
        End Set
    End Property

    Sub New()
        'Obtener mediante otra vía la Raíz del proyecto
        fileRoot = Hosting.HostingEnvironment.MapPath("/")
    End Sub

    ''' <summary>
    ''' Escribe una nueva línea de texto en el archivo de log.
    ''' </summary>
    ''' <param name="txtLine">Cadena con el texto a insertar, por defecto este corresponde a un salto de línea</param>
    Public Sub Write_Line(Optional ByVal txtLine As String = "", Optional ByVal Timestamp As Boolean = True)
        Select Case txtLine
            Case ""
                File.AppendAllText(fileRoot & filePath, txtLine & vbCrLf)
            Case Else
                Dim xStr As String = txtLine

                If (Timestamp = True) Then
                    xStr = Format(Date.Now, "[dd/MM/yyyy -> hh:mm:ss] ") & xStr
                End If

                xStr = xStr.Replace(" />", "/>")
                xStr = xStr.Replace("<space/>", "                         ")

                File.AppendAllText(fileRoot & filePath, xStr & vbCrLf)
        End Select


    End Sub
    Public Sub Write_Separator()
        File.AppendAllText(fileRoot & filePath, "----------------------------------------------------------------------------------" & vbCrLf)
    End Sub

    Public Sub Write_ERROR(ByVal Ex As Exception)
        ' Obtener la ruta base del proyecto dinámicamente
        Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
        Dim logFolder As String = baseDirectory & "Logs\" ' Carpeta Logs dentro del proyecto
        Dim logFile As String = logFolder & "error_log.txt" ' Archivo dentro de Logs

        ' Verificar si la carpeta "Logs" existe, si no, la crea
        If Not Directory.Exists(logFolder) Then
            Directory.CreateDirectory(logFolder)
        End If

        ' Construir el mensaje de error
        Dim txtError As New StringBuilder
        txtError.Append("----------------------------------------------------------------------------------" & vbCrLf)
        txtError.Append(Format(Date.Now, "[dd/MM/yyyy -> hh:mm:ss]") & " ERROR:" & vbCrLf)
        txtError.Append("    Código: " & vbCrLf)
        txtError.Append("        " & Ex.GetHashCode() & vbCrLf)
        txtError.Append(vbCrLf)

        ' Manejar la descripción del error
        Dim txtMessage As String = Ex.Message
        Dim xLen_Limit As Integer = 60
        Dim List_Message As New List(Of String)

        Do Until Trim(txtMessage) = ""
            Dim arrText As String() = txtMessage.Split(" ")
            Dim xItem As String = ""

            For i = 0 To (arrText.Count - 1)
                xItem &= arrText(i)

                If (xItem.Length >= xLen_Limit) Then
                    Exit For
                ElseIf (xItem <> "") Then
                    xItem &= " "
                End If
            Next i

            xItem = Trim(xItem)
            txtMessage = txtMessage.Replace(xItem, "")
            List_Message.Add(xItem)
        Loop

        txtError.Append("    Descripción: " & vbCrLf)
        For Each item As String In List_Message
            txtError.Append("        " & item & vbCrLf)
        Next

        ' Agregar el StackTrace formateado
        txtError.Append(vbCrLf)
        txtError.Append("    Stack Trace:" & vbCrLf)

        If Ex.StackTrace IsNot Nothing Then
            Dim strStackTrace As String = Ex.StackTrace.Replace(" en ", vbCrLf & "en ")
            Dim arrStackTrace As String() = strStackTrace.Split(vbCrLf)

            For Each elem As String In arrStackTrace
                txtError.Append("        " & LTrim(elem) & vbCrLf)
            Next
        End If

        txtError.Append("----------------------------------------------------------------------------------" & vbCrLf)

        ' Escribir el error en el archivo de log
        File.AppendAllText(logFile, txtError.ToString)
    End Sub

    'Public Sub Write_ERROR(ByVal Ex As Exception)
    '    Dim xPath As String = IO.Path.Combine(fileRoot, filePath)
    '    Dim txtError As New StringBuilder()

    '    Try
    '        ' Validar la ruta antes de escribir
    '        Dim directoryPath As String = IO.Path.GetDirectoryName(xPath)
    '        If String.IsNullOrWhiteSpace(directoryPath) Then
    '            Throw New ArgumentException("La ruta del archivo no está correctamente configurada.")
    '        End If

    '        If Not Directory.Exists(directoryPath) Then
    '            Directory.CreateDirectory(directoryPath)
    '        End If

    '        ' Construcción del mensaje de error
    '        txtError.AppendLine("----------------------------------------------------------------------------------")
    '        txtError.AppendLine($"{DateTime.Now: [dd/MM/yyyy -> hh:mm:ss]} ERROR:")
    '        txtError.AppendLine("    Código:")
    '        txtError.AppendLine($"        {Ex.GetHashCode}")
    '        txtError.AppendLine()

    '        ' Formatear el mensaje de descripción
    '        txtError.AppendLine("    Descripción:")
    '        txtError.Append(FormatMessage(Ex.Message, 60))

    '        txtError.AppendLine()
    '        txtError.AppendLine("    Stack Trace:")
    '        txtError.AppendLine(FormatStackTrace(Ex.StackTrace))

    '        txtError.AppendLine("----------------------------------------------------------------------------------")

    '        ' Guardar el error en el archivo
    '        File.AppendAllText(xPath, txtError.ToString())

    '    Catch dirEx As DirectoryNotFoundException
    '        Console.WriteLine("Error: No se encontró la ruta: " & xPath)
    '    Catch authEx As UnauthorizedAccessException
    '        Console.WriteLine("Error: Permisos insuficientes para escribir en: " & xPath)
    '    Catch genEx As Exception
    '        Console.WriteLine("Error inesperado: " & genEx.Message)
    '    End Try
    'End Sub

    ' Función para formatear el mensaje de error
    Private Function FormatMessage(ByVal message As String, ByVal lengthLimit As Integer) As String
        Dim listMessage As New List(Of String)()
        Do Until String.IsNullOrWhiteSpace(message)
            Dim arrText As String() = message.Split(" "c)
            Dim xItem As String = ""

            For i = 0 To arrText.Length - 1
                xItem &= arrText(i)
                If xItem.Length >= lengthLimit Then
                    Exit For
                ElseIf xItem <> "" Then
                    xItem &= " "
                End If
            Next

            xItem = xItem.Trim()
            message = message.Replace(xItem, "").Trim()
            listMessage.Add(xItem)
        Loop

        Dim formattedMessage As New StringBuilder()
        For Each line In listMessage
            formattedMessage.AppendLine($"        {line}")
        Next
        Return formattedMessage.ToString()
    End Function

    ' Función para formatear el stack trace
    Private Function FormatStackTrace(ByVal stackTrace As String) As String
        Dim formattedStackTrace As New StringBuilder()
        Dim strStackTrace As String = stackTrace.Replace(" en ", vbCrLf & "en ")
        Dim arrStackTrace As String() = strStackTrace.Split(New String() {vbCrLf}, StringSplitOptions.None)

        For Each elem As String In arrStackTrace
            formattedStackTrace.AppendLine($"        {elem.Trim().Replace(Hosting.HostingEnvironment.MapPath("/"), "ROOT:\")}")
        Next

        Return formattedStackTrace.ToString()
    End Function
End Class
