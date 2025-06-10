'Importar Capas
Imports Conexion
Imports Entidades
Imports MySql.Data.MySqlClient
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class Ejemplo
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function UPDATE_ESTADO_TEST(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        Dim parametro_2(0) As MySqlParameter
        'Declaraciones 'lista'



        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("OMI", MySqlDbType.VarChar)
        parametro_1(0).Value = OC

        parametro_2(0) = New MySqlParameter("COD_EXAMEN", MySqlDbType.VarChar)
        parametro_2(0).Value = CODIGO_TEST

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UPDATE_ESTADO_EXAMEN"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
            .Parameters.AddRange(parametro_2)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteNonQuery


        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

    Function UPDATE_ESTADO_TEST_NULL(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_MYSQL As New MySqlCommand
        Dim parametro_1(0) As MySqlParameter
        Dim parametro_2(0) As MySqlParameter
        'Declaraciones 'lista'



        'Enviar parámetros
        parametro_1(0) = New MySqlParameter("OMI", MySqlDbType.VarChar)
        parametro_1(0).Value = OC

        parametro_2(0) = New MySqlParameter("COD_EXAMEN", MySqlDbType.VarChar)
        parametro_2(0).Value = CODIGO_TEST

        'Configuración general
        With Cmd_MYSQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UPDATE_ESTADO_EXAMEN_TO_NULL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_Penalolen
            .Parameters.AddRange(parametro_1)
            .Parameters.AddRange(parametro_2)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Connect_to_IrisLab_Penalolen.State
            Case ConnectionState.Open
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Close()
            Case Else
                CC_ConnBD.Connect_to_IrisLab_Penalolen.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_MYSQL.ExecuteNonQuery


        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function


End Class
