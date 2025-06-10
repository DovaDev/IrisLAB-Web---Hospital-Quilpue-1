Imports Datos
Imports Entidades

Public Class N_GrupoPesquisa

    Dim D_Data As D_GrupoPesquisa

    Sub New()
        D_Data = New D_GrupoPesquisa
    End Sub
    Public Function IRIS_WEBF_BUSCA_GRUPOS_PESQUISA_ACTIVOS() As List(Of E_GrupoPesquisa)
        Return D_Data.IRIS_WEBF_BUSCA_GRUPOS_PESQUISA_ACTIVOS()
    End Function
End Class
