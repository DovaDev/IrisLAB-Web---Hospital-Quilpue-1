﻿Imports Entidades
Imports Datos
Public Class N_IRIS_GRABA_QC_ANALITO
    Dim DD_Data As D_IRIS_GRABA_QC_ANALITO
    Sub New()
        DD_Data = New D_IRIS_GRABA_QC_ANALITO
    End Sub
    Function IRIS_GRABA_QC_ANALITO(ByVal AREA_COD As String,
                                     ByVal AREA_DES As String,
                                     ByVal ID_ESTADO As Integer,
                                     ByVal ID_U_MEDIDA As Integer) As Integer
        Return DD_Data.IRIS_GRABA_QC_ANALITO(AREA_COD, AREA_DES, ID_ESTADO, ID_U_MEDIDA)
    End Function
End Class
