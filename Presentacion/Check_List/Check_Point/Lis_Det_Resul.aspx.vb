Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Det_Resul
    Inherits System.Web.UI.Page

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
    Public Shared Function Llenar_Ddl_Seccion() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Seccion As New N_IRIS_WEBF_BUSCA_REL_LAB_SECCION
        Dim Data_Seccion As New List(Of E_IRIS_WEBF_BUSCA_REL_LAB_SECCION)

        Data_Seccion = NN_Seccion.IRIS_WEBF_BUSCA_REL_LAB_SECCION()
        If (Data_Seccion.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Seccion, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_VAL As Integer,
                                            ByVal ID_NMUE As Integer,
                                            ByVal ID_SECCION As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Validado As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2
        Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2)
        'Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        'Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)

        Dim idate As String = ""

        Dim NAte As Integer = 0
        Dim NExa As Integer = 0
        Dim recSi As Integer = 0
        Dim recNo As Integer = 0
        Dim valiSi As Integer = 0
        Dim valiNo As Integer = 0
        Dim total As Integer = 0
        Dim rechSi As Integer = 0
        Dim rechNo As Integer = 0


        Data_Validado = NN_Validado.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2(TIPO, CDate(DESDE), CDate(HASTA), ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION)
        If (Data_Validado.Count > 0) Then
            idate = Data_Validado(0).ID_ATENCION
            NAte = 1
            For y = 0 To Data_Validado.Count - 1
                If idate = Data_Validado(y).ID_ATENCION Then
                    idate = idate
                Else
                    NAte += 1
                    idate = Data_Validado(y).ID_ATENCION
                End If

                If Data_Validado(y).ATE_DET_V_ID_ESTADO = 6 Then
                    valiSi += 1
                Else
                    valiNo += 1
                End If

                If Data_Validado(y).ATE_EST_RECHAZO = 16 Then
                    rechSi += 1
                Else
                    rechNo += 1
                End If

                If Data_Validado(y).ATE_EST_RECEP = 9 Then
                    recSi += 1
                Else
                    recNo += 1
                End If

                NExa += 1
                total += 1

                Data_Validado(0).NAte = NAte
                Data_Validado(0).NExa = NExa
                Data_Validado(0).recSi = recSi
                Data_Validado(0).recNo = recNo
                Data_Validado(0).valiSi = valiSi
                Data_Validado(0).valiNo = valiNo
                Data_Validado(0).rechSi = rechSi
                Data_Validado(0).rechNo = rechNo
                Data_Validado(0).total = total

                'Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data_Validado(y).ID_ATENCION)
                'Data_Validado(y).PAC_FNAC = Data_Datos_Pac(0).PAC_FNAC

            Next y

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Validado, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_VAL As Integer,
                                            ByVal ID_NMUE As Integer,
                                            ByVal ID_SECCION As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN_Validado As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2
        Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2)

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
        Dim edad As Integer = 0
        Dim idate As String = ""

        Dim NAte As Integer = 0
        Dim NExa As Integer = 0
        Dim recSi As Integer = 0
        Dim recNo As Integer = 0
        Dim valiSi As Integer = 0
        Dim valiNo As Integer = 0
        Dim total As Integer = 0
        Dim rechSi As Integer = 0
        Dim rechNo As Integer = 0

        Dim Mx_Data(21, 0) As Object

        Data_Validado = NN_Validado.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2(TIPO, CDate(DESDE), CDate(HASTA), ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION)
        If (Data_Validado.Count > 0) Then
            edad = 0
            idate = Data_Validado(0).ID_ATENCION
            NAte = 1
            For y = 0 To Data_Validado.Count - 1
                If idate = Data_Validado(y).ID_ATENCION Then
                    idate = idate
                Else
                    NAte += 1
                    idate = Data_Validado(y).ID_ATENCION
                End If

                If Data_Validado(y).ATE_DET_V_ID_ESTADO = 6 Then
                    valiSi += 1
                Else
                    valiNo += 1
                End If

                If Data_Validado(y).ATE_EST_RECHAZO = 16 Then
                    rechSi += 1
                Else
                    rechNo += 1
                End If

                If Data_Validado(y).ATE_EST_RECEP = 9 Then
                    recSi += 1
                Else
                    recNo += 1
                End If

                NExa += 1
                total += 1

            Next y

            Dim Mx_Datac(21, 0) As Object

            'Vaciar Matriz
            ReDim Mx_Data(21, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data_Validado.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(21, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(Data_Validado(y).ATE_NUM)
                Mx_Data(2, y) = Data_Validado(y).ATE_NUM_INTERNO
                Mx_Data(3, y) = Data_Validado(y).PAC_RUT
                Mx_Data(4, y) = Data_Validado(y).ATE_DNI
                Mx_Data(5, y) = Data_Validado(y).NAC_DESC
                Mx_Data(6, y) = Data_Validado(y).PAC_NOMBRE + " " + Data_Validado(y).PAC_APELLIDO
                Mx_Data(7, y) = Format(Data_Validado(y).PAC_FNAC, "dd/MM/yyyy")
                Mx_Data(8, y) = Calcular_Edad(CDate(Data_Validado(y).PAC_FNAC)) & " " & "Años"
                Mx_Data(9, y) = Format(Data_Validado(y).ATE_FECHA, "dd/mm/yyyy")
                Mx_Data(10, y) = Format(Data_Validado(y).ATE_FECHA, "hh:mm:ss")
                Mx_Data(11, y) = Data_Validado(y).PROC_DESC

                If Data_Validado(y).ID_SEXO = "2" Then
                    Mx_Data(12, y) = "Femenino"
                Else
                    Mx_Data(12, y) = "Masculino"
                End If
                Mx_Data(13, y) = Data_Validado(y).PROGRA_DESC
                Mx_Data(14, y) = Data_Validado(y).SECTOR_DESC
                Mx_Data(15, y) = Data_Validado(y).CF_DESC
                Mx_Data(16, y) = Data_Validado(y).T_MUESTRA_DESC
                Mx_Data(17, y) = CInt(Data_Validado(y).CB_DESC)

                If Data_Validado(y).ATE_EST_DERIVA = "9" Then
                    Mx_Data(18, y) = "SI"
                Else
                    Mx_Data(18, y) = "NO"
                End If

                If Data_Validado(y).Expr1 = "VALIDADO" Then
                    Mx_Data(19, y) = "SI"
                Else
                    Mx_Data(19, y) = "NO"
                End If

                If Data_Validado(y).ATE_EST_RECHAZO = "7" Then
                    Mx_Data(20, y) = "NO"
                Else
                    Mx_Data(20, y) = "SI"
                End If
                Mx_Data(21, y) = Data_Validado(y).DOC_NOMBRE & " " & Data_Validado(y).DOC_APELLIDO
            Next y

        Else
            Return "null"
        End If

        sl.SetCellValue("A4", "N° Atenciones:" & " " & NAte)
        sl.SetCellValue("A6", "N° Exámenes:" & " " & NExa)
        sl.SetCellValue("C4", "Recepcionado SI:" & " " & recSi & " / " & "NO:" & " " & rechNo)
        sl.SetCellValue("C6", "Valida SI:" & " " & valiSi & " / " & "NO:" & " " & valiNo)
        sl.SetCellValue("E4", "Rechazado SI:" & " " & rechSi & " / " & "NO:" & " " & rechNo)
        sl.SetCellValue("E6", "TOTAL:" & " " & total)

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Detalle de Resultados")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Detalle de Resultados")

        For y = 1 To 22
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetColumnWidth("B", 15)
        sl.SetCellValue("C8", "N° Interno")
        sl.SetColumnWidth("C", 15)
        sl.SetCellValue("D8", "Rut Paciente")
        sl.SetCellValue("E8", "DNI")
        sl.SetCellValue("F8", "Nacionalidad")
        sl.SetCellValue("G8", "Nombre Paciente")
        sl.SetColumnWidth("G", 40)
        sl.SetCellValue("H8", "Fecha Nac")
        sl.SetCellValue("I8", "Edad")
        sl.SetColumnWidth("I", 15)
        sl.SetCellValue("J8", "Fecha")
        sl.SetCellValue("K8", "Hora")
        sl.SetColumnWidth("K", 10)
        sl.SetCellValue("L8", "Lugar de TM")
        sl.SetColumnWidth("L", 25)
        sl.SetCellValue("M8", "Sexo")
        sl.SetCellValue("N8", "Programa")
        sl.SetCellValue("O8", "Sector")
        sl.SetCellValue("P8", "Examen")
        sl.SetColumnWidth("P", 30)
        sl.SetCellValue("Q8", "Tipo Etiqueta")
        sl.SetCellValue("R8", "CB")
        sl.SetColumnWidth("A", 15)
        sl.SetCellValue("S8", "Recep.")
        sl.SetColumnWidth("S", 10)
        sl.SetCellValue("T8", "Validado")
        sl.SetColumnWidth("T", 10)
        sl.SetCellValue("U8", "Rechazado")
        sl.SetColumnWidth("U", 10)
        sl.SetCellValue("V8", "Médico")
        sl.SetColumnWidth("V", 30)

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
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)

        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("V" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

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