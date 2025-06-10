Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_DET_ATE_USU
    'Declaraciones Generales
    Dim DD_Data As D_DET_ATE_USU
    Sub New()
        DD_Data = New D_DET_ATE_USU
    End Sub
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, USU)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, USU)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, USU)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION(DESDE, HASTA, ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, USU)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_PRE As Long, ByVal ID_PROCE As Long, ByVal ID_TP_PAGO As Long, ByVal USUARIO As Long,
                                            ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal EDAD_DESDE As Long, ByVal EDAD_HASTA As Long, ByVal radio As Long) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_TM_Prevision As New N_DET_ATE_USU
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        Dim Mx_Data(9, 0) As Object
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        'Realizar Consulta
        If (EDAD_DESDE <> 0) And (EDAD_HASTA <> 0) Then
            If (radio = 0) Then
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
            Else
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
            End If
        Else
            If (radio = 0) Then
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
            Else
                Data_TM_Provision = NN_TM_Prevision.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION(Date_01, Date_02, ID_PROCE, ID_TP_PAGO, ID_PRE, EDAD_DESDE, EDAD_HASTA, USUARIO)
            End If
        End If

        'Vaciar Matriz
        ReDim Mx_Data(9, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_TM_Provision.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(9, y)
            End If
            Mx_Data(0, y) = Data_TM_Provision(y).ATE_NUM
            Mx_Data(1, y) = Format(CDate(Data_TM_Provision(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(2, y) = Data_TM_Provision(y).PAC_NOMBRE & " " & Data_TM_Provision(y).PAC_APELLIDO
            Mx_Data(3, y) = Data_TM_Provision(y).CF_DESC
            Mx_Data(4, y) = Data_TM_Provision(y).CF_COD
            Mx_Data(5, y) = Data_TM_Provision(y).PROC_DESC
            Mx_Data(6, y) = Data_TM_Provision(y).TP_PAGO_DESC
            Mx_Data(7, y) = Data_TM_Provision(y).PREVE_DESC
            Mx_Data(8, y) = Data_TM_Provision(y).DOC_NOMBRE & " " & Data_TM_Provision(y).DOC_APELLIDO
            Mx_Data(9, y) = Data_TM_Provision(y).USU_NIC
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
        Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Atencion por Usuario")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Atencion por Usuario")
        If (USUARIO = 0) Then
            sl.SetCellValue("B3", "Usuario: Todos")
        Else
            sl.SetCellValue("B3", "Usuario: " & Data_TM_Provision(0).PREVE_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & Date_01 & " Hasta: " & Date_02)
        'nombre columnas
        sl.SetCellValue("A7", "N° Atencion")
        sl.SetCellValue("B7", "Fecha")
        sl.SetCellValue("C7", "Nombre")
        sl.SetCellValue("D7", "Exámen")
        sl.SetCellValue("E7", "Cod. Fonasa")
        sl.SetCellValue("F7", "Procedencia")
        sl.SetCellValue("G7", "F. Pago")
        sl.SetCellValue("H7", "Prevesión")
        sl.SetCellValue("I7", "Medico")
        sl.SetCellValue("J7", "Usuario")
        For y = 1 To 10
            sl.SetColumnWidth(y, 20.0)
        Next y
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

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)


        tabla = sl.CreateTable("A7", CStr("J" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (USUARIO = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_TM_Provision(0).PREVE_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function

End Class