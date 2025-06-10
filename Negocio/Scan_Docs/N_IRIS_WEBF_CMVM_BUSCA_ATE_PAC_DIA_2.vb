Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2(ByVal DESDE As String, ByVal HASTA As String, ByVal USUARIO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2(DESDE, HASTA, USUARIO)
    End Function
End Class
