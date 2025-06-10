Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_SECCIONES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_SECCIONES
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_SECCIONES
    End Sub
    Function IRIS_WEBF_UPDATE_SECCIONES(ByVal ID_SECC As Integer, ByVal SECC_COD As String, ByVal SECC_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_SECCIONES(ID_SECC, SECC_COD, SECC_DES, ID_ESTADO)
    End Function
End Class
