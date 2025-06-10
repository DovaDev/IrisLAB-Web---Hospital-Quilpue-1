'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_USUARIO_POR_ID
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_USUARIO_POR_ID(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_USUARIO_POR_ID)

        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_USUARIO_POR_ID
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_USUARIO_POR_ID)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_USUARIO_POR_ID"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_USUARIO_POR_ID

            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.USU_PASS = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PER_USU = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.USU_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_PROFESION = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.USU_RUT = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.USU_DIR = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_REL_CIU_COM = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.USU_FONO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.USU_MOVIL = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.USU_EMAIL = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_CARGO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.USU_FNAC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_CIUDAD = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
