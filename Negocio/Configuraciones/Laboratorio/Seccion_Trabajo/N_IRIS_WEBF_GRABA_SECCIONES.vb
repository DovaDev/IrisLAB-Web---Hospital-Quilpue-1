Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_SECCIONES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_SECCIONES
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_SECCIONES
    End Sub
    Function IRIS_WEBF_GRABA_SECCIONES(ByVal SECC_COD As String, ByVal SECC_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_SECCIONES(SECC_COD, SECC_DES, ID_ESTADO)
    End Function
End Class
