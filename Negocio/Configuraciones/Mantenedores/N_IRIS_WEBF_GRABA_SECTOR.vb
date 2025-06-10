'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_SECTOR
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_SECTOR
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_SECTOR
    End Sub
    Function IRIS_WEBF_GRABA_SECTOR(ByVal BAN_COD As String, ByVal BAN_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_SECTOR(BAN_COD, BAN_DES, ID_ESTADO)
    End Function
End Class
