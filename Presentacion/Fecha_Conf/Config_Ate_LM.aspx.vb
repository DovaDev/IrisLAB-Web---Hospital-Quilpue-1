Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Config_Ate_LM
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Año() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Año As New N_IRIS_WEBF_BUSCA_AÑO_ACTIVO
        Dim Data_Año As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        Data_Año = NN_Año.IRIS_WEBF_BUSCA_AÑO_ACTIVO()
        If (Data_Año.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Año, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Tabla(ByVal ID_PRO As Integer, ByVal FECHA As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_BUSC_DIAS_CONF_ATE_PROC As New N_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
        Dim Data_BUSC_DIAS_CONF_ATE_PROC As New List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2)
        Data_BUSC_DIAS_CONF_ATE_PROC = NN_BUSC_DIAS_CONF_ATE_PROC.IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2(ID_PRO, FECHA)
        Dim fechass() As String = Split(FECHA, "/")
        Dim month As Integer = fechass(0)
        Dim year As Integer = fechass(1)
        Dim days As Integer = System.DateTime.DaysInMonth(year, month)
        Dim Resp As New List(Of Nose)
        Dim fcomp = ""
        Dim x = 0
        For dd = 1 To days
            Dim di As String = ""
            If (dd <= 9) Then
                di = "0" + dd.ToString()
            Else
                di = dd.ToString()
            End If
            Dim mess As String = ""
            If (month <= 9) Then
                mess = "0" + month.ToString()
            Else
                mess = month.ToString()
            End If
            Dim Date_01 As String = di + "/" + mess + "/" + year.ToString()
            If (Data_BUSC_DIAS_CONF_ATE_PROC.Count <> 0 And x < Data_BUSC_DIAS_CONF_ATE_PROC.Count) Then
                If (Data_BUSC_DIAS_CONF_ATE_PROC(x).CONF_DIAS_FECHA.Equals(Date_01)) Then
                    Dim Item_REEEE = New Nose
                    Item_REEEE.N_FECHA = Data_BUSC_DIAS_CONF_ATE_PROC(x).CONF_DIAS_FECHA
                    Item_REEEE.N_CANT_EXA = Data_BUSC_DIAS_CONF_ATE_PROC(x).CONF_DIAS_EXA
                    Item_REEEE.N_ESTADO = 1
                    Item_REEEE.N_ID = Data_BUSC_DIAS_CONF_ATE_PROC(x).ID_CONF_DIAS
                    Resp.Add(Item_REEEE)
                    x += 1
                Else
                    Dim Item_REEEE = New Nose
                    Item_REEEE.N_FECHA = Date_01
                    Item_REEEE.N_CANT_EXA = 0
                    Item_REEEE.N_ID = "NULL"
                    Item_REEEE.N_ESTADO = 0
                    Resp.Add(Item_REEEE)
                End If
            Else
                Dim Item_REEEE = New Nose
                Item_REEEE.N_FECHA = Date_01
                Item_REEEE.N_CANT_EXA = 0
                Item_REEEE.N_ID = "NULL"
                Item_REEEE.N_ESTADO = 0
                Resp.Add(Item_REEEE)
            End If
        Next dd

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Resp, str_Builder)
        Return str_Builder.ToString
    End Function
    <Services.WebMethod()>
    Public Shared Function Guardar_Conf_Examenes(ByVal ID_PRO As String, ByVal FECHA As String, ByVal CANT As String) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_GRABA_CONF_EXAMENES = New N_IRIS_WEBF_GRABA_CONF_EXAMENES
        Dim numerito As Integer
        numerito = NN.IRIS_WEBF_GRABA_CONF_EXAMENES(ID_PRO, FECHA, CANT)
        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(numerito, str_Builder)
        datas = str_Builder.ToString
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Modificar_Conf_Examenes(ByVal ID_CONF As String, ByVal CANTIDAD As String, ByVal ID_ESTADO As String) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN = New N_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN
        Dim numerito As Integer
        numerito = NN.IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN(ID_CONF, CANTIDAD, ID_ESTADO)
        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(numerito, str_Builder)
        datas = str_Builder.ToString
        Return datas
    End Function

    Private Sub Config_Ate_LM_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class
Public Class Nose
    Private NOSE_ID As String
    Public Property N_ID() As String
        Get
            Return NOSE_ID
        End Get
        Set(ByVal value As String)
            NOSE_ID = value
        End Set
    End Property
    Private NOSE_FECHA As String
    Public Property N_FECHA() As String
        Get
            Return NOSE_FECHA
        End Get
        Set(ByVal value As String)
            NOSE_FECHA = value
        End Set
    End Property
    Private NOSE_CANT_EXA As Integer
    Public Property N_CANT_EXA() As Integer
        Get
            Return NOSE_CANT_EXA
        End Get
        Set(ByVal value As Integer)
            NOSE_CANT_EXA = value
        End Set
    End Property
    Private NOSE_ESTADO As String
    Public Property N_ESTADO() As String
        Get
            Return NOSE_ESTADO
        End Get
        Set(ByVal value As String)
            NOSE_ESTADO = value
        End Set
    End Property

End Class