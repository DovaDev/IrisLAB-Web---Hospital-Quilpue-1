Imports Entidades
Imports Negocio
Imports SpreadsheetLight
Public Class Indica_Tiempo_Respuesta
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador

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
    Public Shared Function Llenar_Ddl_Seccion() As List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Prevision As New N_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
        Dim Data_Prevision As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)

        Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
        If (Data_Prevision.Count > 0) Then
            Return Data_Prevision
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                        ByVal HASTA As String,
                                        ByVal ID_CF As Integer,
                                        ByVal ID_FP As Integer,
                                        ByVal ID_PREV As Integer,
                                        ByVal ID_IE As Integer,
                                        ByVal ID_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION)
        'Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION(CDate(DESDE), CDate(HASTA), ID_CF, ID_FP, ID_PREV, ID_IE, ID_SECC)

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
                                        ByVal ID_CF As Integer,
                                        ByVal ID_FP As Integer,
                                        ByVal ID_PREV As Integer,
                                        ByVal ID_IE As Integer,
                                        ByVal ID_SECC As Integer) As String
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION)

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
        Dim Last_Ate As Integer, Ate_Tot As Integer
        Dim max_tot As Integer = 0
        Dim Mx_Data(11, 0) As Object
        Dim Arr_primera As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION)
        Dim cont As Integer = 0, cont_si As Integer, cont_no As Integer
        Arr_primera = NN.IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION(CDate(DESDE), CDate(HASTA), ID_CF, ID_FP, ID_PREV, ID_IE, ID_SECC)

        If (Arr_primera.Count > 0) Then
            For y = 0 To (Arr_primera.Count - 1)
                If (Arr_primera(y).ATE_DET_V_ID_ESTADO = 6 Or Arr_primera(y).ATE_DET_V_ID_ESTADO = 14) Then
                    Data_Datos_Pac.Add(Arr_primera(y))
                    cont = cont + 1
                End If
            Next y
        End If
        If (Data_Datos_Pac.Count > 0) Then
            'Vaciar Matriz
            ReDim Mx_Data(11, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data_Datos_Pac.Count - 1)
                ' If Data_Datos_Pac(y).ATE_DET_V_ID_ESTADO = 6 Or Data_Datos_Pac(y).ATE_DET_V_ID_ESTADO = 14 Then
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
                Mx_Data(5, y) = Data_Datos_Pac(y).CF_DESC
                Mx_Data(6, y) = Data_Datos_Pac(y).PROC_DESC
                Mx_Data(7, y) = Format(Data_Datos_Pac(y).ATE_FECHA, "dd/MM/yyyy H:mm:ss")
                Mx_Data(8, y) = Format(Data_Datos_Pac(y).ATE_DET_V_FECHA, "dd/MM/yyyy H:mm:ss")
                If Data_Datos_Pac(y).CF_TIEMPO_NORMAL = Nothing Then
                    Mx_Data(9, y) = "24 Hrs"
                    max_tot = 24
                Else
                    Mx_Data(9, y) = Data_Datos_Pac(y).CF_TIEMPO_NORMAL + " Hrs"
                    max_tot = Data_Datos_Pac(y).CF_TIEMPO_NORMAL
                End If

                Dim ms_crea As Integer
                Dim ms_valida As Integer
                Dim difff As Integer

                max_tot = (max_tot * 60) * 60 - 1

                ms_crea = (Data_Datos_Pac(y).ATE_DET_V_FECHA - Data_Datos_Pac(y).ATE_FECHA).TotalSeconds

                difff = ms_crea - ms_valida

                Dim _Hora As Integer = Math.Floor(difff / 3600)
                Dim _Minutos As Integer = Math.Floor((difff - (_Hora * 3600)) / 60)
                Dim _Segundos As Integer = difff - (_Hora * 3600) - (_Minutos * 60)
                Dim _Hora_str As String
                Dim _Minutosa_str As String
                Dim _Segundos_str As String

                If _Hora < 10 Then
                    _Hora_str = "0" + _Hora
                Else
                    _Hora_str = _Hora
                End If
                If _Minutos < 10 Then
                    _Minutosa_str = "0" + _Minutos
                Else
                    _Minutosa_str = _Minutos
                End If
                If _Segundos < 10 Then
                    _Segundos_str = "0" + _Segundos
                Else
                    _Segundos_str = _Segundos
                End If

                Mx_Data(10, y) = _Hora_str + ":" + _Minutosa_str + ":" + _Segundos_str

                If difff <= max_tot Then
                    Mx_Data(11, y) = "SI"
                    cont_si = cont_si + 1
                ElseIf difff >= max_tot Then
                    Mx_Data(11, y) = "NO"
                    cont_no = cont_no + 1
                End If

                'End If
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
        sl.SetCellValue("F18", "Examen")
        sl.SetColumnWidth("F", 40)
        sl.SetCellValue("G18", "Lugar TM")
        sl.SetCellValue("H18", "Fecha Creación")
        sl.SetCellValue("I18", "Fecha Validación")
        sl.SetCellValue("J18", "Max")
        sl.SetColumnWidth("J", 20)
        sl.SetCellValue("K18", "Diferencia")
        sl.SetCellValue("L18", "Aprobo")
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

        sl.SetCellValue("C10", "Cumplido. SI")
        sl.SetCellValue("C11", "Cumplido. NO")


        'COl2
        sl.SetCellValue("D6", "Total")
        sl.SetCellValue("D7", Ate_Tot)
        sl.SetCellValue("D8", cont)

        sl.SetCellValue("D10", cont_si)
        sl.SetCellValue("D11", cont_no)


        'Col3
        Dim cont_si_pc As Integer, cont_no_pc As Integer

        cont_si_pc = (cont_si * 100) / cont
        cont_no_pc = (cont_no * 100) / cont


        sl.SetCellValue("E6", "Porcentaje")
        sl.SetCellValue("E7", "100%")
        sl.SetCellValue("E8", "100%")

        sl.SetCellValue("E10", cont_si_pc & "%")
        sl.SetCellValue("E11", cont_no_pc & "%")




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

        sl.SetCellStyle("D6", "D11", estilo4)
        sl.SetCellStyle("E6", "E11", estilo4)

        'insertar tabla
        tabla = sl.CreateTable("A18", CStr("L" & ltabla))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        tabla2 = sl.CreateTable("C6", "E11")
        tabla2.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla2)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class