Imports Datos
Public Class N_IRIS_WEBF_UPDATE_CONTROL_COSTOS_ELIMINA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_CONTROL_COSTOS_ELIMINA
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_CONTROL_COSTOS_ELIMINA
    End Sub
    Function IRIS_WEBF_UPDATE_CONTROL_COSTOS_ELIMINA(ByVal ID As Integer) As Integer
        Return DD_Data.IRIS_UPDATE_CONTROL_COSTOS_ELIMINA(ID)
    End Function
End Class

