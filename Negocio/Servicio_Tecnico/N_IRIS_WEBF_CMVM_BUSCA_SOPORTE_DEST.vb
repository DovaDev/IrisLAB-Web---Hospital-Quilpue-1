Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST() As List(Of String)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_SOPORTE_DEST()
    End Function
End Class
