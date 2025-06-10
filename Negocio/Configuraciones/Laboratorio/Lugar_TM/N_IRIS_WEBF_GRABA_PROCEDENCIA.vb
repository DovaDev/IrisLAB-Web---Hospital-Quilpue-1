Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_PROCEDENCIA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PROCEDENCIA
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PROCEDENCIA
    End Sub
    Function IRIS_WEBF_GRABA_PROCEDENCIA(ByVal PROC_COD As String, ByVal PROC_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PROCEDENCIA(PROC_COD, PROC_DES, ID_ESTADO)
    End Function
End Class
