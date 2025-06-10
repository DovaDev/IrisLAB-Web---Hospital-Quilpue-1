'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_USUARIOS_CONVENIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_USUARIOS_CONVENIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_USUARIOS_CONVENIO
    End Sub

    Function IRIS_WEBF_GRABA_USUARIOS_CONVENIO(ByVal ID_USU As Integer,
                                               ByVal USU_CONV_NIC As String,
                                               ByVal USU_CONV_PASS As String,
                                               ByVal USU_CONV_NOMBRE As String,
                                               ByVal USU_CONV_APELLIDO As String,
                                               ByVal USU_RUT As String,
                                               ByVal USU_DIR As String,
                                               ByVal USU_FONO As String,
                                               ByVal USU_MOVIL As String,
                                               ByVal USU_EMAIL As String,
                                               ByVal ID_ESTADO As Integer,
                                               ByVal ID_LAB As Integer,
                                               ByVal ID_PREVE As Integer,
                                               ByVal ID_PREVE2 As Integer,
                                               ByVal ID_PROCEDENCIA As Integer) As Integer

        Return DD_Data.IRIS_WEBF_GRABA_USUARIOS_CONVENIO(ID_USU,
                                                         USU_CONV_NIC,
                                                         USU_CONV_PASS,
                                                         USU_CONV_NOMBRE,
                                                         USU_CONV_APELLIDO,
                                                         USU_RUT,
                                                         USU_DIR,
                                                         USU_FONO,
                                                         USU_MOVIL,
                                                         USU_EMAIL,
                                                         ID_ESTADO,
                                                         ID_LAB,
                                                         ID_PREVE,
                                                         ID_PREVE2,
                                                         ID_PROCEDENCIA)

    End Function
End Class