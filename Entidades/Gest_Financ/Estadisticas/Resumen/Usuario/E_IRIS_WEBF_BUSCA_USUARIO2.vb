﻿Public Class E_IRIS_WEBF_BUSCA_USUARIO2
    Private E_ID_USUARIO As Long
    Private E_USU_NOMBRE As String
    Private E_USU_APELLIDO As String
    Private E_ID_ESTADO As Long
    Private E_PER_USU_DESC As String
    Private E_USU_NIC As String
    Public Property ID_USUARIO As Long
        Get
            Return E_ID_USUARIO
        End Get
        Set(value As Long)
            E_ID_USUARIO = value
        End Set
    End Property
    Public Property USU_NOMBRE As String
        Get
            Return E_USU_NOMBRE
        End Get
        Set(value As String)
            E_USU_NOMBRE = value
        End Set
    End Property
    Public Property USU_APELLIDO As String
        Get
            Return E_USU_APELLIDO
        End Get
        Set(value As String)
            E_USU_APELLIDO = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Long)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property PER_USU_DESC As String
        Get
            Return E_PER_USU_DESC
        End Get
        Set(value As String)
            E_PER_USU_DESC = value
        End Set
    End Property
    Public Property USU_NIC As String
        Get
            Return E_USU_NIC
        End Get
        Set(value As String)
            E_USU_NIC = value
        End Set
    End Property
End Class
