Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_AGRUPA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_AGRUPA
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_AGRUPA
    End Sub
    Function IRIS_WEBF_GRABA_AGRUPA(ByVal AGRU_COD As String, ByVal AGRU_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_AGRUPA(AGRU_COD, AGRU_DES, ID_ESTADO)
    End Function
End Class
