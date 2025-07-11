﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX

    Sub New()
        DD_Data = New D_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
    End Sub

    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX(ByVal FOLIO As Integer) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        Return DD_Data.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX(FOLIO)

    End Function
    Function IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_SAYDEX(ByVal RUT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        Return DD_Data.IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_SAYDEX(RUT)

    End Function
    Function IRIS_HOST_BUSCA_PACIENTE_SIN_RUT_SAYDEX() As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        Return DD_Data.IRIS_HOST_BUSCA_PACIENTE_SIN_RUT_SAYDEX()

    End Function
End Class