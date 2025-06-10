Public Class E_GrupoPesquisa

    Private E_ID_GRUPO_PESQUISA As Integer
    Private E_GRUPO_PESQUISA_COD As String
    Private E_GRUPO_PESQUISA_DESC As String
    Private E_ID_TIPO_PESQUISA As Integer
    Private E_ID_ESTADO As Integer

    Public Property ID_GRUPO_PESQUISA As Integer
        Get
            Return E_ID_GRUPO_PESQUISA
        End Get
        Set(value As Integer)
            E_ID_GRUPO_PESQUISA = value
        End Set
    End Property

    Public Property GRUPO_PESQUISA_COD As String
        Get
            Return E_GRUPO_PESQUISA_COD
        End Get
        Set(value As String)
            E_GRUPO_PESQUISA_COD = value
        End Set
    End Property

    Public Property GRUPO_PESQUISA_DESC As String
        Get
            Return E_GRUPO_PESQUISA_DESC
        End Get
        Set(value As String)
            E_GRUPO_PESQUISA_DESC = value
        End Set
    End Property

    Public Property ID_TIPO_PESQUISA As Integer
        Get
            Return E_ID_TIPO_PESQUISA
        End Get
        Set(value As Integer)
            E_ID_TIPO_PESQUISA = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
End Class
