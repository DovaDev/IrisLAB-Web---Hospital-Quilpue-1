Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Drawing
Imports System.Collections.Generic

Public Class XlsDcto
    Inherits SLDocument

    'Posición Actual
    Private xx As Integer
    Private yy As Integer
    Private width As Integer

    Private Dot As List(Of Rectangle)
    Private Table As SLTable
    Private e_CSS As CSS_class
    Public Property CSSref() As CSS_class
        Get
            Return e_CSS
        End Get
        Set(ByVal value As CSS_class)
            e_CSS = value
        End Set
    End Property

    Private posX As Integer
    ''' <summary>
    ''' Eje x
    ''' </summary>
    ''' <param name="now">True si se quiere saber la posición actual del cursor, False si se quiere saber la posición establecida por el usuario</param>
    ''' <returns></returns>
    Public Property x(Optional ByVal now As Boolean = True) As Integer
        Get
            If (now = True) Then
                Return xx
            Else
                Return posX
            End If
        End Get
        Set(ByVal value As Integer)
            posX = value
            xx = value
        End Set
    End Property

    Private posY As Integer
    ''' <summary>
    ''' Eje y
    ''' </summary>
    ''' <param name="now">True si se quiere saber la posición actual del cursor, False si se quiere saber la posición establecida por el usuario</param>
    ''' <returns></returns>
    Public Property y(Optional ByVal now As Boolean = True) As Integer
        Get
            If (now = True) Then
                Return yy
            Else
                Return posY
            End If
        End Get
        Set(ByVal value As Integer)
            posY = value
            yy = value
        End Set
    End Property

    Private e_LocalPath As String
    Private e_Path As String
    ''' <summary>
    ''' Ruta de Guardado del archivo
    ''' </summary>
    ''' <returns></returns>
    Public Property Path() As String
        Get
            Return e_Path
        End Get
        Set(ByVal value As String)
            e_Path = value
        End Set
    End Property

    Sub New()
        Dot = New List(Of Rectangle)
        e_CSS = New CSS_class

        e_LocalPath = System.Web.HttpContext.Current.Server.MapPath("~/")
        arr_formula = New List(Of formula)
    End Sub

    ''' <summary>
    ''' Salto de línea, setea la posición x en 0
    ''' </summary>
    Public Sub NxtRow()
        width = xx - 1
        xx = posX
        yy += 1
    End Sub

    ''' <summary>
    ''' Permite ingresar un objeto, ya sea del tipo cadena, númerico, booleano, etc en el campo posicionado actualmente.
    ''' </summary>
    ''' <param name="value">El valor a Ingresar, se aceptan Cadenas, Números, Fechas y Booleanos</param>
    ''' <param name="CSS_Style">[opcional] El objeto CSS asociado al Estilo</param>
    Public Sub Write(ByVal value As Object, Optional ByVal CSS_Style As SLStyle = Nothing)
        If (IsNothing(value) = True) Then
            value = ""
        End If

        'Agregar valor y CSS a la celda
        Me.SetCellValue(yy, xx, value)
        If (IsNothing(CSS_Style) = False) Then
            Me.SetCellStyle(yy, xx, CSS_Style)
        End If

        'Comprobar la siguiente celda disponible
        xx += 1
        For i = 0 To (Dot.Count - 1)
            If (yy <> Dot(i).Y) Then
                Continue For
            End If

            If ((xx > Dot(i).X) And (xx <= Dot(i).Right)) Then
                xx = Dot(i).Right + 1
                Exit For
            End If

            If ((yy > Dot(i).Y) And (yy <= Dot(i).Bottom)) Then
                xx = Dot(i).Right + 1
                Exit For
            End If
        Next i
    End Sub

    ''' <summary>
    ''' Fusiona celdas de acuerdo al ancho y alto indicado
    ''' </summary>
    ''' <param name="width">Ancho de la Fusión</param>
    ''' <param name="height">[opcional] Alto de la Fusión</param>
    Public Sub Merge(ByVal width As Integer, Optional ByVal height As Integer = 0)
        If (width < 1) Then
            Exit Sub
        End If

        Dim objPoint As New Point
        Dim objSize As New Size
        Dim objRect As Rectangle

        objPoint.X = xx
        objPoint.Y = yy
        objSize.Width = width - 1
        objSize.Height = height

        objRect = New Rectangle(objPoint, objSize)
        Me.MergeWorksheetCells(yy, xx, objRect.Bottom, objRect.Right)
        Me.Dot.Add(objRect)
    End Sub

    Private Class formula
        Private E_column As Integer
        Public Property column() As Integer
            Get
                Return E_column
            End Get
            Set(ByVal value As Integer)
                E_column = value
            End Set
        End Property

        Private E_formula As String
        Public Property formula() As String
            Get
                Return E_formula
            End Get
            Set(ByVal value As String)
                E_formula = value
            End Set
        End Property
    End Class
    Dim arr_formula As List(Of formula)
    ''' <summary>
    ''' Establece una columna de la tabla como 
    ''' </summary>
    ''' <param name="num_col"></param>
    ''' <param name="math_operation"></param>
    Public Sub Set_Footer_Formula(ByVal num_col As Integer, ByVal math_operation As String)
        Dim item As New formula

        item.column = num_col
        item.formula = math_operation

        arr_formula.Add(item)
    End Sub

    ''' <summary>
    ''' Crea una Tabla Utilizando la Posición Inicial Seteada (Me.x y Me.y) hasta la posición Actual.
    ''' </summary>
    ''' <param name="Table_CSS">[opcional]Estilo de la Tabla</param>
    Public Sub Set_Table(Optional ByVal Table_CSS As SLTableStyleTypeValues = SLTableStyleTypeValues.Dark11)
        Dim bol_have As Boolean = False
        If (Me.GetCellValueAsString(yy, xx) <> "") Then
            bol_have = True
        End If

        If (bol_have = False) Then
            Table = Me.CreateTable(posY, posX, yy - 1, width)
        Else
            Table = Me.CreateTable(posY, posX, yy, width)
        End If

        Table.SetTableStyle(Table_CSS)
        Me.InsertTable(Table)
    End Sub

    ''' <summary>
    ''' Guarda el archivo en la ubicación especificada en la propiedad "Path"
    ''' </summary>
    ''' <param name="relative">True para usar Path como ruta relativa a la ubicación del proyecto. 
    ''' False para usar "Path" como ruta absoluta</param>
    Public Sub Guardar_Como(ByVal relative As Boolean)
        If (e_Path = Nothing) Then
            Exit Sub
        End If

        If (relative = True) Then
            Me.SaveAs(e_LocalPath & e_Path)
        Else
            Me.SaveAs(e_Path)
        End If
    End Sub
    Public Class CSS_class
        Private e_h1 As SLStyle
        ''' <summary>
        ''' Estilo para Título de nivel 1
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property h1(Optional ByVal align As String = "") As SLStyle
            Get
                With e_h1
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                        Case Else
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                    End Select
                End With

                Return e_h1
            End Get
            Set(ByVal value As SLStyle)
                e_h1 = value
            End Set
        End Property

        Private e_h2 As SLStyle
        ''' <summary>
        ''' Estilo para Título de nivel 2
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property h2(Optional ByVal align As String = "") As SLStyle
            Get
                With e_h2
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                        Case Else
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                    End Select
                End With

                Return e_h2
            End Get
            Set(ByVal value As SLStyle)
                e_h2 = value
            End Set
        End Property

        Private e_th As SLStyle
        ''' <summary>
        ''' Estilo para Encabezados de Columnas
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property th(Optional ByVal align As String = "") As SLStyle
            Get
                With e_th
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_th
            End Get
            Set(ByVal value As SLStyle)
                e_th = value
            End Set
        End Property

        Private e_td_string As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos del tipo String
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property td_string(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_string
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_string
            End Get
            Set(ByVal value As SLStyle)
                e_td_string = value
            End Set
        End Property

        Private e_td_date As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos del tipo Date
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property td_date(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_date
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_date
            End Get
            Set(ByVal value As SLStyle)
                e_td_date = value
            End Set
        End Property

        Private e_td_time As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos del tipo Date
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property td_time(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_time
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_date
            End Get
            Set(ByVal value As SLStyle)
                e_td_date = value
            End Set
        End Property

        Private e_td_datetime As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos del tipo DateTime
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property td_datetime(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_datetime
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_datetime
            End Get
            Set(ByVal value As SLStyle)
                e_td_datetime = value
            End Set
        End Property

        Private e_td_integer As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos del tipo Integer o Long
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "right"</param>
        ''' <returns></returns>
        Public Property td_integer(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_integer
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_integer
            End Get
            Set(ByVal value As SLStyle)
                e_td_integer = value
            End Set
        End Property

        Private e_td_float As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos del tipo Float o Double
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property td_float(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_float
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_float
            End Get
            Set(ByVal value As SLStyle)
                e_td_float = value
            End Set
        End Property

        Private e_td_currency As SLStyle
        ''' <summary>
        ''' Estilo para Datos dentro de la tabla. Usar para datos nuéricos para representarlos en formato Moneda
        ''' </summary>
        ''' <param name="align">[opcional] Alineación del texto : "left", "center", "right", "justify",
        ''' por defecto "center"</param>
        ''' <returns></returns>
        Public Property td_currency(Optional ByVal align As String = "") As SLStyle
            Get
                With e_td_currency
                    Select Case (align.ToLower)
                        Case "left"
                            .SetHorizontalAlignment(HorizontalAlign.Left)
                        Case "center"
                            .SetHorizontalAlignment(HorizontalAlign.Center)
                        Case "right"
                            .SetHorizontalAlignment(HorizontalAlign.Right)
                        Case "justify"
                            .SetHorizontalAlignment(HorizontalAlign.Justify)
                    End Select
                End With

                Return e_td_currency
            End Get
            Set(ByVal value As SLStyle)
                e_td_currency = value
            End Set
        End Property

        Sub New()
            e_h1 = New SLStyle
            With e_h1
                .Font.Bold = True
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 22)
            End With

            e_h2 = New SLStyle
            With e_h2
                .Font.Bold = True
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 16)
            End With

            e_th = New SLStyle
            With e_th
                .Font.Bold = True
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFontBold(True)
                .SetFont("Calibri", 14)
            End With

            e_td_string = New SLStyle
            With e_td_string
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
            End With

            e_td_date = New SLStyle
            With e_td_date
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
                .FormatCode = "dd/mm/yyyy"
            End With

            e_td_time = New SLStyle
            With e_td_date
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
                .FormatCode = "h:mm:ss"
            End With

            e_td_datetime = New SLStyle
            With e_td_datetime
                .SetHorizontalAlignment(HorizontalAlignmentValues.Center)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
                .FormatCode = "dd/mm/yyyy h:mm:ss"
            End With

            e_td_integer = New SLStyle
            With e_td_integer
                .SetHorizontalAlignment(HorizontalAlignmentValues.Right)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
                .FormatCode = "###,###,##0"
            End With

            e_td_float = New SLStyle
            With e_td_float
                .SetHorizontalAlignment(HorizontalAlignmentValues.Right)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
                .FormatCode = "###,###,##0.####"
            End With

            e_td_currency = New SLStyle
            With e_td_currency
                .SetHorizontalAlignment(HorizontalAlignmentValues.Right)
                .SetVerticalAlignment(VerticalAlignmentValues.Center)
                .SetFont("Calibri", 12)
                .FormatCode = "$ ###,###,##0"
            End With
        End Sub
    End Class
End Class