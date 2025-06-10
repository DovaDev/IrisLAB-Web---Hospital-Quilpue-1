'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER
    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER(ByVal ID_ATE As Integer) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_DIR = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_FONO1 = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_MOVIL1 = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PAC_EMAIL = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PAC_OBS_PERMA = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.COM_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.CIU_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
