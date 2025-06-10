Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Recep_Mue_SGB
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
    Public Shared Function Llenar_tabla_exam(ByVal ID_ATENCION As String, ByVal OBS_VIH As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
        Dim Data_Exam As Integer

        Data_Exam = NN_Exam.IRIS_WEBF_UPDATE_ESTADO_bos_vih(ID_ATENCION, OBS_VIH)
        If (Data_Exam > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        Dim data_det_ate_2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim Item_data As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

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


        Dim Mx_Data(15, 0) As Object

        If TIPO = 7 Then ' 7 = NO RECEPCIONADO
            data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_vih(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        ElseIf TIPO = 9 Then '9 RECEPCIONADO
            data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_vih(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        ElseIf TIPO = 0 Then
            data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_vih(7, DESDE, HASTA, ID_PRE, ID_CF)
            data_det_ate_2 = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_vih(9, DESDE, HASTA, ID_PRE, ID_CF)

            If data_det_ate_2.Count > 0 Then
                For i = 0 To data_det_ate_2.Count - 1
                    Item_data = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

                    Item_data.ATE_NUM = data_det_ate_2(i).ATE_NUM
                    Item_data.ATE_NUM_INTERNO = data_det_ate_2(i).ATE_NUM_INTERNO
                    Item_data.PAC_NOMBRE = data_det_ate_2(i).PAC_NOMBRE
                    Item_data.PAC_APELLIDO = data_det_ate_2(i).PAC_APELLIDO
                    Item_data.PAC_RUT = data_det_ate_2(i).PAC_RUT
                    Item_data.PAC_DNI = data_det_ate_2(i).PAC_DNI
                    Item_data.ATE_AÑO = data_det_ate_2(i).ATE_AÑO
                    Item_data.ATE_FECHA = data_det_ate_2(i).ATE_FECHA
                    Item_data.PROC_DESC = data_det_ate_2(i).PROC_DESC
                    Item_data.PROGRA_DESC = data_det_ate_2(i).PROGRA_DESC
                    Item_data.SECTOR_DESC = data_det_ate_2(i).SECTOR_DESC
                    Item_data.CF_DESC = data_det_ate_2(i).CF_DESC
                    Item_data.DOC_NOMBRE = data_det_ate_2(i).DOC_NOMBRE
                    Item_data.DOC_APELLIDO = data_det_ate_2(i).DOC_APELLIDO
                    Item_data.RECEP_ETI_FECHA = data_det_ate_2(i).RECEP_ETI_FECHA
                    Item_data.ATE_OBS_TM = data_det_ate_2(i).ATE_OBS_TM
                    Item_data.EST_DESCRIPCION = data_det_ate_2(i).EST_DESCRIPCION
                    Item_data.RATE_OBS_VIH = data_det_ate_2(i).RATE_OBS_VIH
                    Item_data.PAC_FNAC = data_det_ate_2(i).PAC_FNAC


                    data_det_ate.Add(Item_data)
                Next i
            End If
        End If

        'If data_det_ate.Count > 0 Then
        '    For i = 0 To data_det_ate.Count - 1
        '        data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8(ID_USER, data_det_ate(i).CB_DESC, data_det_ate(i).ATE_NUM)
        '        If data_paciente2.Count > 0 Then
        '            'data_det_ate(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
        '            data_det_ate(i).RECEP_ETI_FECHA = data_paciente2(0).RECEP_ETI_FECHA
        '            'data_det_ate(i).PAC_NOMBRE = data_paciente2(0).PAC_NOMBRE
        '            'data_det_ate(i).PAC_APELLIDO = data_paciente2(0).PAC_APELLIDO

        '        End If
        '    Next i
        'End If

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(15, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(15, y)
                End If

                'Mx_Data(0, y) = y + 1

                Mx_Data(0, y) = CInt(data_det_ate(y).ATE_NUM)
                Mx_Data(1, y) = data_det_ate(y).ATE_NUM_INTERNO



                'EDITAR NOMBRE
                'Editar nombre
                'Dim xNUM As String = ""
                'xNUM &= Mid(data_det_ate(y).PAC_NOMBRE, 1, 1).ToUpper

                'Dim xSurN As String() = data_det_ate(y).PAC_APELLIDO.Split(" ")
                'Select Case (xSurN.GetUpperBound(0))
                '    Case 0
                '        xNUM &= Mid(xSurN(0), 1, 1).ToUpper
                '        xNUM &= "#"
                '    Case Else
                '        xNUM &= Mid(xSurN(0), 1, 1).ToUpper
                '        xNUM &= Mid(xSurN(1), 1, 1).ToUpper
                'End Select

                ''Agregar Fecha Nac
                'If (data_det_ate(y).PAC_RUT = Nothing) Then
                '    data_det_ate(y).PAC_RUT = ""
                'End If
                'If (data_det_ate(y).PAC_RUT.Length < 8) Then
                '    data_det_ate(y).PAC_RUT = "ABC-D"
                'End If
                'xNUM &= Format(CDate(data_det_ate(y).PAC_FNAC), "ddMMyy")
                'xNUM &= Mid(data_det_ate(y).PAC_RUT, data_det_ate(y).PAC_RUT.Length - 4, 5)



                Mx_Data(2, y) = data_det_ate(y).PAC_NOMBRE & " " & data_det_ate(y).PAC_APELLIDO
                If data_det_ate(y).PAC_RUT = "" Then
                    If data_det_ate(y).PAC_DNI = "" Then
                        Mx_Data(3, y) = ""
                    Else
                        Mx_Data(3, y) = data_det_ate(y).PAC_DNI
                    End If

                Else
                    If (data_det_ate(y).PAC_RUT = "ABC-D") Then
                        data_det_ate(y).PAC_RUT = ""
                    End If




                    Mx_Data(3, y) = data_det_ate(y).PAC_RUT
                End If

                Mx_Data(4, y) = data_det_ate(y).ATE_AÑO & " " & "Años"
                Mx_Data(5, y) = data_det_ate(y).PAC_FNAC
                Mx_Data(6, y) = Format(data_det_ate(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(7, y) = Format(data_det_ate(y).ATE_FECHA, "HH:mm:ss")
                Mx_Data(8, y) = data_det_ate(y).PROC_DESC
                Mx_Data(9, y) = data_det_ate(y).PROGRA_DESC
                Mx_Data(10, y) = data_det_ate(y).SECTOR_DESC
                Mx_Data(11, y) = data_det_ate(y).CF_DESC
                Mx_Data(12, y) = data_det_ate(y).DOC_NOMBRE & " " & data_det_ate(y).DOC_APELLIDO


                If data_det_ate(y).RECEP_ETI_FECHA = "12:00:00 AM" Then
                    Mx_Data(13, y) = ""
                Else
                    Mx_Data(13, y) = Format(data_det_ate(y).RECEP_ETI_FECHA, "dd/MM/yyyy HH:mm:ss")
                End If
                Mx_Data(14, y) = data_det_ate(y).ATE_OBS_TM
                'Mx_Data(14, y) = data_det_ate(y).RATE_OBS_VIH
                Mx_Data(15, y) = data_det_ate(y).EST_DESCRIPCION
            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Recepción de Exámenes: Screening SGB")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Recepción de Exámenes: Screening SGB")

        For y = 1 To 16
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "N° Atención")
        sl.SetCellValue("B8", "N° Interno")
        sl.SetCellValue("C8", "Nombre Paciente")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D8", "Rut/DNI")
        sl.SetCellValue("E8", "Edad")
        sl.SetCellValue("F8", "Fecha Nac.")
        sl.SetCellValue("G8", "Fecha")
        sl.SetCellValue("H8", "Hora")
        sl.SetCellValue("I8", "Lugar de TM")
        sl.SetCellValue("J8", "Programa")
        sl.SetCellValue("K8", "Sector")
        sl.SetCellValue("L8", "Examen")
        sl.SetColumnWidth("L", 30)
        sl.SetCellValue("M8", "Doctor")
        sl.SetColumnWidth("M", 40)
        sl.SetCellValue("N8", "Fecha Recep.")
        sl.SetCellValue("O8", "Obs.")
        sl.SetColumnWidth("O", 30)
        'sl.SetCellValue("O8", "Obs. VIH")
        sl.SetCellValue("P8", "Estado")

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
        tabla = sl.CreateTable("A8", CStr("P" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        'Declaraciones internas

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        Dim data_det_ate_2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim Item_data As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8



        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)


        If TIPO = 7 Then ' 7 = NO RECEPCIONADO
            data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_vih(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        ElseIf TIPO = 9 Then '9 RECEPCIONADO
            data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_vih(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        ElseIf TIPO = 0 Then
            data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_vih(7, DESDE, HASTA, ID_PRE, ID_CF)
            data_det_ate_2 = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_vih(9, DESDE, HASTA, ID_PRE, ID_CF)

            If data_det_ate_2.Count > 0 Then
                For i = 0 To data_det_ate_2.Count - 1
                    Item_data = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

                    Item_data.ATE_NUM = data_det_ate_2(i).ATE_NUM
                    Item_data.ATE_NUM_INTERNO = data_det_ate_2(i).ATE_NUM_INTERNO
                    Item_data.PAC_NOMBRE = data_det_ate_2(i).PAC_NOMBRE
                    Item_data.PAC_APELLIDO = data_det_ate_2(i).PAC_APELLIDO
                    Item_data.PAC_RUT = data_det_ate_2(i).PAC_RUT
                    Item_data.PAC_DNI = data_det_ate_2(i).PAC_DNI
                    Item_data.ATE_AÑO = data_det_ate_2(i).ATE_AÑO
                    Item_data.ATE_FECHA = data_det_ate_2(i).ATE_FECHA
                    Item_data.PROC_DESC = data_det_ate_2(i).PROC_DESC
                    Item_data.PROGRA_DESC = data_det_ate_2(i).PROGRA_DESC
                    Item_data.SECTOR_DESC = data_det_ate_2(i).SECTOR_DESC
                    Item_data.CF_DESC = data_det_ate_2(i).CF_DESC
                    Item_data.DOC_NOMBRE = data_det_ate_2(i).DOC_NOMBRE
                    Item_data.DOC_APELLIDO = data_det_ate_2(i).DOC_APELLIDO
                    Item_data.RECEP_ETI_FECHA = data_det_ate_2(i).RECEP_ETI_FECHA
                    Item_data.ATE_OBS_TM = data_det_ate_2(i).ATE_OBS_TM
                    Item_data.EST_DESCRIPCION = data_det_ate_2(i).EST_DESCRIPCION
                    Item_data.RATE_OBS_VIH = data_det_ate_2(i).RATE_OBS_VIH
                    Item_data.ID_ATENCION = data_det_ate_2(i).ID_ATENCION
                    Item_data.PAC_FNAC = data_det_ate_2(i).PAC_FNAC

                    data_det_ate.Add(Item_data)
                Next i
            End If
        End If





        Return data_det_ate
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub


End Class