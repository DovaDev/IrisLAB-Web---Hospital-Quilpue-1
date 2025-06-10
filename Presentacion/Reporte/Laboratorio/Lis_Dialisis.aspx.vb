Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Dialisis
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PREVISON_DIALISIS() As List(Of E_IRIS_WEBF_BUSCA_PREVISON_DIALISIS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISON_DIALISIS)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISON_DIALISIS = New N_IRIS_WEBF_BUSCA_PREVISON_DIALISIS

        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISON_DIALISIS()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ByVal HASTA As String, ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_pru_dia As List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
        Dim NN_pru_dia As N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS = New N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS

        Dim ano() As Object = HASTA.Split("-")
        data_pru_dia = NN_pru_dia.IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ano(2), ID_PRE)

        Return data_pru_dia
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String,
                                            ByVal HASTA As String,
                                            ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS)

        Data = NN.IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS(CDate(DESDE), CDate(HASTA), ID_PRE)

        Return Data

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RESULTADO_DIALISIS(ByVal PACIENTES As List(Of E_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS),
                                            ByVal HASTA As String,
                                            ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Resultado_Dialisis As New N_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
        Dim Data_Resultado_Dialisis As New List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        Dim Data_Resultado_Dialisis_Enviar As New List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        Dim Item_Resultado_Dialisis As E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS

        Dim data_pruebas_dialisis As List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
        Dim NN_pruebas_dialisis As N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS = New N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS


        Dim ano() As Object = HASTA.Split("-")
        data_pruebas_dialisis = NN_pruebas_dialisis.IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ano(2), ID_PRE)

        If (PACIENTES.Count > 0 And data_pruebas_dialisis.Count > 0) Then
            For a = 0 To PACIENTES.Count - 1
                For b = 0 To data_pruebas_dialisis.Count - 1
                    Data_Resultado_Dialisis = NN_Resultado_Dialisis.IRIS_WEBF_BUSCA_RESULTADO_DIALISIS(PACIENTES(a).ID_ATENCION, data_pruebas_dialisis(b).ID_PRUEBA)
                    If Data_Resultado_Dialisis.Count > 0 Then
                        Item_Resultado_Dialisis = New E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS

                        Item_Resultado_Dialisis.ID_ATENCION = Data_Resultado_Dialisis(0).ID_ATENCION
                        Item_Resultado_Dialisis.ATE_RESULTADO = Data_Resultado_Dialisis(0).ATE_RESULTADO
                        Item_Resultado_Dialisis.ATE_RESULTADO_NUM = Data_Resultado_Dialisis(0).ATE_RESULTADO_NUM
                        Item_Resultado_Dialisis.ID_PRUEBA = Data_Resultado_Dialisis(0).ID_PRUEBA
                        Item_Resultado_Dialisis.ATE_EST_VALIDA = Data_Resultado_Dialisis(0).ATE_EST_VALIDA

                        Data_Resultado_Dialisis_Enviar.Add(Item_Resultado_Dialisis)
                    End If
                Next b
            Next a

            Return Data_Resultado_Dialisis_Enviar

        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
                                          ByVal ID_PRE As Integer) As String
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        'Declaraciones internas
        Dim NN_Atenciones As New N_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS
        Dim Data_Atenciones As New List(Of E_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS)

        Dim Data_Pruebas As List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
        Dim NN_Pruebas As N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS = New N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
        Dim ano() As Object = HASTA.Split("-")

        Dim NN_Resultado As New N_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
        Dim Data_Resultado As New List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        Dim Data_Resultado_Enviar As New List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        Dim Item_Resultado As E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS

        Data_Atenciones = NN_Atenciones.IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS(CDate(DESDE), CDate(HASTA), ID_PRE)

        Data_Pruebas = NN_Pruebas.IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ano(2), ID_PRE)

        If Data_Atenciones.Count > 0 And Data_Pruebas.Count > 0 Then
            For a = 0 To Data_Atenciones.Count - 1
                For b = 0 To Data_Pruebas.Count - 1
                    Data_Resultado = NN_Resultado.IRIS_WEBF_BUSCA_RESULTADO_DIALISIS(Data_Atenciones(a).ID_ATENCION, Data_Pruebas(b).ID_PRUEBA)
                    If Data_Resultado.Count > 0 Then
                        Item_Resultado = New E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
                        Item_Resultado.ID_ATENCION = Data_Resultado(0).ID_ATENCION
                        Item_Resultado.ATE_RESULTADO = Data_Resultado(0).ATE_RESULTADO
                        Item_Resultado.ATE_RESULTADO_NUM = Data_Resultado(0).ATE_RESULTADO_NUM
                        Item_Resultado.ID_PRUEBA = Data_Resultado(0).ID_PRUEBA
                        Item_Resultado.ATE_EST_VALIDA = Data_Resultado(0).ATE_EST_VALIDA

                        Data_Resultado_Enviar.Add(Item_Resultado)
                    End If
                Next b
            Next a
            If Data_Resultado_Enviar.Count > 0 Then
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
                Dim Mx_Data(0, 0) As Object

                'Vaciar Matriz
                ReDim Mx_Data(4 + Data_Pruebas.Count, 0)

                For x = 0 To (Mx_Data.GetUpperBound(0))
                    Mx_Data(x, 0) = Nothing
                Next x
                'Llenar Matriz

                Dim data_pos = 5
                Dim data_pos_aux = 5


                For a = 0 To Data_Atenciones.Count - 1
                    If (a > 0) Then
                        ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), a)
                    End If


                    For b = 0 To 5 + (Data_Pruebas.Count - 1)
                        Mx_Data(b, a) = "-"
                    Next b
                Next a



                For y = 0 To (Data_Atenciones.Count - 1)
                    data_pos = 5
                    'If (y > 0) Then
                    '    ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
                    'End If
                    Mx_Data(0, y) = y + 1
                    Mx_Data(1, y) = CInt(Data_Atenciones(y).ATE_NUM)
                    Mx_Data(2, y) = Data_Atenciones(y).PAC_NOMBRE + " " + Data_Atenciones(y).PAC_APELLIDO
                    Mx_Data(3, y) = Data_Atenciones(y).PAC_RUT
                    Mx_Data(4, y) = Data_Atenciones(y).PROC_DESC

                    For yy = 0 To Data_Pruebas.Count - 1
                        For yyy = 0 To Data_Resultado_Enviar.Count - 1
                            If Data_Resultado_Enviar(yyy).ID_ATENCION = Data_Atenciones(y).ID_ATENCION And Data_Resultado_Enviar(yyy).ID_PRUEBA = Data_Pruebas(yy).ID_PRUEBA Then
                                Mx_Data(data_pos, y) = CStr(Data_Resultado_Enviar(yyy).ATE_RESULTADO)
                            End If
                        Next yyy
                        data_pos += 1
                    Next yy
                Next y

                'nombrar hoja 
                sl.RenameWorksheet("Sheet1", "Listado de Atenciones por Diálisis")
                'titulo de la tabla
                sl.SetCellValue("B2", "Listado de Atenciones por Diálisis")

                sl.SetCellValue("B4", "Desde: " & DESDE)
                sl.SetCellValue("B6", "Hasta: " & HASTA)
                sl.SetCellValue("D4", "Previsión: " & Data_Atenciones(0).PREVE_DESC)


                Dim columna_Cabecera = 6
                'nombre columnas
                sl.SetCellValue("A8", "#")
                sl.SetColumnWidth("A", 8)
                sl.SetCellValue("B8", "N° Atención")
                sl.SetColumnWidth("B", 15)
                sl.SetCellValue("C8", "Nombre Paciente")
                sl.SetColumnWidth("C", 40)
                sl.SetCellValue("D8", "Rut Paciente")
                sl.SetColumnWidth("D", 20)
                sl.SetCellValue("E8", "Lugar de TM")
                sl.SetColumnWidth("E", 20)

                For i = 0 To Data_Pruebas.Count - 1
                    sl.SetCellValue(8, columna_Cabecera, Data_Pruebas(i).AGRU_PRU_DESC)
                    sl.SetColumnWidth(columna_Cabecera, 20)
                    columna_Cabecera += 1
                Next i

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
                sl.SetCellStyle("B6", estilo3)
                sl.SetCellStyle("D4", estilo3)

                Dim Letrita As String = Lis_Dialisis.GetLetter(columna_Cabecera - 1)

                'insertar tabla
                tabla = sl.CreateTable("A8", CStr(Letrita & ltabla + 1))
                tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
                sl.InsertTable(tabla)

                Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
                Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

                sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

                'Devolver la url del archivo generado
                Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
            Else
                Return "null"
            End If

        Else
            Return "null"
        End If
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

    Public Shared Function GetLetter(Number As Integer) As String
        Dim theLetters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim rv As String = "" 'number out of range returns ""

        If Number > 52 Then
            If Number > 0 AndAlso Number <= theLetters.Length Then
                rv = theLetters(Number - 1)
            End If
            Return "AA" + rv
        ElseIf Number > 26 Then
            If Number > 0 AndAlso Number <= theLetters.Length Then
                rv = theLetters(Number - 1)
            End If
            Return "A" + rv
        Else
            If Number > 0 AndAlso Number <= theLetters.Length Then
                rv = theLetters(Number - 1)
            End If
            Return rv
        End If

    End Function

End Class