'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO
    End Sub

    Function IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO(ByVal NUM As Integer, ByVal ID_USUARIO As Integer, ByVal ID_DERIV As Integer) As List(Of E_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO)
        Return DD_Data.IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO(NUM, ID_USUARIO, ID_DERIV)

    End Function
End Class
