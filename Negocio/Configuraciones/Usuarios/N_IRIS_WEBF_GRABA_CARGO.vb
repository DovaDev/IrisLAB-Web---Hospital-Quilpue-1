Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_CARGO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_CARGO
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_CARGO
    End Sub
    Function IRIS_WEBF_GRABA_CARGO(ByVal CAR_COD As String, ByVal CAR_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_CARGO(CAR_COD, CAR_DES, ID_ESTADO)
    End Function
End Class
