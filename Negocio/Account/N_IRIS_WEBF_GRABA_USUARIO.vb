'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_USUARIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_USUARIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_USUARIO
    End Sub

    Function IRIS_WEBF_GRABA_USUARIO(ByVal USU_RUT As String,
                                        ByVal NOMBRE_USU As String,
                                        ByVal APE_USU As String,
                                        ByVal FNAC_USU As Date,
                                        ByVal DIR_USU As String,
                                        ByVal EMAIL_USU As String,
                                        ByVal ID_EST_USU As Integer,
                                        ByVal ID_CIU_COM As Integer,
                                        ByVal ID_PRO_USU As Integer,
                                        ByVal ID_CAR_USU As Integer,
                                        ByVal USUARIO As String,
                                        ByVal PASS As String,
                                        ByVal FONO As String,
                                        ByVal MOVIL As String,
                                        ByVal USU_ADMIN As Integer,
                                        ByVal USU_TM As Integer) As Integer

        Return DD_Data.IRIS_WEBF_GRABA_USUARIO(USU_RUT, NOMBRE_USU, APE_USU, FNAC_USU, DIR_USU, EMAIL_USU, ID_EST_USU, ID_CIU_COM, ID_PRO_USU, ID_CAR_USU, USUARIO, PASS, FONO, MOVIL, USU_ADMIN, USU_TM)

    End Function
End Class