Public Class E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2
    Private EE_QC_RESUL_OMITIDO As Integer
    Public Property QC_RESUL_OMITIDO() As Integer
        Get
            Return EE_QC_RESUL_OMITIDO
        End Get
        Set(ByVal value As Integer)
            EE_QC_RESUL_OMITIDO = value
        End Set
    End Property
    Private EE_ID_TP_QC_ACCION As Long
    Public Property ID_TP_QC_ACCION() As Long
        Get
            Return EE_ID_TP_QC_ACCION
        End Get
        Set(ByVal value As Long)
            EE_ID_TP_QC_ACCION = value
        End Set
    End Property
    Private EE_ID_QC_RESULTADO As Long
    Public Property ID_QC_RESULTADO() As Long
        Get
            Return EE_ID_QC_RESULTADO
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_RESULTADO = value
        End Set
    End Property
    Private EE_QC_COMENTARIOS As String
    Public Property QC_COMENTARIOS() As String
        Get
            Return EE_QC_COMENTARIOS
        End Get
        Set(ByVal value As String)
            EE_QC_COMENTARIOS = value
        End Set
    End Property
    Private EE_QC_RESUL_VALOR_3 As String
    Public Property QC_RESUL_VALOR_3() As String
        Get
            Return EE_QC_RESUL_VALOR_3
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_3 = value
        End Set
    End Property
    Private EE_QC_RESUL_VALOR_2 As String
    Public Property QC_RESUL_VALOR_2() As String
        Get
            Return EE_QC_RESUL_VALOR_2
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_2 = value
        End Set
    End Property
    Private EE_QC_RESUL_VALOR_1 As String
    Public Property QC_RESUL_VALOR_1() As String
        Get
            Return EE_QC_RESUL_VALOR_1
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_1 = value
        End Set
    End Property
    Private EE_QC_RESUL_HORA As DateTime
    Public Property QC_RESUL_HORA() As DateTime
        Get
            Return EE_QC_RESUL_HORA
        End Get
        Set(ByVal value As DateTime)
            EE_QC_RESUL_HORA = value
        End Set
    End Property
End Class
