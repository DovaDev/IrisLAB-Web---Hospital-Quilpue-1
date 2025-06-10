Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_MEDICOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_MEDICOS
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_MEDICOS
    End Sub
    Function IRIS_WEBF_UPDATE_MEDICOS(ByVal ID_DOC As Integer,
                                     ByVal RUT_DOC As String,
                                     ByVal NOMBRE_DOC As String,
                                     ByVal APE_DOC As String,
                                     ByVal ID_SEXO As Integer,
                                     ByVal FNAC_DOC As Date,
                                     ByVal ID_NACIONALIDAD As Integer,
                                     ByVal DIR_DOC As String,
                                     ByVal ID_CIU_COM As Integer,
                                     ByVal FONO1 As String,
                                     ByVal FONO2 As String,
                                     ByVal MOVIL1 As String,
                                     ByVal MOVIL2 As String,
                                     ByVal EMAIL_DESC As String,
                                     ByVal ID_ESPECIALIDAD As Integer,
                                     ByVal ID_ESTADO As Integer) As Integer

        Return DD_Data.IRIS_WEBF_UPDATE_MEDICOS(ID_DOC, RUT_DOC, NOMBRE_DOC, APE_DOC, ID_SEXO, FNAC_DOC, ID_NACIONALIDAD, DIR_DOC, ID_CIU_COM, FONO1, FONO2, MOVIL1, MOVIL2, EMAIL_DESC, ID_ESPECIALIDAD, ID_ESTADO)
    End Function
End Class