'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO
    End Sub

    Function IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO(ByVal FOLIO As Integer, ByVal ID_CF As Integer, ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO(FOLIO, ID_CF, ID_ATE, ID_USUARIO)

    End Function
End Class
