Imports Entidades
Imports Negocio
Imports SpreadsheetLight
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Codigos_Fonasa
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Estado_Mant() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        If (Data_Estado_Mant.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Estado_Mant, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Agrupacion_Mant() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Agrupacion_Mant As New N_IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR
        Dim Data_Agrupacion_Mant As New List(Of E_IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR)
        Data_Agrupacion_Mant = NN_Agrupacion_Mant.IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR()
        If (Data_Agrupacion_Mant.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Agrupacion_Mant, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Dtt() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Cod_Fonasa As New N_IRIS_WEBF_BUSCA_CODIGO_FONASA
        Dim Data_Cod_Fonasa As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
        Data_Cod_Fonasa = NN_Cod_Fonasa.IRIS_WEBF_BUSCA_CODIGO_FONASA()
        If (Data_Cod_Fonasa.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Cod_Fonasa, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function LLENAR_TABLA_CODIGO_FONASA_ESTUDIO(ID_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION)

        'Declaraciones internas
        Dim NN_Cod_Fonasa As New N_IRIS_WEBF_BUSCA_CODIGO_FONASA

        Return NN_Cod_Fonasa.LLENAR_TABLA_CODIGO_FONASA_ESTUDIO(ID_FONASA)

    End Function

    <Services.WebMethod()>
    Public Shared Function LLENAR_TABLA_CODIGO_FONASA_ESTUDIO_SIN_ID() As List(Of E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION)

        'Declaraciones internas
        Dim NN_Cod_Fonasa As New N_IRIS_WEBF_BUSCA_CODIGO_FONASA

        Return NN_Cod_Fonasa.LLENAR_TABLA_CODIGO_FONASA_ESTUDIO_SIN_ID()

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS(ByVal ID_FONASA As Integer) As IEnumerable(Of Object)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_INDICACIONES = New N_IRIS_WEBF_BUSCA_INDICACIONES


        data_progra = NN_progra.IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS(ID_FONASA)


        Return data_progra
    End Function


    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL(ByVal ID_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_INDICACIONES
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA)
        Data_CF = NN_CF.IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL(ID_FONASA)

        Return Data_CF

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_REL_INDICACION_FONASA_QUITAR_RELACION(ByVal ARRAY_COMUNAS As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_INDICACIONES = New N_IRIS_WEBF_BUSCA_INDICACIONES


        For Each Item As Integer In ARRAY_COMUNAS

            numerin = NN.IRIS_WEBF_UPDATE_REL_INDICACION_FONASA_QUITAR_RELACION(Item)
        Next

        Return datas
    End Function


    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_AGREGA_INDICACIONES_FONASA(ByVal ID_FONASA As Integer, ByVal ARRAY_COMUNAS As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_INDICACIONES = New N_IRIS_WEBF_BUSCA_INDICACIONES


        For Each Item As Integer In ARRAY_COMUNAS

            numerin = NN.IRIS_WEBF_AGREGA_INDICACIONES_FONASA(ID_FONASA, Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Año(ByVal ANO As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Año As New N_IRIS_WEBF_BUSCA_ANOS_POR_ID
        Dim Data_Año As New List(Of E_IRIS_WEBF_BUSCA_ANOS_POR_ID)
        Data_Año = NN_Año.IRIS_WEBF_BUSCA_ANOS_POR_ID(ANO)
        If (Data_Año.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Año, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_CF(ByVal ID_CF As Integer, ByVal COD_CF As String, ByVal DESC_CF As String, ByVal CORTO_CF As String, ByVal DIAS_CF As Integer, ByVal ID_ESTADO As Integer, ByVal SOLA_CF As String, ByVal IMP_NOM_CF As String, ByVal IMP_SEL_CF As String, ByVal IMP_PAR_CF As String, ByVal HOST_CF As String, ByVal ID_MUESTRA As String) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_UCF As New N_IRIS_WEBF_UPDATE_CODIGO_FONASA
        Dim Data_UCF As Integer
        Data_UCF = NN_UCF.IRIS_WEBF_UPDATE_CODIGO_FONASA(ID_CF, COD_CF, DESC_CF, CORTO_CF, DIAS_CF, ID_ESTADO, SOLA_CF, IMP_NOM_CF, IMP_SEL_CF, IMP_PAR_CF, HOST_CF, ID_MUESTRA)

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Data_UCF, str_Builder)
        Return str_Builder.ToString
        Return Nothing
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_PF(ByVal ID_ANO As Integer, ByVal ID_USUARIO As Integer, ByVal ID_FONASA As Integer, ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_UPF As New N_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
        Dim Data_UPF As Integer
        Data_UPF = NN_UPF.IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION(ID_ANO, ID_USUARIO, ID_FONASA, ID_ESTADO)

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Data_UPF, str_Builder)
        Return str_Builder.ToString
        Return Nothing
    End Function
    <Services.WebMethod()>
    Public Shared Function Create_CF(ByVal COD_CF As String, ByVal DESC_CF As String, ByVal CORTO_CF As String, ByVal DIAS_CF As Integer, ByVal ID_ESTADO As Integer, ByVal SOLA_CF As String, ByVal IMP_NOM_CF As String, ByVal IMP_SEL_CF As String, ByVal IMP_PAR_CF As String, ByVal HOST_CF As String, ByVal ID_MUESTRA As String) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_UCF As New N_IRIS_WEBF_GRABA_CODIGO_FONASA
        Dim Data_UCF As Integer
        Data_UCF = NN_UCF.IRIS_WEBF_GRABA_CODIGO_FONASA(COD_CF, DESC_CF, CORTO_CF, DIAS_CF, ID_ESTADO, SOLA_CF, IMP_NOM_CF, IMP_SEL_CF, IMP_PAR_CF, HOST_CF, ID_MUESTRA)
        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(Data_UCF, str_Builder)
        Return str_Builder.ToString
        Return Nothing
    End Function



    <Services.WebMethod()>
    Public Shared Function vincular_estudio_fonasa(ByVal ID_EST As Integer, ByVal ID_FONASA As Integer) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_UPDATE_VINCULO
        Dim Data As Integer
        Data = NN.IRIS_WEBF_UPDATE_VINCULO(ID_EST, ID_FONASA)
        If (Data > 0) Then
            Return Data
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function desvincular_estudio_fonasa(ByVal ID_EST As Integer, ByVal ID_FONASA As Integer) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_UPDATE_VINCULO
        Dim Data As Integer
        Data = NN.IRIS_WEBF_UPDATE_DESVINCULACION(ID_EST, ID_FONASA)
        If (Data > 0) Then
            Return Data
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(DOMAIN_URL As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas

        Dim NN_Excel As New N_Excel
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA
        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_CODIGO_FONASA()

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

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetCellValue("B8", "Código")
        sl.SetCellValue("C8", "Descripción")
        sl.SetCellValue("D8", "Activo")
        sl.SetCellValue("E8", "Imp. 1 Pag.")
        sl.SetCellValue("F8", "Imp. Nom Est.")
        sl.SetCellValue("G8", "Sel Prueba")
        sl.SetCellValue("H8", "Imp-Parcial")

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_CODIGO_FONASA()

        If (data_det_ate.Count > 0) Then

            For i = 0 To data_det_ate.Count - 1
                Dim colActual = 1
                sl.SetCellValue(i + 9, colActual, i + 1) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).CF_COD) : colActual += 1
                sl.SetCellValue(i + 9, colActual, Replace(data_det_ate(i).CF_DESC, ChrW(31), "")) : colActual += 1
                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).ID_ESTADO, "ACTIVO", "DESACTIVADO")) : colActual += 1
                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).CF_IMP_SOLA, "ACTIVO", "DESACTIVADO")) : colActual += 1
                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).CF_IMP_NOM_PER, "ACTIVO", "DESACTIVADO")) : colActual += 1
                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).CF_SEL_PRUE, "ACTIVO", "DESACTIVADO")) : colActual += 1
                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).CF_IMP_PARCIAL, "ACTIVO", "DESACTIVADO"))
                ltabla += 1
            Next

        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Envío de Exámenes")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Envío de Exámenes")

        sl.AutoFitColumn(1, 8, 45)
        For y = 1 To 8
            sl.SetColumnWidth(y, sl.GetColumnWidth(y) + 3)
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
        tabla = sl.CreateTable("A8", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    '<Services.WebMethod()>
    'Public Shared Function Excel(ByVal DOMAIN_URL As String) As String
    '    Dim NN_Excel As New N_Excel
    '    Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
    '    Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA
    '    data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA()
    '    Dim titulo As String = "Información de Código Fonasa"
    '    Dim Mx(6, 0) As Object
    '    For y = 0 To (data_paciente.Count - 1)
    '        If (y > 0) Then
    '            ReDim Preserve Mx(6, y)
    '        End If
    '        Mx(0, y) = data_paciente(y).CF_COD
    '        Mx(1, y) = data_paciente(y).CF_DESC
    '        Mx(2, y) = data_paciente(y).ID_ESTADO
    '        Mx(3, y) = data_paciente(y).CF_IMP_SOLA
    '        Mx(4, y) = data_paciente(y).CF_IMP_NOM_PER
    '        Mx(5, y) = data_paciente(y).CF_SEL_PRUE
    '        Mx(6, y) = data_paciente(y).CF_IMP_PARCIAL

    '    Next y
    '    Return NN_Excel.Excel_Beta(DOMAIN_URL, Mx, titulo)
    'End Function


    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 100, 101, 102
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class