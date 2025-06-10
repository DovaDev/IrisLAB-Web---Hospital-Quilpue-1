Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_BUSCA_DATOS_BE
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_DATOS_BE
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_DATOS_BE
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_DATOS_BE(ByVal ATE_NUM As String) As E_IRIS_WEBF_CMVM_BUSCA_DATOS_BE
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_DATOS_BE(ATE_NUM)
    End Function
End Class
