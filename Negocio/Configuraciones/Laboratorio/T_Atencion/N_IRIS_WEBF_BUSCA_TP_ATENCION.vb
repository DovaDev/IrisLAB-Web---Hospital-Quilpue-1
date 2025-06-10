Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_TP_ATENCION
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_ATENCION
    End Sub
    Function IRIS_WEBF_BUSCA_TP_ATENCION() As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_ATENCION()
    End Function
End Class
