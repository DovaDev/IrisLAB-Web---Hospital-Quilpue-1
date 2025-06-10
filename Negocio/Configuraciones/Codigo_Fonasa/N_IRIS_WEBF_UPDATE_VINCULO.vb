Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_VINCULO
    Private DD_Data As D_IRIS_WEBF_UPDATE_VINCULO
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_VINCULO
    End Sub
    Function IRIS_WEBF_UPDATE_VINCULO(ByVal ID_EST As Integer, ByVal ID_FONASA As Integer) As Integer
        Return DD_Data.D_IRIS_WEBF_UPDATE_VINCULACION(ID_EST, ID_FONASA)
    End Function
    Function IRIS_WEBF_UPDATE_DESVINCULACION(ByVal ID_EST As Integer, ByVal ID_FONASA As Integer) As Integer
        Return DD_Data.D_IRIS_WEBF_UPDATE_DESVINCULACION(ID_EST, ID_FONASA)
    End Function
End Class
