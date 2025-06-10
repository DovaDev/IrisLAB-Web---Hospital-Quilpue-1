Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_PROCEDENCIA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PROCEDENCIA
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PROCEDENCIA
    End Sub
    Function IRIS_WEBF_UPDATE_PROCEDENCIA(ByVal ID_PROCEDENCIA As Integer, ByVal PROC_COD As String, ByVal PROC_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PROCEDENCIA(ID_PROCEDENCIA, PROC_COD, PROC_DES, ID_ESTADO)
    End Function

    Function IRIS_WEBF_UPDATE_PROCEDENCIA_2(ByVal ID_PROCEDENCIA As Integer, ByVal PROC_COD As String, ByVal PROC_DES As String, ByVal ID_ESTADO As Integer, ByVal COD_AVIS As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PROCEDENCIA_2(ID_PROCEDENCIA, PROC_COD, PROC_DES, ID_ESTADO, COD_AVIS)
    End Function

End Class
