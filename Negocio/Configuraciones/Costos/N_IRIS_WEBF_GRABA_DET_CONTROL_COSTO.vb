Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_DET_CONTROL_COSTO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_DET_CONTROL_COSTO
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_DET_CONTROL_COSTO
    End Sub
    Function IRIS_WEBF_GRABA_DET_CONTROL_COSTO(ByVal ID_CONTROL As Integer, ByVal ID_COSTO As Integer, ByVal PRECIO As Integer, ByVal ID_USUARIO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DET_CONTROL_COSTO(ID_CONTROL, ID_COSTO, PRECIO, ID_USUARIO)
    End Function
End Class
