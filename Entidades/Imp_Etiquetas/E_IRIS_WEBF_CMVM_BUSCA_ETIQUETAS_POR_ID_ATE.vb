Public Class E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE
    Private EE_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property

    Private EE_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property

    Private EE_ATE_FECHA As Date
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Private EE_ID_PROCEDENCIA As Integer
    Public Property ID_PROCEDENCIA() As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property

    Private EE_ID_PREVE As Integer
    Public Property ID_PREVE() As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property

    Private EE_ID_CODIGO_BARRA As Integer
    Public Property ID_CODIGO_BARRA() As Integer
        Get
            Return EE_ID_CODIGO_BARRA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_BARRA = value
        End Set
    End Property

    Private EE_CB_COD As String
    Public Property CB_COD() As String
        Get
            Return EE_CB_COD
        End Get
        Set(ByVal value As String)
            EE_CB_COD = value
        End Set
    End Property

    Private EE_CB_DESC As String
    Public Property CB_DESC() As String
        Get
            Return EE_CB_DESC
        End Get
        Set(ByVal value As String)
            EE_CB_DESC = value
        End Set
    End Property

    Private EE_ID_T_MUESTRA As Long
    Public Property ID_T_MUESTRA() As Long
        Get
            Return EE_ID_T_MUESTRA
        End Get
        Set(ByVal value As Long)
            EE_ID_T_MUESTRA = value
        End Set
    End Property

    Private EE_T_MUESTRA_COD As String
    Public Property T_MUESTRA_COD() As String
        Get
            Return EE_T_MUESTRA_COD
        End Get
        Set(ByVal value As String)
            EE_T_MUESTRA_COD = value
        End Set
    End Property

    Private EE_T_MUESTRA_DESC As String
    Public Property T_MUESTRA_DESC() As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(ByVal value As String)
            EE_T_MUESTRA_DESC = value
        End Set
    End Property

    Private EE_ID_G_MUESTRA As Long
    Public Property ID_G_MUESTRA() As Long
        Get
            Return EE_ID_G_MUESTRA
        End Get
        Set(ByVal value As Long)
            EE_ID_G_MUESTRA = value
        End Set
    End Property

    Private EE_GMUE_COD As String
    Public Property GMUE_COD() As String
        Get
            Return EE_GMUE_COD
        End Get
        Set(ByVal value As String)
            EE_GMUE_COD = value
        End Set
    End Property

    Private EE_GMUE_DESC As String
    Public Property GMUE_DESC() As String
        Get
            Return EE_GMUE_DESC
        End Get
        Set(ByVal value As String)
            EE_GMUE_DESC = value
        End Set
    End Property

    Public Property PAC_FULLNAME As String
        Get
            Return EE_PAC_FULLNAME
        End Get
        Set(value As String)
            EE_PAC_FULLNAME = value
        End Set
    End Property

    Private EE_PAC_FULLNAME As String
End Class