﻿Imports Entidades
Imports Datos
Public Class N_IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL
    Dim DD_Data As D_IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL
    Sub New()
        DD_Data = New D_IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL
    End Sub
    Function IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL(ByVal ID_ANA As Long, ByVal ID_DET As Long) As Integer
        Return DD_Data.IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL(ID_ANA, ID_DET)
    End Function
End Class
