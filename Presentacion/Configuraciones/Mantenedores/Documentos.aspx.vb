Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Documentos
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        Dim DATA_DOCUMENTO As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        DATA_DOCUMENTO = NN_DATA.IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR()

        Return DATA_DOCUMENTO
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_DOCUMENTO(ByVal DCTO_DESC As String,
                                                    ByVal DCTO_TIPO As Integer,
                                                    ByVal DCTO_FECHA As Date,
                                                    ByVal DCTO_RUTA As String,
                                                    ByVal DCTO_BITS As String,
                                                     ByVal DCTO_COD As String) As Integer


        Dim GRABA_DOCUMENTO As Integer = 0
        Dim BUSCA_SI_EXISTE As Integer = 0

        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        Dim rutaza As String = DCTO_RUTA.Replace("C:\fakepath\", "")

        BUSCA_SI_EXISTE = NN_DATA.IRIS_WEBF_BUSCA_DOCUMENTOS_SI_EXISTE(rutaza)

        If BUSCA_SI_EXISTE = 0 Then
            GRABA_DOCUMENTO = NN_DATA.IRIS_WEBF_GRABA_DOCUMENTO_2(DCTO_DESC, DCTO_TIPO, DCTO_FECHA, rutaza, DCTO_BITS, DCTO_COD)
            Return GRABA_DOCUMENTO
        Else
            Return 3
        End If




    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ByVal ID_DCTO As Integer) As Integer


        Dim ELIMINA_DOCUMENTO As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        ELIMINA_DOCUMENTO = NN_DATA.IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ID_DCTO)

        Return ELIMINA_DOCUMENTO
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ByVal ID_DCTO As Integer) As Integer


        Dim ELIMINA_DOCUMENTO As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        ELIMINA_DOCUMENTO = NN_DATA.IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ID_DCTO)

        Return ELIMINA_DOCUMENTO
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String) As String
        Dim NN_Excel As New N_Excel
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        Dim titulo As String = "PREVISIONES"
        Dim Mx(3, 0) As Object
        For y = 0 To (data_paciente.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx(3, y)
            End If
            Mx(0, y) = data_paciente(y).ID_PREVE
            Mx(1, y) = data_paciente(y).PREVE_COD
            Mx(2, y) = data_paciente(y).PREVE_DESC
            Mx(3, y) = data_paciente(y).ID_ESTADO
        Next y
        Return NN_Excel.Excel(DOMAIN_URL, Mx, titulo)
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_DCTO_DESC(ByVal ID_DCTO As String, ByVal DCTO_DESC As String) As Integer


        Dim Update_Desc As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        ID_DCTO = CInt(ID_DCTO)

        Update_Desc = NN_DATA.IRIS_WEBF_UPDATE_DCTO_DESC(ID_DCTO, DCTO_DESC)

        Return Update_Desc
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case Is <> 1
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class