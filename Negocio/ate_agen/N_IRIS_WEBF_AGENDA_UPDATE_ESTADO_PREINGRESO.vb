'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
    Sub New()
        DD_Data = New D_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
    End Sub
    Function IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(ByVal ID_PRE As Integer, ByVal ID_ATE As Integer) As Integer
        Return DD_Data.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(ID_PRE, ID_ATE)
    End Function
End Class