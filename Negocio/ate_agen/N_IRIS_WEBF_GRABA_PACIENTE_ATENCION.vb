'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PACIENTE_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PACIENTE_ATENCION
    End Sub
    Function IRIS_WEBF_GRABA_PACIENTE_ATENCION(ByVal RUT_PAC As String,
                                               ByVal NOMBRE_PAC As String,
                                               ByVal APE_PAC As String,
                                               ByVal FNAC_PAC As Date,
                                               ByVal ID_SEXO As Integer,
                                               ByVal ID_NACIONALIDAD As Integer,
                                               ByVal FONO1 As String,
                                               ByVal MOVIL1 As String,
                                               ByVal ID_CIU_COM As Integer,
                                               ByVal DIR_PAC As String,
                                               ByVal EMAIL_PAC As String,
                                               ByVal ID_DIAGNOSTICO As Integer,
                                               ByVal OBS_PER As String,
                                               ByVal ID_ESTADO As String,
                                               ByVal dni As String,
                                               ByVal ID_ETNIA As Integer,
                                               ByVal PAC_NOM_SOCIAL As String
                                                ) As String
        'Checar Galletas) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PACIENTE_ATENCION(RUT_PAC, NOMBRE_PAC, APE_PAC, FNAC_PAC, ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, ID_DIAGNOSTICO, OBS_PER, ID_ESTADO, dni, ID_ETNIA, PAC_NOM_SOCIAL)
    End Function

    Function IRIS_WEBF_GRABA_PACIENTE_ATENCION_GENERO(ByVal RUT_PAC As String,
                                               ByVal NOMBRE_PAC As String,
                                               ByVal APE_PAC As String,
                                               ByVal FNAC_PAC As Date,
                                               ByVal ID_SEXO As Integer,
                                               ByVal ID_GENERO As Integer,
                                               ByVal ID_NACIONALIDAD As Integer,
                                               ByVal FONO1 As String,
                                               ByVal MOVIL1 As String,
                                               ByVal ID_CIU_COM As Integer,
                                               ByVal DIR_PAC As String,
                                               ByVal EMAIL_PAC As String,
                                               ByVal ID_DIAGNOSTICO As Integer,
                                               ByVal OBS_PER As String,
                                               ByVal ID_ESTADO As String,
                                               ByVal dni As String,
                                               ByVal ID_ETNIA As Integer,
                                               ByVal PAC_NOM_SOCIAL As String,
                                               ByVal IS_NEO As Integer
                                                ) As String
        'Checar Galletas) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PACIENTE_ATENCION_GENERO(RUT_PAC, NOMBRE_PAC, APE_PAC, FNAC_PAC, ID_SEXO, ID_GENERO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, ID_DIAGNOSTICO, OBS_PER, ID_ESTADO, dni, ID_ETNIA, PAC_NOM_SOCIAL, IS_NEO)
    End Function

    Function IRIS_WEBF_GRABA_PACIENTE_VIH_ATE(ByVal RUT_PAC As String,
                                               ByVal NOMBRE_PAC As String,
                                               ByVal APE_PAC As String,
                                               ByVal FNAC_PAC As Date,
                                               ByVal ID_SEXO As Integer,
                                               ByVal ID_NACIONALIDAD As Integer,
                                               ByVal FONO1 As String,
                                               ByVal MOVIL1 As String,
                                               ByVal ID_CIU_COM As Integer,
                                               ByVal DIR_PAC As String,
                                               ByVal EMAIL_PAC As String,
                                               ByVal ID_DIAGNOSTICO As Integer,
                                               ByVal OBS_PER As String,
                                               ByVal ID_ESTADO As String,
                                               ByVal dni As String,
                                               ByVal ID_ETNIA As Integer,
                                               ByVal PAC_NOM_SOCIAL As String
                                                ) As String
        'Checar Galletas) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PACIENTE_VIH_ATE(RUT_PAC, NOMBRE_PAC, APE_PAC, FNAC_PAC, ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, ID_DIAGNOSTICO, OBS_PER, ID_ESTADO, dni, ID_ETNIA, PAC_NOM_SOCIAL)
    End Function

End Class