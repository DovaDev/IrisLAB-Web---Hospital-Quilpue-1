Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_TP_MUESTRA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_TP_MUESTRA
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_TP_MUESTRA
    End Sub
    Function IRIS_WEBF_GRABA_TP_MUESTRA(ByVal RE_COD As String, ByVal RE_DES As String, ByVal ID_CB As Integer, ByVal ID_RECEP As Integer, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_TP_MUESTRA(RE_COD, RE_DES, ID_CB, ID_RECEP, ID_ESTADO)
    End Function
End Class
