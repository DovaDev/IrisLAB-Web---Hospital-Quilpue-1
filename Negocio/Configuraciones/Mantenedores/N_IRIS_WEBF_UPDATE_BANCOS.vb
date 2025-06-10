'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_BANCOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_BANCOS
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_BANCOS
    End Sub
    Function IRIS_WEBF_UPDATE_BANCOS(ByVal ID_BAN As Integer, ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_BANCOS(ID_BAN, BAN_COD, BAN_DES, ID_ESTADO)
    End Function
    Function IRIS_WEBF_UPDATE_PROGRAMA(ByVal ID_BAN As Integer, ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PROGRAMA(ID_BAN, BAN_COD, BAN_DES, ID_ESTADO)
    End Function
    Function IRIS_WEBF_UPDATE_DIAGNOSTICO(ByVal ID_BAN As Integer, ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_DIAGNOSTICO(ID_BAN, BAN_COD, BAN_DES, ID_ESTADO)
    End Function

    Function IRIS_WEBF_UPDATE_SUBPROGRAMA(ByVal ID_BAN As Integer, ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_SUBPROGRAMA(ID_BAN, BAN_COD, BAN_DES, ID_ESTADO)
    End Function
End Class