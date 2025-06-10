'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Registrar
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_EXCEL(ByVal num As String,
                                ByVal codBarra As String,
                                ByVal establecimientoContenedor As String,
                                ByVal cajaTrans As String,
                                ByVal fechaIngreso As String,
                                ByVal muesRecep As String,
                                ByVal MuesEnv As String,
                                ByVal folioHojaTrabajo As String,
                                ByVal FechaEnvio As String,
                                ByVal fechaRecepcion As String,
                                ByVal fechaValidacion As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Definiendo tipo de consulta a la DB
        Cmd_SQL.CommandType = CommandType.StoredProcedure
        Cmd_SQL.CommandText = "IRIS_WEBF_GRABA_EXCEL"
        Cmd_SQL.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@num", OleDbType.VarChar).Value = num
            .Add("@codBarra", OleDbType.VarChar).Value = codBarra
            .Add("@establecimientoContenedor", OleDbType.VarChar).Value = establecimientoContenedor
            .Add("@cajaTrans", OleDbType.VarChar).Value = cajaTrans
            .Add("@fechaIngreso", OleDbType.Date).Value = CDate(fechaIngreso)
            .Add("@muesRecep", OleDbType.VarChar).Value = muesRecep
            .Add("@MuesEnv", OleDbType.VarChar).Value = MuesEnv
            .Add("@folioHojaTrabajo", OleDbType.VarChar).Value = folioHojaTrabajo
            .Add("@FechaEnvio", OleDbType.Date).Value = CDate(FechaEnvio)
            .Add("@fechaRecepcion", OleDbType.Date).Value = CDate(fechaRecepcion)
            .Add("@fechaValidacion", OleDbType.Date).Value = CDate(fechaValidacion)

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_GRABA_TRAZA_RESIDUOS(ByVal FOLIO As String,
                                   ByVal FECHA As Date,
                                   ByVal ID_SECCION As Integer,
                                   ByVal ID_TP_RESIDUO As Integer,
                                   ByVal BOLSA_CONTENEDOR As String,
                                   ByVal KILOS_RESIDUO As String,
                                   ByVal RESPONSABLE As String,
                                   ByVal ID_PROCEDENCIA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Definiendo tipo de consulta a la DB
        Cmd_SQL.CommandType = CommandType.StoredProcedure
        Cmd_SQL.CommandText = "IRIS_WEBF_GRABA_TRAZA_RESIDUOS"
        Cmd_SQL.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_TP_RESIDUO", OleDbType.Numeric).Value = ID_TP_RESIDUO
            .Add("@BOLSA_CONTENEDOR", OleDbType.VarChar).Value = BOLSA_CONTENEDOR
            .Add("@KILOS_RESIDUO", OleDbType.VarChar).Value = KILOS_RESIDUO
            .Add("@RESPONSABLE", OleDbType.VarChar).Value = RESPONSABLE
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql

    End Function
    Function IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS(ByVal ID_REG As Integer, ByVal NUM_AVIS As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Definiendo tipo de consulta a la DB
        Cmd_SQL.CommandType = CommandType.StoredProcedure
        Cmd_SQL.CommandText = "IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS"
        Cmd_SQL.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_REG", OleDbType.Integer).Value = ID_REG
            .Add("@NUM_AVIS", OleDbType.Integer).Value = NUM_AVIS

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_GRABA_EXCEL_CONTENEDOR_ENVIO(ByVal num As String,
                              ByVal codBarra As String,
                              ByVal establecimientoContenedor As String,
                              ByVal cajaTrans As String,
                              ByVal Contenedor_Envio As String,
                              ByVal fechaIngreso As String,
                              ByVal muesRecep As String,
                              ByVal MuesEnv As String,
                              ByVal folioHojaTrabajo As String,
                              ByVal FechaEnvio As String,
                              ByVal fechaRecepcion As String,
                              ByVal fechaValidacion As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Definiendo tipo de consulta a la DB
        Cmd_SQL.CommandType = CommandType.StoredProcedure
        Cmd_SQL.CommandText = "IRIS_WEBF_GRABA_EXCEL_CONTENEDOR_ENVIO"
        Cmd_SQL.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@num", OleDbType.VarChar).Value = num
            .Add("@codBarra", OleDbType.VarChar).Value = codBarra
            .Add("@establecimientoContenedor", OleDbType.VarChar).Value = establecimientoContenedor
            .Add("@cajaTrans", OleDbType.VarChar).Value = cajaTrans
            .Add("@contenedorEnvio", OleDbType.VarChar).Value = Contenedor_Envio
            .Add("@fechaIngreso", OleDbType.Date).Value = CDate(fechaIngreso)
            .Add("@muesRecep", OleDbType.VarChar).Value = muesRecep
            .Add("@MuesEnv", OleDbType.VarChar).Value = MuesEnv
            .Add("@folioHojaTrabajo", OleDbType.VarChar).Value = folioHojaTrabajo
            .Add("@FechaEnvio", OleDbType.Date).Value = CDate(FechaEnvio)
            .Add("@fechaRecepcion", OleDbType.Date).Value = CDate(fechaRecepcion)
            .Add("@fechaValidacion", OleDbType.Date).Value = CDate(fechaValidacion)

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_GRABA_EXCEL_2(ByVal num As String,
                              ByVal codBarra As String,
                              ByVal establecimientoContenedor As String,
                              ByVal cajaTrans As String,
                              ByVal fechaIngreso As String,
                              ByVal muesRecep As String,
                              ByVal MuesEnv As String,
                              ByVal folioHojaTrabajo As String,
                              ByVal FechaEnvio As String,
                              ByVal fechaRecepcion As String,
                              ByVal fechaValidacion As String,
                            ByVal aviiiiis As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Definiendo tipo de consulta a la DB
        Cmd_SQL.CommandType = CommandType.StoredProcedure
        Cmd_SQL.CommandText = "IRIS_WEBF_GRABA_EXCEL_2"
        Cmd_SQL.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@num", OleDbType.VarChar).Value = num
            .Add("@codBarra", OleDbType.VarChar).Value = codBarra
            .Add("@establecimientoContenedor", OleDbType.VarChar).Value = establecimientoContenedor
            .Add("@cajaTrans", OleDbType.VarChar).Value = cajaTrans
            .Add("@fechaIngreso", OleDbType.Date).Value = CDate(fechaIngreso)
            .Add("@muesRecep", OleDbType.VarChar).Value = muesRecep
            .Add("@MuesEnv", OleDbType.VarChar).Value = MuesEnv
            .Add("@folioHojaTrabajo", OleDbType.VarChar).Value = folioHojaTrabajo
            .Add("@FechaEnvio", OleDbType.Date).Value = CDate(FechaEnvio)
            .Add("@fechaRecepcion", OleDbType.Date).Value = CDate(fechaRecepcion)
            .Add("@fechaValidacion", OleDbType.Date).Value = CDate(fechaValidacion)
            .Add("@aviiiiis", OleDbType.VarChar).Value = aviiiiis

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_GRABA_TRAZA_RESIDUOS_2(ByVal FOLIO As String,
                                   ByVal FECHA As Date,
                                   ByVal ID_SECCION As Integer,
                                   ByVal ID_TP_RESIDUO As Integer,
                                   ByVal BOLSA_CONTENEDOR As String,
                                   ByVal KILOS_RESIDUO As String,
                                   ByVal RESPONSABLE As String,
                                   ByVal ID_PROCEDENCIA As Integer,
                                    ByVal SUPERVISOR As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Definiendo tipo de consulta a la DB
        Cmd_SQL.CommandType = CommandType.StoredProcedure
        Cmd_SQL.CommandText = "IRIS_WEBF_GRABA_TRAZA_RESIDUOS_2"
        Cmd_SQL.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_TP_RESIDUO", OleDbType.Numeric).Value = ID_TP_RESIDUO
            .Add("@BOLSA_CONTENEDOR", OleDbType.VarChar).Value = BOLSA_CONTENEDOR
            .Add("@KILOS_RESIDUO", OleDbType.VarChar).Value = KILOS_RESIDUO
            .Add("@RESPONSABLE", OleDbType.VarChar).Value = RESPONSABLE
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@SUPERVISOR", OleDbType.VarChar).Value = SUPERVISOR

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql

    End Function
End Class
