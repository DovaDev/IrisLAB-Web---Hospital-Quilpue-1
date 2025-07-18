﻿Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Rev_Est_Exa_New
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DdL_prevision() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_PROC As Integer,
                                          ByVal ID_PRE As Integer,
                                          ByVal ID_CF As Integer,
                                          ByVal ID_EST As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW)

        Data = NN.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW(CDate(DESDE), CDate(HASTA), ID_PROC, ID_PRE, ID_CF, ID_EST)

        Return Data

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
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Det_Ate(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Encrypt As New N_Encrypt
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE)
        Dim data_num As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE = New N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE
        Dim NN_Num As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE(ID_ATE)
        If (data_det_ate.Count > 0) Then
            data_num = NN_Num.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data_det_ate(0).ID_ATENCION)
            data_det_ate(0).NUM_ATE = data_num(0).ATE_NUM
            For i = 0 To (data_det_ate.Count - 1)
                data_det_ate(i).ENCRYPTED_ID = Encrypt.Encode(ID_ATE)
            Next i
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
                                  ByVal ID_PROC As Integer,
                                          ByVal ID_PRE As Integer,
                                          ByVal ID_CF As Integer,
                                          ByVal ID_EST As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW)
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim Mx_Data(15, 0) As Object
        Data = NN.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW(CDate(DESDE), CDate(HASTA), ID_PROC, ID_PRE, ID_CF, ID_EST)
        If (Data.Count > 0) Then

            Dim Mx_Datac(15, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(15, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(15, y)
                End If

                Dim Estado As String = ""
                Dim Fono As String = ""
                Dim AP As String = ""
                Dim AM As String = ""

                Dim APES As String()

                APES = Data(y).PAC_APELLIDO.Split(" ")

                If APES.Count = 1 Then
                    AP = APES(0)
                    AM = ""
                ElseIf APES.Count = 2 Then
                    AP = APES(0)
                    AM = APES(1)
                ElseIf APES.Count = 3 Then
                    AP = APES(0) + " " + APES(1)
                    AM = APES(2)
                ElseIf APES.Count = 4 Then
                    AP = APES(0) + " " + APES(1)
                    AM = APES(2) + " " + APES(3)
                ElseIf APES.Count = 5 Then
                    AP = APES(0) + " " + APES(1) + " " + APES(2)
                    AM = APES(3) + " " + APES(4)
                End If

                If (Data(y).PAC_FONO <> "") Then
                    Fono = Data(y).PAC_FONO
                Else
                    Fono = Data(y).PAC_MOVIL
                End If

                If (Data(y).EST_VALIDA = 6 Or Data(y).EST_VALIDA = 14) Then
                    Estado = "Validado"
                Else
                    Estado = "Espera"
                End If


                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = Data(y).ATE_NUM
                Mx_Data(2, y) = Format(Data(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(3, y) = Data(y).PAC_RUT + Data(y).PAC_DNI
                Mx_Data(4, y) = Data(y).PAC_NOMBRE
                Mx_Data(5, y) = AP
                Mx_Data(6, y) = AM
                Mx_Data(7, y) = Data(y).PAC_SEXO
                Mx_Data(8, y) = Data(y).PAC_EDAD + " Años"
                Mx_Data(9, y) = Data(y).PROC_DESC
                Mx_Data(10, y) = Fono
                Mx_Data(11, y) = Data(y).PAC_DIR
                Mx_Data(12, y) = Data(y).CF_DESC
                Mx_Data(13, y) = Estado

                If (Estado = "Validado") Then
                    Mx_Data(14, y) = Format(Data(y).FECHA_VALIDA, "dd/MM/yyyy")
                    Mx_Data(15, y) = Format(Data(y).FECHA_VALIDA, "hh:mm:ss")
                Else
                    Mx_Data(14, y) = ""
                    Mx_Data(15, y) = ""
                End If
            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Revisar Estados de Exámenes")
        'titulo de la tabla
        sl.SetCellValue("B2", "Revisar Estados de Exámenes")
        sl.SetCellValue("B4", "Desde: " + DESDE)
        sl.SetCellValue("D4", "Desde: " + HASTA)
        For y = 1 To 16
            sl.SetColumnWidth(y, 20.0)
        Next y
        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "Folio")
        sl.SetCellValue("C8", "Fecha Atención")
        sl.SetCellValue("D8", "RUT/DNI")
        sl.SetCellValue("E8", "Nombre")
        sl.SetColumnWidth("E", 20)
        sl.SetCellValue("F8", "Apellido Paterno")
        sl.SetColumnWidth("F", 20)
        sl.SetCellValue("G8", "Apellido Materno")
        sl.SetColumnWidth("G", 20)
        sl.SetCellValue("H8", "Sexo")
        sl.SetCellValue("I8", "Edad")
        sl.SetCellValue("J8", "Procedencia")
        sl.SetCellValue("K8", "Teléfono")
        sl.SetCellValue("L8", "Dirección")
        sl.SetColumnWidth("L", 30)
        sl.SetCellValue("M8", "Examen")
        sl.SetColumnWidth("M", 30)
        sl.SetCellValue("N8", "Estado")
        sl.SetCellValue("O8", "Fecha Validación")
        sl.SetCellValue("P8", "Hora Validación")

        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 8
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True
        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("D4", estilo3)
        sl.SetCellStyle("B4", estilo3)
        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("P" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Public Shared Function Calcular_Edad(Fecha_Nacimiento As Date) As Integer
        Dim Años As Object
        ' comprueba si el valor no es nulo  
        Años = DateDiff("yyyy", Fecha_Nacimiento, Now)
        If Date.Now < DateSerial(Year(Now), Month(Fecha_Nacimiento),
                           Day(Fecha_Nacimiento)) Then
            Años = Años - 1
        End If
        Calcular_Edad = CInt(Años)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        'If (IsNothing(C_P_ADMIN) = True) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'Select Case (C_P_ADMIN.Value)
        '    Case Is <> 1
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub
End Class