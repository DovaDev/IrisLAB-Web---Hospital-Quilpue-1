Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Gest_Financ
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

    <Services.WebMethod>
    Public Shared Function Data_Graph(ByVal str_Date As String) As List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Search As New N_GraficoVisor
        Dim Data_Out As New List(Of E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES)
        Dim days As Integer = System.DateTime.DaysInMonth(2017, 1)
        Debug.WriteLine(">>>ATENCIONES POR CONSULTA<<<")
        str_Date = str_Date.Replace("-", "/")
        For h = 0 To 23
            str_Date = str_Date.Replace("-", "/")
            Dim dRef() As String = str_Date.Split("/")
            Dim Date_Out As Date = NN_Date.strToDate(dRef(2), dRef(1), dRef(0), h)
            Dim Value As Long = 0
            Value = NN_Search.IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES(Date_Out, Date_Out)
            Debug.WriteLine("Fecha: " & Format(Date_Out, "dd/MM/yyyy HH:mm:ss"))
            Debug.WriteLine("Valor: " & Format(Value, "###,###,##0.##"))
            Debug.WriteLine("")
            Dim E_Item As New E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES
            E_Item.FECHA = Date_Out
            E_Item.NUMERO = Value
            Data_Out.Add(E_Item)
        Next h
        Debug.WriteLine("Llenado Completado")
        If (Data_Out.Count > 0) Then
            Return Data_Out
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
