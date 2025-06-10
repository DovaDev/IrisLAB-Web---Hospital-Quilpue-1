Imports Entidades
Imports Datos
Public Class N_IRIS_GRABA_QC_LOTE_DE_MUESTRA
    Dim DD_Data As D_IRIS_GRABA_QC_LOTE_DE_MUESTRA
    Sub New()
        DD_Data = New D_IRIS_GRABA_QC_LOTE_DE_MUESTRA
    End Sub
    Function IRIS_GRABA_QC_LOTE_DE_MUESTRA(ByVal AREA_COD As String,
                                                  ByVal AREA_DES As String,
                                                  ByVal ID_ESTADO As Integer,
                                                  ByVal ID_ANA As Integer,
                                                  ByVal EXP As String) As Integer
        Return DD_Data.IRIS_GRABA_QC_LOTE_DE_MUESTRA(AREA_COD, AREA_DES, ID_ESTADO, ID_ANA, EXP)
    End Function
    Function IRIS_GRABA_QC_LOTE_DE_MUESTRA_(ByVal AREA_COD As String,
                                                  ByVal AREA_DES As String,
                                                  ByVal ID_ESTADO As Integer,
                                                  ByVal ID_ANA As Integer,
                                                  ByVal EXP As String,
                                                  ByVal CONTROL_ANA As String,
                                                  ByVal NIVEL As Long) As Integer
        Return DD_Data.IRIS_GRABA_QC_LOTE_DE_MUESTRA_(AREA_COD, AREA_DES, ID_ESTADO, ID_ANA, EXP, CONTROL_ANA, NIVEL)
    End Function
End Class
