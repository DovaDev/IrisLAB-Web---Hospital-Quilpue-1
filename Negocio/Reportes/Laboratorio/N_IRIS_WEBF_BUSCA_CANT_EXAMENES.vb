Imports System.Drawing
Imports System.Security.Cryptography
Imports Datos
Imports DocumentFormat.OpenXml.Drawing.Wordprocessing
Imports Entidades
Imports SpreadsheetLight

Public Class N_IRIS_WEBF_BUSCA_CANT_EXAMENES

    'Declaraciones Generales
    Dim D_Data As D_IRIS_WEBF_BUSCA_CANT_EXAMENES

    Sub New()
        D_Data = New D_IRIS_WEBF_BUSCA_CANT_EXAMENES
    End Sub

    Function IRIS_WEBF_BUSCA_VHS_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_VHS_POR_FECHA)
        Return D_Data.IRIS_WEBF_BUSCA_VHS_POR_FECHA(DESDE, HASTA)
    End Function



    Function IRIS_WEBF_BUSCA_CONTEO_RETICULO(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        Return D_Data.IRIS_WEBF_BUSCA_CONTEO_RETICULO(DESDE, HASTA)
    End Function

    Function IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA)
        Return D_Data.IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA(DESDE, HASTA)
    End Function


    Function IRIS_WEBF_BUSCA_CONTEO_TRANSAMINASA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        Return D_Data.IRIS_WEBF_BUSCA_CONTEO_TRANSAMINASA(DESDE, HASTA)
    End Function


    Function IRIS_WEBF_ACTUALIZA_EXCL_PRIO_REM(ID_FONASA_REM As Integer, ID_CF_EX As Integer, ByVal OPT As String)
        Return D_Data.IRIS_WEBF_ACTUALIZA_EXCL_PRIO_REM(ID_FONASA_REM, ID_CF_EX, OPT)
    End Function

    Function IRIS_WEBF_GUARDA_QUITA_PANEL_CODIGO(ByVal Mx_Panel As List(Of E_IRIS_WEBF_GUARDA_QUITA_PANEL_CODIGO)) As Integer
        For Each item In Mx_Panel
            'D_Data.IRIS_WEBF_GUARDA_QUITA_PANEL_CODIGO(item.ID_CF, item.ID_FONASA_REM_HOSP, item.TYPE)
        Next
    End Function

    Function IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM(ByVal ID_FONASA_REM_HOSP As Integer) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM)
        Return D_Data.IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM(ID_FONASA_REM_HOSP)
    End Function

    Function IRIS_WEBF_BUSCA_TODOS_EXAMENES() As List(Of E_IRIS_WEBF_BUSCA_TODOS_EXAMENES)
        Return D_Data.IRIS_WEBF_BUSCA_TODOS_EXAMENES()
    End Function
    Function IRIS_WEBF_BUSCA_SECCION_FORMATO_REM() As List(Of E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM)
        Return D_Data.IRIS_WEBF_BUSCA_SECCION_FORMATO_REM()
    End Function

    Function IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM(ByVal ID_DDL_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM)
        Return D_Data.IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM(ID_DDL_SECC)
    End Function

    Function IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)
        Return D_Data.IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_REL_PRU_REM() As List(Of E_IRIS_WEBF_BUSCA_REL_PRU_REM)
        Return D_Data.IRIS_WEBF_BUSCA_REL_PRU_REM()
    End Function

    Function IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        Return D_Data.IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA, "noCompile")
    End Function

#Region "HELPER"
    Private Shared Function Crear_Estilo(ByVal sl As SLDocument, ByVal fontSize As Integer, ByVal isBold? As Boolean, ByVal fontName As String, ByVal horizontalAlignment? As HorizontalAlign, ByVal verticalAlignment As VerticalAlign?, ByVal fillColor? As System.Drawing.Color, ByVal isWrapText As Boolean) As SLStyle
        Dim estilo As SLStyle = sl.CreateStyle()

        If Not isBold Is Nothing Then
            With estilo.Font
                .Bold = isBold
            End With
        End If
        With estilo.Font
            .FontSize = fontSize
            .FontName = fontName
        End With
        With estilo.Alignment
            If horizontalAlignment IsNot Nothing Then
                .Horizontal = horizontalAlignment
            End If
            .Vertical = verticalAlignment
        End With
        If fillColor IsNot Nothing Then
            estilo.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, fillColor, System.Drawing.Color.Transparent)
        End If
        If verticalAlignment IsNot Nothing Then
            estilo.Alignment.Vertical = DocumentFormat.OpenXml.Drawing.Diagrams.VerticalAlignmentValues.Middle
        End If
        estilo.SetWrapText(isWrapText)
        Return estilo

    End Function

    Public Shared Function Header_Excel(ByVal DESDE As String,
                                        ByVal HASTA As String,
                                        ByVal sl As SLDocument,
                                        ByVal estilo_1 As SLStyle,
                                        ByVal estilo_2 As SLStyle,
                                        ByVal estilo_3 As SLStyle,
                                        ByVal estilo_4 As SLStyle,
                                        ByVal estilo_borde As SLStyle,
                                        ByVal color_proc1 As Color,
                                        ByVal color_proc2 As Color,
                                        ByVal color_proc3 As Color,
                                        ByVal color_proc4 As Color,
                                        ByVal color_proc5 As Color,
                                        ByVal color_tp1 As Color,
                                        ByVal color_tp2 As Color,
                                        ByVal color_tp3 As Color,
                                        ByVal color_tp4 As Color,
                                        ByVal color_tp5 As Color,
                                        ByVal color_tp6 As Color,
                                        ByVal first_sheet As Boolean)

        If first_sheet Then
            ' Princpio
            sl.SetCellValue("A1", "SEREMI: Región de Valparaíso")
            sl.SetCellValue("A2", "Establecimiento: Hospital Quilpué")
            sl.SetCellValue("A3", "Comuna: Quilpué")
            sl.SetCellValue("A4", $"Desde: {DESDE}, Hasta: {HASTA}")
            sl.SetCellValue("A5", "Año: " & Now.ToString("yyyy"))

            sl.SetCellValue("B7", "CENSO REM")
            ' Aplicar el estilo a las celdas A10:C10 y A11:C11
        End If

        sl.SetCellValue("A9", "CÓDIGOS")
        sl.MergeWorksheetCells("A9", "A10")
        sl.SetCellValue("B9", "GLOSA")
        sl.MergeWorksheetCells("B9", "B10")


        sl.SetCellValue("D9", "CANTIDAD DE ATENCIONES POR PROCEDENCIA")
        sl.MergeWorksheetCells("D9", "BK9")

        '----------------COLUMNAS TIPO ATENCIÓN----------------------
        sl.SetCellValue("D10", "ATENCIÓN ABIERTA")
        sl.MergeWorksheetCells("D10", "F10")

        sl.SetCellValue("G10", "ATENCIÓN CERRADA")
        sl.MergeWorksheetCells("G10", "S10")

        sl.SetCellValue("T10", "UE")
        sl.MergeWorksheetCells("T10", "V10")

        sl.SetCellValue("W10", "UEGO")

        sl.SetCellValue("X10", "UNIDAD DE APOYO")
        sl.MergeWorksheetCells("X10", "Y10")

        sl.SetCellValue("Z10", "ATENCIÓN EXTRAHOSPITALARIO")
        sl.MergeWorksheetCells("Z10", "BE10")



        '----------------COLUMNAS TOTAL GENERAL----------------------
        sl.SetCellValue("C9", "TOTAL GENERAL")
        sl.MergeWorksheetCells("C9", "C10")

        '----------------COLUMNAS PROCEDENCIAS----------------------
        'sl.SetCellValue("B11", "EXÁMENES DE LABORATORIO")

        ' ---------------COLUMN ATENCIÓN ABIERTA------------------------------
        sl.SetCellValue("D11", "CAE")
        sl.SetCellValue("E11", "USM-HDIURNO")
        sl.SetCellValue("F11", "PERSONAL")
        'sl.SetCellValue("G11", "TOTAL")
        ' ---------------COLUMN ATENCIÓN CERRADA------------------------------
        sl.SetCellValue("G11", "MQ1")
        sl.SetCellValue("H11", "MQ2")
        sl.SetCellValue("I11", "MQ3")
        sl.SetCellValue("J11", "UAPQ (Pabellon)")
        sl.SetCellValue("K11", "PEDIATRIA")
        sl.SetCellValue("L11", "NEONATOLOGIA")
        sl.SetCellValue("M11", "UPC")
        sl.SetCellValue("N11", "UCI-A")
        sl.SetCellValue("O11", "UTI")
        sl.SetCellValue("P11", "MATERNIDAD")
        sl.SetCellValue("Q11", "CMA")
        sl.SetCellValue("R11", "HOSP. DOMICI")
        sl.SetCellValue("S11", "UEA-HOSP")
        'sl.SetCellValue("U11", "TOTAL")
        '-----------------COLUMNAS UE--------------------------------------------
        sl.SetCellValue("T11", "UEA")
        sl.SetCellValue("U11", "UEI")
        sl.SetCellValue("V11", "SAUD")
        'sl.SetCellValue("Y11", "TOTAL")
        '-----------------COLUMNAS UEGO---------------------------------
        sl.SetCellValue("W11", "UEGO")
        '-----------------COLUMNAS UNIDAD DE APOYO---------------------------------
        sl.SetCellValue("X11", "ANATOMIA PATOLOGICA")
        sl.SetCellValue("Y11", "IMAGENOLOGIA")
        'sl.SetCellValue("AC11", "TOTAL")
        '-----------------COLUMNAS EXTRAHOSPITALARIO---------------------------------
        sl.SetCellValue("Z11", "CESFAM Alcalde Iván Manríquez")
        sl.SetCellValue("AA11", "CESFAM Aviador Acevedo")
        sl.SetCellValue("AB11", "CESFAM QUILPUE")
        sl.SetCellValue("AC11", "CESFAM y SAR Belloto SUR")
        sl.SetCellValue("AD11", "Cons.Pompeya")
        sl.SetCellValue("AE11", "CECOSF El Retiro")
        sl.SetCellValue("AF11", "Cons.El Belloto")
        sl.SetCellValue("AG11", "CESFAM Villa Alemana")
        sl.SetCellValue("AH11", "CESFAM Las Américas")
        sl.SetCellValue("AI11", "Cons.Eduardo Frei")
        sl.SetCellValue("AJ11", "CESFAM Juan Bautista Bravo Vega")
        sl.SetCellValue("AK11", "Cons.Cien Aguilas")
        sl.SetCellValue("AL11", "SAPU EDUARDO FREI")
        sl.SetCellValue("AM11", "CESFAM Limache")
        sl.SetCellValue("AN11", "CESFAM Olmue")
        sl.SetCellValue("AO11", "APS CABILDO")
        sl.SetCellValue("AP11", "APS Hijuelas")
        sl.SetCellValue("AQ11", "APS La Calera")
        sl.SetCellValue("AR11", "APS LA LIGUA")
        sl.SetCellValue("AS11", "APS Nogales ")
        sl.SetCellValue("AT11", "APS PETORCA ")
        sl.SetCellValue("AU11", "HOSPITAL DE LIMACHE")
        sl.SetCellValue("AV11", "Hosp.Geriatrico Paz de la tarde (limache)")
        sl.SetCellValue("AW11", "Hosp.Modular de Emergencia (limache)")
        sl.SetCellValue("AX11", "Hosp.Peñablanca")
        sl.SetCellValue("AY11", "Hosp.Gustavo Fricke")
        sl.SetCellValue("AZ11", "HOSPITAL CALERA")
        sl.SetCellValue("BA11", "Hospital de Petorca")
        sl.SetCellValue("BB11", "HOSPITAL DE QUILLOTA")
        sl.SetCellValue("BC11", "Hospital de Cabildo")
        sl.SetCellValue("BD11", "Hospital de La Ligua")
        sl.SetCellValue("BE11", "HOSPITAL QUINTERO")
        'sl.SetCellValue("BJ11", "OTROS")
        'sl.SetCellValue("BK11", "TOTAL")


        sl.SetCellStyle("A9", estilo_1)
        sl.SetCellStyle("A9", estilo_borde)
        sl.SetCellStyle("A10", estilo_borde)

        sl.SetCellStyle("B9", estilo_1)
        sl.SetCellStyle("B9", estilo_borde)
        sl.SetCellStyle("B10", estilo_borde)

        sl.SetCellStyle(9, 4, 9, 57, estilo_3)
        sl.SetCellStyle(10, 4, 10, 57, estilo_4)
        sl.SetCellStyle(9, 3, 11, 57, estilo_borde)

        sl.SetCellStyle("A11", estilo_2)
        sl.SetCellStyle("A11", estilo_borde)
        sl.SetCellStyle("C11", estilo_borde)
        sl.SetCellStyle("A7", estilo_3)
        sl.SetCellStyle("A8", estilo_3)


        ' Colores para columnas tp atención
        sl.SetCellStyle(10, 4, 10, 6, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp1, True))
        sl.SetCellStyle(10, 7, 10, 20, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp2, True))
        sl.SetCellStyle(10, 21, 10, 24, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp3, True))
        sl.SetCellStyle(10, 25, 10, 25, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp4, True))
        sl.SetCellStyle(10, 26, 10, 28, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp5, True))
        sl.SetCellStyle(10, 29, 10, 57, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp6, True))

        ' Colores para columnas procedencias
        sl.SetCellStyle(11, 29, 11, 32, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc1, True))
        sl.SetCellStyle(11, 33, 11, 39, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc2, True))
        sl.SetCellStyle(11, 40, 11, 49, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc3, True))
        sl.SetCellStyle(11, 50, 11, 54, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc4, True))
        sl.SetCellStyle(11, 55, 11, 55, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc5, True))

    End Function
    Public Shared Function calcularCantidadTotal(ByVal item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES) As Integer
        Dim total As Integer = 0

        total += item.CAE
        total += item.USM_HDIURNO
        total += item.PERSONAL
        total += item.MQ1
        total += item.MQ2
        total += item.MQ3
        total += item.UAPQ_PABELLON
        total += item.PEDIATRIA
        total += item.NEONATOLOGIA
        total += item.UPC
        total += item.UCI_A
        total += item.UTI
        total += item.MATERNIDAD
        total += item.CMA
        total += item.HOSP_DOCIMI
        total += item.UEA_HOSP
        total += item.UEA
        total += item.UEI
        total += item.SAUD
        total += item.UEGO
        total += item.ANATOMIA_PATO
        total += item.IMAGENOLOGIA
        total += item.CESFAM_IVAN_MAN
        total += item.CESFAM_AV_AC
        total += item.CESFAM_QUILPUE
        total += item.CESFAM_BELLOTO
        total += item.CONS_POMPEYA
        total += item.CECOSF_RETIRO
        total += item.CONS_BELLOTO
        total += item.CESFAM_VILLA_AL
        total += item.CESFAM_AMERICAS
        total += item.CONS_EDUARDO_FREI
        total += item.CESFAM_JUAN_BT
        total += item.CONS_AGUILAS
        total += item.SAPU_FREI
        total += item.CESFAM_LIMACHE
        total += item.CESFAM_OLMUE
        total += item.APS_CABILDO
        total += item.APS_HIJUELAS
        total += item.APS_CALERA
        total += item.APS_LIGUA
        total += item.APS_NOGALES
        total += item.APS_PETORCA
        total += item.HOSP_LIMACHE
        total += item.HOSP_GERIATRICO_LMCHE
        total += item.HOSP_MODULAR_LMCHE
        total += item.HOSP_PENBLANCA
        total += item.HOSP_GUSTAVO_FRICKE
        total += item.HOSP_CALERA
        total += item.HOSP_PETORCA
        total += item.HOSP_QUILLOTA
        total += item.HOSP_CABILDO
        total += item.HOSP_LIGUA
        total += item.HOSP_QUINTERO

        item.CANTIDAD = total
        Return item.CANTIDAD
    End Function

#End Region

    '    Function Gen_Excel_REM(MAIN_URL As String, DESDE As String, HASTA As String, List_Data As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES))
    '        'Declaraciones Generales

    '        Dim N_Date As New N_Date
    '        ' Lista  Objetos de Examenes REM
    '        '    List_Data = D_Data.IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA)

    '        '    List_Data = List_Data _
    '        '.Where(Function(p) Not String.IsNullOrEmpty(p.CF_DESC_HOSP)) _
    '        '.ToList()
    '        'List_Data = List_Data _
    '        '     .GroupBy(Function(item) New With {Key .CF_COD_IRIS = item.CF_COD_IRIS, Key .ID_SECC_REM = item.ID_SECC_REM}) _
    '        '     .SelectMany(Function(group) group.ToList()) _
    '        '     .ToList()
    '        ' Agrupar por CF_COD_IRIS y ID_SECC_REM
    '        Dim groupedData = List_Data.GroupBy(Function(item) New With {Key .CF_COD_IRIS = item.CF_COD_IRIS, Key .ID_SECC_REM = item.ID_SECC_REM})

    '        ' Crear una nueva lista para los resultados agrupados y sumados
    '        Dim result As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)()
    '        For Each group In groupedData
    '            ' Crear un nuevo objeto E_IRIS_WEBF_BUSCA_CANT_EXAMENES para almacenar los resultados sumados
    '            Dim summary As New E_IRIS_WEBF_BUSCA_CANT_EXAMENES() With {
    '        .CF_DESC_HOSP = group.First().CF_DESC_HOSP,
    '        .CF_COD_IRIS = group.Key.CF_COD_IRIS,
    '        .ID_SECC_REM = group.Key.ID_SECC_REM,
    '        .SECC_REM_DESC = group.First().SECC_REM_DESC, ' Asumiendo que la descripción es la misma para todos los elementos del grupo
    '        .CANTIDAD = group.Sum(Function(item) item.CANTIDAD),
    '        .CAE = group.Sum(Function(item) item.CAE),
    '        .USM_HDIURNO = group.Sum(Function(item) item.USM_HDIURNO),
    '        .PERSONAL = group.Sum(Function(item) item.PERSONAL),
    '        .TOTAL_ABIERTA = group.Sum(Function(item) item.TOTAL_ABIERTA),
    '        .MQ1 = group.Sum(Function(item) item.MQ1),
    '        .MQ2 = group.Sum(Function(item) item.MQ2),
    '        .MQ3 = group.Sum(Function(item) item.MQ3),
    '        .UAPQ_PABELLON = group.Sum(Function(item) item.UAPQ_PABELLON),
    '        .PEDIATRIA = group.Sum(Function(item) item.PEDIATRIA),
    '        .NEONATOLOGIA = group.Sum(Function(item) item.NEONATOLOGIA),
    '        .UPC = group.Sum(Function(item) item.UPC),
    '        .UCI_A = group.Sum(Function(item) item.UCI_A),
    '        .UTI = group.Sum(Function(item) item.UTI),
    '        .MATERNIDAD = group.Sum(Function(item) item.MATERNIDAD),
    '        .CMA = group.Sum(Function(item) item.CMA),
    '        .HOSP_DOCIMI = group.Sum(Function(item) item.HOSP_DOCIMI),
    '        .UEA_HOSP = group.Sum(Function(item) item.UEA_HOSP),
    '        .TOTAL_CERRADA = group.Sum(Function(item) item.TOTAL_CERRADA),
    '        .UEA = group.Sum(Function(item) item.UEA),
    '        .UEI = group.Sum(Function(item) item.UEI),
    '        .SAUD = group.Sum(Function(item) item.SAUD),
    '        .TOTAL_UE = group.Sum(Function(item) item.TOTAL_UE),
    '        .UEGO = group.Sum(Function(item) item.UEGO),
    '        .ANATOMIA_PATO = group.Sum(Function(item) item.ANATOMIA_PATO),
    '        .IMAGENOLOGIA = group.Sum(Function(item) item.IMAGENOLOGIA),
    '        .TOTAL_UNIDAD_APOYO = group.Sum(Function(item) item.TOTAL_UNIDAD_APOYO),
    '        .CESFAM_IVAN_MAN = group.Sum(Function(item) item.CESFAM_IVAN_MAN),
    '        .CESFAM_AV_AC = group.Sum(Function(item) item.CESFAM_AV_AC),
    '        .CESFAM_QUILPUE = group.Sum(Function(item) item.CESFAM_QUILPUE),
    '        .CESFAM_BELLOTO = group.Sum(Function(item) item.CESFAM_BELLOTO),
    '        .CONS_POMPEYA = group.Sum(Function(item) item.CONS_POMPEYA),
    '        .CECOSF_RETIRO = group.Sum(Function(item) item.CECOSF_RETIRO),
    '        .CONS_BELLOTO = group.Sum(Function(item) item.CONS_BELLOTO),
    '        .CESFAM_VILLA_AL = group.Sum(Function(item) item.CESFAM_VILLA_AL),
    '        .CESFAM_AMERICAS = group.Sum(Function(item) item.CESFAM_AMERICAS),
    '        .CONS_EDUARDO_FREI = group.Sum(Function(item) item.CONS_EDUARDO_FREI),
    '        .CESFAM_JUAN_BT = group.Sum(Function(item) item.CESFAM_JUAN_BT),
    '        .CONS_AGUILAS = group.Sum(Function(item) item.CONS_AGUILAS),
    '        .SAPU_FREI = group.Sum(Function(item) item.SAPU_FREI),
    '        .CESFAM_LIMACHE = group.Sum(Function(item) item.CESFAM_LIMACHE),
    '        .CESFAM_OLMUE = group.Sum(Function(item) item.CESFAM_OLMUE),
    '        .APS_CABILDO = group.Sum(Function(item) item.APS_CABILDO),
    '        .APS_HIJUELAS = group.Sum(Function(item) item.APS_HIJUELAS),
    '        .APS_CALERA = group.Sum(Function(item) item.APS_CALERA),
    '        .APS_LIGUA = group.Sum(Function(item) item.APS_LIGUA),
    '        .APS_NOGALES = group.Sum(Function(item) item.APS_NOGALES),
    '        .APS_PETORCA = group.Sum(Function(item) item.APS_PETORCA),
    '        .HOSP_LIMACHE = group.Sum(Function(item) item.HOSP_LIMACHE),
    '        .HOSP_GERIATRICO_LMCHE = group.Sum(Function(item) item.HOSP_GERIATRICO_LMCHE),
    '        .HOSP_MODULAR_LMCHE = group.Sum(Function(item) item.HOSP_MODULAR_LMCHE),
    '        .HOSP_PENBLANCA = group.Sum(Function(item) item.HOSP_PENBLANCA),
    '        .HOSP_GUSTAVO_FRICKE = group.Sum(Function(item) item.HOSP_GUSTAVO_FRICKE),
    '        .HOSP_CALERA = group.Sum(Function(item) item.HOSP_CALERA),
    '        .HOSP_PETORCA = group.Sum(Function(item) item.HOSP_PETORCA),
    '        .HOSP_QUILLOTA = group.Sum(Function(item) item.HOSP_QUILLOTA),
    '        .HOSP_CABILDO = group.Sum(Function(item) item.HOSP_CABILDO),
    '        .HOSP_LIGUA = group.Sum(Function(item) item.HOSP_LIGUA),
    '        .HOSP_QUINTERO = group.Sum(Function(item) item.HOSP_QUINTERO),
    '        .OTROS = group.Sum(Function(item) item.OTROS),
    '        .TOTAL_EXTRA = group.Sum(Function(item) item.TOTAL_EXTRA)
    '    }
    '            ' Agregar el objeto resumen a la lista de resultados
    '            result.Add(summary)
    '        Next

    '        DESDE = DESDE.Replace("-", "/")
    '        HASTA = HASTA.Replace("-", "/")
    '        Dim Date_01 As Date = N_Date.strToDate(Split(DESDE, "/")(2), Split(DESDE, "/")(1), Split(DESDE, "/")(0))
    '        Dim Date_02 As Date = N_Date.strToDate(Split(HASTA, "/")(2), Split(HASTA, "/")(1), Split(HASTA, "/")(0))

    '        ' Obtenemos el nombre del mes
    '        Dim mes_nombre As String = Date_01.ToString("MMMM")
    '        ' Obtenemos el numero del mes
    '        Dim mes_numero As String = Date_01.Month.ToString("00")

    '        'Declaraciones para Excel
    '        Dim sl As New SLDocument
    '        Dim tabla As SLTable
    '        Dim ltabla As Integer = 0

    '        Dim End_Column As Integer = 2
    '        Dim End_Column_Table As String = "BJ"



    '        '---------------------Estilos----------------------

    '        'Crear un nuevo estilo y restablecer el color de fondo
    '        Dim estilo_1 As SLStyle
    '        Dim estilo_2 As SLStyle
    '        Dim estilo_3 As SLStyle
    '        Dim estilo_4 As SLStyle

    '        Dim estilo_celda_1 As SLStyle
    '        Dim estilo_celda_2 As SLStyle
    '        Dim estilo_celda_3 As SLStyle
    '        Dim estilo_celda_4 As SLStyle


    '        Dim soft_orange As Color = ColorTranslator.FromHtml("#fcd5b4") ' color_1
    '        Dim light_gray_o As Color = ColorTranslator.FromHtml("#fde9d9") 'color_2
    '        Dim soft_yellow As Color = ColorTranslator.FromHtml("#fce74e") ' color_3
    '        Dim pale_yellow As Color = ColorTranslator.FromHtml("#ffffcc") 'color_4
    '        Dim light_gray As Color = ColorTranslator.FromHtml("#c0c0c0") 'color_5
    '        Dim light_blue As Color = ColorTranslator.FromHtml("#ccffff") 'color_6
    '        Dim gray_green As Color = ColorTranslator.FromHtml("#e2efda") 'color_7


    '        ' Colores para columnas tipos de atención y otros
    '        Dim color_tp1 As Color = ColorTranslator.FromHtml("#f8cbad") ' Atención abierta
    '        Dim color_tp2 As Color = ColorTranslator.FromHtml("#ffe699") ' Atención cerrada
    '        Dim color_tp3 As Color = ColorTranslator.FromHtml("#a9d08e") ' UE
    '        Dim color_tp4 As Color = ColorTranslator.FromHtml("#9bc2e6") ' UEGO
    '        Dim color_tp5 As Color = ColorTranslator.FromHtml("#bfbfbf") ' Unidad de apoyo
    '        Dim color_tp6 As Color = ColorTranslator.FromHtml("#ff7c80") ' Atención extrahospitalaria

    '        ' Colores para procedencias 
    '        Dim color_proc1 As Color = ColorTranslator.FromHtml("#ffff00") ' proc 1 extra hosp
    '        Dim color_proc2 As Color = ColorTranslator.FromHtml("#00b0f0") ' proc 2 extra hosp
    '        Dim color_proc3 As Color = ColorTranslator.FromHtml("#a6a6a6") ' proc 3 extra hosp
    '        Dim color_proc4 As Color = ColorTranslator.FromHtml("#bf8f00") ' proc 4 extra hosp
    '        Dim color_proc5 As Color = ColorTranslator.FromHtml("#9bc2e6") ' proc 5 extra hosp


    '        ' Estilos para celdas de titulo
    '        ' Crear estilos para celdas de título
    '        estilo_1 = Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
    '        estilo_2 = Crear_Estilo(sl, 8, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
    '        estilo_3 = Crear_Estilo(sl, 11, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
    '        estilo_4 = Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)

    '        ' Crear estilos para celdas de información
    '        estilo_celda_1 = Crear_Estilo(sl, 8, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, soft_yellow, False)
    '        estilo_celda_2 = Crear_Estilo(sl, 8, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, pale_yellow, False)
    '        estilo_celda_3 = Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, gray_green, False)
    '        estilo_celda_4 = Crear_Estilo(sl, 9, False, "Verdana", Nothing, VerticalAlign.Middle, gray_green, False)

    '        ' Crear un estilo para las celdas con bordes internos
    '        Dim estilo_borde As New SLStyle()
    '        Dim estilo_borde_punto As New SLStyle()
    '        Dim estilo_borde_punto_2 As New SLStyle()
    '        Dim estilo_borde_final As New SLStyle()
    '        Dim estilo_borde_final_2 As New SLStyle()

    '        Dim estilo_sin_borde As New SLStyle()


    '        ' Establecer el borde con un color específico
    '        estilo_borde_punto.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
    '        estilo_borde_punto.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
    '        estilo_borde_punto.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
    '        estilo_borde_punto.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

    '        'Estilos qlos 2
    '        ' Establecer el borde con un color específico
    '        estilo_borde_punto_2.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
    '        estilo_borde_punto_2.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
    '        estilo_borde_punto_2.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
    '        estilo_borde_punto_2.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

    '        estilo_borde.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
    '        estilo_borde.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
    '        estilo_borde.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
    '        estilo_borde.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

    '        estilo_borde_final.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
    '        estilo_borde_final.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

    '        estilo_borde_final_2.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)


    '        estilo_sin_borde.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)
    '        estilo_sin_borde.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)
    '        estilo_sin_borde.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)

    '        'Creacion de hojas
    '        sl.AddWorksheet("Sheet1")
    '#Region "Sheet1"

    '        'Seleccionamos Sheet1
    '        sl.SelectWorksheet("Sheet1")

    '        ' Princpio
    '        sl.SetCellValue("A1", "SEREMI: Región de Valparaíso")
    '        sl.SetCellValue("A2", "Establecimiento: Hospital Quilpué")
    '        sl.SetCellValue("A3", "Comuna: Quilpué")
    '        sl.SetCellValue("A4", "Mes: " & mes_nombre & "(" & mes_numero & ")")
    '        sl.SetCellValue("A5", "Año: " & Now.ToString("yyyy"))

    '        sl.SetCellValue("B7", "CENSO REM")
    '        ' Aplicar el estilo a las celdas A10:C10 y A11:C11

    '        sl.SetCellValue("A9", "CÓDIGOS")
    '        sl.MergeWorksheetCells("A9", "A10")
    '        sl.SetCellValue("B9", "GLOSA")
    '        sl.MergeWorksheetCells("B9", "B10")


    '        sl.SetCellValue("C9", "CANTIDAD DE ATENCIONES POR PROCEDENCIA")
    '        sl.MergeWorksheetCells("C9", "BJ9")

    '        '----------------COLUMNAS TIPO ATENCIÓN----------------------
    '        sl.SetCellValue("C10", "ATENCIÓN ABIERTA")
    '        sl.MergeWorksheetCells("C10", "F10")
    '        sl.SetCellValue("G10", "ATENCIÓN CERRADA")
    '        sl.MergeWorksheetCells("G10", "T10")

    '        sl.SetCellValue("U10", "UE")
    '        sl.MergeWorksheetCells("U10", "X10")

    '        sl.SetCellValue("Y10", "UEGO")

    '        sl.SetCellValue("Z10", "UNIDAD DE APOYO")
    '        sl.MergeWorksheetCells("Z10", "AB10")

    '        sl.SetCellValue("AC10", "ATENCIÓN EXTRAHOSPITALARIO")
    '        sl.MergeWorksheetCells("AC10", "BJ10")

    '        ' ---------------COLUMNA ATENCIÓN ABIERTA------------------------------
    '        sl.SetCellValue("C11", "CAE")
    '        sl.SetCellValue("D11", "USM-HDIURNO")
    '        sl.SetCellValue("E11", "PERSONAL")
    '        sl.SetCellValue("F11", "TOTAL")
    '        ' ---------------COLUMNA ATENCIÓN CERRADA------------------------------
    '        sl.SetCellValue("G11", "MQ1")
    '        sl.SetCellValue("H11", "MQ2")
    '        sl.SetCellValue("I11", "MQ3")
    '        sl.SetCellValue("J11", "UAPQ (Pabellon)")
    '        sl.SetCellValue("K11", "PEDIATRIA")
    '        sl.SetCellValue("L11", "NEONATOLOGIA")
    '        sl.SetCellValue("M11", "UPC")
    '        sl.SetCellValue("N11", "UCI-A")
    '        sl.SetCellValue("O11", "UTI")
    '        sl.SetCellValue("P11", "MATERNIDAD")
    '        sl.SetCellValue("Q11", "CMA")
    '        sl.SetCellValue("R11", "HOSP. DOMICI")
    '        sl.SetCellValue("S11", "UEA-HOSP")
    '        sl.SetCellValue("T11", "TOTAL")
    '        '-----------------COLUMNAS UE--------------------------------------------
    '        sl.SetCellValue("U11", "UEA")
    '        sl.SetCellValue("V11", "UEI")
    '        sl.SetCellValue("W11", "SAUD")
    '        sl.SetCellValue("X11", "TOTAL")
    '        '-----------------COLUMNAS UEGO---------------------------------
    '        sl.SetCellValue("Y11", "UEGO")
    '        '-----------------COLUMNAS UNIDAD DE APOYO---------------------------------
    '        sl.SetCellValue("Z11", "ANATOMIA PATOLOGICA")
    '        sl.SetCellValue("AA11", "IMAGENOLOGIA")
    '        sl.SetCellValue("AB11", "TOTAL")
    '        '-----------------COLUMNAS EXTRAHOSPITALARIO---------------------------------
    '        sl.SetCellValue("AC11", "CESFAM Alcalde Iván Manríquez")
    '        sl.SetCellValue("AD11", "CESFAM Aviador Acevedo")
    '        sl.SetCellValue("AE11", "CESFAM QUILPUE")
    '        sl.SetCellValue("AF11", "CESFAM y SAR Belloto SUR")
    '        sl.SetCellValue("AG11", "Cons.Pompeya")
    '        sl.SetCellValue("AH11", "CECOSF El Retiro")
    '        sl.SetCellValue("AI11", "Cons.El Belloto")
    '        sl.SetCellValue("AJ11", "CESFAM Villa Alemana")
    '        sl.SetCellValue("AK11", "CESFAM Las Américas ")
    '        sl.SetCellValue("AL11", "Cons.Eduardo Frei")
    '        sl.SetCellValue("AM11", "CESFAM Juan Bautista Bravo Vega")
    '        sl.SetCellValue("AN11", "Cons.Cien Aguilas")
    '        sl.SetCellValue("AO11", "SAPU EDUARDO FREI")
    '        sl.SetCellValue("AP11", "CESFAM Limache")
    '        sl.SetCellValue("AQ11", "CESFAM Olmue")
    '        sl.SetCellValue("AR11", "APS CABILDO")
    '        sl.SetCellValue("AS11", "APS Hijuelas")
    '        sl.SetCellValue("AT11", "APS La Calera")
    '        sl.SetCellValue("AU11", "APS LA LIGUA")
    '        sl.SetCellValue("AV11", "APS Nogales ")
    '        sl.SetCellValue("AW11", "APS PETORCA ")
    '        sl.SetCellValue("AX11", "HOSPITAL DE LIMACHE")
    '        sl.SetCellValue("AY11", "Hosp.Geriatrico Paz de la tarde (limache)")
    '        sl.SetCellValue("AZ11", "Hosp.Modular de Emergencia (limache)")
    '        sl.SetCellValue("BA11", "Hosp.Peñablanca")
    '        sl.SetCellValue("BB11", "Hosp.Gustavo Fricke")
    '        sl.SetCellValue("BC11", "HOSPITAL CALERA")
    '        sl.SetCellValue("BD11", "Hospital de Petorca")
    '        sl.SetCellValue("BE11", "HOSPITAL DE QUILLOTA")
    '        sl.SetCellValue("BF11", "Hospital de Cabildo")
    '        sl.SetCellValue("BG11", "Hospital de La Ligua	")
    '        sl.SetCellValue("BH11", "HOSPITAL QUINTERO")
    '        sl.SetCellValue("BI11", "OTROS")
    '        sl.SetCellValue("BJ11", "TOTAL")


    '        sl.SetCellStyle("A9", estilo_1)
    '        sl.SetCellStyle("A9", estilo_borde)
    '        sl.SetCellStyle("A10", estilo_borde)

    '        sl.SetCellStyle("B9", estilo_1)
    '        sl.SetCellStyle("B9", estilo_borde)
    '        sl.SetCellStyle("B10", estilo_borde)

    '        sl.SetCellStyle(9, 3, 9, 62, estilo_3)
    '        sl.SetCellStyle(10, 4, 10, 62, estilo_4)
    '        sl.SetCellStyle(9, 3, 11, 62, estilo_borde)

    '        sl.SetCellStyle("A11", estilo_2)
    '        sl.SetCellStyle("A11", estilo_borde)
    '        sl.SetCellStyle("C11", estilo_borde)
    '        sl.SetCellStyle("A7", estilo_3)
    '        sl.SetCellStyle("A8", estilo_3)


    '        ' Colores para columnas tp atención
    '        sl.SetCellStyle(10, 3, 10, 6, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp1, True))
    '        sl.SetCellStyle(10, 7, 10, 20, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp2, True))
    '        sl.SetCellStyle(10, 21, 10, 24, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp3, True))
    '        sl.SetCellStyle(10, 25, 10, 25, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp4, True))
    '        sl.SetCellStyle(10, 26, 10, 28, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp5, True))
    '        sl.SetCellStyle(10, 29, 10, 62, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp6, True))

    '        ' Colores para columnas procedencias
    '        sl.SetCellStyle(12, 29, 11, 32, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc1, True))
    '        sl.SetCellStyle(12, 33, 11, 39, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc2, True))
    '        sl.SetCellStyle(12, 40, 11, 49, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc3, True))
    '        sl.SetCellStyle(12, 50, 11, 60, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc4, True))
    '        sl.SetCellStyle(12, 61, 11, 61, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc5, True))

    '        '-----------TABLA------------
    '        If (List_Data.Count > 0) Then
    '            ' Declarar una variable para realizar un seguimiento de la fila actual
    '            Dim fila_actual As Integer = 11

    '            ' Iterar sobre las secciones en el JSON
    '            Dim id_seccion_actual As Long
    '            Dim datos_seccion_actual As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
    '            Dim indice As Integer
    '            Dim totalDatos As Integer


    '            Dim contador As Integer = 0
    '            For Each seccion In result.GroupBy(Function(item) item.ID_SECC_REM)

    '                ' Contador
    '                contador += 1

    '                ' Obtener la sección actual
    '                id_seccion_actual = seccion.Key
    '                datos_seccion_actual = seccion.ToList()


    '                ' Establecer el nombre de la sección
    '                sl.SetCellValue(fila_actual, 1, If(datos_seccion_actual(0).SECC_REM_DESC.ToUpper, ""))

    '                sl.SetCellStyle(fila_actual, 1, fila_actual, 62, estilo_celda_1)
    '                sl.SetCellStyle(fila_actual, 1, fila_actual, 62, estilo_borde)

    '                sl.MergeWorksheetCells($"A{fila_actual}", $"B{fila_actual}")
    '                ' Sumar los TOTAL_ATE para esta sección
    '                'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)

    '                'total_ate_cerrada = datos_seccion_actual.Sum(Function(x) x.ATENCION_CERRADA)
    '                'total_ate_abierta = datos_seccion_actual.Sum(Function(x) x.ATENCION_ABIERTA)
    '                'total_ate_emergencia = datos_seccion_actual.Sum(Function(x) x.EMERGENCIA)

    '                'sl.SetCellValue(fila_actual, 3, total_ate_seccion)
    '                'sl.SetCellValue(fila_actual, 4, total_ate_cerrada)
    '                'sl.SetCellValue(fila_actual, 5, total_ate_abierta)
    '                'sl.SetCellValue(fila_actual, 6, total_ate_emergencia)

    '                ' Incrementar la fila actual para los datos
    '                fila_actual += 1
    '                totalDatos = datos_seccion_actual.Count
    '                indice = 1 ' Suponiendo que el índice del primer elemento es 1
    '                ' Iterar sobre los datos de la sección actual
    '                For Each dato In datos_seccion_actual

    '                    sl.SetCellValue(fila_actual, 1, dato.CF_COD_IRIS)
    '                    sl.SetCellValue(fila_actual, 2, dato.CF_DESC_HOSP)

    '                    ' ATENCIÓN ABIERTA
    '                    sl.SetCellValue(fila_actual, 3, dato.CAE)
    '                    sl.SetCellValue(fila_actual, 4, dato.USM_HDIURNO)
    '                    sl.SetCellValue(fila_actual, 5, dato.PERSONAL)
    '                    sl.SetCellValue(fila_actual, 6, dato.TOTAL_ABIERTA)

    '                    ' ATENCIÓN CERRADA
    '                    sl.SetCellValue(fila_actual, 7, dato.MQ1)
    '                    sl.SetCellValue(fila_actual, 8, dato.MQ2)
    '                    sl.SetCellValue(fila_actual, 9, dato.MQ3)
    '                    sl.SetCellValue(fila_actual, 10, dato.UAPQ_PABELLON)
    '                    sl.SetCellValue(fila_actual, 11, dato.PEDIATRIA)
    '                    sl.SetCellValue(fila_actual, 12, dato.NEONATOLOGIA)
    '                    sl.SetCellValue(fila_actual, 13, dato.UPC)
    '                    sl.SetCellValue(fila_actual, 14, dato.UCI_A)
    '                    sl.SetCellValue(fila_actual, 15, dato.UTI)
    '                    sl.SetCellValue(fila_actual, 16, dato.MATERNIDAD)
    '                    sl.SetCellValue(fila_actual, 17, dato.CMA)
    '                    sl.SetCellValue(fila_actual, 18, dato.HOSP_DOCIMI)
    '                    sl.SetCellValue(fila_actual, 19, dato.UEA_HOSP)
    '                    sl.SetCellValue(fila_actual, 20, dato.TOTAL_CERRADA)

    '                    ' UE
    '                    sl.SetCellValue(fila_actual, 21, dato.UEA)
    '                    sl.SetCellValue(fila_actual, 22, dato.UEI)
    '                    sl.SetCellValue(fila_actual, 23, dato.SAUD)
    '                    sl.SetCellValue(fila_actual, 24, dato.TOTAL_UE)

    '                    ' UEGO
    '                    sl.SetCellValue(fila_actual, 25, dato.UEGO)

    '                    ' UNIDAD DE APOYO
    '                    sl.SetCellValue(fila_actual, 26, dato.ANATOMIA_PATO)
    '                    sl.SetCellValue(fila_actual, 27, dato.IMAGENOLOGIA)
    '                    sl.SetCellValue(fila_actual, 28, dato.TOTAL_UNIDAD_APOYO)

    '                    ' ATENCIÓN EXTRAHOSPITALARIO
    '                    sl.SetCellValue(fila_actual, 29, dato.CESFAM_IVAN_MAN)
    '                    sl.SetCellValue(fila_actual, 30, dato.CESFAM_AV_AC)
    '                    sl.SetCellValue(fila_actual, 31, dato.CESFAM_QUILPUE) ' FALTA
    '                    sl.SetCellValue(fila_actual, 32, dato.CESFAM_BELLOTO) ' FALTA
    '                    sl.SetCellValue(fila_actual, 33, dato.CONS_POMPEYA)
    '                    sl.SetCellValue(fila_actual, 34, dato.CECOSF_RETIRO)
    '                    sl.SetCellValue(fila_actual, 35, dato.CONS_BELLOTO)
    '                    sl.SetCellValue(fila_actual, 36, dato.CESFAM_VILLA_AL)
    '                    sl.SetCellValue(fila_actual, 37, dato.CESFAM_AMERICAS)
    '                    sl.SetCellValue(fila_actual, 38, dato.CONS_EDUARDO_FREI)
    '                    sl.SetCellValue(fila_actual, 39, dato.CESFAM_JUAN_BT)
    '                    sl.SetCellValue(fila_actual, 40, dato.CONS_AGUILAS)
    '                    sl.SetCellValue(fila_actual, 41, dato.SAPU_FREI)
    '                    sl.SetCellValue(fila_actual, 42, dato.CESFAM_LIMACHE)
    '                    sl.SetCellValue(fila_actual, 43, dato.CESFAM_OLMUE)
    '                    sl.SetCellValue(fila_actual, 44, dato.APS_CABILDO)
    '                    sl.SetCellValue(fila_actual, 45, dato.APS_HIJUELAS)
    '                    sl.SetCellValue(fila_actual, 46, dato.APS_CALERA)
    '                    sl.SetCellValue(fila_actual, 47, dato.APS_LIGUA)
    '                    sl.SetCellValue(fila_actual, 48, dato.APS_NOGALES)
    '                    sl.SetCellValue(fila_actual, 49, dato.APS_PETORCA)
    '                    sl.SetCellValue(fila_actual, 50, dato.HOSP_LIMACHE)
    '                    sl.SetCellValue(fila_actual, 51, dato.HOSP_PETORCA) ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
    '                    sl.SetCellValue(fila_actual, 52, dato.HOSP_MODULAR_LMCHE) ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
    '                    sl.SetCellValue(fila_actual, 53, dato.HOSP_PENBLANCA)
    '                    sl.SetCellValue(fila_actual, 54, dato.HOSP_GUSTAVO_FRICKE)
    '                    sl.SetCellValue(fila_actual, 55, dato.HOSP_CALERA)
    '                    sl.SetCellValue(fila_actual, 56, dato.HOSP_PETORCA)
    '                    sl.SetCellValue(fila_actual, 57, dato.HOSP_QUILLOTA)
    '                    sl.SetCellValue(fila_actual, 58, dato.HOSP_CABILDO)
    '                    sl.SetCellValue(fila_actual, 59, dato.HOSP_LIGUA)
    '                    sl.SetCellValue(fila_actual, 60, dato.HOSP_QUINTERO)
    '                    sl.SetCellValue(fila_actual, 61, 0) ' FALTA OTROS
    '                    sl.SetCellValue(fila_actual, 62, dato.TOTAL_EXTRA) ' FALTA PROC OTROS

    '                    sl.SetCellStyle(fila_actual, 1, fila_actual, 62, estilo_borde_punto)
    '                    If indice = totalDatos Then
    '                        sl.SetCellValue((fila_actual + 1), 2, "TOTAL")
    '                        sl.SetCellStyle((fila_actual + 1), 2, (fila_actual + 1), 2, Crear_Estilo(sl, 9, True, "Verdana", Nothing, VerticalAlign.Middle, Nothing, False))
    '                        sl.SetCellStyle(fila_actual + 1, 1, fila_actual + 1, 62, estilo_borde_punto)
    '                        sl.SetCellStyle((fila_actual + 2), 1, (fila_actual + 2), 62, estilo_borde)
    '                        'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)
    '                        ' ATENCIÓN ABIERTA
    '                        sl.SetCellValue((fila_actual + 1), 3, datos_seccion_actual.Sum(Function(x) x.CAE))
    '                        sl.SetCellValue((fila_actual + 1), 4, datos_seccion_actual.Sum(Function(x) x.USM_HDIURNO))
    '                        sl.SetCellValue((fila_actual + 1), 5, datos_seccion_actual.Sum(Function(x) x.PERSONAL))
    '                        sl.SetCellValue((fila_actual + 1), 6, datos_seccion_actual.Sum(Function(x) x.TOTAL_ABIERTA))

    '                        ' ATENCIÓN CERRADA
    '                        sl.SetCellValue((fila_actual + 1), 7, datos_seccion_actual.Sum(Function(x) x.MQ1))
    '                        sl.SetCellValue((fila_actual + 1), 8, datos_seccion_actual.Sum(Function(x) x.MQ2))
    '                        sl.SetCellValue((fila_actual + 1), 9, datos_seccion_actual.Sum(Function(x) x.MQ3))
    '                        sl.SetCellValue((fila_actual + 1), 10, datos_seccion_actual.Sum(Function(x) x.UAPQ_PABELLON))
    '                        sl.SetCellValue((fila_actual + 1), 11, datos_seccion_actual.Sum(Function(x) x.PEDIATRIA))
    '                        sl.SetCellValue((fila_actual + 1), 12, datos_seccion_actual.Sum(Function(x) x.NEONATOLOGIA))
    '                        sl.SetCellValue((fila_actual + 1), 13, datos_seccion_actual.Sum(Function(x) x.UPC))
    '                        sl.SetCellValue((fila_actual + 1), 14, datos_seccion_actual.Sum(Function(x) x.UCI_A))
    '                        sl.SetCellValue((fila_actual + 1), 15, datos_seccion_actual.Sum(Function(x) x.UTI))
    '                        sl.SetCellValue((fila_actual + 1), 16, datos_seccion_actual.Sum(Function(x) x.MATERNIDAD))
    '                        sl.SetCellValue((fila_actual + 1), 17, datos_seccion_actual.Sum(Function(x) x.CMA))
    '                        sl.SetCellValue((fila_actual + 1), 18, datos_seccion_actual.Sum(Function(x) x.HOSP_DOCIMI))
    '                        sl.SetCellValue((fila_actual + 1), 19, datos_seccion_actual.Sum(Function(x) x.UEA_HOSP))
    '                        sl.SetCellValue((fila_actual + 1), 20, datos_seccion_actual.Sum(Function(x) x.TOTAL_CERRADA))

    '                        ' UE
    '                        sl.SetCellValue((fila_actual + 1), 21, datos_seccion_actual.Sum(Function(x) x.UEA))
    '                        sl.SetCellValue((fila_actual + 1), 22, datos_seccion_actual.Sum(Function(x) x.UEI))
    '                        sl.SetCellValue((fila_actual + 1), 23, datos_seccion_actual.Sum(Function(x) x.SAUD))
    '                        sl.SetCellValue((fila_actual + 1), 24, datos_seccion_actual.Sum(Function(x) x.TOTAL_UE))

    '                        ' UEGO
    '                        sl.SetCellValue(fila_actual, 25, datos_seccion_actual.Sum(Function(x) x.UEGO))

    '                        ' UNIDAD DE APOYO
    '                        sl.SetCellValue((fila_actual + 1), 26, datos_seccion_actual.Sum(Function(x) x.ANATOMIA_PATO))
    '                        sl.SetCellValue((fila_actual + 1), 27, datos_seccion_actual.Sum(Function(x) x.IMAGENOLOGIA))
    '                        sl.SetCellValue((fila_actual + 1), 28, datos_seccion_actual.Sum(Function(x) x.TOTAL_UNIDAD_APOYO))

    '                        ' ATENCIÓN EXTRAHOSPITALARIO
    '                        sl.SetCellValue((fila_actual + 1), 29, datos_seccion_actual.Sum(Function(x) x.CESFAM_IVAN_MAN))
    '                        sl.SetCellValue((fila_actual + 1), 30, datos_seccion_actual.Sum(Function(x) x.CESFAM_AV_AC))
    '                        sl.SetCellValue((fila_actual + 1), 31, datos_seccion_actual.Sum(Function(x) x.CESFAM_QUILPUE)) ' FALTA
    '                        sl.SetCellValue((fila_actual + 1), 32, datos_seccion_actual.Sum(Function(x) x.CESFAM_BELLOTO)) ' FALTA
    '                        sl.SetCellValue((fila_actual + 1), 33, datos_seccion_actual.Sum(Function(x) x.CONS_POMPEYA))
    '                        sl.SetCellValue((fila_actual + 1), 34, datos_seccion_actual.Sum(Function(x) x.CECOSF_RETIRO))
    '                        sl.SetCellValue((fila_actual + 1), 35, datos_seccion_actual.Sum(Function(x) x.CONS_BELLOTO))
    '                        sl.SetCellValue((fila_actual + 1), 36, datos_seccion_actual.Sum(Function(x) x.CESFAM_VILLA_AL))
    '                        sl.SetCellValue((fila_actual + 1), 37, datos_seccion_actual.Sum(Function(x) x.CESFAM_AMERICAS))
    '                        sl.SetCellValue((fila_actual + 1), 38, datos_seccion_actual.Sum(Function(x) x.CONS_EDUARDO_FREI))
    '                        sl.SetCellValue((fila_actual + 1), 39, datos_seccion_actual.Sum(Function(x) x.CESFAM_JUAN_BT))
    '                        sl.SetCellValue((fila_actual + 1), 40, datos_seccion_actual.Sum(Function(x) x.CONS_AGUILAS))
    '                        sl.SetCellValue((fila_actual + 1), 41, datos_seccion_actual.Sum(Function(x) x.SAPU_FREI))
    '                        sl.SetCellValue((fila_actual + 1), 42, datos_seccion_actual.Sum(Function(x) x.CESFAM_LIMACHE))
    '                        sl.SetCellValue((fila_actual + 1), 43, datos_seccion_actual.Sum(Function(x) x.CESFAM_OLMUE))
    '                        sl.SetCellValue((fila_actual + 1), 44, datos_seccion_actual.Sum(Function(x) x.APS_CABILDO))
    '                        sl.SetCellValue((fila_actual + 1), 45, datos_seccion_actual.Sum(Function(x) x.APS_HIJUELAS))
    '                        sl.SetCellValue((fila_actual + 1), 46, datos_seccion_actual.Sum(Function(x) x.APS_CALERA))
    '                        sl.SetCellValue((fila_actual + 1), 47, datos_seccion_actual.Sum(Function(x) x.APS_LIGUA))
    '                        sl.SetCellValue((fila_actual + 1), 48, datos_seccion_actual.Sum(Function(x) x.APS_NOGALES))
    '                        sl.SetCellValue((fila_actual + 1), 49, datos_seccion_actual.Sum(Function(x) x.APS_PETORCA))
    '                        sl.SetCellValue((fila_actual + 1), 50, datos_seccion_actual.Sum(Function(x) x.HOSP_LIMACHE))
    '                        sl.SetCellValue((fila_actual + 1), 51, datos_seccion_actual.Sum(Function(x) x.HOSP_PETORCA)) ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
    '                        sl.SetCellValue((fila_actual + 1), 52, datos_seccion_actual.Sum(Function(x) x.HOSP_MODULAR_LMCHE)) ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
    '                        sl.SetCellValue((fila_actual + 1), 53, datos_seccion_actual.Sum(Function(x) x.HOSP_PENBLANCA))
    '                        sl.SetCellValue((fila_actual + 1), 54, datos_seccion_actual.Sum(Function(x) x.HOSP_GUSTAVO_FRICKE))
    '                        sl.SetCellValue((fila_actual + 1), 55, datos_seccion_actual.Sum(Function(x) x.HOSP_CALERA))
    '                        sl.SetCellValue((fila_actual + 1), 56, datos_seccion_actual.Sum(Function(x) x.HOSP_PETORCA))
    '                        sl.SetCellValue((fila_actual + 1), 57, datos_seccion_actual.Sum(Function(x) x.HOSP_QUILLOTA))
    '                        sl.SetCellValue((fila_actual + 1), 58, datos_seccion_actual.Sum(Function(x) x.HOSP_CABILDO))
    '                        sl.SetCellValue((fila_actual + 1), 59, datos_seccion_actual.Sum(Function(x) x.HOSP_LIGUA))
    '                        sl.SetCellValue((fila_actual + 1), 60, datos_seccion_actual.Sum(Function(x) x.HOSP_QUINTERO))
    '                        sl.SetCellValue((fila_actual + 1), 61, 0) ' FALTA OTROS
    '                        sl.SetCellValue((fila_actual + 1), 62, datos_seccion_actual.Sum(Function(x) x.TOTAL_EXTRA)) ' FALTA PROC OTROS

    '                        fila_actual += 1
    '                    End If

    '                    fila_actual += 1
    '                    indice += 1
    '                Next

    '                ' ESTILO FINAL DE TABLA
    '                'sl.SetCellStyle(fila_actual, 1, totalDatos, 2, estilo_borde)

    '                ' COLUMNA 1
    '                'sl.SetCellStyle(fila_actual, 1, totalDatos, 1, estilo_celda_3)
    '                ' COLUMNA 2
    '                'sl.SetCellStyle(fila_actual, 2, totalDatos, 2, estilo_celda_4)

    '                ' COLUMNAS 3 A 61
    '                'sl.SetCellStyle(fila_actual, 3, totalDatos, 61, estilo_celda_2)
    '                'sl.SetCellStyle(fila_actual, 3, totalDatos, 61, estilo_borde_punto)
    '            Next

    '            ' COLUMNAS PROCEDENCIA
    '        End If
    '        ' Calcula y agrega el total general al final de la tabla
    '        Dim totalGeneral As Double = 0

    '        ' Creamos estas variables para la fila Total
    '        Dim filaTotal As Integer = List_Data.Count + 9
    '        Dim columnaTextoTotal As Integer = 3 ' Columna C
    '        Dim columnaTotal As Integer = 5 ' Columna E



    '        'Ancho de Columnas Primera tabla
    '        sl.SetColumnWidth(1, 18)
    '        sl.SetColumnWidth(2, 90)

    '        'Ancho de Columnas Segunda tabla

    '        sl.SetColumnWidth(3, 61, 15)

    '        Dim totalGrupo2 As Integer = List_Data.GroupBy(Function(item) item.ID_SECCION).Count()
    '        Dim totalGrupos As Integer = List_Data.Count()
    '        sl.SetCellStyle(11, 1, 11, 62, Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
    '        sl.SetCellStyle(13, 3, ((totalGrupos * 2) + 12), 62, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
    '        sl.SetCellStyle(13, 1, ((totalGrupos * 2) + 12), 1, Crear_Estilo(sl, 9, Nothing, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
    '        sl.SetCellStyle(13, 2, ((totalGrupos * 2) + 12), 2, Crear_Estilo(sl, 9, Nothing, "Verdana", Nothing, VerticalAlign.Middle, Nothing, True))
    '        'sl.SetCellStyle(13, 1, (totalGrupos + totalGrupo2 + 22), 62, estilo_borde_punto)
    '        'Debug.WriteLine("TOTAL GRUPOS {0}", totalGrupos)
    '        'Debug.WriteLine("TOTAL GRUPOS 2 {0}", totalGrupo2)
    '        ltabla += 10

    '#End Region

    '        'Nombrar hojas
    '        sl.RenameWorksheet("Sheet1", "REM")

    '        'insertar tabla
    '        tabla = sl.CreateTable("A10", CStr(End_Column_Table & ltabla - 4))
    '        tabla.SetTableStyle(SLTableStyleTypeValues.Medium9)
    '        sl.InsertTable(tabla)
    '        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")

    '        Dim hora_actual As DateTime = DateTime.Now
    '        Dim Relative_Path As String = "Excel\" & "REM_" & Format(Date.Parse(DESDE), "dd-MM-yyyy") & "_" & Format(Date.Parse(HASTA), "dd-MM-yyyy") & "_" & hora_actual.ToString("HH-mm-ss") & ".xlsx"
    '        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
    '        sl.Dispose()
    '        'Devolver la url del archivo generado
    '        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    '    End Function

    Function Gen_Excel_Desagrupado(MAIN_URL As String, DESDE As String, HASTA As String, List_Data As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES))
        'Declaraciones Generales

        Dim N_Date As New N_Date
        ' Lista  Objetos de Examenes REM
        '    List_Data = D_Data.IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA)

        '    List_Data = List_Data _
        '.Where(Function(p) Not String.IsNullOrEmpty(p.CF_DESC_HOSP)) _
        '.ToList()


        DESDE = DESDE.Replace("-", "/")
        HASTA = HASTA.Replace("-", "/")
        Dim Date_01 As Date = N_Date.strToDate(Split(DESDE, "/")(2), Split(DESDE, "/")(1), Split(DESDE, "/")(0))
        Dim Date_02 As Date = N_Date.strToDate(Split(HASTA, "/")(2), Split(HASTA, "/")(1), Split(HASTA, "/")(0))

        ' Obtenemos el nombre del mes
        Dim mes_nombre As String = Date_01.ToString("MMMM")
        ' Obtenemos el numero del mes
        Dim mes_numero As String = Date_01.Month.ToString("00")

        Dim List_Not_Duplicate = List_Data.
            GroupBy(Function(item) item.ID_RLS_LS).
            Select(Function(item) item.First()).ToList()


        'List_Data = List_Data.Where(Function(item) item.EXISTE_CF = True).ToList()
        'Declaraciones para Excel
        Dim sl As New SLDocument
        Dim tabla As SLTable
        Dim ltabla As Integer = 0

        Dim End_Column As Integer = 2
        Dim End_Column_Table As String = "BJ"

        '---------------------Estilos----------------------

        'Crear un nuevo estilo y restablecer el color de fondo
        Dim estilo_1 As SLStyle
        Dim estilo_2 As SLStyle
        Dim estilo_3 As SLStyle
        Dim estilo_4 As SLStyle

        Dim estilo_celda_1 As SLStyle
        Dim estilo_celda_2 As SLStyle
        Dim estilo_celda_3 As SLStyle
        Dim estilo_celda_4 As SLStyle


        Dim soft_orange As Color = ColorTranslator.FromHtml("#fcd5b4") ' color_1
        Dim light_gray_o As Color = ColorTranslator.FromHtml("#fde9d9") 'color_2
        Dim soft_yellow As Color = ColorTranslator.FromHtml("#fce74e") ' color_3
        Dim pale_yellow As Color = ColorTranslator.FromHtml("#ffffcc") 'color_4
        Dim light_gray As Color = ColorTranslator.FromHtml("#c0c0c0") 'color_5
        Dim light_blue As Color = ColorTranslator.FromHtml("#ccffff") 'color_6
        Dim gray_green As Color = ColorTranslator.FromHtml("#e2efda") 'color_7

        ' Colores para columnas tipos de atención y otros
        Dim color_tp1 As Color = ColorTranslator.FromHtml("#f8cbad") ' Atención abierta
        Dim color_tp2 As Color = ColorTranslator.FromHtml("#ffe699") ' Atención cerrada
        Dim color_tp3 As Color = ColorTranslator.FromHtml("#a9d08e") ' UE
        Dim color_tp4 As Color = ColorTranslator.FromHtml("#9bc2e6") ' UEGO
        Dim color_tp5 As Color = ColorTranslator.FromHtml("#bfbfbf") ' Unidad de apoyo
        Dim color_tp6 As Color = ColorTranslator.FromHtml("#ff7c80") ' Atención extrahospitalaria

        ' Colores para procedencias 
        Dim color_proc1 As Color = ColorTranslator.FromHtml("#ffff00") ' proc 1 extra hosp
        Dim color_proc2 As Color = ColorTranslator.FromHtml("#00b0f0") ' proc 2 extra hosp
        Dim color_proc3 As Color = ColorTranslator.FromHtml("#a6a6a6") ' proc 3 extra hosp
        Dim color_proc4 As Color = ColorTranslator.FromHtml("#bf8f00") ' proc 4 extra hosp
        Dim color_proc5 As Color = ColorTranslator.FromHtml("#9bc2e6") ' proc 5 extra hosp

        ' Estilos para celdas de titulo
        ' Crear estilos para celdas de título
        estilo_1 = Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
        estilo_2 = Crear_Estilo(sl, 8, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
        estilo_3 = Crear_Estilo(sl, 11, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
        estilo_4 = Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)

        ' Crear estilos para celdas de información
        estilo_celda_1 = Crear_Estilo(sl, 8, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, soft_yellow, False)
        estilo_celda_2 = Crear_Estilo(sl, 8, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, pale_yellow, False)
        estilo_celda_3 = Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, gray_green, False)
        estilo_celda_4 = Crear_Estilo(sl, 9, False, "Verdana", Nothing, VerticalAlign.Middle, gray_green, False)

        ' Crear un estilo para las celdas con bordes internos
        Dim estilo_borde As New SLStyle()
        Dim estilo_borde_punto As New SLStyle()
        Dim estilo_borde_punto_2 As New SLStyle()
        Dim estilo_borde_final As New SLStyle()
        Dim estilo_borde_final_2 As New SLStyle()

        Dim estilo_sin_borde As New SLStyle()


        ' Establecer el borde con un color específico
        estilo_borde_punto.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde_punto.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        'Estilos qlos 2
        ' Establecer el borde con un color específico
        estilo_borde_punto_2.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto_2.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto_2.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde_punto_2.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        estilo_borde.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        estilo_borde_final.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_final.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        estilo_borde_final_2.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)


        estilo_sin_borde.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)
        estilo_sin_borde.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)
        estilo_sin_borde.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)

        'Creacion de hojas
        sl.AddWorksheet("Sheet1")
        sl.AddWorksheet("Sheet2")

#Region "Sheet1"

        'Seleccionamos Sheet1
        sl.SelectWorksheet("Sheet1")

        Dim name_sheet1 As String = sl.GetCurrentWorksheetName()

        Dim new_name_sheet1 As String = "REM"
        sl.RenameWorksheet(name_sheet1, new_name_sheet1)

        Header_Excel(DESDE, HASTA, sl, estilo_1, estilo_2, estilo_3, estilo_4, estilo_borde, color_proc1, color_proc2, color_proc3, color_proc4, color_proc5, color_tp1, color_tp2, color_tp3, color_tp4, color_tp5, color_tp6, True)

        'sl.FreezePanes(11, 2)
        sl.FreezePanes(0, 2)
        '' Princpio
        'sl.SetCellValue("A1", "SEREMI: Región de Valparaíso")
        'sl.SetCellValue("A2", "Establecimiento: Hospital Quilpué")
        'sl.SetCellValue("A3", "Comuna: Quilpué")
        'sl.SetCellValue("A4", $"Desde: {DESDE}, Hasta: {HASTA}")
        'sl.SetCellValue("A5", "Año: " & Now.ToString("yyyy"))

        'sl.SetCellValue("B7", "CENSO REM")
        '' Aplicar el estilo a las celdas A10:C10 y A11:C11

        'sl.SetCellValue("A9", "CÓDIGOS")
        'sl.MergeWorksheetCells("A9", "A10")
        'sl.SetCellValue("B9", "GLOSA")
        'sl.MergeWorksheetCells("B9", "B10")


        'sl.SetCellValue("D9", "CANTIDAD DE ATENCIONES POR PROCEDENCIA")
        'sl.MergeWorksheetCells("D9", "BK9")

        ''----------------COLUMNAS TIPO ATENCIÓN----------------------
        'sl.SetCellValue("D10", "ATENCIÓN ABIERTA")
        'sl.MergeWorksheetCells("D10", "F10")

        'sl.SetCellValue("G10", "ATENCIÓN CERRADA")
        'sl.MergeWorksheetCells("G10", "S10")

        'sl.SetCellValue("T10", "UE")
        'sl.MergeWorksheetCells("T10", "V10")

        'sl.SetCellValue("W10", "UEGO")

        'sl.SetCellValue("X10", "UNIDAD DE APOYO")
        'sl.MergeWorksheetCells("X10", "Y10")

        'sl.SetCellValue("Z10", "ATENCIÓN EXTRAHOSPITALARIO")
        'sl.MergeWorksheetCells("Z10", "BE10")



        ''----------------COLUMNAS TOTAL GENERAL----------------------
        'sl.SetCellValue("C9", "TOTAL GENERAL")
        'sl.MergeWorksheetCells("C9", "C10")

        ''----------------COLUMNAS PROCEDENCIAS----------------------
        ''sl.SetCellValue("B11", "EXÁMENES DE LABORATORIO")

        '' ---------------COLUMN ATENCIÓN ABIERTA------------------------------
        'sl.SetCellValue("D11", "CAE")
        'sl.SetCellValue("E11", "USM-HDIURNO")
        'sl.SetCellValue("F11", "PERSONAL")
        ''sl.SetCellValue("G11", "TOTAL")
        '' ---------------COLUMN ATENCIÓN CERRADA------------------------------
        'sl.SetCellValue("G11", "MQ1")
        'sl.SetCellValue("H11", "MQ2")
        'sl.SetCellValue("I11", "MQ3")
        'sl.SetCellValue("J11", "UAPQ (Pabellon)")
        'sl.SetCellValue("K11", "PEDIATRIA")
        'sl.SetCellValue("L11", "NEONATOLOGIA")
        'sl.SetCellValue("M11", "UPC")
        'sl.SetCellValue("N11", "UCI-A")
        'sl.SetCellValue("O11", "UTI")
        'sl.SetCellValue("P11", "MATERNIDAD")
        'sl.SetCellValue("Q11", "CMA")
        'sl.SetCellValue("R11", "HOSP. DOMICI")
        'sl.SetCellValue("S11", "UEA-HOSP")
        ''sl.SetCellValue("U11", "TOTAL")
        ''-----------------COLUMNAS UE--------------------------------------------
        'sl.SetCellValue("T11", "UEA")
        'sl.SetCellValue("U11", "UEI")
        'sl.SetCellValue("V11", "SAUD")
        ''sl.SetCellValue("Y11", "TOTAL")
        ''-----------------COLUMNAS UEGO---------------------------------
        'sl.SetCellValue("W11", "UEGO")
        ''-----------------COLUMNAS UNIDAD DE APOYO---------------------------------
        'sl.SetCellValue("X11", "ANATOMIA PATOLOGICA")
        'sl.SetCellValue("Y11", "IMAGENOLOGIA")
        ''sl.SetCellValue("AC11", "TOTAL")
        ''-----------------COLUMNAS EXTRAHOSPITALARIO---------------------------------
        'sl.SetCellValue("Z11", "CESFAM Alcalde Iván Manríquez")
        'sl.SetCellValue("AA11", "CESFAM Aviador Acevedo")
        'sl.SetCellValue("AB11", "CESFAM QUILPUE")
        'sl.SetCellValue("AC11", "CESFAM y SAR Belloto SUR")
        'sl.SetCellValue("AD11", "Cons.Pompeya")
        'sl.SetCellValue("AE11", "CECOSF El Retiro")
        'sl.SetCellValue("AF11", "Cons.El Belloto")
        'sl.SetCellValue("AG11", "CESFAM Villa Alemana")
        'sl.SetCellValue("AH11", "CESFAM Las Américas")
        'sl.SetCellValue("AI11", "Cons.Eduardo Frei")
        'sl.SetCellValue("AJ11", "CESFAM Juan Bautista Bravo Vega")
        'sl.SetCellValue("AK11", "Cons.Cien Aguilas")
        'sl.SetCellValue("AL11", "SAPU EDUARDO FREI")
        'sl.SetCellValue("AM11", "CESFAM Limache")
        'sl.SetCellValue("AN11", "CESFAM Olmue")
        'sl.SetCellValue("AO11", "APS CABILDO")
        'sl.SetCellValue("AP11", "APS Hijuelas")
        'sl.SetCellValue("AQ11", "APS La Calera")
        'sl.SetCellValue("AR11", "APS LA LIGUA")
        'sl.SetCellValue("AS11", "APS Nogales ")
        'sl.SetCellValue("AT11", "APS PETORCA ")
        'sl.SetCellValue("AU11", "HOSPITAL DE LIMACHE")
        'sl.SetCellValue("AV11", "Hosp.Geriatrico Paz de la tarde (limache)")
        'sl.SetCellValue("AW11", "Hosp.Modular de Emergencia (limache)")
        'sl.SetCellValue("AX11", "Hosp.Peñablanca")
        'sl.SetCellValue("AY11", "Hosp.Gustavo Fricke")
        'sl.SetCellValue("AZ11", "HOSPITAL CALERA")
        'sl.SetCellValue("BA11", "Hospital de Petorca")
        'sl.SetCellValue("BB11", "HOSPITAL DE QUILLOTA")
        'sl.SetCellValue("BC11", "Hospital de Cabildo")
        'sl.SetCellValue("BD11", "Hospital de La Ligua")
        'sl.SetCellValue("BE11", "HOSPITAL QUINTERO")
        ''sl.SetCellValue("BJ11", "OTROS")
        ''sl.SetCellValue("BK11", "TOTAL")


        'sl.SetCellStyle("A9", estilo_1)
        'sl.SetCellStyle("A9", estilo_borde)
        'sl.SetCellStyle("A10", estilo_borde)

        'sl.SetCellStyle("B9", estilo_1)
        'sl.SetCellStyle("B9", estilo_borde)
        'sl.SetCellStyle("B10", estilo_borde)

        'sl.SetCellStyle(9, 4, 9, 57, estilo_3)
        'sl.SetCellStyle(10, 4, 10, 57, estilo_4)
        'sl.SetCellStyle(9, 3, 11, 57, estilo_borde)

        'sl.SetCellStyle("A11", estilo_2)
        'sl.SetCellStyle("A11", estilo_borde)
        'sl.SetCellStyle("C11", estilo_borde)
        'sl.SetCellStyle("A7", estilo_3)
        'sl.SetCellStyle("A8", estilo_3)


        '' Colores para columnas tp atención
        'sl.SetCellStyle(10, 4, 10, 6, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp1, True))
        'sl.SetCellStyle(10, 7, 10, 20, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp2, True))
        'sl.SetCellStyle(10, 21, 10, 24, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp3, True))
        'sl.SetCellStyle(10, 25, 10, 25, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp4, True))
        'sl.SetCellStyle(10, 26, 10, 28, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp5, True))
        'sl.SetCellStyle(10, 29, 10, 57, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp6, True))

        '' Colores para columnas procedencias
        'sl.SetCellStyle(11, 29, 11, 32, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc1, True))
        'sl.SetCellStyle(11, 33, 11, 39, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc2, True))
        'sl.SetCellStyle(11, 40, 11, 49, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc3, True))
        'sl.SetCellStyle(11, 50, 11, 54, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc4, True))
        'sl.SetCellStyle(11, 55, 11, 55, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc5, True))

        ''sl.FreezePanes(11, 2)
        'sl.FreezePanes(0, 2)

        '-----------TABLA------------
        If (List_Data.Count > 0) Then
            ' Declarar una variable para realizar un seguimiento de la fila actual
            Dim fila_actual As Integer = 12

            ' Iterar sobre las secciones en el JSON
            Dim id_seccion_actual As Long
            Dim datos_seccion_actual As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
            Dim indice As Integer
            Dim totalDatos As Integer

            ' Ordenar la lista por ID_SECC_REM
            Dim sortedList = List_Data.OrderBy(Function(item) item.ID_SECC_REM).ToList()
            Dim contador As Integer = 0
            For Each seccion In sortedList.GroupBy(Function(item) item.ID_SECC_REM)

                ' Contador
                contador += 1

                ' Obtener la sección actual
                id_seccion_actual = seccion.Key
                datos_seccion_actual = seccion.ToList()

                'Debug.WriteLine("CONTADOR: " & contador)
                ' Establecer el nombre de la sección
                If (contador = 1) Then
                    sl.SetCellValue(fila_actual - 1, 2, datos_seccion_actual(0).AREA_DESC.ToUpper)
                    'fila_actual += 1
                End If
                If (contador = 6 And datos_seccion_actual(0).ID_AREA_REM = 2) Then
                    'Debug.WriteLine("CONTADOR 2: " & contador)
                    sl.SetCellValue(fila_actual, 2, datos_seccion_actual(0).AREA_DESC.ToUpper)
                    fila_actual += 1
                End If
                sl.SetCellStyle(fila_actual - 1, 2, fila_actual, 57, estilo_borde)
                sl.SetCellValue(fila_actual, 1, datos_seccion_actual(0).SECC_REM_DESC.ToUpper)

                sl.SetCellStyle(fila_actual, 1, fila_actual, 57, estilo_celda_1)
                sl.SetCellStyle(fila_actual, 1, fila_actual, 57, estilo_borde)

                sl.MergeWorksheetCells($"A{fila_actual}", $"B{fila_actual}")
                ' Sumar los TOTAL_ATE para esta sección
                'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)

                'total_ate_cerrada = datos_seccion_actual.Sum(Function(x) x.ATENCION_CERRADA)
                'total_ate_abierta = datos_seccion_actual.Sum(Function(x) x.ATENCION_ABIERTA)
                'total_ate_emergencia = datos_seccion_actual.Sum(Function(x) x.EMERGENCIA)

                'sl.SetCellValue(fila_actual, 3, total_ate_seccion)
                'sl.SetCellValue(fila_actual, 4, total_ate_cerrada)
                'sl.SetCellValue(fila_actual, 5, total_ate_abierta)
                'sl.SetCellValue(fila_actual, 6, total_ate_emergencia)

                ' Incrementar la fila actual para los datos
                fila_actual += 1
                totalDatos = datos_seccion_actual.Count
                indice = 1 ' Suponiendo que el índice del primer elemento es 1
                ' Iterar sobre los datos de la sección actual
                For Each dato In datos_seccion_actual

                    sl.SetCellValue(fila_actual, 1, dato.CF_COD_IRIS)
                    sl.SetCellValue(fila_actual, 2, dato.CF_DESC_HOSP)

                    ' TOTAL GENERAL
                    'sl.SetCellValue(fila_actual, 3, EnsureNonNegative(dato.CANTIDAD))
                    sl.SetCellValue(fila_actual, 3, EnsureNonNegative(calcularCantidadTotal(dato)))
                    ' ATENCIÓN ABIERTA
                    sl.SetCellValue(fila_actual, 4, EnsureNonNegative(dato.CAE))
                    sl.SetCellValue(fila_actual, 5, EnsureNonNegative(dato.USM_HDIURNO))
                    sl.SetCellValue(fila_actual, 6, EnsureNonNegative(dato.PERSONAL))
                    'sl.SetCellValue(fila_actual, 7, dato.TOTAL_ABIERTA)

                    ' ATENCIÓN CERRADA
                    sl.SetCellValue(fila_actual, 7, EnsureNonNegative(dato.MQ1))
                    sl.SetCellValue(fila_actual, 8, EnsureNonNegative(dato.MQ2))
                    sl.SetCellValue(fila_actual, 9, EnsureNonNegative(dato.MQ3))
                    sl.SetCellValue(fila_actual, 10, EnsureNonNegative(dato.UAPQ_PABELLON))
                    sl.SetCellValue(fila_actual, 11, EnsureNonNegative(dato.PEDIATRIA))
                    sl.SetCellValue(fila_actual, 12, EnsureNonNegative(dato.NEONATOLOGIA))
                    sl.SetCellValue(fila_actual, 13, EnsureNonNegative(dato.UPC))
                    sl.SetCellValue(fila_actual, 14, EnsureNonNegative(dato.UCI_A))
                    sl.SetCellValue(fila_actual, 15, EnsureNonNegative(dato.UTI))
                    sl.SetCellValue(fila_actual, 16, EnsureNonNegative(dato.MATERNIDAD))
                    sl.SetCellValue(fila_actual, 17, EnsureNonNegative(dato.CMA))
                    sl.SetCellValue(fila_actual, 18, EnsureNonNegative(dato.HOSP_DOCIMI))
                    sl.SetCellValue(fila_actual, 19, EnsureNonNegative(dato.UEA_HOSP))
                    'sl.SetCellValue(fila_actual, 21, dato.TOTAL_CERRADA)

                    ' UE
                    sl.SetCellValue(fila_actual, 20, EnsureNonNegative(dato.UEA))
                    sl.SetCellValue(fila_actual, 21, EnsureNonNegative(dato.UEI))
                    sl.SetCellValue(fila_actual, 22, EnsureNonNegative(dato.SAUD))
                    'sl.SetCellValue(fila_actual, 25, dato.TOTAL_UE)

                    ' UEGO
                    sl.SetCellValue(fila_actual, 23, EnsureNonNegative(dato.UEGO))

                    ' UNIDAD DE APOYO
                    sl.SetCellValue(fila_actual, 24, EnsureNonNegative(dato.ANATOMIA_PATO))
                    sl.SetCellValue(fila_actual, 25, EnsureNonNegative(dato.IMAGENOLOGIA))
                    'sl.SetCellValue(fila_actual, 29, dato.TOTAL_UNIDAD_APOYO)

                    ' ATENCIÓN EXTRAHOSPITALARIO
                    sl.SetCellValue(fila_actual, 26, EnsureNonNegative(dato.CESFAM_IVAN_MAN))
                    sl.SetCellValue(fila_actual, 27, EnsureNonNegative(dato.CESFAM_AV_AC))
                    sl.SetCellValue(fila_actual, 28, EnsureNonNegative(dato.CESFAM_QUILPUE)) ' FALTA
                    sl.SetCellValue(fila_actual, 29, EnsureNonNegative(dato.CESFAM_BELLOTO)) ' FALTA
                    sl.SetCellValue(fila_actual, 30, EnsureNonNegative(dato.CONS_POMPEYA))
                    sl.SetCellValue(fila_actual, 31, EnsureNonNegative(dato.CECOSF_RETIRO))
                    sl.SetCellValue(fila_actual, 32, EnsureNonNegative(dato.CONS_BELLOTO))
                    sl.SetCellValue(fila_actual, 33, EnsureNonNegative(dato.CESFAM_VILLA_AL))
                    sl.SetCellValue(fila_actual, 34, EnsureNonNegative(dato.CESFAM_AMERICAS))
                    sl.SetCellValue(fila_actual, 35, EnsureNonNegative(dato.CONS_EDUARDO_FREI))
                    sl.SetCellValue(fila_actual, 36, EnsureNonNegative(dato.CESFAM_JUAN_BT))
                    sl.SetCellValue(fila_actual, 37, EnsureNonNegative(dato.CONS_AGUILAS))
                    sl.SetCellValue(fila_actual, 38, EnsureNonNegative(dato.SAPU_FREI))
                    sl.SetCellValue(fila_actual, 39, EnsureNonNegative(dato.CESFAM_LIMACHE))
                    sl.SetCellValue(fila_actual, 40, EnsureNonNegative(dato.CESFAM_OLMUE))
                    sl.SetCellValue(fila_actual, 41, EnsureNonNegative(dato.APS_CABILDO))
                    sl.SetCellValue(fila_actual, 42, EnsureNonNegative(dato.APS_HIJUELAS))
                    sl.SetCellValue(fila_actual, 43, EnsureNonNegative(dato.APS_CALERA))
                    sl.SetCellValue(fila_actual, 44, EnsureNonNegative(dato.APS_LIGUA))
                    sl.SetCellValue(fila_actual, 45, EnsureNonNegative(dato.APS_NOGALES))
                    sl.SetCellValue(fila_actual, 46, EnsureNonNegative(dato.APS_PETORCA))
                    sl.SetCellValue(fila_actual, 47, EnsureNonNegative(dato.HOSP_LIMACHE))
                    sl.SetCellValue(fila_actual, 48, EnsureNonNegative(dato.HOSP_PETORCA)) ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
                    sl.SetCellValue(fila_actual, 49, EnsureNonNegative(dato.HOSP_MODULAR_LMCHE)) ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
                    sl.SetCellValue(fila_actual, 50, EnsureNonNegative(dato.HOSP_PENBLANCA))
                    sl.SetCellValue(fila_actual, 51, EnsureNonNegative(dato.HOSP_GUSTAVO_FRICKE))
                    sl.SetCellValue(fila_actual, 52, EnsureNonNegative(dato.HOSP_CALERA))
                    sl.SetCellValue(fila_actual, 53, EnsureNonNegative(dato.HOSP_PETORCA))
                    sl.SetCellValue(fila_actual, 54, EnsureNonNegative(dato.HOSP_QUILLOTA))
                    sl.SetCellValue(fila_actual, 55, EnsureNonNegative(dato.HOSP_CABILDO))
                    sl.SetCellValue(fila_actual, 56, EnsureNonNegative(dato.HOSP_LIGUA))
                    sl.SetCellValue(fila_actual, 57, EnsureNonNegative(dato.HOSP_QUINTERO))
                    'sl.SetCellValue(fila_actual, 62, 0) ' FALTA OTROS
                    'sl.SetCellValue(fila_actual, 63, dato.TOTAL_EXTRA) ' FALTA PROC OTROS

                    sl.SetCellStyle(fila_actual, 1, fila_actual, 57, estilo_borde_punto)
                    If indice = totalDatos Then
                        sl.SetCellValue((fila_actual + 1), 2, "TOTAL")
                        sl.SetCellStyle((fila_actual + 1), 2, (fila_actual + 1), 2, Crear_Estilo(sl, 9, True, "Verdana", Nothing, VerticalAlign.Middle, Nothing, False))
                        sl.SetCellStyle(fila_actual + 1, 1, fila_actual + 1, 57, estilo_borde_punto)
                        sl.SetCellStyle((fila_actual + 1), 1, (fila_actual + 1), 57, estilo_borde)
                        'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)
                        ' ATENCIÓN ABIERTA
                        'Debug.WriteLine($"Fila Actual: {fila_actual + 1}")
                        'Debug.WriteLine($"Cantidad de data: {datos_seccion_actual.Count()}")
                        sl.SetCellValue(fila_actual + 1, 3, $"=SUM(C{(fila_actual + 1) - datos_seccion_actual.Count()}:C{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 4, $"=SUM(D{(fila_actual + 1) - datos_seccion_actual.Count()}:D{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 5, $"=SUM(E{(fila_actual + 1) - datos_seccion_actual.Count()}:E{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 6, $"=SUM(F{(fila_actual + 1) - datos_seccion_actual.Count()}:F{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 7, datos_seccion_actual.Sum(Function(x) x.TOTAL_ABIERTA))

                        ' ATENCIÓN CERRADA
                        sl.SetCellValue((fila_actual + 1), 7, $"=SUM(G{(fila_actual + 1) - datos_seccion_actual.Count()}:G{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 8, $"=SUM(H{(fila_actual + 1) - datos_seccion_actual.Count()}:H{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 9, $"=SUM(I{(fila_actual + 1) - datos_seccion_actual.Count()}:I{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 10, $"=SUM(J{(fila_actual + 1) - datos_seccion_actual.Count()}:J{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 11, $"=SUM(K{(fila_actual + 1) - datos_seccion_actual.Count()}:K{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 12, $"=SUM(L{(fila_actual + 1) - datos_seccion_actual.Count()}:L{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 13, $"=SUM(M{(fila_actual + 1) - datos_seccion_actual.Count()}:M{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 14, $"=SUM(N{(fila_actual + 1) - datos_seccion_actual.Count()}:N{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 15, $"=SUM(O{(fila_actual + 1) - datos_seccion_actual.Count()}:O{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 16, $"=SUM(P{(fila_actual + 1) - datos_seccion_actual.Count()}:P{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 17, $"=SUM(Q{(fila_actual + 1) - datos_seccion_actual.Count()}:Q{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 18, $"=SUM(R{(fila_actual + 1) - datos_seccion_actual.Count()}:R{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 19, $"=SUM(S{(fila_actual + 1) - datos_seccion_actual.Count()}:S{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 21, datos_seccion_actual.Sum(Function(x) x.TOTAL_CERRADA))

                        ' UE
                        sl.SetCellValue((fila_actual + 1), 20, $"=SUM(T{(fila_actual + 1) - datos_seccion_actual.Count()}:T{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 21, $"=SUM(U{(fila_actual + 1) - datos_seccion_actual.Count()}:U{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 22, $"=SUM(V{(fila_actual + 1) - datos_seccion_actual.Count()}:V{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 25, datos_seccion_actual.Sum(Function(x) x.TOTAL_UE))

                        ' UEGO
                        sl.SetCellValue(fila_actual + 1, 23, $"=SUM(W{(fila_actual + 1) - datos_seccion_actual.Count()}:W{fila_actual})")

                        ' UNIDAD DE APOYO
                        sl.SetCellValue((fila_actual + 1), 24, $"=SUM(X{(fila_actual + 1) - datos_seccion_actual.Count()}:X{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 25, $"=SUM(Y{(fila_actual + 1) - datos_seccion_actual.Count()}:Y{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 29, datos_seccion_actual.Sum(Function(x) x.TOTAL_UNIDAD_APOYO))

                        ' ATENCIÓN EXTRAHOSPITALARIO
                        sl.SetCellValue((fila_actual + 1), 26, $"=SUM(Z{(fila_actual + 1) - datos_seccion_actual.Count()}:Z{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 27, $"=SUM(AA{(fila_actual + 1) - datos_seccion_actual.Count()}:AA{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 28, $"=SUM(AB{(fila_actual + 1) - datos_seccion_actual.Count()}:AB{fila_actual})") ' FALTA
                        sl.SetCellValue((fila_actual + 1), 29, $"=SUM(AC{(fila_actual + 1) - datos_seccion_actual.Count()}:AC{fila_actual})") ' FALTA
                        sl.SetCellValue((fila_actual + 1), 30, $"=SUM(AD{(fila_actual + 1) - datos_seccion_actual.Count()}:AD{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 31, $"=SUM(AE{(fila_actual + 1) - datos_seccion_actual.Count()}:AE{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 32, $"=SUM(AF{(fila_actual + 1) - datos_seccion_actual.Count()}:AF{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 33, $"=SUM(AG{(fila_actual + 1) - datos_seccion_actual.Count()}:AG{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 34, $"=SUM(AH{(fila_actual + 1) - datos_seccion_actual.Count()}:AH{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 35, $"=SUM(AI{(fila_actual + 1) - datos_seccion_actual.Count()}:AI{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 36, $"=SUM(AJ{(fila_actual + 1) - datos_seccion_actual.Count()}:AJ{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 37, $"=SUM(AK{(fila_actual + 1) - datos_seccion_actual.Count()}:AK{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 38, $"=SUM(AL{(fila_actual + 1) - datos_seccion_actual.Count()}:AL{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 39, $"=SUM(AM{(fila_actual + 1) - datos_seccion_actual.Count()}:AM{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 40, $"=SUM(AN{(fila_actual + 1) - datos_seccion_actual.Count()}:AN{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 41, $"=SUM(AO{(fila_actual + 1) - datos_seccion_actual.Count()}:AO{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 42, $"=SUM(AP{(fila_actual + 1) - datos_seccion_actual.Count()}:AP{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 43, $"=SUM(AQ{(fila_actual + 1) - datos_seccion_actual.Count()}:AQ{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 44, $"=SUM(AR{(fila_actual + 1) - datos_seccion_actual.Count()}:AR{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 45, $"=SUM(AS{(fila_actual + 1) - datos_seccion_actual.Count()}:AS{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 46, $"=SUM(AT{(fila_actual + 1) - datos_seccion_actual.Count()}:AT{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 47, $"=SUM(AU{(fila_actual + 1) - datos_seccion_actual.Count()}:AU{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 48, $"=SUM(AV{(fila_actual + 1) - datos_seccion_actual.Count()}:AV{fila_actual})") ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
                        sl.SetCellValue((fila_actual + 1), 49, $"=SUM(AW{(fila_actual + 1) - datos_seccion_actual.Count()}:AW{fila_actual})") ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
                        sl.SetCellValue((fila_actual + 1), 50, $"=SUM(AX{(fila_actual + 1) - datos_seccion_actual.Count()}:AX{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 51, $"=SUM(AY{(fila_actual + 1) - datos_seccion_actual.Count()}:AY{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 52, $"=SUM(AZ{(fila_actual + 1) - datos_seccion_actual.Count()}:AZ{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 53, $"=SUM(BA{(fila_actual + 1) - datos_seccion_actual.Count()}:BA{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 54, $"=SUM(BB{(fila_actual + 1) - datos_seccion_actual.Count()}:BB{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 55, $"=SUM(BC{(fila_actual + 1) - datos_seccion_actual.Count()}:BC{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 56, $"=SUM(BD{(fila_actual + 1) - datos_seccion_actual.Count()}:BD{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 57, $"=SUM(BE{(fila_actual + 1) - datos_seccion_actual.Count()}:BE{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 62, 0) ' FALTA OTROS
                        'sl.SetCellValue((fila_actual + 1), 63, datos_seccion_actual.Sum(Function(x) x.TOTAL_EXTRA)) ' FALTA PROC OTROS

                        fila_actual += 1
                    End If

                    fila_actual += 1
                    indice += 1
                Next

                ' ESTILO FINAL DE TABLA
                'sl.SetCellStyle(fila_actual, 1, totalDatos, 2, estilo_borde)

                ' COLUMNA 1
                'sl.SetCellStyle(fila_actual, 1, totalDatos, 1, estilo_celda_3)
                ' COLUMNA 2
                'sl.SetCellStyle(fila_actual, 2, totalDatos, 2, estilo_celda_4)

                ' COLUMNAS 3 A 61
                'sl.SetCellStyle(fila_actual, 3, totalDatos, 61, estilo_celda_2)
                'sl.SetCellStyle(fila_actual, 3, totalDatos, 61, estilo_borde_punto)
            Next

            ' COLUMNAS PROCEDENCIA
        End If

        ' Calcula y agrega el total general al final de la tabla
        Dim totalGeneral As Double = 0

        ' Creamos estas variables para la fila Total
        Dim filaTotal As Integer = List_Data.Count + 9
        Dim columnaTextoTotal As Integer = 3 ' Columna C
        Dim columnaTotal As Integer = 5 ' Columna E



        'Ancho de Columnas Primera tabla
        sl.SetColumnWidth(1, 18)
        sl.SetColumnWidth(2, 90)

        'Ancho de Columnas Segunda tabla

        sl.SetColumnWidth(3, 61, 15)

        Dim totalGrupo2 As Integer = List_Data.GroupBy(Function(item) item.ID_SECCION).Count()
        Dim totalGrupos As Integer = List_Data.Count()
        sl.SetCellStyle(11, 1, 11, 57, Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
        sl.SetCellStyle(13, 3, ((totalGrupos * 2) + 12), 57, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
        sl.SetCellStyle(13, 1, ((totalGrupos * 2) + 12), 1, Crear_Estilo(sl, 9, Nothing, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
        sl.SetCellStyle(13, 2, ((totalGrupos * 2) + 12), 2, Crear_Estilo(sl, 9, Nothing, "Verdana", Nothing, VerticalAlign.Middle, Nothing, True))
        'sl.SetCellStyle(13, 1, (totalGrupos + totalGrupo2 + 22), 62, estilo_borde_punto)
        'Debug.WriteLine("TOTAL GRUPOS {0}", totalGrupos)
        'Debug.WriteLine("TOTAL GRUPOS 2 {0}", totalGrupo2)
        ltabla += 10

#End Region

#Region "Sheet 2"
        'Seleccionamos Sheet1
        sl.SelectWorksheet("Sheet2")

        Dim name_sheet2 As String = sl.GetCurrentWorksheetName()

        Dim new_name_sheet2 As String = "FROTIS"
        sl.RenameWorksheet(name_sheet2, new_name_sheet2)

        sl.SetRowHeight(11, 25)

        Header_Excel(DESDE, HASTA, sl, estilo_1, estilo_2, estilo_3, estilo_4, estilo_borde, color_proc1, color_proc2, color_proc3, color_proc4, color_proc5, color_tp1, color_tp2, color_tp3, color_tp4, color_tp5, color_tp6, False)


        Dim N_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Dim List_Conteo As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CONTEO_RETICULO(DESDE, HASTA)

        Dim List_Filtered As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = List_Conteo.Where(Function(c) c.ID_PRUEBA = 316).ToList()

        '---------TABLA------------
        If List_Filtered.Count > 0 Then

            Dim fila_actual_2 As Integer = 12


            Dim indice_2 As Integer
            Dim totalDatos_2 As Integer

            indice_2 = 1
            totalDatos_2 = List_Filtered.Count

            For Each dato In List_Filtered
                sl.SetCellValue(fila_actual_2, 1, "--")
                sl.SetCellValue(fila_actual_2, 2, "--")

                ' TOTAL GENERAL
                sl.SetCellValue(fila_actual_2, 3, EnsureNonNegative(calcularCantidadTotal(dato)))
                ' ATENCIÓN ABIERTA
                sl.SetCellValue(fila_actual_2, 4, EnsureNonNegative(dato.CAE))
                sl.SetCellValue(fila_actual_2, 5, EnsureNonNegative(dato.USM_HDIURNO))
                sl.SetCellValue(fila_actual_2, 6, EnsureNonNegative(dato.PERSONAL))

                ' ATENCIÓN CERRADA
                sl.SetCellValue(fila_actual_2, 7, EnsureNonNegative(dato.MQ1))
                sl.SetCellValue(fila_actual_2, 8, EnsureNonNegative(dato.MQ2))
                sl.SetCellValue(fila_actual_2, 9, EnsureNonNegative(dato.MQ3))
                sl.SetCellValue(fila_actual_2, 10, EnsureNonNegative(dato.UAPQ_PABELLON))
                sl.SetCellValue(fila_actual_2, 11, EnsureNonNegative(dato.PEDIATRIA))
                sl.SetCellValue(fila_actual_2, 12, EnsureNonNegative(dato.NEONATOLOGIA))
                sl.SetCellValue(fila_actual_2, 13, EnsureNonNegative(dato.UPC))
                sl.SetCellValue(fila_actual_2, 14, EnsureNonNegative(dato.UCI_A))
                sl.SetCellValue(fila_actual_2, 15, EnsureNonNegative(dato.UTI))
                sl.SetCellValue(fila_actual_2, 16, EnsureNonNegative(dato.MATERNIDAD))
                sl.SetCellValue(fila_actual_2, 17, EnsureNonNegative(dato.CMA))
                sl.SetCellValue(fila_actual_2, 18, EnsureNonNegative(dato.HOSP_DOCIMI))
                sl.SetCellValue(fila_actual_2, 19, EnsureNonNegative(dato.UEA_HOSP))

                ' UE
                sl.SetCellValue(fila_actual_2, 20, EnsureNonNegative(dato.UEA))
                sl.SetCellValue(fila_actual_2, 21, EnsureNonNegative(dato.UEI))
                sl.SetCellValue(fila_actual_2, 22, EnsureNonNegative(dato.SAUD))

                ' UEGO
                sl.SetCellValue(fila_actual_2, 23, EnsureNonNegative(dato.UEGO))

                ' UNIDAD DE APOYO
                sl.SetCellValue(fila_actual_2, 24, EnsureNonNegative(dato.ANATOMIA_PATO))
                sl.SetCellValue(fila_actual_2, 25, EnsureNonNegative(dato.IMAGENOLOGIA))

                ' ATENCIÓN EXTRAHOSPITALARIO
                sl.SetCellValue(fila_actual_2, 26, EnsureNonNegative(dato.CESFAM_IVAN_MAN))
                sl.SetCellValue(fila_actual_2, 27, EnsureNonNegative(dato.CESFAM_AV_AC))
                sl.SetCellValue(fila_actual_2, 28, EnsureNonNegative(dato.CESFAM_QUILPUE)) ' FALTA
                sl.SetCellValue(fila_actual_2, 29, EnsureNonNegative(dato.CESFAM_BELLOTO)) ' FALTA
                sl.SetCellValue(fila_actual_2, 30, EnsureNonNegative(dato.CONS_POMPEYA))
                sl.SetCellValue(fila_actual_2, 31, EnsureNonNegative(dato.CECOSF_RETIRO))
                sl.SetCellValue(fila_actual_2, 32, EnsureNonNegative(dato.CONS_BELLOTO))
                sl.SetCellValue(fila_actual_2, 33, EnsureNonNegative(dato.CESFAM_VILLA_AL))
                sl.SetCellValue(fila_actual_2, 34, EnsureNonNegative(dato.CESFAM_AMERICAS))
                sl.SetCellValue(fila_actual_2, 35, EnsureNonNegative(dato.CONS_EDUARDO_FREI))
                sl.SetCellValue(fila_actual_2, 36, EnsureNonNegative(dato.CESFAM_JUAN_BT))
                sl.SetCellValue(fila_actual_2, 37, EnsureNonNegative(dato.CONS_AGUILAS))
                sl.SetCellValue(fila_actual_2, 38, EnsureNonNegative(dato.SAPU_FREI))
                sl.SetCellValue(fila_actual_2, 39, EnsureNonNegative(dato.CESFAM_LIMACHE))
                sl.SetCellValue(fila_actual_2, 40, EnsureNonNegative(dato.CESFAM_OLMUE))
                sl.SetCellValue(fila_actual_2, 41, EnsureNonNegative(dato.APS_CABILDO))
                sl.SetCellValue(fila_actual_2, 42, EnsureNonNegative(dato.APS_HIJUELAS))
                sl.SetCellValue(fila_actual_2, 43, EnsureNonNegative(dato.APS_CALERA))
                sl.SetCellValue(fila_actual_2, 44, EnsureNonNegative(dato.APS_LIGUA))
                sl.SetCellValue(fila_actual_2, 45, EnsureNonNegative(dato.APS_NOGALES))
                sl.SetCellValue(fila_actual_2, 46, EnsureNonNegative(dato.APS_PETORCA))
                sl.SetCellValue(fila_actual_2, 47, EnsureNonNegative(dato.HOSP_LIMACHE))
                sl.SetCellValue(fila_actual_2, 48, EnsureNonNegative(dato.HOSP_PETORCA)) ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
                sl.SetCellValue(fila_actual_2, 49, EnsureNonNegative(dato.HOSP_MODULAR_LMCHE)) ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
                sl.SetCellValue(fila_actual_2, 50, EnsureNonNegative(dato.HOSP_PENBLANCA))
                sl.SetCellValue(fila_actual_2, 51, EnsureNonNegative(dato.HOSP_GUSTAVO_FRICKE))
                sl.SetCellValue(fila_actual_2, 52, EnsureNonNegative(dato.HOSP_CALERA))
                sl.SetCellValue(fila_actual_2, 53, EnsureNonNegative(dato.HOSP_PETORCA))
                sl.SetCellValue(fila_actual_2, 54, EnsureNonNegative(dato.HOSP_QUILLOTA))
                sl.SetCellValue(fila_actual_2, 55, EnsureNonNegative(dato.HOSP_CABILDO))
                sl.SetCellValue(fila_actual_2, 56, EnsureNonNegative(dato.HOSP_LIGUA))
                sl.SetCellValue(fila_actual_2, 57, EnsureNonNegative(dato.HOSP_QUINTERO))

                sl.SetCellStyle(fila_actual_2, 1, fila_actual_2, 57, estilo_borde_punto)


                If indice_2 = totalDatos_2 Then
                    sl.SetCellValue((fila_actual_2 + 1), 2, "TOTAL")
                    sl.SetCellStyle((fila_actual_2 + 1), 2, (fila_actual_2 + 1), 2, Crear_Estilo(sl, 9, True, "Verdana", Nothing, VerticalAlign.Middle, Nothing, False))
                    sl.SetCellStyle(fila_actual_2 + 1, 1, fila_actual_2 + 1, 57, estilo_borde_punto)
                    sl.SetCellStyle((fila_actual_2 + 1), 1, (fila_actual_2 + 1), 57, estilo_borde)
                    'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)
                    ' ATENCIÓN ABIERTA
                    'Debug.WriteLine($"Fila Actual: {fila_actual + 1}")
                    'Debug.WriteLine($"Cantidad de data: {datos_seccion_actual.Count()}")
                    sl.SetCellValue(fila_actual_2 + 1, 3, $"=SUM(C{(fila_actual_2 + 1) - List_Filtered.Count()}:C{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 4, $"=SUM(D{(fila_actual_2 + 1) - List_Filtered.Count()}:D{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 5, $"=SUM(E{(fila_actual_2 + 1) - List_Filtered.Count()}:E{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 6, $"=SUM(F{(fila_actual_2 + 1) - List_Filtered.Count()}:F{fila_actual_2})")
                    'sl.SetCellValue((fila_actual + 1), 7, datos_seccion_actual.Sum(Function(x) x.TOTAL_ABIERTA))

                    ' ATENCIÓN CERRADA
                    sl.SetCellValue((fila_actual_2 + 1), 7, $"=SUM(G{(fila_actual_2 + 1) - List_Filtered.Count()}:G{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 8, $"=SUM(H{(fila_actual_2 + 1) - List_Filtered.Count()}:H{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 9, $"=SUM(I{(fila_actual_2 + 1) - List_Filtered.Count()}:I{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 10, $"=SUM(J{(fila_actual_2 + 1) - List_Filtered.Count()}:J{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 11, $"=SUM(K{(fila_actual_2 + 1) - List_Filtered.Count()}:K{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 12, $"=SUM(L{(fila_actual_2 + 1) - List_Filtered.Count()}:L{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 13, $"=SUM(M{(fila_actual_2 + 1) - List_Filtered.Count()}:M{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 14, $"=SUM(N{(fila_actual_2 + 1) - List_Filtered.Count()}:N{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 15, $"=SUM(O{(fila_actual_2 + 1) - List_Filtered.Count()}:O{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 16, $"=SUM(P{(fila_actual_2 + 1) - List_Filtered.Count()}:P{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 17, $"=SUM(Q{(fila_actual_2 + 1) - List_Filtered.Count()}:Q{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 18, $"=SUM(R{(fila_actual_2 + 1) - List_Filtered.Count()}:R{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 19, $"=SUM(S{(fila_actual_2 + 1) - List_Filtered.Count()}:S{fila_actual_2})")

                    ' UE
                    sl.SetCellValue((fila_actual_2 + 1), 20, $"=SUM(T{(fila_actual_2 + 1) - List_Filtered.Count()}:T{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 21, $"=SUM(U{(fila_actual_2 + 1) - List_Filtered.Count()}:U{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 22, $"=SUM(V{(fila_actual_2 + 1) - List_Filtered.Count()}:V{fila_actual_2})")

                    ' UEGO
                    sl.SetCellValue(fila_actual_2 + 1, 23, $"=SUM(W{(fila_actual_2 + 1) - List_Filtered.Count()}:W{fila_actual_2})")

                    ' UNIDAD DE APOYO
                    sl.SetCellValue((fila_actual_2 + 1), 24, $"=SUM(X{(fila_actual_2 + 1) - List_Filtered.Count()}:X{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 25, $"=SUM(Y{(fila_actual_2 + 1) - List_Filtered.Count()}:Y{fila_actual_2})")
                    'sl.SetCellValue((fila_actual + 1), 29, datos_seccion_actual.Sum(Function(x) x.TOTAL_UNIDAD_APOYO))

                    ' ATENCIÓN EXTRAHOSPITALARIO
                    sl.SetCellValue((fila_actual_2 + 1), 26, $"=SUM(Z{(fila_actual_2 + 1) - List_Filtered.Count()}:Z{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 27, $"=SUM(AA{(fila_actual_2 + 1) - List_Filtered.Count()}:AA{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 28, $"=SUM(AB{(fila_actual_2 + 1) - List_Filtered.Count()}:AB{fila_actual_2})") ' FALTA
                    sl.SetCellValue((fila_actual_2 + 1), 29, $"=SUM(AC{(fila_actual_2 + 1) - List_Filtered.Count()}:AC{fila_actual_2})") ' FALTA
                    sl.SetCellValue((fila_actual_2 + 1), 30, $"=SUM(AD{(fila_actual_2 + 1) - List_Filtered.Count()}:AD{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 31, $"=SUM(AE{(fila_actual_2 + 1) - List_Filtered.Count()}:AE{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 32, $"=SUM(AF{(fila_actual_2 + 1) - List_Filtered.Count()}:AF{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 33, $"=SUM(AG{(fila_actual_2 + 1) - List_Filtered.Count()}:AG{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 34, $"=SUM(AH{(fila_actual_2 + 1) - List_Filtered.Count()}:AH{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 35, $"=SUM(AI{(fila_actual_2 + 1) - List_Filtered.Count()}:AI{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 36, $"=SUM(AJ{(fila_actual_2 + 1) - List_Filtered.Count()}:AJ{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 37, $"=SUM(AK{(fila_actual_2 + 1) - List_Filtered.Count()}:AK{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 38, $"=SUM(AL{(fila_actual_2 + 1) - List_Filtered.Count()}:AL{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 39, $"=SUM(AM{(fila_actual_2 + 1) - List_Filtered.Count()}:AM{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 40, $"=SUM(AN{(fila_actual_2 + 1) - List_Filtered.Count()}:AN{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 41, $"=SUM(AO{(fila_actual_2 + 1) - List_Filtered.Count()}:AO{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 42, $"=SUM(AP{(fila_actual_2 + 1) - List_Filtered.Count()}:AP{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 43, $"=SUM(AQ{(fila_actual_2 + 1) - List_Filtered.Count()}:AQ{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 44, $"=SUM(AR{(fila_actual_2 + 1) - List_Filtered.Count()}:AR{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 45, $"=SUM(AS{(fila_actual_2 + 1) - List_Filtered.Count()}:AS{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 46, $"=SUM(AT{(fila_actual_2 + 1) - List_Filtered.Count()}:AT{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 47, $"=SUM(AU{(fila_actual_2 + 1) - List_Filtered.Count()}:AU{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 48, $"=SUM(AV{(fila_actual_2 + 1) - List_Filtered.Count()}:AV{fila_actual_2})") ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
                    sl.SetCellValue((fila_actual_2 + 1), 49, $"=SUM(AW{(fila_actual_2 + 1) - List_Filtered.Count()}:AW{fila_actual_2})") ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
                    sl.SetCellValue((fila_actual_2 + 1), 50, $"=SUM(AX{(fila_actual_2 + 1) - List_Filtered.Count()}:AX{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 51, $"=SUM(AY{(fila_actual_2 + 1) - List_Filtered.Count()}:AY{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 52, $"=SUM(AZ{(fila_actual_2 + 1) - List_Filtered.Count()}:AZ{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 53, $"=SUM(BA{(fila_actual_2 + 1) - List_Filtered.Count()}:BA{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 54, $"=SUM(BB{(fila_actual_2 + 1) - List_Filtered.Count()}:BB{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 55, $"=SUM(BC{(fila_actual_2 + 1) - List_Filtered.Count()}:BC{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 56, $"=SUM(BD{(fila_actual_2 + 1) - List_Filtered.Count()}:BD{fila_actual_2})")
                    sl.SetCellValue((fila_actual_2 + 1), 57, $"=SUM(BE{(fila_actual_2 + 1) - List_Filtered.Count()}:BE{fila_actual_2})")

                    fila_actual_2 += 1
                    indice_2 += 1
                End If
            Next
            Dim totalGrupos_2 As Integer = List_Data.Count()
            sl.SetCellStyle(11, 1, 11, 57, Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
            sl.SetCellStyle(13, 3, ((totalGrupos_2 * 2) + 12), 57, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
            sl.SetCellStyle(13, 1, ((totalGrupos_2 * 2) + 12), 1, Crear_Estilo(sl, 9, Nothing, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
            sl.SetCellStyle(13, 2, ((totalGrupos_2 * 2) + 12), 2, Crear_Estilo(sl, 9, Nothing, "Verdana", Nothing, VerticalAlign.Middle, Nothing, True))
        Else
            sl.SetCellStyle(12, 1, 12, 57, Crear_Estilo(sl, 10, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
            sl.MergeWorksheetCells("A12", "BE12")
            sl.SetCellValue(12, 1, "No encontraron datos")
        End If


#End Region

        sl.SelectWorksheet(new_name_sheet1)
        'insertar tabla
        tabla = sl.CreateTable("A10", CStr(End_Column_Table & ltabla - 4))
        tabla.SetTableStyle(SLTableStyleTypeValues.Medium9)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")

        Dim hora_actual As DateTime = DateTime.Now
        Dim Relative_Path As String = "Excel\" & "REM_" & mes_nombre.ToUpper & "_" & Format(Date.Parse(HASTA), "yyyy") & "_" & hora_actual.ToString("HH-mm") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        sl.Dispose()
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    ' Función para asegurarse de que el valor sea positivo
    Private Function EnsureNonNegative(value As Integer) As Integer
        If value < 0 Then
            Return 0
        End If
        Return value
    End Function

#Region "HELPER"


#End Region

    Private Function Write_Email_rem(ByVal Date_01 As String, ByVal Date_02 As String, ByVal link As String, ByVal url_base As String) As String
        Dim HTML_str As String = ""

        Debug.WriteLine("<img style='width: 40%; height: auto; margin: 0; padding: 0; float: left;' src='" & url_base & "/Imagenes/IrisLab_Logo_LARGO.png' />" & vbLf)
        HTML_str &= "<!DOCTYPE html>" & vbLf
        HTML_str &= "<html>" & vbLf
        HTML_str &= "<head>" & vbLf
        HTML_str &= "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>" & vbLf
        HTML_str &= "<title>REM - Hospital Quilpué</title>" & vbLf
        HTML_str &= "</head>" & vbLf
        HTML_str &= "<body>" & vbLf
        HTML_str &= "    <link href='https://fonts.googleapis.com/css?family=Saira' rel='stylesheet'>" & vbLf
        HTML_str &= "    <table style='width: 90%; margin: 0 auto; font-family: 'Saira', sans-serif;'>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <th align='center' style='padding: 0;'>" & vbLf
        HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: left;' src='" & url_base & "/Imagenes/IrisLab_Logo_LARGO.png' />" & vbLf
        'HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: right;' src='" & url_base & "/Imagenes/00_logo_holanda_full.png />" & vbLf
        HTML_str &= "            </th>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <td style='padding: 5px; padding-top: 15px;'>" & vbLf
        HTML_str &= "                <table style='width: 100%; border-collapse: collapse; border: 2px solid #2d43d5;'>" & vbLf
        HTML_str &= "                    <tr>" & vbLf
        HTML_str &= "                        <th colspan='2' style='color: #ffffff; background: #2d43d5; font-size: 22px; padding: 5px;'>Solicitud de Documento:</th>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Documento Solicitado:</td>" & vbLf
        HTML_str &= "                        <td>REM - Hospital Quilpué</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Desde:</td>" & vbLf
        HTML_str &= "                        <td>" & Date_01 & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Hasta:</td>" & vbLf
        HTML_str &= "                        <td>" & Date_02 & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Procedencia:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(0) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Prevision:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(1) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Programa:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(2) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>SubPrograma:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(3) & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr align='center'>" & vbLf
        HTML_str &= "                        <td colspan='2'>" & vbLf

        If (String.IsNullOrEmpty(link) = False) Then
            HTML_str &= "                            <a href='" & link & "' style='text-decoration: none; font-size: 20px;'>Descargar Archivo</a>" & vbLf
        Else
            HTML_str &= "                            <strong style='text-decoration: none; font-size: 20px;'>La búsqueda solicitada no devolvió resultados.</strong>" & vbLf
        End If

        HTML_str &= "                        </td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                </table>" & vbLf
        HTML_str &= "            </td>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "    </table>" & vbLf
        HTML_str &= "</body>" & vbLf
        HTML_str &= "</html>" & vbLf

        Return HTML_str
    End Function
End Class