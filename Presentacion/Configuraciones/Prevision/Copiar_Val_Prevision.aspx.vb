Imports Entidades
Imports Negocio
Public Class Copiar_Val_Prevision
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Año() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_AÑO_ACTIVO
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_AÑO_ACTIVO()
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Preve() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_AÑO As String, ByVal ID_PREVI As String) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)

        Data_OUT = NN_Search.IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO(ID_AÑO, ID_PREVI)
        If (Data_OUT.Count > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Precio(ByVal Mx_Pos As List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO),
                                         ByVal ID_ANO As Integer, ByVal ID_PREVE As Integer) As Integer
        Dim UPre As New E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
        Dim LUPre As New List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
        Dim Data_UPre As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        LUPre = Mx_Pos

        Dim data_ver As New List(Of E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO)
        Dim nn_ver As N_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO = New N_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO

        Dim data_graba As Integer = 0
        Dim nn_graba As N_IRIS_WEBF_GRABA_PRECIOS_FONASA = New N_IRIS_WEBF_GRABA_PRECIOS_FONASA

        For Each Item As E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO In LUPre
            'Declaraciones internas
            Dim NN_UPre As New N_IRIS_WEBF_UPDATE_PRECIO_FONASA_2

            Dim _ID_PRE As Integer = Item.ID_CF_PRECIO
            Dim _ID_CF As Integer = Item.ID_CODIGO_FONASA
            Dim _AMB As Integer = Item.CF_PRECIO_AMB
            Dim _HOSP As Integer = Item.CF_PRECIO_HOS


            Dim _ID_USU As Integer = objSession("ID_USER")
            Dim _Fecha As DateTime = DateTime.Now
            Dim _ID_ESTADO = "1"

            data_ver = nn_ver.IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO(ID_ANO, ID_PREVE, _ID_CF)

            If data_ver.Count > 0 Then
                Data_UPre = NN_UPre.IRIS_WEBF_UPDATE_PRECIO_FONASA_2(_ID_PRE, _AMB, _HOSP, _ID_USU, _Fecha, _ID_ESTADO, ID_PREVE, _ID_CF, ID_ANO)

                If Data_UPre = 0 Then
                    data_graba = nn_graba.IRIS_WEBF_GRABA_PRECIOS_FONASA(ID_PREVE, _ID_CF, ID_ANO, _ID_USU, _AMB)
                End If
            Else
                data_graba = nn_graba.IRIS_WEBF_GRABA_PRECIOS_FONASA(ID_PREVE, _ID_CF, ID_ANO, _ID_USU, _AMB)

            End If

        Next


        If (Data_UPre > 0) Then

            Return Data_UPre
        Else
            Return Nothing
        End If
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