
Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization

Public Class Exa_Esp_V
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_Datos(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_AtencionDet As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
        Dim DataAtencionDet As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        Dim DCrypt As New N_Encrypt

        DataAtencionDet = NN_AtencionDet.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2(ID_ATE)
        If (DataAtencionDet.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DataAtencionDet, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_ExamenDet As New N_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
        Dim DataExamenDet As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        Dim DCrypt As New N_Encrypt



        DataExamenDet = NN_ExamenDet.IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_2(ID_ATE)
        If (DataExamenDet.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DataExamenDet, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Actualiar_Examenes(ByVal ID_ATE As String, ByVal numero_avis As String, ByVal num_ate As String, ByVal Codigo_Fonasa_avis As String, ByVal ID_CODIGO_FONASA As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_ExamenDet As New N_Exa_Esp_V
        Dim DataExamenDet As Integer
        Dim DCrypt As New N_Encrypt
        Dim exa_avis As Integer

        DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ID_ATE, ID_CODIGO_FONASA)

        If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
            exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
        End If

        Dim LOG As New N_Log
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim xNick As String = CType(objSession("NICKNAME"), String)

        LOG.Path = "\LOG\Cambio_Estado\" & Format(Date.Now, "dd-MM-yyyy - ") & "CAMBIO DE ESTADO" & ".txt"
        LOG.Write_Line("Cambio Estado")
        LOG.Write_Line("NICKNAME = " & xNick, False)
        LOG.Write_Line("ID_ATE = " & ID_ATE, False)
        LOG.Write_Line("NUMERO AVIS = " & numero_avis, False)
        LOG.Write_Line("ID_CODIGO_FONOSA = " & ID_CODIGO_FONASA, False)
        LOG.Write_Separator()


        Dim datos_his As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA)
        Dim n_histr As New N_historial
        datos_his = n_histr.IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA(ID_ATE, ID_CODIGO_FONASA)
        Dim id_usuario As String = CType(objSession("ID_USER"), String)
        Dim grabar_01 As Integer
        If (datos_his.Count > 0) Then

            grabar_01 = n_histr.IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ID_ATE,
                                                                               datos_his(0).ID_PER,
                                                                               datos_his(0).ATE_DET_V_PAGADO,
                                                                               datos_his(0).ATE_DET_V_COPAGO,
                                                                              datos_his(0).ATE_DET_V_PREVI, 0, 0, 0, 0, 2, id_usuario)
        End If
        If (DataExamenDet > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DataExamenDet, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
End Class