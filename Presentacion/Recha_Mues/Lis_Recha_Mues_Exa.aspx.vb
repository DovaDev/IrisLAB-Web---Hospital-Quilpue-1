Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports Datos
Imports System.Collections.Generic
Imports System.Runtime.Remoting

Public Class Lis_Recha_Mues_Exa
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
    Public Shared Function Llenar_DataTable(DESDE As String, HASTA As String, ID_PRE As Integer, ID_RLS_LS As Integer, ID_EXAMEN As Integer) As Object
        Return D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1.IRIS_WEB_BUSCA_LISTADO_RECHAZOS_POR_EXAMEN(CDate(DESDE), CDate(HASTA), ID_PRE, ID_RLS_LS, ID_EXAMEN)
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(DOMAIN_URL As String, DESDE As String, HASTA As String, ID_PRE As Integer, ID_RLS_LS As Integer, ID_EXAMEN As Integer) As String
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
        Excel_y = 8
        Dim ltabla As Integer = 0
        Dim edad As Integer = 0
        Dim idate As String = ""


        Dim Mx_Data(23, 0) As Object

        'Declaraciones internas
        Dim data_fechas As List(Of E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO)
        Dim NN_fechas As N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO = New N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO

        'Dim data_lote As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        'Dim item_lote As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim NN_Lote As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim LUGARCITO = CType(objSession("USU_ID_PROC"), Integer)
        Dim ADMINISTRADORCITO = CType(objSession("P_ADMIN"), Integer)


        data_fechas = NN_fechas.IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(CDate(DESDE), CDate(HASTA))


        Dim data_det_ate = D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1.IRIS_WEB_BUSCA_LISTADO_RECHAZOS_POR_EXAMEN(CDate(DESDE), CDate(HASTA), ID_PRE, ID_RLS_LS, ID_EXAMEN)

        data_det_ate = data_det_ate.Where(Function(x) ADMINISTRADORCITO = 1 Or x.ID_PROCEDENCIA = LUGARCITO Or LUGARCITO = 0).ToList()




        If data_det_ate.Count = 0 Then
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Exámenes Rechazados")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Exámenes Rechazados")
        sl.SetCellValue("B4", "Desde: " & DESDE)
        sl.SetCellValue("B5", "Hasta: " & HASTA)

        Dim curCol = Excel_x
        Dim curRow = Excel_y
        'nombre columnas
        sl.SetCellValue(curRow, curCol, "#") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Rut Paciente") : curCol += 1
        sl.SetCellValue(curRow, curCol, "DNI") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Nacionalidad") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Examen Fonasa") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Estado") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Fecha") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Hora") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Nombre Paciente") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Fecha Nac") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Edad") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Folio") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Usuario") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Descripción Sección") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Lugar de TM") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Programa") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Sector") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Motivo") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Observación") : curCol += 1
        sl.SetCellValue(curRow, curCol, "Médico") : curCol += 1

        For i = 0 To data_det_ate.Count - 1

            Dim item = data_det_ate(i)

            curRow += 1
            curCol = Excel_x

            Dim fechaRechazo = Format(item.RECEP_ETI_FECHA_RECHAZO, "dd-MM-yyyy")
            Dim horaRechazo = Format(item.RECEP_ETI_FECHA_RECHAZO, "HH:mm:ss")
            Dim fechaNacimiento = Format(item.PAC_FNAC, "dd-MM-yyyy")
            Dim pacNomCompleto = item.PAC_NOMBRE & " " & item.PAC_APELLIDO
            Dim docNomCompleto = item.DOC_NOMBRE & " " & item.DOC_APELLIDO

            sl.SetCellValue(curRow, curCol, i + 1) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.PAC_RUT) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.ATE_DNI) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.NAC_DESC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.CF_DESC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.EST_DESCRIPCION) : curCol += 1
            sl.SetCellValue(curRow, curCol, fechaRechazo) : curCol += 1
            sl.SetCellValue(curRow, curCol, horaRechazo) : curCol += 1
            sl.SetCellValue(curRow, curCol, pacNomCompleto) : curCol += 1
            sl.SetCellValue(curRow, curCol, fechaNacimiento) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.ATE_AÑO & " Años") : curCol += 1
            sl.SetCellValue(curRow, curCol, item.RECEP_ETI_NUM_ATE_RECHAZO) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.USU_NIC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.RLS_LS_DESC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.PROC_DESC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.PROGRA_DESC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.SECTOR_DESC) : curCol += 1
            sl.SetCellValue(curRow, curCol, item.TP_RECHA_DESC) : curCol += 1
            Dim fecha As DateTime

            ' Intentar convertir el valor a DateTime
            If DateTime.TryParse(item.RECEP_ETI_RECHAZO_OBS, fecha) Then
                ' Insertar el valor en la celda
                sl.SetCellValue(curRow, curCol, fecha)

                ' Crear un estilo para el formato de fecha y hora en 24 horas
                Dim style As New SLStyle()
                style.FormatCode = "dd-MM-yyyy HH:mm"

                ' Aplicar el estilo a la celda
                sl.SetCellStyle(curRow, curCol, style)
            Else
                ' Si no es una fecha válida, insertar el valor tal cual
                sl.SetCellValue(curRow, curCol, item.RECEP_ETI_RECHAZO_OBS)
            End If

            curCol += 1
            sl.SetCellValue(curRow, curCol, docNomCompleto)
        Next
        sl.AutoFitColumn(Excel_x, curCol, 50)
        For i = 1 To curCol
            sl.SetColumnWidth(i, sl.GetColumnWidth(i) + 2)
        Next

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
        tabla = sl.CreateTable(Excel_y, Excel_x, curRow, curCol)
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
End Class