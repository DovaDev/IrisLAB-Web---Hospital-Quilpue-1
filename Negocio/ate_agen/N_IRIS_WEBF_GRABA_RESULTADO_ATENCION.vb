'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_RESULTADO_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_RESULTADO_ATENCION
    End Sub
    Function IRIS_WEBF_GRABA_RESULTADO_ATENCION(ByVal ID_ATE As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_DET_ATE As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATE, ID_CF, ID_PER, ID_PRUEBA, ID_DET_ATE)
    End Function

    Function IRIS_WEBF_GRABA_RESULTADO_ATENCION_ANATO(ByVal ID_ATE As Integer, ByVal SITIO_ANATO As String, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_DET_ATE As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_RESULTADO_ATENCION_ANATO(ID_ATE, SITIO_ANATO, ID_CF, ID_PER, ID_PRUEBA, ID_DET_ATE)
    End Function
    Function IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(ByVal ID_ATE As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_PRUEBA As Integer, ByVal Defecto As String, ByVal ID_DET_ATE As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(ID_ATE, ID_CF, ID_PER, ID_PRUEBA, Defecto, ID_DET_ATE)
    End Function
End Class