Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS(ByVal ID_ATENCION As Long) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS(ID_ATENCION)
    End Function
End Class
