﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO(ID_USU)

    End Function
End Class