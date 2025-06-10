Public Class E_Examen_Pendiente_Ate_Resultado
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As String
    Private EE_SECC_COD As String
    Private EE_PROC_DESC As String
    Private EE_CF_DESC As String
    Private EE_ID_RLS_LS As String
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_ID_SECCION As Integer
    Private EE_ID_AREA As Integer

    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property SECC_COD() As String
        Get
            Return EE_SECC_COD
        End Get
        Set(ByVal value As String)
            EE_SECC_COD = value
        End Set
    End Property
    Public Property ATE_FECHA() As String
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As String)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property

    Public Property ID_RLS_LS As String
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(value As String)
            EE_ID_RLS_LS = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property ID_SECCION As Integer
        Get
            Return EE_ID_SECCION
        End Get
        Set(value As Integer)
            EE_ID_SECCION = value
        End Set
    End Property

    Public Property ID_AREA As Integer
        Get
            Return EE_ID_AREA
        End Get
        Set(value As Integer)
            EE_ID_AREA = value
        End Set
    End Property
End Class
