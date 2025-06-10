Imports Entidades
Imports Datos
Public Class N_IRIS_UPDATE_QC_RESULTADO
    Dim DD_Data As D_IRIS_UPDATE_QC_RESULTADO
    Sub New()
        DD_Data = New D_IRIS_UPDATE_QC_RESULTADO
    End Sub
    Function IRIS_UPDATE_QC_RESULTADO(ByVal ID_TP_ACCION As Long,
                                      ByVal COMENTARIO As String,
                                      ByVal OMITIDO As Integer,
                                      ByVal ID_RESUL As Long) As Integer
        Return DD_Data.IRIS_UPDATE_QC_RESULTADO(ID_TP_ACCION, COMENTARIO, OMITIDO, ID_RESUL)
    End Function
End Class
