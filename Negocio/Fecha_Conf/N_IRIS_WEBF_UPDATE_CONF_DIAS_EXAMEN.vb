Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN
    Private DD_Data As D_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN
    End Sub
    Function IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN(ByVal ID_CONF As String, ByVal CANTIDAD As String, ByVal ID_ESTADO As String) As Integer
        Return DD_Data.D_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN(ID_CONF, CANTIDAD, ID_ESTADO)
    End Function
    Function IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN_NEW(ByVal ID_CONF As String, ByVal CANTIDAD As String, ByVal ID_ESTADO As String, ByVal normal As String, ByVal prioritario As String, ByVal espontaneo As String, ByVal Optional COMENTARIO As String = "0") As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN_NEW(ID_CONF, CANTIDAD, ID_ESTADO, normal, prioritario, espontaneo, COMENTARIO)
    End Function
End Class
