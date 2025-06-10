Imports System.Globalization
Public Class N_Date_Operat
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

End Class
