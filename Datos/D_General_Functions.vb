Imports System.Web
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Reflection
Imports Conexion

Public Class D_General_Functions
    'Usar en caso de que exista la posibilidad de recibir datos nulos de la DB
    Function DB_NULL(ByVal Obj_Reader_inst As OleDbDataReader, ByVal Index As Integer, Optional ByVal Default_Value As Object = Nothing) As Object
        If (IsDBNull(Obj_Reader_inst(Index)) = False) Then
            Return Obj_Reader_inst(Index)
        Else
            Return Default_Value
        End If
    End Function

    'Usar en caso de que exista la posibilidad de recibir datos nulos de la DB
    Function DB_NULL_MYSQL(ByVal Obj_Reader_inst As MySqlDataReader, ByVal Index As Integer, Optional ByVal Default_Value As Object = Nothing) As Object
        If (IsDBNull(Obj_Reader_inst(Index)) = False) Then
            Return Obj_Reader_inst(Index)
        Else
            Return Default_Value
        End If
    End Function


    Shared Function GetDataAndMapToObjectList(Of T As New)(command As SqlCommand) As List(Of T)
        Dim result As New List(Of T)()
        command.CommandTimeout = 600
        Using reader As SqlDataReader = command.ExecuteReader()
            Dim fieldNames As New HashSet(Of String)(Enumerable.Range(0, reader.FieldCount).Select(Function(i) reader.GetName(i)))

            While reader.Read()
                Dim obj As New T()
                Dim typeOfGeneric = obj.GetType()
                If obj.GetType().IsPrimitive Then
                    Dim readerValue = reader(0)
                    Dim typeOfReaderValue = readerValue.GetType()
                    If typeOfGeneric.IsAssignableFrom(typeOfReaderValue) Then
                        obj = DirectCast(readerValue, T)
                    End If
                End If
                For Each propInfo As PropertyInfo In obj.GetType().GetProperties()

                    If Not propInfo.CanWrite OrElse Not fieldNames.Contains(propInfo.Name) Then
                        Continue For
                    End If

                    Dim readerValue As Object = reader(propInfo.Name)
                    If readerValue Is DBNull.Value Then
                        Continue For
                    End If

                    Dim targetType = propInfo.PropertyType

                    If targetType.IsAssignableFrom(readerValue.GetType()) Then
                        propInfo.SetValue(obj, readerValue)
                    Else
                        Try
                            Dim parsedValue = Convert.ChangeType(readerValue, targetType)
                            propInfo.SetValue(obj, parsedValue)
                        Catch ex As Exception
                            Continue For
                        End Try
                    End If
                Next
                result.Add(obj)
            End While
        End Using

        Return result
    End Function

    Public Shared Function ExecuteReaderSP(Of T As New)(spName As String, Optional parameters As List(Of SqlParameter) = Nothing) As List(Of T)
        Using connection As New SqlConnection(ConexionBD.getConnectionString())
            connection.Open()

            Using command As New SqlCommand(spName, connection)
                With command
                    .CommandType = CommandType.StoredProcedure
                    If parameters IsNot Nothing Then
                        .Parameters.AddRange(parameters.ToArray())
                    End If
                End With

                Return D_General_Functions.GetDataAndMapToObjectList(Of T)(command)
            End Using
        End Using
    End Function

    Public Shared Function ExecuteNonQuerySP(spName As String, Optional parameters As List(Of SqlParameter) = Nothing) As Integer
        Using connection As New SqlConnection(ConexionBD.getConnectionString())
            connection.Open()

            Using command As New SqlCommand(spName, connection)
                With command
                    .CommandType = CommandType.StoredProcedure
                    If parameters IsNot Nothing Then
                        .Parameters.AddRange(parameters.ToArray())
                    End If
                End With

                Return command.ExecuteNonQuery()
            End Using
        End Using
    End Function
End Class

