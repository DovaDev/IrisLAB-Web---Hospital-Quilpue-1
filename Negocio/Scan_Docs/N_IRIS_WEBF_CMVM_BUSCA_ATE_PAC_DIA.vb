Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA(ByVal DESDE As String, ByVal HASTA As String, ByVal USUARIO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA(DESDE, HASTA, USUARIO)
    End Function
End Class
