'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_GrupoPesquisa
    'Declaraciones Generales
    Dim C_ConnBD As C_ConnBD
    Dim D_Gen As New D_General_Functions

    Public Function IRIS_WEBF_BUSCA_GRUPOS_PESQUISA_ACTIVOS() As List(Of E_GrupoPesquisa)
        'Declaraciones
        Dim C_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim objITem As E_GrupoPesquisa
        Dim objList As New List(Of E_GrupoPesquisa)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_GRUPOS_PESQUISA_ACTIVOS"
            .Connection = C_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datps
        Select Case C_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                C_ConnBD.Oledbconexion.Close()
            Case Else
                C_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            objITem = New E_GrupoPesquisa With {
                .ID_GRUPO_PESQUISA = D_Gen.DB_NULL(Obj_Reader, 0, 0),
                .GRUPO_PESQUISA_COD = D_Gen.DB_NULL(Obj_Reader, 1, ""),
                .GRUPO_PESQUISA_DESC = D_Gen.DB_NULL(Obj_Reader, 2, ""),
                .ID_TIPO_PESQUISA = D_Gen.DB_NULL(Obj_Reader, 3, 0),
                .ID_ESTADO = D_Gen.DB_NULL(Obj_Reader, 4, 0)
            }

            'Agregar elementos a la lista
            objList.Add(objITem)
        End While

        C_ConnBD.Oledbconexion.Close()
        Return objList
    End Function
End Class
