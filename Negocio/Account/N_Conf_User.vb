Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Conf_User
    'Declaraciones Generales
    Dim DD_Data As D_Conf_User

    Sub New()
        DD_Data = New D_Conf_User
    End Sub

    Function IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO() As List(Of E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO)
        Return DD_Data.IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO()
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2() As List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2()
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE(ID_USER)
    End Function

    Function IRIS_WEBF_CMVM_USER_UPDATE_STATUS(ByVal ID_USER As Long, ByVal ID_ESTADO As Boolean) As Boolean
        Dim numStat As Integer

        If (ID_ESTADO = True) Then
            numStat = 1
        Else
            numStat = 3
        End If

        Return DD_Data.IRIS_WEBF_CMVM_USER_UPDATE_STATUS(ID_USER, numStat)
    End Function

    Function IRIS_WEBF_CMVM_USER_INSERT(ByVal USU_NICK As String,
                                        ByVal ID_ROLE As Integer,
                                        ByVal USU_PASS As String,
                                        ByVal USU_FNAC As Date,
                                        ByVal USU_RUT As String,
                                        ByVal ID_PROC As Integer,
                                        ByVal ID_PREV As Integer,
                                        ByVal USU_NOMBRE As String,
                                        ByVal USU_APELLIDO As String,
                                        ByVal USU_DIR As String,
                                        ByVal USU_EMAIL As String,
                                        ByVal USU_FONO As String,
                                        ByVal USU_MOVIL As String,
                                        ByVal ID_CIUDAD As Integer,
                                        ByVal ID_COMUNA As Integer,
                                        ByVal ID_PROFESION As Integer,
                                        ByVal ID_CARGO As Integer,
                                        ByVal ID_ESTADO As Integer) As Boolean

        Return DD_Data.IRIS_WEBF_CMVM_USER_INSERT(
                                            USU_NICK,
                                            ID_ROLE,
                                            USU_PASS,
                                            USU_FNAC,
                                            USU_RUT,
                                            ID_PROC,
                                            ID_PREV,
                                            USU_NOMBRE,
                                            USU_APELLIDO,
                                            USU_DIR,
                                            USU_EMAIL,
                                            USU_FONO,
                                            USU_MOVIL,
                                            ID_CIUDAD,
                                            ID_COMUNA,
                                            ID_PROFESION,
                                            ID_CARGO,
                                            ID_ESTADO)
    End Function

    Function IRIS_WEBF_CMVM_USER_UPDATE(ByVal ID_USER As Long,
                                        ByVal USU_NICK As String,
                                        ByVal ID_ROLE As Integer,
                                        ByVal USU_PASS As String,
                                        ByVal USU_FNAC As Date,
                                        ByVal USU_RUT As String,
                                        ByVal ID_PROC As Integer,
                                        ByVal ID_PREV As Integer,
                                        ByVal USU_NOMBRE As String,
                                        ByVal USU_APELLIDO As String,
                                        ByVal USU_DIR As String,
                                        ByVal USU_EMAIL As String,
                                        ByVal USU_FONO As String,
                                        ByVal USU_MOVIL As String,
                                        ByVal ID_CIUDAD As Integer,
                                        ByVal ID_COMUNA As Integer,
                                        ByVal ID_PROFESION As Integer,
                                        ByVal ID_CARGO As Integer,
                                        ByVal ID_ESTADO As Integer) As Boolean

        Return DD_Data.IRIS_WEBF_CMVM_USER_UPDATE(
                                            ID_USER,
                                            USU_NICK,
                                            ID_ROLE,
                                            USU_PASS,
                                            USU_FNAC,
                                            USU_RUT,
                                            ID_PROC,
                                            ID_PREV,
                                            USU_NOMBRE,
                                            USU_APELLIDO,
                                            USU_DIR,
                                            USU_EMAIL,
                                            USU_FONO,
                                            USU_MOVIL,
                                            ID_CIUDAD,
                                            ID_COMUNA,
                                            ID_PROFESION,
                                            ID_CARGO,
                                            ID_ESTADO)
    End Function
End Class