Public Class E_IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA
    Dim EE_CB_DESC As String
    Dim EE_Expr1 As String
    Dim EE_T_MUESTRA_COD As String
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_ID_ESTADO As Integer

    Public Property CB_DESC As String
        Get
            Return EE_CB_DESC
        End Get
        Set(value As String)
            EE_CB_DESC = value
        End Set
    End Property

    Public Property Expr1 As String
        Get
            Return EE_Expr1
        End Get
        Set(value As String)
            EE_Expr1 = value
        End Set
    End Property

    Public Property T_MUESTRA_COD As String
        Get
            Return EE_T_MUESTRA_COD
        End Get
        Set(value As String)
            EE_T_MUESTRA_COD = value
        End Set
    End Property

    Public Property T_MUESTRA_DESC As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(value As String)
            EE_T_MUESTRA_DESC = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
