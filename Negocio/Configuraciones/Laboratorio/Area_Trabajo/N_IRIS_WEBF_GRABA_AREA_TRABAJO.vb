Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_AREA_TRABAJO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_AREA_TRABAJO
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_AREA_TRABAJO
    End Sub
    Function IRIS_WEBF_GRABA_AREA_TRABAJO(ByVal AREA_COD As String, ByVal AREA_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_AREA_TRABAJO(AREA_COD, AREA_DES, ID_ESTADO)
    End Function
End Class
