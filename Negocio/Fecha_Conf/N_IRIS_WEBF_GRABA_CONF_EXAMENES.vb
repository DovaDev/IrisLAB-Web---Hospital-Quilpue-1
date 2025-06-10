Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_CONF_EXAMENES
    Private DD_Data As D_IRIS_WEBF_GRABA_CONF_EXAMENES
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_CONF_EXAMENES
    End Sub
    Function IRIS_WEBF_GRABA_CONF_EXAMENES(ByVal ID_PRO As String, ByVal FECHA As String, ByVal CANT As String) As Integer
        Return DD_Data.D_IRIS_WEBF_GRABA_CONF_EXAMENES(ID_PRO, FECHA, CANT)
    End Function
    Function IRIS_WEBF_GRABA_CONF_EXAMENES_2(ByVal ID_PRO As String, ByVal FECHA As String, ByVal CANT As String, ByVal normal As String, ByVal prioritario As String, ByVal espontaneo As String, ByVal Optional COMENTARIO As String = "0") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_CONF_EXAMENES_2(ID_PRO, FECHA, CANT, normal, prioritario, espontaneo, COMENTARIO)
    End Function
End Class
