Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_ORDEN_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_ORDEN_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_ORDEN_ATENCION
    End Sub
    Function IRIS_WEBF_GRABA_ORDEN_ATENCION(ByVal ORD_COD As String, ByVal ORD_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_ORDEN_ATENCION(ORD_COD, ORD_DES, ID_ESTADO)
    End Function
End Class
