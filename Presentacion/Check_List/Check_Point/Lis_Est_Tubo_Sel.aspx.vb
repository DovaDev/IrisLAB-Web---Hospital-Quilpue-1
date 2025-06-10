Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Est_Tubo_Sel
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
        Dim NN_Seccion As New N_IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA
        Dim Data_Seccion As New List(Of E_IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA)

        Data_Seccion = NN_Seccion.IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA()
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
    Public Shared Function Llenar_DataTable(ByVal TIPO As Integer,
                                            ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_VAL As Integer,
                                            ByVal ID_NMUE As Integer,
                                            ByVal ID_SECCION As Integer,
                                            ByVal ID_TUBO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS)
        Dim N_ECrypt As New N_Encrypt
        Dim ID_SECC = 0

        Data = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS(TIPO, CDate(DESDE), CDate(HASTA), ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ID_TUBO)

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
                                 ByVal TIPO As Integer,
                                            ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_VAL As Integer,
                                            ByVal ID_NMUE As Integer,
                                            ByVal ID_SECCION As Integer,
                                            ByVal ID_TUBO As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS)

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

        Dim Mx_Data(14, 0) As Object

        Data_Datos_Pac = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS(TIPO, CDate(DESDE), CDate(HASTA), ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ID_TUBO)

        If (Data_Datos_Pac.Count > 0) Then

            'Vaciar Matriz
            ReDim Mx_Data(14, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data_Datos_Pac.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(14, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(Data_Datos_Pac(y).ATE_NUM)
                Mx_Data(2, y) = Data_Datos_Pac(y).PAC_NOMBRE + " " + Data_Datos_Pac(y).PAC_APELLIDO
                Mx_Data(3, y) = Data_Datos_Pac(y).ATE_AÑO
                Mx_Data(4, y) = Format(Data_Datos_Pac(y).ATE_FECHA, "dd/mm/yyyy")
                Mx_Data(5, y) = Data_Datos_Pac(y).PROC_DESC
                Mx_Data(6, y) = Data_Datos_Pac(y).CF_DESC
                Mx_Data(7, y) = Data_Datos_Pac(y).T_MUESTRA_DESC
                Mx_Data(8, y) = Data_Datos_Pac(y).CB_DESC

                If Data_Datos_Pac(y).ATE_EST_RECEP = "9" Then
                    Mx_Data(9, y) = "SI"
                Else
                    Mx_Data(9, y) = "NO"
                End If

                If Data_Datos_Pac(y).ATE_DET_V_ID_ESTADO = "6" Or Data_Datos_Pac(y).ATE_DET_V_ID_ESTADO = "14" Then
                    Mx_Data(10, y) = "SI"
                Else
                    Mx_Data(10, y) = "NO"
                End If

                If Data_Datos_Pac(y).ATE_DET_REV_ID_ESTADO = "1" Then
                    Mx_Data(11, y) = "SI"
                Else
                    Mx_Data(11, y) = "NO"
                End If

                If Data_Datos_Pac(y).ATE_EST_RECHAZO = "16" Then
                    Mx_Data(12, y) = "SI"
                Else
                    Mx_Data(12, y) = "NO"
                End If

                Mx_Data(13, y) = Data_Datos_Pac(y).PAC_RUT


                Mx_Data(14, y) = Data_Datos_Pac(y).ATE_NUM_INTERNO

            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Tubos por Sección")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Tubos por Sección")

        For y = 1 To 15
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Nombre")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D8", "Edad")
        sl.SetCellValue("E8", "Fecha")
        sl.SetCellValue("F8", "Lugar TM")
        sl.SetCellValue("G8", "Examen")
        sl.SetColumnWidth("G", 30)
        sl.SetCellValue("H8", "Tipo Etiqueta")
        sl.SetCellValue("I8", "CB")
        sl.SetColumnWidth("I", 20)
        sl.SetCellValue("J8", "Recep")
        sl.SetColumnWidth("J", 10)
        sl.SetCellValue("K8", "Validado")
        sl.SetColumnWidth("K", 10)
        sl.SetCellValue("L8", "Revisado")
        sl.SetColumnWidth("L", 10)
        sl.SetCellValue("M8", "Nueva Muestra")
        sl.SetColumnWidth("M", 10)
        sl.SetCellValue("N8", "RUT")
        sl.SetCellValue("O8", "N° Interno")


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
        tabla = sl.CreateTable("A8", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class