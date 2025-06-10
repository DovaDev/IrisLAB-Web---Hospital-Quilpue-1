Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY() As List(Of String)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY()
    End Function
End Class
