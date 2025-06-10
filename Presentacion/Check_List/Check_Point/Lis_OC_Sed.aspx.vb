Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports ASPPDFLib
Public Class Lis_OC_Sed
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal seleccion As Integer) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED = New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED

        Dim data_pac As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim NN_pac As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES

        Dim data_2 As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES)
        Dim NN_2 As N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES = New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES

        If seleccion = 0 Then
            data = NN.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED(DESDE, HASTA)

            If data.Count > 0 Then
                For i = 0 To data.Count - 1
                    data_pac = NN_pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data(i).ID_ATENCION)
                    data(i).PAC_RUT = data_pac(0).PAC_RUT
                Next i


                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data, str_Builder)
                Return str_Builder.ToString
            Else
                Return "null"
            End If

        Else
            data_2 = NN_2.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES(DESDE, HASTA)

            If data_2.Count > 0 Then
                For i = 0 To data_2.Count - 1
                    data_pac = NN_pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data_2(i).ID_ATENCION)
                    data_2(i).PAC_RUT = data_pac(0).PAC_RUT
                Next i

                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data_2, str_Builder)
                Return str_Builder.ToString
            Else
                Return "null"
            End If
        End If





    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal seleccion As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""


        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED = New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED

        Dim data_pac As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim NN_pac As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES

        Dim data_2 As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES)
        Dim NN_2 As N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES = New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES


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


        Dim Mx_Data(10, 0) As Object

        If seleccion = 0 Then
            data_det_ate = NN.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED(DESDE, HASTA)

            For i = 0 To data_det_ate.Count - 1
                data_pac = NN_pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data_det_ate(i).ID_ATENCION)
                data_det_ate(i).PAC_RUT = data_pac(0).PAC_RUT
            Next i

            If (data_det_ate.Count > 0) Then
                edad = 0

                Dim Mx_Datax(10, 0) As Object
                'Llenar Matriz
                For y = 0 To (data_det_ate.Count - 1)

                    If (y > 0) Then
                        ReDim Preserve Mx_Data(10, y)
                    End If

                    Mx_Data(0, y) = y + 1

                    Mx_Data(0, y) = Format(data_det_ate(y).ATE_FECHA, "dd/MM/yyyy") & " " & "Folio: " & " " & data_det_ate(y).ATE_NUM & " " & data_det_ate(y).PAC_NOMBRE & " " & data_det_ate(y).PAC_APELLIDO & " Rut: " & " " & data_det_ate(y).PAC_RUT

                    Mx_Data(1, y) = ""
                    Mx_Data(2, y) = ""
                    Mx_Data(3, y) = ""
                    Mx_Data(4, y) = ""
                    Mx_Data(5, y) = ""
                    Mx_Data(6, y) = ""
                    Mx_Data(7, y) = ""
                    Mx_Data(8, y) = ""
                    Mx_Data(9, y) = ""
                    Mx_Data(10, y) = ""


                Next y
            Else
                Return "null"
            End If
        Else
            data_2 = NN_2.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED_PENDIENTES(DESDE, HASTA)

            For i = 0 To data_2.Count - 1
                data_pac = NN_pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data_2(i).ID_ATENCION)
                data_2(i).PAC_RUT = data_pac(0).PAC_RUT
            Next i

            If (data_2.Count > 0) Then
                edad = 0

                Dim Mx_Datax(10, 0) As Object
                'Llenar Matriz
                For y = 0 To (data_2.Count - 1)

                    If (y > 0) Then
                        ReDim Preserve Mx_Data(10, y)
                    End If

                    Mx_Data(0, y) = y + 1

                    Mx_Data(0, y) = Format(data_2(y).ATE_FECHA, "dd/mm/yyyy") & " " & "Folio: " & data_2(y).ATE_NUM & " " & data_2(y).PAC_NOMBRE & " " & data_2(y).PAC_APELLIDO & " Rut: " & " " & data_2(y).PAC_RUT

                    Mx_Data(1, y) = ""
                    Mx_Data(2, y) = ""
                    Mx_Data(3, y) = ""
                    Mx_Data(4, y) = ""
                    Mx_Data(5, y) = ""
                    Mx_Data(6, y) = ""
                    Mx_Data(7, y) = ""
                    Mx_Data(8, y) = ""
                    Mx_Data(9, y) = ""
                    Mx_Data(10, y) = ""


                Next y
            Else
                Return "null"
            End If
        End If


        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Búsqueda Orina y Sedimento")

        'titulo de la tabla
        sl.SetCellValue("B2", "Búsqueda Orina y Sedimento")

        For y = 1 To 11
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "Datos")
        sl.SetColumnWidth("A", 80)
        sl.SetCellValue("B8", "C.EPI")
        sl.SetCellValue("C8", "LEUCO")
        sl.SetCellValue("D8", "ERITRO.")
        sl.SetCellValue("E8", "BACT.")
        sl.SetCellValue("F8", "MUCUS")
        sl.SetCellValue("G8", "CRIST.")
        sl.SetCellValue("H8", "CILIN")
        sl.SetCellValue("I8", "OTROS 1")
        sl.SetCellValue("J8", "OTROS 2")
        sl.SetCellValue("K8", "Id")


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
        tabla = sl.CreateTable("A8", CStr("K" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    <Services.WebMethod()>
    Public Shared Function PDF(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal seleccion As Integer, selected() As Object) As String

        'Declaraciones internas
        Dim List_print As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED)
        Dim Item_print As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED
        Dim NN_PDF As New N_PDF
        Dim elemento()
        If selected.Length > 0 Then
            For i = 0 To selected.Length - 1
                Item_print = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED

                elemento = selected(i).split("~")


                Item_print.SEXO_DESC = elemento(0)
                Item_print.ATE_NUM = elemento(1)
                Item_print.PAC_NOMBRE = elemento(2)
                Item_print.PAC_APELLIDO = elemento(3)
                Item_print.ATE_AÑO = elemento(4)
                Item_print.CF_CORTO = elemento(5)
                Item_print.PAC_RUT = elemento(6)

                List_print.Add(Item_print)
            Next i
            Return NN_PDF.PDF_waa(DOMAIN_URL, DESDE, HASTA, List_print)
        End If

        Return "null"

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