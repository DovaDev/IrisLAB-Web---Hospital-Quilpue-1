Imports Datos
Imports Entidades
Public Class N_IRIS_UPDATE_QC_ANALIZADOR
    Dim DD_Data As D_IRIS_UPDATE_QC_ANALIZADOR
    Sub New()
        DD_Data = New D_IRIS_UPDATE_QC_ANALIZADOR
    End Sub
    Function IRIS_UPDATE_QC_ANALIZADOR(ByVal ID_AREA As Long,
                                      ByVal AREA_COD As String,
                                      ByVal AREA_DES As String,
                                      ByVal ID_ESTADO As Integer,
                                      ByVal ID_SECCION As Integer) As Integer
        Return DD_Data.IRIS_UPDATE_QC_ANALIZADOR(ID_AREA, AREA_COD, AREA_DES, ID_ESTADO, ID_SECCION)
    End Function
End Class
