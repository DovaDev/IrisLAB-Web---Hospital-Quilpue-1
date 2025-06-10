Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Indica_Muestra_Ingresa
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            Return Data_LugarTM
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Orden_Ate() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Orden_Ate As New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
        Dim Data_Orden_Ate As New List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)

        Data_Orden_Ate = NN_Orden_Ate.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
        If (Data_Orden_Ate.Count > 0) Then
            Return Data_Orden_Ate
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prevision() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Prevision As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Prevision As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Prevision.Count > 0) Then
            Return Data_Prevision
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal ID_PREV As Integer,
                                            ByVal ID_PROC As Integer,
                                            ByVal ID_IE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1)
        Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1(CDate(DESDE), CDate(HASTA), ID_PREV, ID_PROC, ID_IE)

        If (Data.Count > 0) Then
            For i = 0 To (Data.Count - 1)
                Data(i).ENCRYPTED_ID = N_ECrypt.Encode(Data(i).ID_ATENCION)
            Next i
            Return Data
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String,
                                            ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal ID_PREV As Integer,
                                            ByVal ID_PROC As Integer,
                                            ByVal ID_IE As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1)

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim estilo4 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 19
        Dim ltabla As Integer = 0
        Dim Last_Ate As Integer, Ate_Tot As Integer, Si_Recep_Tot As Integer, No_Recep_Tot As Integer, Si_Deriva_Tot As Integer, No_Deriva_Tot As Integer, Si_Recha_Tot As Integer, No_Recha_Tot As Integer
        Dim Mx_Data(11, 0) As Object

        Data_Datos_Pac = NN.IRIS_WEBF_BUSCA_ACREDITACION_ETIQUETAS_ESTADOS_CHECK_1(CDate(DESDE), CDate(HASTA), ID_PREV, ID_PROC, ID_IE)

        If (Data_Datos_Pac.Count > 0) Then

            'Vaciar Matriz
            ReDim Mx_Data(11, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data_Datos_Pac.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(11, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(Data_Datos_Pac(y).ATE_NUM)


                If (Last_Ate <> Mx_Data(1, y)) Then
                    Ate_Tot = Ate_Tot + 1
                    Last_Ate = Mx_Data(1, y)
                End If


                Mx_Data(2, y) = Data_Datos_Pac(y).PAC_NOMBRE + " " + Data_Datos_Pac(y).PAC_APELLIDO
                Mx_Data(3, y) = Data_Datos_Pac(y).PAC_RUT
                Mx_Data(4, y) = Data_Datos_Pac(y).ATE_AÑO
                Mx_Data(5, y) = Format(Data_Datos_Pac(y).ATE_FECHA, "dd/mm/yyyy")
                Mx_Data(6, y) = Data_Datos_Pac(y).PROC_DESC
                Mx_Data(7, y) = Data_Datos_Pac(y).T_MUESTRA_DESC
                Mx_Data(8, y) = Data_Datos_Pac(y).CB_DESC

                If Data_Datos_Pac(y).ID_RECEP_ETI <> 0 Then
                    Si_Recep_Tot = Si_Recep_Tot + 1
                    Mx_Data(9, y) = "SI"
                Else
                    No_Recep_Tot = No_Recep_Tot + 1
                    Mx_Data(9, y) = "NO"
                End If

                If Data_Datos_Pac(y).ID_RECEP_ETI_DERIVA <> 0 Then
                    Si_Deriva_Tot = Si_Deriva_Tot + 1
                    Mx_Data(10, y) = "SI"
                Else
                    No_Deriva_Tot = No_Deriva_Tot + 1
                    Mx_Data(10, y) = "NO"
                End If

                If Data_Datos_Pac(y).ID_RECEP_ETI_RECHAZO <> 0 Then
                    Si_Recha_Tot = Si_Recha_Tot + 1
                    Mx_Data(11, y) = "SI"
                Else
                    No_Recha_Tot = No_Recha_Tot + 1
                    Mx_Data(11, y) = "NO"
                End If
            Next y
        Else
            Return Nothing
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Atenciones")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Atenciones")

        For y = 1 To 12
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A18", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B18", "N° Atención")
        sl.SetCellValue("C18", "Nombre")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D18", "RUT")
        sl.SetCellValue("E18", "Edad")
        sl.SetCellValue("F18", "Fecha")
        sl.SetCellValue("G18", "Lugar TM")
        sl.SetCellValue("H18", "Tipo Etiqueta")
        sl.SetCellValue("I18", "CB")
        sl.SetColumnWidth("I", 20)
        sl.SetCellValue("J18", "Recep")
        sl.SetColumnWidth("J", 10)
        sl.SetCellValue("K18", "Derivado")
        sl.SetColumnWidth("K", 10)
        sl.SetCellValue("L18", "Rechazo")
        sl.SetColumnWidth("L", 10)

        Dim YY As Integer
        Dim XX As Integer
        For YY = 0 To Mx_Data.GetUpperBound(1)
            For XX = 0 To Mx_Data.GetUpperBound(0)

                sl.SetCellValue(YY + Excel_y, XX + 1, Mx_Data(XX, YY))

            Next XX
            ltabla += 1
        Next YY

        sl.SetCellValue("B3", "Desde: " & CDate(DESDE) & " - Hasta: " & CDate(HASTA))



        'Col1
        sl.SetCellValue("C6", "Descripción")
        sl.SetCellValue("C7", "Atenciones")
        sl.SetCellValue("C8", "Examenes")

        sl.SetCellValue("C10", "Recepcionado. SI")
        sl.SetCellValue("C11", "Recepcionado. NO")
        sl.SetCellValue("C12", "Derivado SI")
        sl.SetCellValue("C13", "Derivado NO")
        sl.SetCellValue("C14", "Rechazado SI")
        sl.SetCellValue("C15", "Rechazado NO")

        'COl2
        sl.SetCellValue("D6", "Total")
        sl.SetCellValue("D7", Ate_Tot)
        sl.SetCellValue("D8", Si_Deriva_Tot + No_Deriva_Tot)

        sl.SetCellValue("D10", Si_Recep_Tot)
        sl.SetCellValue("D11", No_Recep_Tot)
        sl.SetCellValue("D12", Si_Deriva_Tot)
        sl.SetCellValue("D13", No_Deriva_Tot)
        sl.SetCellValue("D14", Si_Recha_Tot)
        sl.SetCellValue("D15", No_Recha_Tot)

        'Col3
        Dim Si_Recep_Tot_pc As Integer, No_Recep_Tot_pc As Integer, Si_Deriv_Tot_pc As Integer, No_Deriv_Tot_pc As Integer, Si_Recha_Tot_pc As Integer, No_Recha_Tot_pc As Integer, Tot As Integer
        Tot = Si_Recep_Tot + No_Recep_Tot

        Si_Recep_Tot_pc = (Si_Recep_Tot * 100) / Tot
        No_Recep_Tot_pc = (No_Recep_Tot * 100) / Tot
        Si_Deriv_Tot_pc = (Si_Deriva_Tot * 100) / Tot
        No_Deriv_Tot_pc = (No_Deriva_Tot * 100) / Tot
        Si_Recha_Tot_pc = (Si_Recha_Tot * 100) / Tot
        No_Recha_Tot_pc = (No_Recha_Tot * 100) / Tot

        sl.SetCellValue("E6", "Porcentaje")
        sl.SetCellValue("E7", "100%")
        sl.SetCellValue("E8", "100%")

        sl.SetCellValue("E10", Si_Recep_Tot_pc & "%")
        sl.SetCellValue("E11", No_Recep_Tot_pc & "%")
        sl.SetCellValue("E12", Si_Deriv_Tot_pc & "%")
        sl.SetCellValue("E13", No_Deriv_Tot_pc & "%")
        sl.SetCellValue("E14", Si_Recha_Tot_pc & "%")
        sl.SetCellValue("E15", No_Recha_Tot_pc & "%")


        ltabla += 18
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True

        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 12
        estilo2.Font.Bold = True

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True

        estilo4 = sl.CreateStyle()
        estilo4.SetHorizontalAlignment(HorizontalAlign.Center)

        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)

        sl.SetCellStyle("D6", "D15", estilo4)
        sl.SetCellStyle("E6", "E15", estilo4)

        'insertar tabla
        tabla = sl.CreateTable("A18", CStr("L" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        tabla2 = sl.CreateTable("C6", "E15")
        tabla2.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla2)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class