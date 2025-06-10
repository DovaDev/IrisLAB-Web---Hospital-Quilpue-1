Imports System

Public Class E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB
    Private EE_RUT_PAC_EXA As String
    Private EE_NOM_PAC_EXA As String
    Private EE_APE_PAC_EXA As String
    Private EE_FNAC_PAC_EXA As DateTime
    Private EE_SEXO_PAC_EXA As Integer
    Private EE_FONO_PAC_EXA As String
    Private EE_DIR_PAC_EXA As String
    Private EE_EMAIL_PAC_EXA As String
    Public Property EMAIL_PAC_EXA() As String
        Get
            Return EE_EMAIL_PAC_EXA
        End Get
        Set(ByVal value As String)
            EE_EMAIL_PAC_EXA = value
        End Set
    End Property
    Public Property DIR_PAC_EXA() As String
        Get
            Return EE_DIR_PAC_EXA
        End Get
        Set(ByVal value As String)
            EE_DIR_PAC_EXA = value
        End Set
    End Property
    Public Property FONO_PAC_EXA() As String
        Get
            Return EE_FONO_PAC_EXA
        End Get
        Set(ByVal value As String)
            EE_FONO_PAC_EXA = value
        End Set
    End Property
    Public Property SEXO_PAC_EXA() As Integer
        Get
            Return EE_SEXO_PAC_EXA
        End Get
        Set(ByVal value As Integer)
            EE_SEXO_PAC_EXA = value
        End Set
    End Property
    Public Property FNAC_PAC_EXA() As DateTime
        Get
            Return EE_FNAC_PAC_EXA
        End Get
        Set(ByVal value As DateTime)
            EE_FNAC_PAC_EXA = value
        End Set
    End Property
    Public Property APE_PAC_EXA() As String
        Get
            Return EE_APE_PAC_EXA
        End Get
        Set(ByVal value As String)
            EE_APE_PAC_EXA = value
        End Set
    End Property
    Public Property NOM_PAC_EXA() As String
        Get
            Return EE_NOM_PAC_EXA
        End Get
        Set(ByVal value As String)
            EE_NOM_PAC_EXA = value
        End Set
    End Property
    Public Property RUT_PAC_EXA() As String
        Get
            Return EE_RUT_PAC_EXA
        End Get
        Set(ByVal value As String)
            EE_RUT_PAC_EXA = value
        End Set
    End Property
End Class
