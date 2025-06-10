'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
    End Sub
    Function IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO()
    End Function
End Class