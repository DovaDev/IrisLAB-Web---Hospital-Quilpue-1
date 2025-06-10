'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_BANCO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_BANCO
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_BANCO
    End Sub
    Function IRIS_WEBF_GRABA_BANCO(ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_BANCO(BAN_COD, BAN_DES, ID_ESTADO)
    End Function
    Function IRIS_WEBF_GRABA_PROGRAMA(ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PROGRAMA(BAN_COD, BAN_DES, ID_ESTADO)
    End Function
    Function IRIS_WEBF_GRABA_LUGAR_TM(ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_LUGAR_TM(BAN_COD, BAN_DES, ID_ESTADO)
    End Function
    Function IRIS_WEBF_INSERT_RELACION(ByVal ID_PROCE As String, ByVal ID_PROGRAMA As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_INSERT_RELACION(ID_PROCE, ID_PROGRAMA, ID_ESTADO)
    End Function
    Function IRIS_WEBF_INSERT_RELACION_ub_preve_blablabla(ByVal ID_PRREVE As String, ByVal ID_PROGRAMA As String, ByVal ID_SUB_PROGRAMA As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_INSERT_RELACION_ub_preve_blablabla(ID_PRREVE, ID_PROGRAMA, ID_SUB_PROGRAMA, ID_ESTADO)
    End Function
    Function IRIS_WEBF_GRABA_DIAGNOSTICO(ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DIAGNOSTICO(BAN_COD, BAN_DES, ID_ESTADO)
    End Function

    Function IRIS_WEBF_GRABA_SUBPROGRAMA(ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_SUBPROGRAMA(BAN_COD, BAN_DES, ID_ESTADO)
    End Function
End Class
