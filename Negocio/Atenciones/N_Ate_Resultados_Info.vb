Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Ate_Resultados_Info
    'Declaraciones Generales
    Dim DD_Data As D_Ate_Resultados_Info

    Sub New()
        DD_Data = New D_Ate_Resultados_Info
    End Sub

    Function IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_H2M_CAMA(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3(ID_ATE)
    End Function

    Function IRIS_WEBF_RESULTADOS_PACIENTE_DATA(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        Return DD_Data.IRIS_WEBF_RESULTADOS_PACIENTE_DATA(ID_ATE)
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        Return DD_Data.IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3(ID_ATE)
    End Function
End Class