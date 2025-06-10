Public Class E_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
    Private EE_ID_PROCEDENCIA As String
    Private EE_PROC_CANT_EXA As String
    Public Property PROC_CANT_EXA() As String
        Get
            Return EE_PROC_CANT_EXA
        End Get
        Set(ByVal value As String)
            EE_PROC_CANT_EXA = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA() As String
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As String)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
End Class
