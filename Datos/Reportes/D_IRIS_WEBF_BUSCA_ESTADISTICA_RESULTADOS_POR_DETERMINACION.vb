'Importar Capas
Imports Entidades
Imports System.Collections.Generic

'Importar Funciones
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION
    Shared Function IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION(desde As Date,
                                                                             hasta As Date,
                                                                             idProcedencia As Integer,
                                                                             idPrevision As Integer,
                                                                             idCodigoFonasa As Integer,
                                                                             idDeterminacion As Integer) As List(Of E_ESTADISTICA_RESULTADOS_POR_DETERMINACION)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_List As New List(Of E_ESTADISTICA_RESULTADOS_POR_DETERMINACION)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.VarChar).Value = desde
            .Add("@HASTA", OleDbType.VarChar).Value = hasta
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = idProcedencia
            .Add("@ID_PREVISION", OleDbType.Numeric).Value = idPrevision
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = idCodigoFonasa
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = idDeterminacion
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
            Dim E_Proc_Item = New E_ESTADISTICA_RESULTADOS_POR_DETERMINACION
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.NOMBRE_COMPLETO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
