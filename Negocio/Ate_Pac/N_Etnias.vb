'Importar Capas
Imports System.Collections.Generic
Imports Datos
Imports Entidades
Public Class N_Etnias
    Shared Function IRIS_WEBF_BUSCA_ETNIAS_ACTIVAS() As List(Of E_Etnia)
        Return D_Etnias.IRIS_WEBF_BUSCA_ETNIAS_ACTIVAS()
    End Function
End Class
