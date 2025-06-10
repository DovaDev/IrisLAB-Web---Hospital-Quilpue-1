Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class N_Ver_Disponibilidad
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 2
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

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
    Public Shared Function Llenar_DataTable(ByVal fecha As String, ByVal ID_Procedencia As String, ByVal timer As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas

        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN As New N_PROCEDENCIAS_Y_CANT_MAX
        Dim date_json_rial As New List(Of E_DATOS_FECHA_PROCEDENCIA)
        Dim DIA As Integer
        Dim MES As Integer
        Dim AÑO As Integer
        fecha = fecha.Replace("/", "-")
        DIA = fecha.Split("-")(0)
        MES = fecha.Split("-")(1)
        AÑO = fecha.Split("-")(2)
        Dim cof_exa As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim Date_01 As Date = NN_Date.strToDate(AÑO, MES, DIA)
        Dim DateW As Date = Date_01
        While (DateDiff(DateInterval.Day, Date_01, DateW) <= timer - 1)
            Dim Item As New E_DATOS_FECHA_PROCEDENCIA
            If (Format(DateW, "dddd") = "domingo") Then
                DateW = DateAdd(DateInterval.Day, 1, DateW)
                timer = timer + 1
            Else
                Dim Elem_Alt As Integer = 0 'total_ate
                Elem_Alt = NN.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2(ID_Procedencia, DateW)
                cof_exa = NN.examens(ID_Procedencia, Format(DateW, "dd/MM/yyyy")) 'CONF_DIAS_EXA_BUSCA_DIAS
                Item.FECHA = Format(DateW, "dd-MM-yyyy")
                If (cof_exa.Count > 0) Then
                    Item.CONF_DIAS_EXA_BUSCA_DIAS = cof_exa(0).CONF_DIAS_EXA_BUSCA_DIAS
                Else
                    Item.CONF_DIAS_EXA_BUSCA_DIAS = 0
                End If
                Item.TOTAL_ATE = Elem_Alt
                Item.DIA_DEL_DIA = Format(DateW, "dddd")
                date_json_rial.Add(Item)
                DateW = DateAdd(DateInterval.Day, 1, DateW)
                'DateW.AddDays(+1)
            End If
        End While
        If (date_json_rial.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(date_json_rial, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(ID)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(ID)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(ID)
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        If data_pac.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(reeeeeee, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    Private Class REEE
        Dim arr1 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim arr2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim arr3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Public Property proparra3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
            Get
                Return arr3
            End Get
            Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION))
                arr3 = value
            End Set
        End Property
        Public Property proparra1 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
            Get
                Return arr1
            End Get
            Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2))
                arr1 = value
            End Set
        End Property
        Public Property proparra2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Get
                Return arr2
            End Get
            Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL))
                arr2 = value
            End Set
        End Property
    End Class
End Class