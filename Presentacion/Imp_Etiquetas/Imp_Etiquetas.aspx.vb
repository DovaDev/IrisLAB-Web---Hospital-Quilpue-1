Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Imp_Etiquetas
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 2
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(ByVal NUM_ATE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_PACIENTE_IMPRIMIR)
        Dim NN As N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION = New N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_PACIENTE_IMPRIMIR = New N_IRIS_WEBF_BUSCA_ETIQUETA_PACIENTE_IMPRIMIR

        data_paciente = NN.IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(NUM_ATE)
        If data_paciente.Count > 0 Then
            data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_PACIENTE_IMPRIMIR(data_paciente(0).ID_ATENCION)
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente2, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2(ByVal NUM_ATE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2 = New N_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2

        'Dim data_id As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        'Dim NN_id As N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION = New N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION


        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2(NUM_ATE)
        If (data_paciente.Count > 0) Then

            'data_id = NN_id.IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(NUM_ATE)

            'If data_id.Count - 1 > 0 Then
            '    data_paciente(0).ID_ATENCION
            'End If

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    '<Services.WebMethod()>
    'Public Shared Function IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO(ByVal ATE_NUM As String, ByVal examen() As Object) As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""

    '    'Declaraciones internas
    '    Dim data_print As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO)
    '    Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO = New N_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO


    '    For i = 0 To (examen.GetUpperBound(0))
    '        data_print = NN.IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO(ATE_NUM, examen(i))
    '    Next i

    '    If data_print.Count > 0 Then
    '        'Serializar con JSON
    '        Serializer.MaxJsonLength = 999999999
    '        Serializer.Serialize(data_print, str_Builder)
    '        datas = str_Builder.ToString
    '    Else
    '        datas = "null"
    '    End If

    '    Return datas
    'End Function


    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2_2(ByVal NUM_ATE() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_print As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2 = New N_IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2

        For i = 0 To (NUM_ATE.GetUpperBound(0))
            data_print = NN.IRIS_WEBF_BUSCA_ETIQUETA_FOLIO_IMPRIMIR_NUEVO_2(NUM_ATE(i))
        Next i

        If data_print.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_print, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function
End Class