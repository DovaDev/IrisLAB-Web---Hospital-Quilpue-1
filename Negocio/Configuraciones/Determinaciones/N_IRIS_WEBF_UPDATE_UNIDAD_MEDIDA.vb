'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_UNIDAD_MEDIDA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_UNIDAD_MEDIDA
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_UNIDAD_MEDIDA
    End Sub
    Function IRIS_WEBF_UPDATE_UNIDAD_MEDIDA(ByVal ID_UM As Integer, ByVal UM_COD As String, ByVal UM_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_UNIDAD_MEDIDA(ID_UM, UM_COD, UM_DES, ID_ESTADO)
    End Function
End Class