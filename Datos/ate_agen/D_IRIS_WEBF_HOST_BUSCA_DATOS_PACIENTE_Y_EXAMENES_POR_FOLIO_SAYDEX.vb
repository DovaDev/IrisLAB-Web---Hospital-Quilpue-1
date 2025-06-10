'Importar Capas
Imports conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX(ByVal FOLIO As Integer) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.numeric).Value = FOLIO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX

            E_Proc_Item.Id_integracion = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.Orden = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.Nombres = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.Apellidos = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.Rut = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.Sexo = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)

            Dim re As String = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            Dim arr_date As New List(Of String)
            arr_date.Add(Mid(re, 1, 4))
            arr_date.Add(Mid(re, 5, 2))
            arr_date.Add(Mid(re, 7, 2))

            E_Proc_Item.F_Nacimiento = strToDate(CInt(arr_date(0)), CInt(arr_date(1)), CInt(arr_date(2)))


            E_Proc_Item.Telefono = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.Mail = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)

            E_Proc_Item.F_Atencion = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)

            E_Proc_Item.Rut_medico = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.Nombre_Medico = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.Apellido_Medico = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.Servicio_Codigo = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.Cod_Procedencia = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.Examen_Codigo = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.Examen_Descripcion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.Fecha_Registro = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.Prevision = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.Diagnostico = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.Estado = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.Proc_interfaz = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_SAYDEX(ByVal RUT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_SAYDEX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = RUT
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX

            E_Proc_Item.Id_integracion = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.Orden = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.Nombres = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.Apellidos = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.Rut = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.Sexo = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)

            Dim re As String = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            Dim arr_date As New List(Of String)
            arr_date.Add(Mid(re, 1, 4))
            arr_date.Add(Mid(re, 5, 2))
            arr_date.Add(Mid(re, 7, 2))

            E_Proc_Item.F_Nacimiento = strToDate(CInt(arr_date(0)), CInt(arr_date(1)), CInt(arr_date(2)))


            E_Proc_Item.Telefono = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.Mail = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)

            E_Proc_Item.F_Atencion = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)

            E_Proc_Item.Rut_medico = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.Nombre_Medico = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.Apellido_Medico = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.Servicio_Codigo = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.Cod_Procedencia = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.Examen_Codigo = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.Examen_Descripcion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.Fecha_Registro = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.Prevision = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.Diagnostico = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.Estado = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.Proc_interfaz = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_HOST_BUSCA_PACIENTE_SIN_RUT_SAYDEX() As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_HOST_BUSCA_PACIENTE_SIN_RUT_SAYDEX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX

            E_Proc_Item.Orden = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.Nombres = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.Apellidos = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.Rut = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.Estado = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    '''<summary>
    '''Función que transforma una serie de números a una variable tipo Date
    '''</summary>
    '''<param name="nYear">Entregar un número tipo Long con el año (no se aceptan ceros).</param>
    '''<param name="nMonth">Entregar un número tipo Integer con el mes (no se aceptan ceros).</param>
    '''<param name="nDay">Entregar un número tipo Integer con el día (no se aceptan ceros).</param>
    '''<returns></returns>
    '''<remarks></remarks>
    Public Function strToDate(ByVal nYear As Long, ByVal nMonth As Integer, ByVal nDay As Integer, Optional ByVal nHour As Integer = 0, Optional ByVal nMin As Integer = 0, Optional ByVal nSec As Integer = 0) As Date
        Dim nDate As New Date
        nDate = nDate.AddYears(CInt(nYear) - 1)
        nDate = nDate.AddMonths(CInt(nMonth) - 1)
        nDate = nDate.AddDays(CInt(nDay) - 1)

        nDate = nDate.AddHours(nHour)
        nDate = nDate.AddMinutes(nMin)
        nDate = nDate.AddSeconds(nSec)

        Return nDate
    End Function
End Class
