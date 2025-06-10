Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_CIUDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_CIUDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_CIUDAD
    End Sub
    Function IRIS_WEBF_GRABA_CIUDAD(ByVal CIU_COD As String, ByVal CIU_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_CIUDAD(CIU_COD, CIU_DES, ID_ESTADO)
    End Function
End Class
