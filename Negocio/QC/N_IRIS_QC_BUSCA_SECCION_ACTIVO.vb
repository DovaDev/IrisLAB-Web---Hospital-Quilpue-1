﻿Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_SECCION_ACTIVO
    Dim DD_Data As D_IRIS_QC_BUSCA_SECCION_ACTIVO
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_SECCION_ACTIVO
    End Sub
    Function IRIS_QC_BUSCA_SECCION_ACTIVO() As List(Of E_IRIS_QC_BUSCA_SECCION_ACTIVO)
        Return DD_Data.IRIS_QC_BUSCA_SECCION_ACTIVO()
    End Function
End Class
