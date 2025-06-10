Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Recha_Mues_TP
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function DDL_TIPO_RECHAZO_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        Dim data_rechazo_activo As List(Of E_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS)
        Dim NN_rechazo_activos As N_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS = New N_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS

        data_rechazo_activo = NN_rechazo_activos.IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS()

        If data_rechazo_activo.Count > 0 Then
            Return data_rechazo_activo
        Else
            Return Nothing
        End If



    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TP_RECHA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim data_fechas As List(Of E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO)
        Dim NN_fechas As N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO = New N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO

        Dim data_lote As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        Dim data_lote2 As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        Dim item_lote As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2
        Dim NN_Lote As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2

        Dim data_pacienteUSU As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN2USU As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_fechas = NN_fechas.IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(CDate(DESDE), CDate(HASTA))

        If data_fechas.Count > 0 Then
            For i = 0 To data_fechas.Count - 1
                data_lote = NN_Lote.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2(data_fechas(i).LOTE_RECHAZO_NUM, ID_TP_RECHA)

                If data_lote.Count > 0 Then
                    For ii = 0 To data_lote.Count - 1
                        item_lote = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2

                        data_pacienteUSU = NN2USU.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_lote(ii).ID_USUARIO)

                        If data_pacienteUSU.Count > 0 Then
                            item_lote.USU_NIC = data_pacienteUSU(0).USU_NIC
                        Else
                            item_lote.USU_NIC = "< Sin Usuario >"
                        End If

                        item_lote.LOTE_RECHAZO_NUM = data_lote(ii).LOTE_RECHAZO_NUM
                        item_lote.ID_ATENCION = data_lote(ii).ID_ATENCION
                        item_lote.RECEP_ETI_CURVA_RECHAZO = data_lote(ii).RECEP_ETI_CURVA_RECHAZO
                        item_lote.RECEP_ETI_NUM_ATE_RECHAZO = data_lote(ii).RECEP_ETI_NUM_ATE_RECHAZO
                        item_lote.ID_USUARIO = data_lote(ii).ID_USUARIO
                        item_lote.RECEP_ETI_RECHAZO_OBS = data_lote(ii).RECEP_ETI_RECHAZO_OBS
                        item_lote.RECEP_ETI_FECHA_RECHAZO = data_lote(ii).RECEP_ETI_FECHA_RECHAZO
                        item_lote.ID_LOTE_RECHAZO = data_lote(ii).ID_LOTE_RECHAZO
                        item_lote.ID_ESTADO = data_lote(ii).ID_ESTADO
                        item_lote.CB_DESC = data_lote(ii).CB_DESC
                        item_lote.T_MUESTRA_DESC = data_lote(ii).T_MUESTRA_DESC
                        item_lote.CF_DESC = data_lote(ii).CF_DESC
                        item_lote.PAC_NOMBRE = data_lote(ii).PAC_NOMBRE
                        item_lote.PAC_APELLIDO = data_lote(ii).PAC_APELLIDO
                        item_lote.RLS_LS_DESC = data_lote(ii).RLS_LS_DESC
                        item_lote.ID_RLS_LS = data_lote(ii).ID_RLS_LS
                        item_lote.EST_DESCRIPCION = data_lote(ii).EST_DESCRIPCION
                        item_lote.ID_PER = data_lote(ii).ID_PER
                        item_lote.PROC_DESC = data_lote(ii).PROC_DESC
                        item_lote.ATE_AÑO = data_lote(ii).ATE_AÑO
                        item_lote.ATE_MES = data_lote(ii).ATE_MES
                        'item_lote.USU_NIC = data_lote(ii).USU_NIC
                        item_lote.ATE_DIA = data_lote(ii).ATE_DIA
                        item_lote.SEXO_DESC = data_lote(ii).SEXO_DESC
                        item_lote.TP_RECHA_DESC = data_lote(ii).TP_RECHA_DESC
                        item_lote.ID_TP_RECHA = data_lote(ii).ID_TP_RECHA
                        item_lote.PAC_RUT = data_lote(ii).PAC_RUT
                        item_lote.PAC_FNAC = data_lote(ii).PAC_FNAC
                        item_lote.ATE_NUM = data_lote(ii).ATE_NUM
                        item_lote.ATE_NUM_INTERNO = data_lote(ii).ATE_NUM_INTERNO
                        item_lote.ATE_DNI = data_lote(ii).ATE_DNI
                        item_lote.DOC_NOMBRE = data_lote(ii).DOC_NOMBRE
                        item_lote.DOC_APELLIDO = data_lote(ii).DOC_APELLIDO
                        item_lote.ID_PROCEDENCIA = data_lote(ii).ID_PROCEDENCIA
                        item_lote.NAC_DESC = data_lote(ii).NAC_DESC
                        item_lote.PROGRA_DESC = data_lote(ii).PROGRA_DESC
                        item_lote.SECTOR_DESC = data_lote(ii).SECTOR_DESC


                        data_lote2.Add(item_lote)
                    Next ii
                End If
            Next i
        Else
            Return "null"
        End If

        If (data_lote2.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_lote2, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TP_RECHA As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""


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


        Dim Mx_Data(23, 0) As Object

        'Declaraciones internas
        Dim data_fechas As List(Of E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO)
        Dim NN_fechas As N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO = New N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO

        Dim data_lote As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        Dim data_det_ate As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        Dim item_lote As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2
        Dim NN_Lote As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2
        Dim data_pacienteUSU As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN2USU As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim LUGARCITO = CType(objSession("USU_TM"), Integer)
        Dim ADMINISTRADORCITO = CType(objSession("P_ADMIN"), Integer)


        data_fechas = NN_fechas.IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(CDate(DESDE), CDate(HASTA))

        If data_fechas.Count > 0 Then
            For i = 0 To data_fechas.Count - 1
                data_lote = NN_Lote.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2(data_fechas(i).LOTE_RECHAZO_NUM, ID_TP_RECHA)

                If data_lote.Count > 0 Then
                    If ADMINISTRADORCITO <> 1 Then
                        For ii = 0 To data_lote.Count - 1

                            If LUGARCITO = data_lote(ii).ID_PROCEDENCIA Then

                                item_lote = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2

                                data_pacienteUSU = NN2USU.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_lote(ii).ID_USUARIO)

                                If data_pacienteUSU.Count > 0 Then
                                    item_lote.USU_NIC = data_pacienteUSU(0).USU_NIC
                                Else
                                    item_lote.USU_NIC = "< Sin Usuario >"
                                End If

                                item_lote.LOTE_RECHAZO_NUM = data_lote(ii).LOTE_RECHAZO_NUM
                                item_lote.ID_ATENCION = data_lote(ii).ID_ATENCION
                                item_lote.RECEP_ETI_CURVA_RECHAZO = data_lote(ii).RECEP_ETI_CURVA_RECHAZO
                                item_lote.RECEP_ETI_NUM_ATE_RECHAZO = data_lote(ii).RECEP_ETI_NUM_ATE_RECHAZO
                                item_lote.ID_USUARIO = data_lote(ii).ID_USUARIO
                                item_lote.RECEP_ETI_RECHAZO_OBS = data_lote(ii).RECEP_ETI_RECHAZO_OBS
                                item_lote.RECEP_ETI_FECHA_RECHAZO = data_lote(ii).RECEP_ETI_FECHA_RECHAZO
                                item_lote.ID_LOTE_RECHAZO = data_lote(ii).ID_LOTE_RECHAZO
                                item_lote.ID_ESTADO = data_lote(ii).ID_ESTADO
                                item_lote.CB_DESC = data_lote(ii).CB_DESC
                                item_lote.T_MUESTRA_DESC = data_lote(ii).T_MUESTRA_DESC
                                item_lote.CF_DESC = data_lote(ii).CF_DESC
                                item_lote.PAC_NOMBRE = data_lote(ii).PAC_NOMBRE
                                item_lote.PAC_APELLIDO = data_lote(ii).PAC_APELLIDO
                                item_lote.RLS_LS_DESC = data_lote(ii).RLS_LS_DESC
                                item_lote.ID_RLS_LS = data_lote(ii).ID_RLS_LS
                                item_lote.EST_DESCRIPCION = data_lote(ii).EST_DESCRIPCION
                                item_lote.ID_PER = data_lote(ii).ID_PER
                                item_lote.PROC_DESC = data_lote(ii).PROC_DESC
                                item_lote.ATE_AÑO = data_lote(ii).ATE_AÑO
                                item_lote.ATE_MES = data_lote(ii).ATE_MES
                                'item_lote.USU_NIC = data_lote(ii).USU_NIC
                                item_lote.ATE_DIA = data_lote(ii).ATE_DIA
                                item_lote.SEXO_DESC = data_lote(ii).SEXO_DESC
                                item_lote.TP_RECHA_DESC = data_lote(ii).TP_RECHA_DESC
                                item_lote.ID_TP_RECHA = data_lote(ii).ID_TP_RECHA
                                item_lote.PAC_RUT = data_lote(ii).PAC_RUT
                                item_lote.PAC_FNAC = data_lote(ii).PAC_FNAC
                                item_lote.ATE_NUM = data_lote(ii).ATE_NUM
                                item_lote.ATE_NUM_INTERNO = data_lote(ii).ATE_NUM_INTERNO
                                item_lote.ATE_DNI = data_lote(ii).ATE_DNI
                                item_lote.DOC_NOMBRE = data_lote(ii).DOC_NOMBRE
                                item_lote.DOC_APELLIDO = data_lote(ii).DOC_APELLIDO
                                item_lote.ID_PROCEDENCIA = data_lote(ii).ID_PROCEDENCIA
                                item_lote.NAC_DESC = data_lote(ii).NAC_DESC
                                item_lote.PROGRA_DESC = data_lote(ii).PROGRA_DESC
                                item_lote.SECTOR_DESC = data_lote(ii).SECTOR_DESC


                                data_det_ate.Add(item_lote)
                            End If
                        Next ii

                    Else
                        For ii = 0 To data_lote.Count - 1
                            item_lote = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2

                            data_pacienteUSU = NN2USU.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_lote(ii).ID_USUARIO)

                            If data_pacienteUSU.Count > 0 Then
                                item_lote.USU_NIC = data_pacienteUSU(0).USU_NIC
                            Else
                                item_lote.USU_NIC = "< Sin Usuario >"
                            End If

                            item_lote.LOTE_RECHAZO_NUM = data_lote(ii).LOTE_RECHAZO_NUM
                            item_lote.ID_ATENCION = data_lote(ii).ID_ATENCION
                            item_lote.RECEP_ETI_CURVA_RECHAZO = data_lote(ii).RECEP_ETI_CURVA_RECHAZO
                            item_lote.RECEP_ETI_NUM_ATE_RECHAZO = data_lote(ii).RECEP_ETI_NUM_ATE_RECHAZO
                            item_lote.ID_USUARIO = data_lote(ii).ID_USUARIO
                            item_lote.RECEP_ETI_RECHAZO_OBS = data_lote(ii).RECEP_ETI_RECHAZO_OBS
                            item_lote.RECEP_ETI_FECHA_RECHAZO = data_lote(ii).RECEP_ETI_FECHA_RECHAZO
                            item_lote.ID_LOTE_RECHAZO = data_lote(ii).ID_LOTE_RECHAZO
                            item_lote.ID_ESTADO = data_lote(ii).ID_ESTADO
                            item_lote.CB_DESC = data_lote(ii).CB_DESC
                            item_lote.T_MUESTRA_DESC = data_lote(ii).T_MUESTRA_DESC
                            item_lote.CF_DESC = data_lote(ii).CF_DESC
                            item_lote.PAC_NOMBRE = data_lote(ii).PAC_NOMBRE
                            item_lote.PAC_APELLIDO = data_lote(ii).PAC_APELLIDO
                            item_lote.RLS_LS_DESC = data_lote(ii).RLS_LS_DESC
                            item_lote.ID_RLS_LS = data_lote(ii).ID_RLS_LS
                            item_lote.EST_DESCRIPCION = data_lote(ii).EST_DESCRIPCION
                            item_lote.ID_PER = data_lote(ii).ID_PER
                            item_lote.PROC_DESC = data_lote(ii).PROC_DESC
                            item_lote.ATE_AÑO = data_lote(ii).ATE_AÑO
                            item_lote.ATE_MES = data_lote(ii).ATE_MES
                            item_lote.ATE_DIA = data_lote(ii).ATE_DIA
                            item_lote.SEXO_DESC = data_lote(ii).SEXO_DESC
                            item_lote.TP_RECHA_DESC = data_lote(ii).TP_RECHA_DESC
                            item_lote.ID_TP_RECHA = data_lote(ii).ID_TP_RECHA
                            item_lote.PAC_RUT = data_lote(ii).PAC_RUT
                            item_lote.PAC_FNAC = data_lote(ii).PAC_FNAC
                            item_lote.ATE_NUM = data_lote(ii).ATE_NUM
                            item_lote.ATE_NUM_INTERNO = data_lote(ii).ATE_NUM_INTERNO
                            item_lote.ATE_DNI = data_lote(ii).ATE_DNI
                            item_lote.DOC_NOMBRE = data_lote(ii).DOC_NOMBRE
                            item_lote.DOC_APELLIDO = data_lote(ii).DOC_APELLIDO
                            item_lote.ID_PROCEDENCIA = data_lote(ii).ID_PROCEDENCIA
                            item_lote.NAC_DESC = data_lote(ii).NAC_DESC
                            item_lote.PROGRA_DESC = data_lote(ii).PROGRA_DESC
                            item_lote.SECTOR_DESC = data_lote(ii).SECTOR_DESC


                            data_det_ate.Add(item_lote)
                        Next ii
                    End If
                End If
            Next i
        Else
            Return "null"
        End If

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(23, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(23, y)
                End If



                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = data_det_ate(y).PAC_RUT
                Mx_Data(2, y) = data_det_ate(y).ATE_DNI
                Mx_Data(3, y) = data_det_ate(y).NAC_DESC
                Mx_Data(4, y) = "[" & data_det_ate(y).RECEP_ETI_CURVA_RECHAZO & "]" & data_det_ate(y).T_MUESTRA_DESC
                Mx_Data(5, y) = data_det_ate(y).CF_DESC
                Mx_Data(6, y) = data_det_ate(y).EST_DESCRIPCION
                Mx_Data(7, y) = Format(data_det_ate(y).RECEP_ETI_FECHA_RECHAZO, "dd/MM/yyyy")
                Mx_Data(8, y) = Format(data_det_ate(y).RECEP_ETI_FECHA_RECHAZO, "HH:mm:ss")
                Mx_Data(9, y) = data_det_ate(y).PAC_NOMBRE & " " & data_det_ate(y).PAC_APELLIDO
                Mx_Data(10, y) = Format(data_det_ate(y).PAC_FNAC, "dd/MM/yyyy")
                Mx_Data(11, y) = data_det_ate(y).ATE_AÑO & " Años"
                Mx_Data(12, y) = data_det_ate(y).RECEP_ETI_NUM_ATE_RECHAZO
                Mx_Data(13, y) = data_det_ate(y).LOTE_RECHAZO_NUM
                Mx_Data(14, y) = data_det_ate(y).USU_NIC
                Mx_Data(15, y) = data_det_ate(y).RLS_LS_DESC
                Mx_Data(16, y) = data_det_ate(y).PROC_DESC
                Mx_Data(17, y) = data_det_ate(y).ATE_NUM
                Mx_Data(18, y) = data_det_ate(y).ATE_NUM_INTERNO
                Mx_Data(19, y) = data_det_ate(y).PROGRA_DESC
                Mx_Data(20, y) = data_det_ate(y).SECTOR_DESC
                Mx_Data(21, y) = data_det_ate(y).TP_RECHA_DESC
                Mx_Data(22, y) = data_det_ate(y).RECEP_ETI_RECHAZO_OBS
                Mx_Data(23, y) = data_det_ate(y).DOC_NOMBRE & " " & data_det_ate(y).DOC_APELLIDO
            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Exámenes Rechazados")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Exámenes Rechazados")
        sl.SetCellValue("B4", "Desde: " & DESDE)
        sl.SetCellValue("B5", "Hasta: " & HASTA)

        For y = 1 To 24
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 8)
        sl.SetCellValue("B8", "Rut Paciente")
        sl.SetColumnWidth("B", 20)
        sl.SetCellValue("C8", "DNI")
        sl.SetColumnWidth("C", 10)
        sl.SetCellValue("D8", "Nacionalidad")
        sl.SetCellValue("E8", "Etiqueta")
        sl.SetCellValue("F8", "Examen Fonasa")
        sl.SetColumnWidth("F", 40)
        sl.SetCellValue("G8", "Estado")
        sl.SetCellValue("H8", "Fecha")
        sl.SetColumnWidth("H", 15)
        sl.SetCellValue("I8", "Hora")
        sl.SetColumnWidth("I", 15)
        sl.SetCellValue("J8", "Nombre Paciente")
        sl.SetColumnWidth("J", 40)
        sl.SetCellValue("K8", "Fecha Nac")
        sl.SetCellValue("L8", "Edad")
        sl.SetColumnWidth("L", 15)
        sl.SetCellValue("M8", "Folio")
        sl.SetColumnWidth("M", 10)
        sl.SetCellValue("N8", "N° Lote")
        sl.SetColumnWidth("N", 10)
        sl.SetCellValue("O8", "usuario")
        sl.SetCellValue("P8", "Descripción Sección")
        sl.SetColumnWidth("P", 40)
        sl.SetCellValue("Q8", "Lugar de TM")
        sl.SetCellValue("R8", "Número Atención")
        sl.SetColumnWidth("R", 15)
        sl.SetCellValue("S8", "Num Interno")
        sl.SetColumnWidth("S", 15)
        sl.SetCellValue("T8", "Programa")
        sl.SetCellValue("U8", "Sector")
        sl.SetCellValue("V8", "Motivo")
        sl.SetColumnWidth("V", 40)
        sl.SetCellValue("W8", "Observación")
        sl.SetColumnWidth("W", 60)
        sl.SetCellValue("X8", "Médico")

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
        sl.SetCellStyle("B4", estilo2)
        sl.SetCellStyle("B5", estilo2)

        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("X" & ltabla + 1))
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
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 3
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

End Class