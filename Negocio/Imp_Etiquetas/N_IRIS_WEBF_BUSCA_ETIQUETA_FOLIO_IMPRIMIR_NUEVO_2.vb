﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2
    End Sub
    Function IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2(NUM_ATE)
    End Function
End Class