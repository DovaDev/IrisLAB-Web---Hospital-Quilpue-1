Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_TP_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_TP_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_TP_ATENCION
    End Sub
    Function IRIS_WEBF_UPDATE_TP_ATENCION(ByVal ID_TP_ATENCION As Integer, ByVal TP_ATE_COD As String, ByVal TP_ATE_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_TP_ATENCION(ID_TP_ATENCION, TP_ATE_COD, TP_ATE_DES, ID_ESTADO)
    End Function
End Class
