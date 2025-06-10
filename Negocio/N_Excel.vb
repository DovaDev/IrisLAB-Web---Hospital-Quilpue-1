Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports Entidades
Imports Negocio
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Public Class N_Excel
    Function Excel(ByVal DOMAIN_URL As String, ByVal Mx(,) As Object, ByVal titulin As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        Dim Mx_Data(3, 0) As Object
        'Vaciar Matriz
        ReDim Mx_Data(3, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Mx.GetUpperBound(1))
            If (y > 0) Then
                ReDim Preserve Mx_Data(3, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Mx(1, y)
            Mx_Data(2, y) = Mx(2, y)
            If (Mx(3, y) = 1) Then
                Mx_Data(3, y) = "ACTIVO"
            Else
                Mx_Data(3, y) = "DESACTIVADO"
            End If
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", titulin)
        'titulo de la tabla
        sl.SetCellValue("B2", titulin)
        'nombre columnas
        sl.SetCellValue("A7", "Nº")
        sl.SetCellValue("B7", "Código")
        sl.SetCellValue("C7", "Descripción")
        sl.SetCellValue("D7", "Estado")
        For y = 1 To 4
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
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("D" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class
