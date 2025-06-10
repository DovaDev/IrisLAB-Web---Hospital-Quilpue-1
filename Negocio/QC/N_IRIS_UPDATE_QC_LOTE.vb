Imports Entidades
Imports Datos
Public Class N_IRIS_UPDATE_QC_LOTE
    Dim DD_Data As D_IRIS_UPDATE_QC_LOTE
    Sub New()
        DD_Data = New D_IRIS_UPDATE_QC_LOTE
    End Sub
    Function IRIS_UPDATE_QC_LOTE(ByVal ID_LOTE As Long,
                                 ByVal LOTE_COD As String,
                                 ByVal LOTE_DES As String,
                                 ByVal ID_ESTADO As Integer,
                                 ByVal ID_ANA As Integer,
                                 ByVal ID_FECHA As String,
                                 ByVal CONTROL_ANA As String,
                                 ByVal NIVEL As Long) As Integer

        Return DD_Data.IRIS_UPDATE_QC_LOTE(ID_LOTE, LOTE_COD, LOTE_DES, ID_ESTADO, ID_ANA, ID_FECHA, CONTROL_ANA, NIVEL)
    End Function
End Class
