'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_UPDATE_USUARIOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_USUARIOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_USUARIOS
    End Sub

    Function IRIS_WEBF_UPDATE_USUARIOS(ByVal ID_USU As Integer,
                                       ByVal RUT_USU As String,
                                       ByVal NOMBRE_USU As String,
                                       ByVal APE_USU As String,
                                       ByVal FNAC_USU As Date,
                                       ByVal DIR_USU As String,
                                       ByVal EMAIL_USU As String,
                                       ByVal ID_EST_USU As Integer,
                                       ByVal ID_REL_CIU As Integer,
                                       ByVal ID_PRO_USU As Integer,
                                       ByVal ID_CAR_USU As Integer,
                                       ByVal USUARIO As String,
                                       ByVal PASS As String,
                                       ByVal ID_PER_USU As Integer,
                                       ByVal FONO As String,
                                       ByVal MOVIL As String,
                                       ByVal USU_ADMIN As Integer,
                                        ByVal USU_TM As Integer,
                                        ByVal USU_FIRMA As String) As Integer

        Return DD_Data.IRIS_WEBF_UPDATE_USUARIOS(ID_USU,
                                                 RUT_USU,
                                                 NOMBRE_USU,
                                                 APE_USU,
                                                 FNAC_USU,
                                                 DIR_USU,
                                                 EMAIL_USU,
                                                 ID_EST_USU,
                                                 ID_REL_CIU,
                                                 ID_PRO_USU,
                                                 ID_CAR_USU,
                                                 USUARIO,
                                                 PASS,
                                                 ID_PER_USU,
                                                 FONO,
                                                 MOVIL,
                                                 USU_ADMIN,
                                                 USU_TM,
                                                 USU_FIRMA)

    End Function
End Class