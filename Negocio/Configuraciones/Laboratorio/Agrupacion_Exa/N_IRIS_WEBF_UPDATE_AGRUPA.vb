Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_AGRUPA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_AGRUPA
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_AGRUPA
    End Sub
    Function IRIS_WEBF_UPDATE_AGRUPA(ByVal ID_AGRU As Integer, ByVal AGRU_COD As String, ByVal AGRU_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_AGRUPA(ID_AGRU, AGRU_COD, AGRU_DES, ID_ESTADO)
    End Function
End Class
