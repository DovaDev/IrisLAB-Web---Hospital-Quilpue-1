Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Imports ASPPDFLib
Public Class N_REP_LAB_EXA
    'Declaraciones Generales
    Dim DD_Data As D_REP_LAB_EXA
    Sub New()
        DD_Data = New D_REP_LAB_EXA
    End Sub
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS(DESDE, HASTA, PROCEDENCIA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID(ByVal DESDE As Date, ByVal HASTA As Date, ID_CF As Long, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID(DESDE, HASTA, ID_CF, PROCEDENCIA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3(ByVal DESDE As Date, ByVal HASTA As Date, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3(DESDE, HASTA, PROCEDENCIA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2_3(ByVal DESDE As Date, ByVal HASTA As Date, ID_CF As Long, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2_3(DESDE, HASTA, ID_CF, PROCEDENCIA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3_4(ByVal DESDE As Date, ByVal HASTA As Date, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3_4(DESDE, HASTA, PROCEDENCIA)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal PROCEDENCIA As Integer) As String
        'Declaraciones Generales
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_EXA
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Dim Mx_Data(14, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DESDE = DESDE.Replace("-", "a")
        HASTA = HASTA.Replace("-", "a")
        Dim Str_d1() As String = Split(DESDE, "a")
        Dim Str_d2() As String = Split(HASTA, "a")

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        If (ID_CF = 0) Then
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3(Date01, Date02, PROCEDENCIA)
        Else
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2_3(Date01, Date02, ID_CF, PROCEDENCIA)
        End If
        'Vaciar Matriz
        ReDim Mx_Data(14, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(14, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).ATE_NUM
            If (Data_Prev(y).PAC_RUT = "") Then
                Mx_Data(1, y) = Data_Prev(y).DNI
            Else
                Mx_Data(1, y) = Data_Prev(y).PAC_RUT
            End If


            Mx_Data(2, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(3, y) = Data_Prev(y).FECHA_NAC
            Mx_Data(4, y) = Data_Prev(y).ATE_AÑO
            Mx_Data(5, y) = Data_Prev(y).NACIONALIDAD
            Mx_Data(6, y) = Format(CDate(Data_Prev(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(7, y) = Format(CDate(Data_Prev(y).ATE_FECHA), "HH:mm:ss")
            Mx_Data(8, y) = Data_Prev(y).PROC_DESC
            Mx_Data(9, y) = Data_Prev(y).SEXO_DESC
            Mx_Data(10, y) = Data_Prev(y).CF_DESC
            Mx_Data(11, y) = Data_Prev(y).PROGRAMA
            Mx_Data(12, y) = Data_Prev(y).SECTOR
            Mx_Data(13, y) = Data_Prev(y).MEDICO_SOLICITANTE & " " & Data_Prev(y).MEDICO_SOLICITANTE_2
            Mx_Data(14, y) = Data_Prev(y).ATE_OBS_TM
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        'Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        'Dim formatonum As SLStyle
        'Dim formatoporce As SLStyle
        'Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Resumen por Tipo de Examen")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen por Tipo de Examen")
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
        For y = 1 To 15
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A7", "N° Atención")
        sl.SetCellValue("B7", "Rut o D.N.I")
        sl.SetCellValue("c7", "Nombre Paciente")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D7", "Fecha Nac.")
        sl.SetCellValue("E7", "Edad")
        sl.SetCellValue("F7", "Nacionalidad")
        sl.SetCellValue("G7", "Fecha")
        sl.SetCellValue("H7", "Hora")
        sl.SetCellValue("I7", "Lugar de TM")
        sl.SetCellValue("J7", "Sexo")
        sl.SetCellValue("K7", "Exámen")
        sl.SetCellValue("L7", "Programa")
        sl.SetCellValue("M7", "Sector")
        sl.SetCellValue("N7", "Doctor")
        sl.SetColumnWidth("N", 40)
        sl.SetCellValue("O7", "Obs. TM")
        sl.SetColumnWidth(8, 55.0)



        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7

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
        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String
        Relative_Path = "IRISPDFDERIVADOS\" & Data_Prev(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF(ByVal DOMAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal PROCEDENCIA As Integer) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_EXA
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        If (ID_CODIGO_FONASA = 0) Then
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3(Date_01, Date_02, PROCEDENCIA)
        Else
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2_3(Date_01, Date_02, ID_CODIGO_FONASA, PROCEDENCIA)
        End If

        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Ate_Exa" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = System.Web.HttpContext.Current.Server.CreateObject("Persits.Pdf")
        DOC.Title = "Atenciones por Examen"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim eje_y As Integer = 85

        Dim contador_filas As Integer = 1
        'If Data_Prev.Count <= 30 Then

        '    Dim PAGE_1 = DOC.Pages.Add(612, 792)

        '    With PAGE_1.Canvas

        '        .SetFillColor(0, 0, 0)
        '        .DrawText("Atenciones por Examen", STR_PARAM(15, 0, 792, "center", 20, 90), FONT_2)
        '        .DrawText("Desde:  " & Date_01, STR_PARAM(40, 0, 396, "center", 16, 90), FONT_2)
        '        .DrawText("Hasta: " & Date_02, STR_PARAM(40, 396, 396, "center", 16, 90), FONT_2)

        '        .DrawText("#", STR_PARAM(70, 20, 25, "left", 8, 90), FONT_2)
        '        .DrawText("Folio", STR_PARAM(70, 45, 25, "left", 8, 90), FONT_2)
        '        .DrawText("RUT/DNI", STR_PARAM(70, 70, 40, "left", 8, 90), FONT_2)
        '        .DrawText("Nombre Paciente", STR_PARAM(70, 115, 135, "left", 8, 90), FONT_2)
        '        .DrawText("F. Nac.", STR_PARAM(70, 220, 35, "left", 8, 90), FONT_2)
        '        .DrawText("Edad", STR_PARAM(70, 260, 30, "left", 8, 90), FONT_2)
        '        .DrawText("Nac.", STR_PARAM(70, 295, 25, "left", 8, 90), FONT_2)
        '        .DrawText("Fecha.", STR_PARAM(70, 325, 35, "left", 8, 90), FONT_2)
        '        '.DrawText("Hora", STR_PARAM(70, 365, 25, "left", 8, 90), FONT_2)
        '        .DrawText("Lugar TM", STR_PARAM(70, 390, 80, "left", 8, 90), FONT_2)
        '        .DrawText("Sexo", STR_PARAM(70, 470, 20, "left", 8, 90), FONT_2)
        '        .DrawText("Examen", STR_PARAM(70, 495, 100, "left", 8, 90), FONT_2)
        '        .DrawText("Programa", STR_PARAM(70, 600, 40, "left", 8, 90), FONT_2)
        '        .DrawText("Sector", STR_PARAM(70, 645, 40, "left", 8, 90), FONT_2)
        '        .DrawText("Doctor", STR_PARAM(70, 685, 100, "left", 8, 90), FONT_2)

        '        For i = 0 To (Data_Prev.Count - 1)

        '            .DrawText(contador_filas, STR_PARAM(eje_y, 25, 25, "left", 6, 90), FONT_2)
        '            .DrawText(Data_Prev(i).ATE_NUM, STR_PARAM(eje_y, 45, 25, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).PAC_RUT, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).DNI, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).PAC_NOMBRE & " " & Data_Prev(i).PAC_APELLIDO, STR_PARAM(eje_y, 110, 100, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).FECHA_NAC.Substring(0, 10), STR_PARAM(eje_y, 220, 35, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).ATE_AÑO & " Años", STR_PARAM(eje_y, 255, 30, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).NACIONALIDAD, STR_PARAM(eje_y, 295, 25, "left", 6, 90), FONT_1)
        '            .DrawText(Format(Data_Prev(i).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(eje_y, 325, 35, "left", 6, 90), FONT_1)
        '            '.DrawText(Format(Data_Prev(z).ATE_FECHA, "hh:mm"), STR_PARAM(eje_y, 365, 25, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).PROC_DESC, STR_PARAM(eje_y, 390, 80, "left", 6, 90), FONT_1)
        '            Dim Sx As String
        '            If Data_Prev(i).SEXO_DESC = "Femenino" Then
        '                Sx = "F"
        '            Else
        '                Sx = "M"
        '            End If
        '            .DrawText(Sx, STR_PARAM(eje_y, 470, 20, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).CF_DESC, STR_PARAM(eje_y, 495, 100, "left", 6, 90), FONT_1)
        '            Dim Prog As String
        '            If Data_Prev(i).PROGRAMA = "<Sin Programa>" Then
        '                Prog = "Sin Prog."
        '            Else
        '                Prog = Data_Prev(i).PROGRAMA
        '            End If
        '            .DrawText(Prog, STR_PARAM(eje_y, 600, 40, "left", 6, 90), FONT_1)
        '            Dim Sect As String
        '            If Data_Prev(i).SECTOR = "<SIN SECTOR>" Then
        '                Sect = "Sin Sec."
        '            Else
        '                Sect = Data_Prev(i).SECTOR
        '            End If
        '            .DrawText(Sect, STR_PARAM(eje_y, 645, 40, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).MEDICO_SOLICITANTE & " " & Data_Prev(i).MEDICO_SOLICITANTE_2, STR_PARAM(eje_y, 685, 90, "left", 6, 90), FONT_1)

        '            eje_y = eje_y + 17
        '            contador_filas += 1

        '        Next i
        '    End With
        'Else
        Dim zz As Integer
        Dim z As Integer
        Dim xxx As Integer

        eje_y = 85

        Dim fuck = DOC.Pages.Add(612, 792)

        With fuck.Canvas

            .SetFillColor(0, 0, 0)
            .DrawText("Atenciones por Examen", STR_PARAM(15, 0, 792, "center", 20, 90), FONT_2)
            .DrawText("Desde:  " & Date_01, STR_PARAM(40, 0, 396, "center", 16, 90), FONT_2)
            .DrawText("Hasta: " & Date_02, STR_PARAM(40, 396, 396, "center", 16, 90), FONT_2)

            .DrawText("#", STR_PARAM(70, 20, 25, "left", 8, 90), FONT_2)
            .DrawText("Folio", STR_PARAM(70, 45, 25, "left", 8, 90), FONT_2)
            .DrawText("RUT/DNI", STR_PARAM(70, 70, 40, "left", 8, 90), FONT_2)
            .DrawText("Nombre Paciente", STR_PARAM(70, 110, 135, "left", 8, 90), FONT_2)
            .DrawText("F. Nac.", STR_PARAM(70, 220, 35, "left", 8, 90), FONT_2)
            .DrawText("Edad", STR_PARAM(70, 255, 30, "left", 8, 90), FONT_2)
            .DrawText("Nac.", STR_PARAM(70, 285, 25, "left", 8, 90), FONT_2)
            .DrawText("Fecha.", STR_PARAM(70, 315, 35, "left", 8, 90), FONT_2)
            .DrawText("N. Inter", STR_PARAM(70, 350, 40, "left", 8, 90), FONT_2)
            .DrawText("Lugar TM", STR_PARAM(70, 390, 80, "left", 8, 90), FONT_2)
            .DrawText("Sexo", STR_PARAM(70, 470, 20, "left", 8, 90), FONT_2)
            .DrawText("Examen", STR_PARAM(70, 495, 100, "left", 8, 90), FONT_2)
            .DrawText("Programa", STR_PARAM(70, 600, 40, "left", 8, 90), FONT_2)
            .DrawText("Sector", STR_PARAM(70, 645, 35, "left", 8, 90), FONT_2)
            .DrawText("Doctor", STR_PARAM(70, 675, 60, "left", 7, 90), FONT_2)
            .DrawText("Obs. TM", STR_PARAM(70, 745, 60, "left", 7, 90), FONT_2)

            For z = 0 To Data_Prev.Count - 1

                If contador_filas < 31 Then

                    .DrawText(contador_filas, STR_PARAM(eje_y, 20, 25, "left", 6, 90), FONT_2)
                    .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM(eje_y, 45, 25, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_RUT, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).DNI, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM(eje_y, 110, 100, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).FECHA_NAC.Substring(0, 10), STR_PARAM(eje_y, 220, 35, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).ATE_AÑO & " Años", STR_PARAM(eje_y, 255, 30, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).NACIONALIDAD, STR_PARAM(eje_y, 285, 30, "left", 6, 90), FONT_1)
                    .DrawText(Format(Data_Prev(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(eje_y, 315, 35, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).NUMERO_INTERNO, STR_PARAM(eje_y, 350, 30, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM(eje_y, 390, 80, "left", 6, 90), FONT_1)
                    Dim Sx As String
                    If Data_Prev(z).SEXO_DESC = "Femenino" Then
                        Sx = "F"
                    Else
                        Sx = "M"
                    End If
                    .DrawText(Sx, STR_PARAM(eje_y, 470, 20, "center", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).CF_DESC, STR_PARAM(eje_y, 495, 100, "left", 6, 90), FONT_1)
                    Dim Prog As String
                    If Data_Prev(z).PROGRAMA = "<Sin Programa>" Then
                        Prog = "Sin Prog."
                    Else
                        Prog = Data_Prev(z).PROGRAMA
                    End If
                    .DrawText(Prog, STR_PARAM(eje_y, 600, 40, "left", 6, 90), FONT_1)
                    Dim Sect As String
                    If Data_Prev(z).SECTOR = "<SIN SECTOR>" Then
                        Sect = "Sin Sec."
                    Else
                        Sect = Data_Prev(z).SECTOR
                    End If
                    .DrawText(Sect, STR_PARAM(eje_y, 645, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).MEDICO_SOLICITANTE & " " & Data_Prev(z).MEDICO_SOLICITANTE_2, STR_PARAM(eje_y, 675, 60, "left", 5, 90), FONT_1)
                    .DrawText(Data_Prev(z).ATE_OBS_TM, STR_PARAM(eje_y, 745, 50, "left", 5, 90), FONT_1)

                    eje_y = eje_y + 17
                    contador_filas += 1
                    zz += 1
                    If zz = 30 And Data_Prev.Count > 30 Then

                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If
                Else

                    If zz = 32 Then
                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If

                    With fuck.Canvas

                        If xxx = 1 Then
                            .DrawText("#", STR_PARAM(25, 20, 25, "left", 8, 90), FONT_2)
                            .DrawText("Folio", STR_PARAM(25, 45, 25, "left", 8, 90), FONT_2)
                            .DrawText("RUT/DNI", STR_PARAM(25, 70, 40, "left", 8, 90), FONT_2)
                            .DrawText("Nombre Paciente", STR_PARAM(25, 110, 135, "left", 8, 90), FONT_2)
                            .DrawText("F. Nac.", STR_PARAM(25, 220, 35, "left", 8, 90), FONT_2)
                            .DrawText("Edad", STR_PARAM(25, 255, 30, "left", 8, 90), FONT_2)
                            .DrawText("Nac.", STR_PARAM(25, 285, 25, "left", 8, 90), FONT_2)
                            .DrawText("Fecha.", STR_PARAM(25, 315, 35, "left", 8, 90), FONT_2)
                            .DrawText("N. Inter", STR_PARAM(25, 350, 40, "left", 8, 90), FONT_2)
                            .DrawText("Lugar TM", STR_PARAM(25, 390, 80, "left", 8, 90), FONT_2)
                            .DrawText("Sexo", STR_PARAM(25, 470, 20, "left", 8, 90), FONT_2)
                            .DrawText("Examen", STR_PARAM(25, 495, 100, "left", 8, 90), FONT_2)
                            .DrawText("Programa", STR_PARAM(25, 600, 40, "left", 8, 90), FONT_2)
                            .DrawText("Sector", STR_PARAM(25, 645, 40, "left", 8, 90), FONT_2)
                            .DrawText("Doctor", STR_PARAM(25, 680, 60, "left", 8, 90), FONT_2)
                            .DrawText("Obs. TM", STR_PARAM(25, 745, 60, "left", 7, 90), FONT_2)
                            xxx = 0
                        End If

                        .DrawText(contador_filas, STR_PARAM(eje_y, 20, 25, "left", 6, 90), FONT_2)
                        .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM(eje_y, 45, 25, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_RUT, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).DNI, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM(eje_y, 110, 100, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).FECHA_NAC.Substring(0, 10), STR_PARAM(eje_y, 220, 35, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).ATE_AÑO & " Años", STR_PARAM(eje_y, 255, 30, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).NACIONALIDAD, STR_PARAM(eje_y, 285, 30, "left", 6, 90), FONT_1)
                        .DrawText(Format(Data_Prev(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(eje_y, 315, 35, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).NUMERO_INTERNO, STR_PARAM(eje_y, 350, 30, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM(eje_y, 390, 80, "left", 6, 90), FONT_1)
                        Dim Sx As String
                        If Data_Prev(z).SEXO_DESC = "Femenino" Then
                            Sx = "F"
                        Else
                            Sx = "M"
                        End If
                        .DrawText(Sx, STR_PARAM(eje_y, 470, 20, "center", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).CF_DESC, STR_PARAM(eje_y, 495, 100, "left", 6, 90), FONT_1)
                        Dim Prog As String
                        If Data_Prev(z).PROGRAMA = "<Sin Programa>" Then
                            Prog = "Sin Prog."
                        Else
                            Prog = Data_Prev(z).PROGRAMA
                        End If
                        .DrawText(Prog, STR_PARAM(eje_y, 600, 40, "left", 6, 90), FONT_1)
                        Dim Sect As String
                        If Data_Prev(z).SECTOR = "<SIN SECTOR>" Then
                            Sect = "Sin Sec."
                        Else
                            Sect = Data_Prev(z).SECTOR
                        End If
                        .DrawText(Sect, STR_PARAM(eje_y, 645, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).MEDICO_SOLICITANTE & " " & Data_Prev(z).MEDICO_SOLICITANTE_2, STR_PARAM(eje_y, 680, 60, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).ATE_OBS_TM, STR_PARAM(eje_y, 745, 50, "left", 5, 90), FONT_1)

                        eje_y = eje_y + 17
                        contador_filas += 1
                        zz += 1
                    End With
                End If
            Next z
        End With
        'End If
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel333(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal PROCEDENCIA As Integer) As String
        'Declaraciones Generales
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_EXA
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        Dim Mx_Data(14, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DESDE = DESDE.Replace("-", "a")
        HASTA = HASTA.Replace("-", "a")
        Dim Str_d1() As String = Split(DESDE, "a")
        Dim Str_d2() As String = Split(HASTA, "a")

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))

        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3_4(Date01, Date02, PROCEDENCIA)

        'Vaciar Matriz
        ReDim Mx_Data(14, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(14, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).ATE_NUM
            If (Data_Prev(y).PAC_RUT = "") Then
                Mx_Data(1, y) = Data_Prev(y).DNI
            Else
                Mx_Data(1, y) = Data_Prev(y).PAC_RUT
            End If


            Mx_Data(2, y) = Data_Prev(y).PAC_NOMBRE & " " & Data_Prev(y).PAC_APELLIDO
            Mx_Data(3, y) = Data_Prev(y).FECHA_NAC
            Mx_Data(4, y) = Data_Prev(y).ATE_AÑO
            Mx_Data(5, y) = Data_Prev(y).NACIONALIDAD
            Mx_Data(6, y) = Format(CDate(Data_Prev(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(7, y) = Format(CDate(Data_Prev(y).ATE_FECHA), "HH:mm:ss")
            Mx_Data(8, y) = Data_Prev(y).PROC_DESC
            Mx_Data(9, y) = Data_Prev(y).SEXO_DESC
            Mx_Data(10, y) = Data_Prev(y).CF_DESC
            Mx_Data(11, y) = Data_Prev(y).PROGRAMA
            Mx_Data(12, y) = Data_Prev(y).SECTOR
            Mx_Data(13, y) = Data_Prev(y).MEDICO_SOLICITANTE & " " & Data_Prev(y).MEDICO_SOLICITANTE_2
            Mx_Data(14, y) = Data_Prev(y).ATE_OBS_TM
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        'Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        'Dim formatonum As SLStyle
        'Dim formatoporce As SLStyle
        'Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Resumen por vih y screening de sifilis")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen por vih y screening de sifilis")
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
        For y = 1 To 15
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A7", "N° Atención")
        sl.SetCellValue("B7", "Rut o D.N.I")
        sl.SetCellValue("c7", "Nombre Paciente")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D7", "Fecha Nac.")
        sl.SetCellValue("E7", "Edad")
        sl.SetCellValue("F7", "Nacionalidad")
        sl.SetCellValue("G7", "Fecha")
        sl.SetCellValue("H7", "Hora")
        sl.SetCellValue("I7", "Lugar de TM")
        sl.SetCellValue("J7", "Sexo")
        sl.SetCellValue("K7", "Exámen")
        sl.SetCellValue("L7", "Programa")
        sl.SetCellValue("M7", "Sector")
        sl.SetCellValue("N7", "Doctor")
        sl.SetColumnWidth("N", 40)
        sl.SetCellValue("O7", "Obs. TM")
        sl.SetColumnWidth(8, 55.0)



        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7

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
        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String
        Relative_Path = "IRISPDFDERIVADOS\" & "VIH_Y_SCREENING DE SIFILIS" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function PDFF33(ByVal DOMAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal PROCEDENCIA As Integer) As String


        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_EXA
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3_4(Date_01, Date_02, PROCEDENCIA)


        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Ate_Exa" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = System.Web.HttpContext.Current.Server.CreateObject("Persits.Pdf")
        DOC.Title = "Atenciones por Examen"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim eje_y As Integer = 85

        Dim contador_filas As Integer = 1
        'If Data_Prev.Count <= 30 Then

        '    Dim PAGE_1 = DOC.Pages.Add(612, 792)

        '    With PAGE_1.Canvas

        '        .SetFillColor(0, 0, 0)
        '        .DrawText("Atenciones por Examen", STR_PARAM(15, 0, 792, "center", 20, 90), FONT_2)
        '        .DrawText("Desde:  " & Date_01, STR_PARAM(40, 0, 396, "center", 16, 90), FONT_2)
        '        .DrawText("Hasta: " & Date_02, STR_PARAM(40, 396, 396, "center", 16, 90), FONT_2)

        '        .DrawText("#", STR_PARAM(70, 20, 25, "left", 8, 90), FONT_2)
        '        .DrawText("Folio", STR_PARAM(70, 45, 25, "left", 8, 90), FONT_2)
        '        .DrawText("RUT/DNI", STR_PARAM(70, 70, 40, "left", 8, 90), FONT_2)
        '        .DrawText("Nombre Paciente", STR_PARAM(70, 115, 135, "left", 8, 90), FONT_2)
        '        .DrawText("F. Nac.", STR_PARAM(70, 220, 35, "left", 8, 90), FONT_2)
        '        .DrawText("Edad", STR_PARAM(70, 260, 30, "left", 8, 90), FONT_2)
        '        .DrawText("Nac.", STR_PARAM(70, 295, 25, "left", 8, 90), FONT_2)
        '        .DrawText("Fecha.", STR_PARAM(70, 325, 35, "left", 8, 90), FONT_2)
        '        '.DrawText("Hora", STR_PARAM(70, 365, 25, "left", 8, 90), FONT_2)
        '        .DrawText("Lugar TM", STR_PARAM(70, 390, 80, "left", 8, 90), FONT_2)
        '        .DrawText("Sexo", STR_PARAM(70, 470, 20, "left", 8, 90), FONT_2)
        '        .DrawText("Examen", STR_PARAM(70, 495, 100, "left", 8, 90), FONT_2)
        '        .DrawText("Programa", STR_PARAM(70, 600, 40, "left", 8, 90), FONT_2)
        '        .DrawText("Sector", STR_PARAM(70, 645, 40, "left", 8, 90), FONT_2)
        '        .DrawText("Doctor", STR_PARAM(70, 685, 100, "left", 8, 90), FONT_2)

        '        For i = 0 To (Data_Prev.Count - 1)

        '            .DrawText(contador_filas, STR_PARAM(eje_y, 25, 25, "left", 6, 90), FONT_2)
        '            .DrawText(Data_Prev(i).ATE_NUM, STR_PARAM(eje_y, 45, 25, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).PAC_RUT, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).DNI, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).PAC_NOMBRE & " " & Data_Prev(i).PAC_APELLIDO, STR_PARAM(eje_y, 110, 100, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).FECHA_NAC.Substring(0, 10), STR_PARAM(eje_y, 220, 35, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).ATE_AÑO & " Años", STR_PARAM(eje_y, 255, 30, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).NACIONALIDAD, STR_PARAM(eje_y, 295, 25, "left", 6, 90), FONT_1)
        '            .DrawText(Format(Data_Prev(i).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(eje_y, 325, 35, "left", 6, 90), FONT_1)
        '            '.DrawText(Format(Data_Prev(z).ATE_FECHA, "hh:mm"), STR_PARAM(eje_y, 365, 25, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).PROC_DESC, STR_PARAM(eje_y, 390, 80, "left", 6, 90), FONT_1)
        '            Dim Sx As String
        '            If Data_Prev(i).SEXO_DESC = "Femenino" Then
        '                Sx = "F"
        '            Else
        '                Sx = "M"
        '            End If
        '            .DrawText(Sx, STR_PARAM(eje_y, 470, 20, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).CF_DESC, STR_PARAM(eje_y, 495, 100, "left", 6, 90), FONT_1)
        '            Dim Prog As String
        '            If Data_Prev(i).PROGRAMA = "<Sin Programa>" Then
        '                Prog = "Sin Prog."
        '            Else
        '                Prog = Data_Prev(i).PROGRAMA
        '            End If
        '            .DrawText(Prog, STR_PARAM(eje_y, 600, 40, "left", 6, 90), FONT_1)
        '            Dim Sect As String
        '            If Data_Prev(i).SECTOR = "<SIN SECTOR>" Then
        '                Sect = "Sin Sec."
        '            Else
        '                Sect = Data_Prev(i).SECTOR
        '            End If
        '            .DrawText(Sect, STR_PARAM(eje_y, 645, 40, "left", 6, 90), FONT_1)
        '            .DrawText(Data_Prev(i).MEDICO_SOLICITANTE & " " & Data_Prev(i).MEDICO_SOLICITANTE_2, STR_PARAM(eje_y, 685, 90, "left", 6, 90), FONT_1)

        '            eje_y = eje_y + 17
        '            contador_filas += 1

        '        Next i
        '    End With
        'Else
        Dim zz As Integer
        Dim z As Integer
        Dim xxx As Integer

        eje_y = 85

        Dim fuck = DOC.Pages.Add(612, 792)

        With fuck.Canvas

            .SetFillColor(0, 0, 0)
            .DrawText("Atenciones por vih y screening de sifilis", STR_PARAM(15, 0, 760, "center", 20, 90), FONT_2)
            .DrawText("Desde:  " & Date_01, STR_PARAM(40, 0, 396, "center", 16, 90), FONT_2)
            .DrawText("Hasta: " & Date_02, STR_PARAM(40, 396, 396, "center", 16, 90), FONT_2)

            .DrawText("#", STR_PARAM(70, 20, 25, "left", 8, 90), FONT_2)
            .DrawText("Folio", STR_PARAM(70, 45, 25, "left", 8, 90), FONT_2)
            .DrawText("RUT/DNI", STR_PARAM(70, 70, 40, "left", 8, 90), FONT_2)
            .DrawText("Nombre Paciente", STR_PARAM(70, 110, 135, "left", 8, 90), FONT_2)
            .DrawText("F. Nac.", STR_PARAM(70, 220, 35, "left", 8, 90), FONT_2)
            .DrawText("Edad", STR_PARAM(70, 255, 30, "left", 8, 90), FONT_2)
            .DrawText("Nac.", STR_PARAM(70, 285, 25, "left", 8, 90), FONT_2)
            .DrawText("Fecha.", STR_PARAM(70, 315, 35, "left", 8, 90), FONT_2)
            .DrawText("N. Inter", STR_PARAM(70, 350, 40, "left", 8, 90), FONT_2)
            .DrawText("Lugar TM", STR_PARAM(70, 390, 80, "left", 8, 90), FONT_2)
            .DrawText("Sexo", STR_PARAM(70, 470, 20, "left", 8, 90), FONT_2)
            .DrawText("Examen", STR_PARAM(70, 495, 100, "left", 8, 90), FONT_2)
            .DrawText("Programa", STR_PARAM(70, 600, 40, "left", 8, 90), FONT_2)
            .DrawText("Sector", STR_PARAM(70, 645, 35, "left", 8, 90), FONT_2)
            .DrawText("Doctor", STR_PARAM(70, 675, 60, "left", 7, 90), FONT_2)
            .DrawText("Obs. TM", STR_PARAM(70, 745, 60, "left", 7, 90), FONT_2)

            For z = 0 To Data_Prev.Count - 1

                If contador_filas < 31 Then

                    .DrawText(contador_filas, STR_PARAM(eje_y, 20, 25, "left", 6, 90), FONT_2)
                    .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM(eje_y, 45, 25, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_RUT, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).DNI, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM(eje_y, 110, 100, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).FECHA_NAC.Substring(0, 10), STR_PARAM(eje_y, 220, 35, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).ATE_AÑO & " Años", STR_PARAM(eje_y, 255, 30, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).NACIONALIDAD, STR_PARAM(eje_y, 285, 30, "left", 6, 90), FONT_1)
                    .DrawText(Format(Data_Prev(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(eje_y, 315, 35, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).NUMERO_INTERNO, STR_PARAM(eje_y, 350, 30, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM(eje_y, 390, 80, "left", 6, 90), FONT_1)
                    Dim Sx As String
                    If Data_Prev(z).SEXO_DESC = "Femenino" Then
                        Sx = "F"
                    Else
                        Sx = "M"
                    End If
                    .DrawText(Sx, STR_PARAM(eje_y, 470, 20, "center", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).CF_DESC, STR_PARAM(eje_y, 495, 100, "left", 6, 90), FONT_1)
                    Dim Prog As String
                    If Data_Prev(z).PROGRAMA = "<Sin Programa>" Then
                        Prog = "Sin Prog."
                    Else
                        Prog = Data_Prev(z).PROGRAMA
                    End If
                    .DrawText(Prog, STR_PARAM(eje_y, 600, 40, "left", 6, 90), FONT_1)
                    Dim Sect As String
                    If Data_Prev(z).SECTOR = "<SIN SECTOR>" Then
                        Sect = "Sin Sec."
                    Else
                        Sect = Data_Prev(z).SECTOR
                    End If
                    .DrawText(Sect, STR_PARAM(eje_y, 645, 40, "left", 6, 90), FONT_1)
                    .DrawText(Data_Prev(z).MEDICO_SOLICITANTE & " " & Data_Prev(z).MEDICO_SOLICITANTE_2, STR_PARAM(eje_y, 675, 60, "left", 5, 90), FONT_1)
                    .DrawText(Data_Prev(z).ATE_OBS_TM, STR_PARAM(eje_y, 745, 50, "left", 5, 90), FONT_1)

                    eje_y = eje_y + 17
                    contador_filas += 1
                    zz += 1
                    If zz = 30 And Data_Prev.Count > 30 Then

                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If
                Else

                    If zz = 32 Then
                        fuck = DOC.Pages.Add(612, 792)
                        eje_y = 42
                        zz = 0
                        xxx = 1
                    End If

                    With fuck.Canvas

                        If xxx = 1 Then
                            .DrawText("#", STR_PARAM(25, 20, 25, "left", 8, 90), FONT_2)
                            .DrawText("Folio", STR_PARAM(25, 45, 25, "left", 8, 90), FONT_2)
                            .DrawText("RUT/DNI", STR_PARAM(25, 70, 40, "left", 8, 90), FONT_2)
                            .DrawText("Nombre Paciente", STR_PARAM(25, 110, 135, "left", 8, 90), FONT_2)
                            .DrawText("F. Nac.", STR_PARAM(25, 220, 35, "left", 8, 90), FONT_2)
                            .DrawText("Edad", STR_PARAM(25, 255, 30, "left", 8, 90), FONT_2)
                            .DrawText("Nac.", STR_PARAM(25, 285, 25, "left", 8, 90), FONT_2)
                            .DrawText("Fecha.", STR_PARAM(25, 315, 35, "left", 8, 90), FONT_2)
                            .DrawText("N. Inter", STR_PARAM(25, 350, 40, "left", 8, 90), FONT_2)
                            .DrawText("Lugar TM", STR_PARAM(25, 390, 80, "left", 8, 90), FONT_2)
                            .DrawText("Sexo", STR_PARAM(25, 470, 20, "left", 8, 90), FONT_2)
                            .DrawText("Examen", STR_PARAM(25, 495, 100, "left", 8, 90), FONT_2)
                            .DrawText("Programa", STR_PARAM(25, 600, 40, "left", 8, 90), FONT_2)
                            .DrawText("Sector", STR_PARAM(25, 645, 40, "left", 8, 90), FONT_2)
                            .DrawText("Doctor", STR_PARAM(25, 680, 60, "left", 8, 90), FONT_2)
                            .DrawText("Obs. TM", STR_PARAM(25, 745, 60, "left", 7, 90), FONT_2)
                            xxx = 0
                        End If

                        .DrawText(contador_filas, STR_PARAM(eje_y, 20, 25, "left", 6, 90), FONT_2)
                        .DrawText(Data_Prev(z).ATE_NUM, STR_PARAM(eje_y, 45, 25, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_RUT, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).DNI, STR_PARAM(eje_y, 70, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PAC_NOMBRE & " " & Data_Prev(z).PAC_APELLIDO, STR_PARAM(eje_y, 110, 100, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).FECHA_NAC.Substring(0, 10), STR_PARAM(eje_y, 220, 35, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).ATE_AÑO & " Años", STR_PARAM(eje_y, 255, 30, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).NACIONALIDAD, STR_PARAM(eje_y, 285, 30, "left", 6, 90), FONT_1)
                        .DrawText(Format(Data_Prev(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(eje_y, 315, 35, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).NUMERO_INTERNO, STR_PARAM(eje_y, 350, 30, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).PROC_DESC, STR_PARAM(eje_y, 390, 80, "left", 6, 90), FONT_1)
                        Dim Sx As String
                        If Data_Prev(z).SEXO_DESC = "Femenino" Then
                            Sx = "F"
                        Else
                            Sx = "M"
                        End If
                        .DrawText(Sx, STR_PARAM(eje_y, 470, 20, "center", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).CF_DESC, STR_PARAM(eje_y, 495, 100, "left", 6, 90), FONT_1)
                        Dim Prog As String
                        If Data_Prev(z).PROGRAMA = "<Sin Programa>" Then
                            Prog = "Sin Prog."
                        Else
                            Prog = Data_Prev(z).PROGRAMA
                        End If
                        .DrawText(Prog, STR_PARAM(eje_y, 600, 40, "left", 6, 90), FONT_1)
                        Dim Sect As String
                        If Data_Prev(z).SECTOR = "<SIN SECTOR>" Then
                            Sect = "Sin Sec."
                        Else
                            Sect = Data_Prev(z).SECTOR
                        End If
                        .DrawText(Sect, STR_PARAM(eje_y, 645, 40, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).MEDICO_SOLICITANTE & " " & Data_Prev(z).MEDICO_SOLICITANTE_2, STR_PARAM(eje_y, 680, 60, "left", 6, 90), FONT_1)
                        .DrawText(Data_Prev(z).ATE_OBS_TM, STR_PARAM(eje_y, 745, 50, "left", 5, 90), FONT_1)

                        eje_y = eje_y + 17
                        contador_filas += 1
                        zz += 1
                    End With
                End If
            Next z
        End With
        'End If
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Public Function STR_PARAM(ByVal x As Single, ByVal y As Single, ByVal width As Single,
     ByVal alignment As String, ByVal size As Single, ByVal angle As Single) As String
        Dim PARAM_XX As String

        'Parámetros de la cadena
        PARAM_XX = ""
        PARAM_XX += "x=" & x & ";"                              'Posición x del cuadro de texto
        PARAM_XX += "y=" & y & ";"                              'Posición y del cuadro de texto
        PARAM_XX += "width=" & width & ";"                      'Ancho del cuadro de texto
        PARAM_XX += "alignment=" & alignment & ";"              'Alineación del cuadro de texto
        PARAM_XX += "size=" & size & ";"                         'Tamaño de la fuente
        PARAM_XX += "angle=" & angle & ""
        Return PARAM_XX
    End Function
End Class
