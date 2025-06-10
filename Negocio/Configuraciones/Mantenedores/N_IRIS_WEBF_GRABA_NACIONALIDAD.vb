'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_NACIONALIDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_NACIONALIDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_NACIONALIDAD
    End Sub
    Function IRIS_WEBF_GRABA_NACIONALIDAD(ByVal NAC_COD As String, ByVal NAC_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_NACIONALIDAD(NAC_COD, NAC_DES, ID_ESTADO)
    End Function
End Class
