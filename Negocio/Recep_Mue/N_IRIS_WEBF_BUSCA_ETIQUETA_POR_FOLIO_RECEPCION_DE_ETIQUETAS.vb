﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS(ByVal N_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS(N_ATE)

    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_4(ByVal N_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_4(N_ATE)

    End Function
End Class