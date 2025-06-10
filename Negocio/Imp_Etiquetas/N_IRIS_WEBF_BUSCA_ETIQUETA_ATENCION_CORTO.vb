'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO
    End Sub
    Function IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO(ByVal ATE_NUM As String, ByVal CB As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO(ATE_NUM, CB)
    End Function
End Class