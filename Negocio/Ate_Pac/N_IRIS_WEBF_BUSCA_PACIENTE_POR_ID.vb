﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PACIENTE_POR_ID
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PACIENTE_POR_ID
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PACIENTE_POR_ID
    End Sub
    Function IRIS_WEBF_BUSCA_PACIENTE_POR_ID(ByVal ID_PAC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_ID)
        Return DD_Data.IRIS_WEBF_BUSCA_PACIENTE_POR_ID(ID_PAC)
    End Function
End Class