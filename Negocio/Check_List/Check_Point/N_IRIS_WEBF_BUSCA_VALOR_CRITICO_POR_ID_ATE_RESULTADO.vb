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

Public Class N_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO
    End Sub

    Function IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO)
        Return DD_Data.IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ID_ATE_RES)
    End Function
    Function IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ByVal ID_ATE_RES As Integer,
                                                              ByVal ID_USUARIO As Integer,
                                                              ByVal DET_CRITICO_DESC As String,
                                                              ByVal ID_TP_CRITICO As Integer,
                                                              ByVal FECHA As Date,
                                                              ByVal CAUSA As String) As Integer

        Return DD_Data.IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ID_ATE_RES, ID_USUARIO, DET_CRITICO_DESC, ID_TP_CRITICO, FECHA, CAUSA)
    End Function
    Function IRIS_WEBF_UPDATE_DET_ATENCION_ATE_RESULTADO_NOTIFICACION_AVISO(ByVal ID_ATENCION As Integer,
                                                          ByVal ID_CODIGO_FONASA As Integer,
                                                          ByVal ID_ATE_RES As Integer) As Integer

        Return DD_Data.IRIS_WEBF_UPDATE_DET_ATENCION_ATE_RESULTADO_NOTIFICACION_AVISO(ID_ATENCION, ID_CODIGO_FONASA, ID_ATE_RES)
    End Function
End Class