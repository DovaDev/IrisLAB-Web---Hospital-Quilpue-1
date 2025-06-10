Public Class E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20
    Private EE_ID_QD_RESULTADO As Long
    Private EE_ID_QC_ANALIZADOR As Long
    Private EE_ID_QC_LOTE As Long
    Private EE_ID_QC_DETERMINACION As Long
    Private EE_QC_RESUL_FECHA As DateTime
    Private EE_QC_RESUL_VALOR_1 As String
    Private EE_QC_RESUL_VALOR_2 As String
    Private EE_QC_RESUL_VALOR_3 As String
    Private EE_QC_RESUL_COMENTARIOS As String
    Private EE_QC_RESUL_HORA As DateTime
    Private EE_QC_RESUL_OMITIDO As Integer
    Public Property QC_RESUL_OMITIDO() As Integer
        Get
            Return EE_QC_RESUL_OMITIDO
        End Get
        Set(ByVal value As Integer)
            EE_QC_RESUL_OMITIDO = value
        End Set
    End Property
    Public Property QC_RESUL_HORA() As DateTime
        Get
            Return EE_QC_RESUL_HORA
        End Get
        Set(ByVal value As DateTime)
            EE_QC_RESUL_HORA = value
        End Set
    End Property
    Public Property QC_RESUL_COMENTARIOS() As String
        Get
            Return EE_QC_RESUL_COMENTARIOS
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_COMENTARIOS = value
        End Set
    End Property
    Public Property QC_RESUL_VALOR_3() As String
        Get
            Return EE_QC_RESUL_VALOR_3
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_3 = value
        End Set
    End Property
    Public Property QC_RESUL_VALOR_2() As String
        Get
            Return EE_QC_RESUL_VALOR_2
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_2 = value
        End Set
    End Property
    Public Property QC_RESUL_VALOR_1() As String
        Get
            Return EE_QC_RESUL_VALOR_1
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_1 = value
        End Set
    End Property
    Public Property QC_RESUL_FECHA() As DateTime
        Get
            Return EE_QC_RESUL_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_QC_RESUL_FECHA = value
        End Set
    End Property
    Public Property ID_QC_DETERMINACION() As Long
        Get
            Return EE_ID_QC_DETERMINACION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_DETERMINACION = value
        End Set
    End Property
    Public Property ID_QC_LOTE() As Long
        Get
            Return EE_ID_QC_LOTE
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_LOTE = value
        End Set
    End Property
    Public Property ID_QC_ANALIZADOR() As Long
        Get
            Return EE_ID_QC_ANALIZADOR
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_ANALIZADOR = value
        End Set
    End Property
    Public Property ID_QC_RESULTADO() As Long
        Get
            Return EE_ID_QD_RESULTADO
        End Get
        Set(ByVal value As Long)
            EE_ID_QD_RESULTADO = value
        End Set
    End Property
End Class
