Imports System.Collections.Generic
Imports Datos
Imports Entidades
Public Class N_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB
    'Declaraciones Generales
    Dim DD_Data As D_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB

    Sub New()
        DD_Data = New D_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB
    End Sub

    Function EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB(ByVal PREI_NUM As String) As List(Of E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB)
        Return DD_Data.EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB(PREI_NUM)
    End Function
End Class