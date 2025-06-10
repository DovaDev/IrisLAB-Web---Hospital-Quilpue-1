'Importar Capas
Imports Datos
Imports Entidades
Public Class N_Login2
    'Declaraciones Generales
    Dim DD_Data As D_Login2
    Sub New()
        DD_Data = New D_Login2
    End Sub
    Function Login2(ByVal USER As String, ByVal PASS As String) As E_Login2
        Return DD_Data.Login2(USER, PASS)
    End Function
    Function IRIS_WEBF_00_ASPX_LOGIN_PACIENTES(ByVal RUT As String, ByVal N_ATE As Long, ByVal FECHA As Date) As List(Of E_IRIS_WEBF_00_ASPX_LOGIN_PACIENTES)
        Return DD_Data.IRIS_WEBF_00_ASPX_LOGIN_PACIENTES(RUT, N_ATE, FECHA)
    End Function

    Function IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(ByVal USER As String, ByVal PASS As String) As E_Login2
        Return DD_Data.IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(USER, PASS)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
        Dim xItem As E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
        xItem = DD_Data.IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER(ID_USER)

        Return xItem
    End Function
End Class