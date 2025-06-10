Imports Entidades
Imports Negocio
Public Class Asoc_Pre_Pre_2
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

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_Y_PARTICULAR()
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Examen() As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO()
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

        'Data_OUT = NN_Search.IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO(ID_AÑO, ID_PREVI)    
        'Data_OUT = NN_Search.IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO_BONIFICACION(ID_AÑO, ID_PREVI)
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_BUSCA_PRECIO_PREVISION_CONVENIO_BONIFICACION_Y_PARTICULAR(ID_AÑO, ID_PREVI)
        If (Data_OUT.Count > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Precio(ByVal Mx_Pos As List(Of E_UPDATE_PRECIO)) As Integer
        Dim UPre As New E_UPDATE_PRECIO
        Dim LUPre As New List(Of E_UPDATE_PRECIO)
        Dim Data_UPre As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        LUPre = Mx_Pos
        For Each Item As E_UPDATE_PRECIO In LUPre
            'Declaraciones internas
            Dim NN_UPre As New N_IRIS_WEBF_UPDATE_PRECIO_FONASA

            Dim _ID_PRE As Integer = Item.ID_PRECIO
            Dim _AMB As Integer = Item.AMB
            Dim _ID_USU As Integer = objSession("ID_USER")
            Dim _Fecha As DateTime = DateTime.Now
            Dim _ID_ESTADO = "1"
            Dim _BONI As Integer = Item.BON
            Dim _PAR As Integer = Item.PAR
            Data_UPre += NN_UPre.IRIS_WEBF_CMVM_UPDATE_PRECIO_FONASA_BONIFICACION_Y_PARTICULAR(_ID_PRE, _AMB, _ID_USU, _Fecha, _ID_ESTADO, _BONI, _PAR)
        Next
        If (Data_UPre > 0) Then

            Return Data_UPre
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Elimina_Precio(ByVal Mx_Pos As List(Of E_UPDATE_PRECIO)) As Integer
        Dim UPre As New E_UPDATE_PRECIO
        Dim LUPre As New List(Of E_UPDATE_PRECIO)
        Dim Data_UPre As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        LUPre = Mx_Pos
        For Each Item As E_UPDATE_PRECIO In LUPre
            'Declaraciones internas
            Dim NN_UPre As New N_IRIS_WEBF_UPDATE_PRECIO_FONASA

            Dim _ID_PRE As Integer = Item.ID_PRECIO
            Dim _AMB As Integer = Item.AMB
            Dim _ID_USU As Integer = objSession("ID_USER")
            Dim _Fecha As DateTime = DateTime.Now
            Dim _ID_ESTADO = "2"
            Data_UPre += NN_UPre.IRIS_WEBF_UPDATE_PRECIO_FONASA(_ID_PRE, _AMB, _ID_USU, _Fecha, _ID_ESTADO)
        Next
        If (Data_UPre > 0) Then

            Return Data_UPre
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Graba_Precio(ByVal Mx_Pos As List(Of E_UPDATE_PRECIO_2)) As Integer
        Dim UPre As New E_UPDATE_PRECIO_2
        Dim LUPre As New List(Of E_UPDATE_PRECIO_2)
        Dim Data_UPre As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        LUPre = Mx_Pos

        For Each Item As E_UPDATE_PRECIO_2 In LUPre
            'Declaraciones internas
            Dim NN_UPre As New N_IRIS_WEBF_GRABA_PRECIOS_FONASA

            Dim ID_PREVI As Integer = Item.ID_PREVI
            Dim ID_CF As Integer = Item.ID_CF
            Dim ID_USUARIO As Integer = objSession("ID_USER")
            Dim ID_AÑO As Integer = Item.ID_AÑO
            Dim V_AMB As Integer = Item.AMB
            Data_UPre += NN_UPre.IRIS_WEBF_GRABA_PRECIOS_FONASA(ID_PREVI, ID_CF, ID_AÑO, ID_USUARIO, V_AMB)
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

        'Select Case (CInt(C_P_ADMIN.Value))
        '    Case 1, 100, 101, 102
        '    Case Else
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub
End Class