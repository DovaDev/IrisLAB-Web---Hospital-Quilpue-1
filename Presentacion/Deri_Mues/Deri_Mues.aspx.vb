
Imports System.Web.Script.Serialization
Imports Entidades
Imports Negocio

Public Class Deri_Mues
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DERIVADOS() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_derivados As List(Of E_IRIS_WEBF_BUSCA_DERIVADOS)
        Dim NN As N_IRIS_WEBF_BUSCA_DERIVADOS = New N_IRIS_WEBF_BUSCA_DERIVADOS

        data_derivados = NN.IRIS_WEBF_BUSCA_DERIVADOS()

        If (data_derivados.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_derivados, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_2(ByVal NATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_id_ate_x_nate As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim NN_id_ate_x_nate As N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION = New N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION

        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        Dim NN_paciente As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4 = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4

        Dim data_lis_exa As List(Of E_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA)
        Dim NN_lis_exa As N_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA = New N_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA

        data_id_ate_x_nate = NN_id_ate_x_nate.IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(CInt(NATE))

        If data_id_ate_x_nate.Count > 0 Then
            data_paciente = NN_paciente.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4(data_id_ate_x_nate(0).ID_ATENCION)
            data_lis_exa = NN_lis_exa.IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA(data_id_ate_x_nate(0).ID_ATENCION)

            If (data_lis_exa.Count > 0) Then

                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data_lis_exa, str_Builder)
                datas = str_Builder.ToString
            Else
                datas = "null"
            End If
        Else
            Return "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Guardar(ByVal ID_ATE_y_CF() As Object, ByVal ID_DERIVADOR As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim elemento()

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        Dim corre_deriv As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV)
        Dim NN_corre_deriv As N_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV = New N_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV

        Dim graba As List(Of E_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO)
        Dim NN_graba As N_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO = New N_IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO

        Dim det_graba As Integer = 0
        Dim NN_det_graba As N_IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO = New N_IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO

        Dim update As Integer = 0
        Dim NN_update As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_DERIVA2 = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_DERIVA2

        corre_deriv = NN_corre_deriv.IRIS_WEBF_BUSCA_CORRELATIVO_DERIV()
        Dim correlativin As Integer = corre_deriv(0).IDENTIFICADOR
        graba = NN_graba.IRIS_WEBF_GRABA_DERIVA_PROCESO_NUEVO(corre_deriv(0).IDENTIFICADOR, ID_USER, ID_DERIVADOR)

        If graba.Count = 0 Then
            Return "null"
        End If

        If ID_ATE_y_CF.Length > 0 Then
            For i = 0 To ID_ATE_y_CF.Length - 1
                elemento = ID_ATE_y_CF(i).split("~")
                'elemento 0 = ID_ATE
                'elemento 1 = ID_CF
                det_graba = NN_det_graba.IRIS_WEBF_GRABA_DET_DERIVA_PROCESO_NUEVO(graba(0).IDENTIFICADOR, elemento(1), elemento(0), ID_USER)
                If det_graba = 0 Then
                    Return "null"
                End If
                update = NN_update.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_DERIVA2(elemento(0), elemento(1), ID_USER)
                If update = 0 Then
                    Return "null"
                End If
            Next i
            Return correlativin
        Else
            Return "null"
        End If


        'If data_id_ate_x_nate.Count > 0 Then

        '    If (data_id_ate_x_nate.Count > 0) Then
        '        'Serializar con JSON
        '        Serializer.MaxJsonLength = 999999999
        '        Serializer.Serialize(data_id_ate_x_nate, str_Builder)
        '        datas = str_Builder.ToString
        '    Else
        '        datas = "null"
        '    End If
        'Else
        '    Return "null"
        'End If

    End Function

    <Services.WebMethod()>
    Public Shared Function Agregar(ByVal selected() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_grilla_busca As List(Of E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_)
        Dim data_grilla_yeah As New List(Of E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_)
        Dim item_grila = New E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_
        Dim NN_grilla As N_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_ = New N_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_
        Dim elemento()


        For i = 0 To selected.GetUpperBound(0)
            elemento = selected(i).split("~")
            data_grilla_busca = NN_grilla.IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_(elemento(0), elemento(1))

            If data_grilla_busca.Count > 0 Then
                item_grila = New E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_

                item_grila.ID_ATENCION = data_grilla_busca(0).ID_ATENCION
                item_grila.ID_DET_ATE = data_grilla_busca(0).ID_DET_ATE
                item_grila.CF_DESC = data_grilla_busca(0).CF_DESC
                item_grila.PAC_NOMBRE = data_grilla_busca(0).PAC_NOMBRE
                item_grila.PAC_APELLIDO = data_grilla_busca(0).PAC_APELLIDO
                item_grila.SEXO_DESC = data_grilla_busca(0).SEXO_DESC
                item_grila.PAC_FNAC = data_grilla_busca(0).PAC_FNAC
                item_grila.PAC_RUT = data_grilla_busca(0).PAC_RUT
                item_grila.ID_CODIGO_FONASA = data_grilla_busca(0).ID_CODIGO_FONASA
                item_grila.ORD_DESC = data_grilla_busca(0).ORD_DESC
                item_grila.DOC_NOMBRE = data_grilla_busca(0).DOC_NOMBRE
                item_grila.DOC_APELLIDO = data_grilla_busca(0).DOC_APELLIDO
                item_grila.ATE_FECHA = data_grilla_busca(0).ATE_FECHA
                item_grila.ATE_NUM = data_grilla_busca(0).ATE_NUM

                data_grilla_yeah.Add(item_grila)
            End If

        Next i


        If data_grilla_yeah.Count > 0 Then

            If (data_grilla_yeah.Count > 0) Then
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data_grilla_yeah, str_Builder)
                datas = str_Builder.ToString
            Else
                datas = "null"
            End If
        Else
            Return "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Seccion(ByVal ID_SECCION As Long, ByVal DATE_str01 As String,
                                                                      ByVal DATE_str02 As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date
        Dim NN_Exam As New N_REP_LAB_SEC
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS)
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        'DATE_str01 = DATE_str01.Replace("-", "/")
        'DATE_str02 = DATE_str02.Replace("-", "/")
        'Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        'Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        If (ID_SECCION = 0) Then
            Data_Prev = NN_Exam.IRIS_WEBF_CMVM_BUSCA_EST_SECCIONES_TODOS_DERIVA(DATE_str01, DATE_str02)
        Else
            Data_Prev = NN_Exam.IRIS_WEBF_CMVM_BUSCA_EST_SECCIONES_POR_ID_DERIVA(DATE_str01, DATE_str02, ID_SECCION)
        End If


        If (Data_Prev.Count > 0) Then
            For i = 0 To Data_Prev.Count - 1
                Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(Data_Prev(i).ATE_NUM)

                If (Data_Estado_Mant_2.Count > 0) Then
                    Data_Prev(i).DOCS_CANT = Data_Estado_Mant_2.Count
                Else
                    Data_Prev(i).DOCS_CANT = 0
                End If
            Next i
        End If


        If (Data_Prev.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Prev, str_Builder)
            datos = str_Builder.ToString
        Else
            datos = "null"
        End If
        Return datos

    End Function

    <Services.WebMethod()>
    Public Shared Function PDF(ByVal DOMAIN_URL As String, datitos As List(Of ids), ByVal Derivador As String) As String

        'Declaraciones internas
        Dim NN_PDF As New N_PDF
        Dim data_grilla_yeah As New List(Of E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_)
        Dim item_grila = New E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_
        Dim NN_grilla As N_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_ = New N_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_


        If datitos.Count > 0 Then
            For i = 0 To datitos.Count - 1
                'For ii = 0 To datitos.GetUpperBound(0)

                item_grila = New E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_

                item_grila.ID_ATENCION = datitos(i).ID_ATENCION
                item_grila.ID_DET_ATE = datitos(i).ID_DET_ATE
                item_grila.CF_DESC = datitos(i).CF_DESC
                item_grila.PAC_NOMBRE = datitos(i).PAC_NOMBRE
                item_grila.PAC_APELLIDO = datitos(i).PAC_APELLIDO
                item_grila.SEXO_DESC = datitos(i).SEXO_DESC
                item_grila.PAC_FNAC = datitos(i).PAC_FNAC
                item_grila.PAC_RUT = datitos(i).PAC_RUT
                item_grila.ID_CODIGO_FONASA = datitos(i).ID_CODIGO_FONASA
                item_grila.ORD_DESC = datitos(i).ORD_DESC
                item_grila.DOC_NOMBRE = datitos(i).DOC_NOMBRE
                item_grila.DOC_APELLIDO = datitos(i).DOC_APELLIDO
                item_grila.ATE_FECHA = datitos(i).ATE_FECHA
                item_grila.ATE_NUM = datitos(i).ATE_NUM

                data_grilla_yeah.Add(item_grila)

                'Next ii
            Next i

            Return NN_PDF.PDF_Derivados(DOMAIN_URL, data_grilla_yeah, Derivador)
        End If

        Return "null"

    End Function

    Public Class ids
        Dim E_ID_ATENCION As String
        Dim E_ID_DET_ATE As String
        Dim E_CF_DESC As String
        Dim E_PAC_NOMBRE As String
        Dim E_PAC_APELLIDO As String
        Dim E_SEXO_DESC As String
        Dim E_PAC_FNAC As String
        Dim E_PAC_RUT As String
        Dim E_ID_CODIGO_FONASA As String
        Dim E_ORD_DESC As String
        Dim E_DOC_NOMBRE As String
        Dim E_DOC_APELLIDO As String
        Dim E_ATE_FECHA As String
        Dim E_ATE_NUM As String


        Public Property ATE_NUM As String
            Get
                Return E_ATE_NUM
            End Get
            Set(ByVal value As String)
                E_ATE_NUM = value
            End Set
        End Property
        Public Property ATE_FECHA As String
            Get
                Return E_ATE_FECHA
            End Get
            Set(ByVal value As String)
                E_ATE_FECHA = value
            End Set
        End Property
        Public Property DOC_APELLIDO As String
            Get
                Return E_DOC_APELLIDO
            End Get
            Set(ByVal value As String)
                E_DOC_APELLIDO = value
            End Set
        End Property
        Public Property DOC_NOMBRE As String
            Get
                Return E_DOC_NOMBRE
            End Get
            Set(ByVal value As String)
                E_DOC_NOMBRE = value
            End Set
        End Property
        Public Property ORD_DESC As String
            Get
                Return E_ORD_DESC
            End Get
            Set(ByVal value As String)
                E_ORD_DESC = value
            End Set
        End Property
        Public Property ID_CODIGO_FONASA As String
            Get
                Return E_ID_CODIGO_FONASA
            End Get
            Set(ByVal value As String)
                E_ID_CODIGO_FONASA = value
            End Set
        End Property
        Public Property PAC_RUT As String
            Get
                Return E_PAC_RUT
            End Get
            Set(ByVal value As String)
                E_PAC_RUT = value
            End Set
        End Property
        Public Property PAC_FNAC As String
            Get
                Return E_PAC_FNAC
            End Get
            Set(ByVal value As String)
                E_PAC_FNAC = value
            End Set
        End Property
        Public Property SEXO_DESC As String
            Get
                Return E_SEXO_DESC
            End Get
            Set(ByVal value As String)
                E_SEXO_DESC = value
            End Set
        End Property
        Public Property PAC_APELLIDO As String
            Get
                Return E_PAC_APELLIDO
            End Get
            Set(ByVal value As String)
                E_PAC_APELLIDO = value
            End Set
        End Property
        Public Property PAC_NOMBRE As String
            Get
                Return E_PAC_NOMBRE
            End Get
            Set(ByVal value As String)
                E_PAC_NOMBRE = value
            End Set
        End Property
        Public Property ID_ATENCION As String
            Get
                Return E_ID_ATENCION
            End Get
            Set(ByVal value As String)
                E_ID_ATENCION = value
            End Set
        End Property
        Public Property ID_DET_ATE As String
            Get
                Return E_ID_DET_ATE
            End Get
            Set(ByVal value As String)
                E_ID_DET_ATE = value
            End Set
        End Property
        Public Property CF_DESC As String
            Get
                Return E_CF_DESC
            End Get
            Set(ByVal value As String)
                E_CF_DESC = value
            End Set
        End Property
    End Class
End Class