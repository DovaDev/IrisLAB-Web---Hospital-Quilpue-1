Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Rel_Prev_Prog_SubProg
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Dim NN As N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR = New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
        data_paciente = NN.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PROGRAMA() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of e_IRIS_WEBF_BUSCA_PROGRAMA)
        Dim NN As N_IRIS_WEBF_BUSCA_BANCO = New N_IRIS_WEBF_BUSCA_BANCO
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_SUBPROGRAMA() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_SUBPROGRAMA)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO
        data_paciente = NN.IRIS_WEBF_BUSCA_SUBPROGRAMA()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI(ByVal ID_PREVE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of e_IRIS_WEBF_BUSCA_PROGRAMA)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_BANCO = New N_IRIS_WEBF_BUSCA_BANCO

        Dim data_rel As List(Of E_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI)
        Dim NN_rel As N_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI = New N_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI


        data_progra = NN_progra.IRIS_WEBF_BUSCA_PROGRAMA()

        If data_progra.Count > 0 Then
            data_rel = NN_rel.IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI(ID_PREVE)
            If data_rel.Count > 0 Then
                For i = 0 To data_rel.Count - 1
                    For ii = 0 To data_progra.Count - 1
                        If data_rel(i).ID_PROGRA = data_progra(ii).ID_PROGRA Then
                            data_progra(ii).CHECK = 1
                        End If
                    Next ii
                Next i
            End If
        Else
            Return "null"
        End If

        If (data_progra.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_progra, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA(ByVal ID_PREVE As Integer, ByVal ID_PROGRA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_subprogra As List(Of E_IRIS_WEBF_BUSCA_SUBPROGRAMA)
        Dim NN_Progra As N_IRIS_WEBF_BUSCA_DIAGNOSTICO = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO

        Dim data_rel As List(Of E_IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA)
        Dim NN_rel As N_IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA = New N_IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA

        data_subprogra = NN_Progra.IRIS_WEBF_BUSCA_SUBPROGRAMA()
        data_rel = NN_rel.IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA(ID_PREVE, ID_PROGRA)

        If data_subprogra.Count > 0 Then
            data_rel = NN_rel.IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA(ID_PREVE, ID_PROGRA)
            If data_rel.Count > 0 Then
                For i = 0 To data_rel.Count - 1
                    For ii = 0 To data_subprogra.Count - 1
                        If data_rel(i).ID_SUBP = data_subprogra(ii).ID_SUBP Then
                            data_subprogra(ii).CHECK = 1
                        End If
                    Next ii
                Next i
            End If
        Else
            Return "null"
        End If
        If (data_subprogra.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_subprogra, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION(ByVal ID_PREVE As Integer,
                                                                         ByVal ID_PROGRA As Integer,
                                                                         ByVal selected_subprogra() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_graba As List(Of E_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION)
        Dim NN_GRABA As N_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION = New N_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION

        For ii = 0 To selected_subprogra.Length - 1
            data_graba = NN_GRABA.IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION(ID_PREVE, ID_PROGRA, selected_subprogra(ii), 1)
        Next ii

        If (data_graba.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_graba, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_PROGRAMA_SUBPROGRAMA_RELACION(ByVal ID_PREVE As Integer,
                                                                         ByVal ID_PROGRA As Integer,
                                                                         ByVal selected_subprogra() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim delete As Integer = 0
        Dim NN_DELETE As N_IRIS_WEBF_UPDATE_PROGRAMA_SUBPROGRAMA_RELACION = New N_IRIS_WEBF_UPDATE_PROGRAMA_SUBPROGRAMA_RELACION

        For ii = 0 To selected_subprogra.Length - 1
            delete = NN_DELETE.IRIS_WEBF_UPDATE_PROGRAMA_SUBPROGRAMA_RELACION(ID_PREVE, ID_PROGRA, CInt(selected_subprogra(ii)), 2)
        Next ii

        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(delete, str_Builder)
        datas = str_Builder.ToString

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String) As String
        Dim NN_Excel As New N_Excel
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        Dim titulo As String = "PREVISIONES"
        Dim Mx(3, 0) As Object
        For y = 0 To (data_paciente.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx(3, y)
            End If
            Mx(0, y) = data_paciente(y).ID_PREVE
            Mx(1, y) = data_paciente(y).PREVE_COD
            Mx(2, y) = data_paciente(y).PREVE_DESC
            Mx(3, y) = data_paciente(y).ID_ESTADO
        Next y
        Return NN_Excel.Excel(DOMAIN_URL, Mx, titulo)
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
End Class