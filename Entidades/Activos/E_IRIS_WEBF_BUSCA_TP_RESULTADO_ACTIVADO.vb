Public Class E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO
    Dim EE_ID_TP_RESULTADO As Integer
    Dim EE_TP_RESUL_COD As String
    Dim EE_TP_RESUL_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_TP_RESULTADO As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(value As Integer)
            EE_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property TP_RESUL_COD As String
        Get
            Return EE_TP_RESUL_COD
        End Get
        Set(value As String)
            EE_TP_RESUL_COD = value
        End Set
    End Property
    Public Property TP_RESUL_DESC As String
        Get
            Return EE_TP_RESUL_DESC
        End Get
        Set(value As String)
            EE_TP_RESUL_DESC = value
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
