'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_PACIENTES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PACIENTES
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PACIENTES
    End Sub
    Function IRIS_WEBF_UPDATE_PACIENTES(ByVal ID_PAC As Integer, ByVal RUT_PAC As String, ByVal NOMBRE_PAC As String, ByVal APE_PAC As String, ByVal ID_SEXO As Integer, ByVal FNAC_PAC As Date, ByVal ID_NACIONALIDAD As Integer, ByVal DIR_PAC As String, ByVal ID_CIU_COM As Integer, ByVal FONO1 As String, ByVal FONO2 As String, ByVal MOVIL1 As String, ByVal MOVIL2 As String, ByVal EMAIL_PAC As String, ByVal ID_DIAGNOSTICO As Integer, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PACIENTES(ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, ID_SEXO, FNAC_PAC, ID_NACIONALIDAD, DIR_PAC, ID_CIU_COM, FONO1, FONO2, MOVIL1, MOVIL2, EMAIL_PAC, ID_DIAGNOSTICO, ID_ESTADO)
    End Function
    Function IRIS_WEBF_UPDATE_PACIENTES_DNI(ByVal ID_PAC As Integer, ByVal RUT_PAC As String, ByVal DNI_PAC As String, ByVal NOMBRE_PAC As String, ByVal APE_PAC As String, ByVal ID_SEXO As Integer, ByVal FNAC_PAC As Date, ByVal ID_NACIONALIDAD As Integer, ByVal DIR_PAC As String, ByVal ID_CIU_COM As Integer, ByVal FONO1 As String, ByVal FONO2 As String, ByVal MOVIL1 As String, ByVal MOVIL2 As String, ByVal EMAIL_PAC As String, ByVal ID_DIAGNOSTICO As Integer, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PACIENTES_DNI(ID_PAC, RUT_PAC, DNI_PAC, NOMBRE_PAC, APE_PAC, ID_SEXO, FNAC_PAC, ID_NACIONALIDAD, DIR_PAC, ID_CIU_COM, FONO1, FONO2, MOVIL1, MOVIL2, EMAIL_PAC, ID_DIAGNOSTICO, ID_ESTADO)
    End Function
End Class