Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_historial
    'Declaraciones Generales
    Dim DD_Data As D_historial

    Sub New()
        DD_Data = New D_historial
    End Sub

    Function IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA)
        Return DD_Data.IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA(ID_ATE, ID_CODIGO_FONASA)
    End Function

    Function IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ByVal ID_ATE As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal TOT_ANT As Integer,
                                                            ByVal COP_ANT As Integer,
                                                            ByVal PRE_ANT As Integer,
                                                            ByVal PRE_NV As Integer,
                                                            ByVal COP_NV As Integer,
                                                            ByVal TOT_NV As Integer,
                                                            ByVal TOT_FIN As Integer,
                                                            ByVal ID_EST As Integer,
                                                            ByVal ID_USU As Integer) As Integer

        Return DD_Data.IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ID_ATE,
                                                                      ID_CF,
                                                                      TOT_ANT,
                                                                      COP_ANT,
                                                                      PRE_ANT,
                                                                      PRE_NV,
                                                                      COP_NV,
                                                                      TOT_NV,
                                                                      TOT_FIN,
                                                                      ID_EST,
                                                                      ID_USU)
    End Function


    Function IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2(ByVal ID_ATE As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2)
        Return DD_Data.IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2(ID_ATE)
    End Function
End Class