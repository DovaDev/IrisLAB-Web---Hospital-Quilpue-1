'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_COMUNA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_COMUNA
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_COMUNA
    End Sub
    Function IRIS_WEBF_GRABA_COMUNA(ByVal COM_COD As String, ByVal COM_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_COMUNA(COM_COD, COM_DES, ID_ESTADO)
    End Function
End Class
