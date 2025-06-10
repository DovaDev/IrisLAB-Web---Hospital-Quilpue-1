Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_CARGO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_CARGO
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_CARGO
    End Sub
    Function IRIS_WEBF_UPDATE_CARGO(ByVal ID_CAR As Integer, ByVal CAR_COD As String, ByVal CAR_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_CARGO(ID_CAR, CAR_COD, CAR_DES, ID_ESTADO)
    End Function
End Class
