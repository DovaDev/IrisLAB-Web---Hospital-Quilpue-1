'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO(ByVal ANO As Integer, ByVal PREVE As Integer, ByVal FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANO", OleDbType.Numeric).Value = ANO
            .Add("@PREVE", OleDbType.Numeric).Value = PREVE
            .Add("@FONASA", OleDbType.Numeric).Value = FONASA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO

            E_Proc_Item.ID_CF_PRECIO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_AÑO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_PRECIO_HOS = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_USUARIO_CREA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.CF_PRECIO_C_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_USUARIO_MOD = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.CF_PRECIO_M_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_PRECIO_M_FECHA2 = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
