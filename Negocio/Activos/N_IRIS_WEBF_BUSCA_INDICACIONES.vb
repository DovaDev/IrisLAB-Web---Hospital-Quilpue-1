﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_INDICACIONES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_INDICACIONES
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_INDICACIONES
    End Sub
    Function IRIS_WEBF_BUSCA_INDICACIONES() As List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        Return DD_Data.IRIS_WEBF_BUSCA_INDICACIONES()
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS(ByVal ID_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS(ID_FONASA)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL(ByVal ID_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL(ID_FONASA)
    End Function

    Function IRIS_WEBF_AGREGA_INDICACIONES_FONASA(ByVal ID_FONASA As Integer, ByVal ARRAY_COMUNAS As Integer) As Integer
        Return DD_Data.IRIS_WEBF_AGREGA_INDICACIONES_FONASA(ID_FONASA, ARRAY_COMUNAS)
    End Function

    Function IRIS_WEBF_UPDATE_REL_INDICACION_FONASA_QUITAR_RELACION(ByVal ARRAY_COMUNAS As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_REL_INDICACION_FONASA_QUITAR_RELACION(ARRAY_COMUNAS)
    End Function

End Class
