Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_FOLIO_BE
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_FOLIO_BE
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_FOLIO_BE
    End Sub

    Function IRIS_WEBF_CMVM_BUSCA_FOLIO_BE(ByVal ID_ATENCION As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_FOLIO_BE(ID_ATENCION)
    End Function

End Class
