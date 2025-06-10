'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_TP_RESULTADO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_TP_RESULTADO
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_TP_RESULTADO
    End Sub
    Function IRIS_WEBF_UPDATE_TP_RESULTADO(ByVal ID_TP As Integer, ByVal TP_COD As String, ByVal TP_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_TP_RESULTADO(ID_TP, TP_COD, TP_DES, ID_ESTADO)
    End Function
End Class