﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP
    End Sub

    Function IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP)
        Return DD_Data.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(NUM_ATE)

    End Function
End Class