Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_PROFESION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PROFESION
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PROFESION
    End Sub
    Function IRIS_WEBF_GRABA_PROFESION(ByVal PRO_COD As String, ByVal PRO_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PROFESION(PRO_COD, PRO_DES, ID_ESTADO)
    End Function
End Class
