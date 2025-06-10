'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
    End Sub
    Function IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP(ByVal ID_ATE As Integer, ByVal ID_ATE_DOCP As Integer, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP(ID_ATE, ID_ATE_DOCP, ID_ESTADO)
    End Function
End Class