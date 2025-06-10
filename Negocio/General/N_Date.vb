Imports System.Globalization
Public Class N_Date
    '''<summary>
    '''Función que transforma una serie de números a una variable tipo Date
    '''</summary>
    '''<param name="nYear">Entregar un número tipo Long con el año (no se aceptan ceros).</param>
    '''<param name="nMonth">Entregar un número tipo Integer con el mes (no se aceptan ceros).</param>
    '''<param name="nDay">Entregar un número tipo Integer con el día (no se aceptan ceros).</param>
    '''<returns></returns>
    '''<remarks></remarks>
    Public Function strToDate(ByVal nYear As Long, ByVal nMonth As Integer, ByVal nDay As Integer, Optional ByVal nHour As Integer = 0, Optional ByVal nMin As Integer = 0, Optional ByVal nSec As Integer = 0) As Date
        Dim nDate As New Date
        nDate = nDate.AddYears(CInt(nYear) - 1)
        nDate = nDate.AddMonths(CInt(nMonth) - 1)
        nDate = nDate.AddDays(CInt(nDay) - 1)

        nDate = nDate.AddHours(nHour)
        nDate = nDate.AddMinutes(nMin)
        nDate = nDate.AddSeconds(nSec)

        Return nDate
    End Function

    Public Shared Function toDate(ByVal str_in As String) As Date
        Dim DDD As New N_Date
        Dim init As String = ""

        Dim regex As New Regex("[0-9]+", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
        For Each item In regex.Matches(str_in)
            init &= item.ToString
            init &= "/"
        Next

        regex = New Regex("\/$", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
        init = regex.Replace(init, "")

        regex = New Regex("^[0-9]{2,4}\/[0-9]{2,2}\/[0-9]{2,4}$", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
        If (regex.Matches(init).Count = 0) Then
            DDD.strError()

        End If

        init = init.Replace("-", "/")
        init = init.Replace("\", "/")

        Dim arr(2) As String
        arr = init.Split("/")

        For Each item In arr
            If (CInt(item) <= 0) Then
                DDD.strError()

            End If
        Next

        Dim out As Date
        If (arr(0).Length > 2) Then
            If (CInt(arr(2)) > 12) Then
                DDD.strError()

            End If

            out = DDD.strToDate(CInt(arr(0)), CInt(arr(2)), CInt(arr(1)))
        Else
            If (CInt(arr(1)) > 12) Then
                DDD.strError()

            End If

            out = DDD.strToDate(CInt(arr(2)), CInt(arr(1)), CInt(arr(0)))
        End If

        Return out
    End Function

    Private Sub strError()
        Dim resp As HttpResponse = HttpContext.Current.Response
        Dim strError As String = ""

        strError &= "Formato de fecha inválido, los formatos aceptados solo incluyen ""DD/MM/YYYY"" o ""YYYY/MM/DD""."
        Throw New ApplicationException(strError)
        resp.Clear()
        resp.StatusCode = 500
        resp.End()
    End Sub
End Class
