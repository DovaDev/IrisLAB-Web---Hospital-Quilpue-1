'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA
    End Sub

    Function IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Return DD_Data.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(ID_USU)

    End Function
End Class