'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6(ByVal ID_USU As Integer, ByVal NUM_CURVA As String, ByVal NUM_FOLIO As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6(ID_USU, NUM_CURVA, NUM_FOLIO)

    End Function
End Class