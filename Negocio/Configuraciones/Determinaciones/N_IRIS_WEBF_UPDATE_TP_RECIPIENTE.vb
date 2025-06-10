'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_TP_RECIPIENTE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_TP_RECIPIENTE
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_TP_RECIPIENTE
    End Sub
    Function IRIS_WEBF_UPDATE_TP_RECIPIENTE(ByVal ID_RE As Integer, ByVal RE_COD As String, ByVal RE_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_TP_RECIPIENTE(ID_RE, RE_COD, RE_DES, ID_ESTADO)
    End Function
End Class