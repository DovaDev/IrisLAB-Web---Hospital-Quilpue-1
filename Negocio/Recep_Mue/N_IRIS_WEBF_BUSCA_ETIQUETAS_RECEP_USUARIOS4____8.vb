'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8(ByVal ID_USU As Integer, ByVal NUM_CURVA As String, ByVal NUM_FOLIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8(ID_USU, NUM_CURVA, NUM_FOLIO)

    End Function
End Class