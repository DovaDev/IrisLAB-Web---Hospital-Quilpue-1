Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class M_Prevision
    Inherits System.Web.UI.Page
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
    Public Shared Function IRIS_WEBF_BUSCA_PROCEDENCIA() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        Dim NN As N_IRIS_WEBF_BUSCA_PROCEDENCIA = New N_IRIS_WEBF_BUSCA_PROCEDENCIA
        data_paciente = NN.IRIS_WEBF_BUSCA_PROCEDENCIA()
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
    Public Shared Function IRIS_WEBF_GRABA_PREVISION(ByVal PREVE_COD As String, ByVal PREVE_DESC As String, ByVal ID_ESTADO As Integer, ByVal LUGARES() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim ID_PREVI As Integer = 0
        Dim numerin_relacion As Integer = 0
        Dim numm As Integer = 0
        'Dim NUMMMM As Integer

        Dim PREVE_ARH As Integer = 1
        Dim PREVE_FACTORH = 0
        Dim PREVE_ARHA As Integer = 1
        Dim PREVE_FACTORHA As Integer = 0
        Dim PREVE_HOST = 0

        Dim NN As N_IRIS_WEBF_GRABA_PREVISION = New N_IRIS_WEBF_GRABA_PREVISION
        ID_PREVI = NN.IRIS_WEBF_GRABA_PREVISION(PREVE_COD, PREVE_DESC, PREVE_ARH, PREVE_FACTORH, PREVE_ARHA, PREVE_FACTORHA, PREVE_HOST, ID_ESTADO)

        Dim NN_RELACION As New N_IRIS_WEBF_GRABA_RELACION_PRE_PROCE
        If LUGARES.Length > 0 Then
            For i = 0 To LUGARES.Length - 1
                numerin_relacion = NN_RELACION.IRIS_WEBF_GRABA_RELACION_PRE_PROCE(ID_PREVI, CInt(LUGARES(i)), 1)
            Next i
        End If

        If (numerin_relacion > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin_relacion, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_PREVISION(ByVal ID_PREVE As Integer,
                                                      ByVal PREVE_COD As String,
                                                      ByVal PREVE_DES As String,
                                                      ByVal ID_ESTADO As Integer,
                                                      ByVal LUGARES_TM() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim numerin_relacion As Integer = 0
        Dim numerin_relacion_graba As Integer = 0

        Dim NN As N_IRIS_WEBF_UPDATE_PREVISION = New N_IRIS_WEBF_UPDATE_PREVISION
        Dim NN_RELACION As New N_IRIS_WEBF_UPDATE_RELACION_PRE_PROCE
        Dim NN_RELACION_GRABA As New N_IRIS_WEBF_GRABA_RELACION_PRE_PROCE

        Dim data_rel_preve_proce As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE)
        Dim NN_BUSCA_RELACION As N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE = New N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE

        data_rel_preve_proce = NN_BUSCA_RELACION.IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ID_PREVE)

        Dim PREVE_ARH As Integer = 1
        Dim PREVE_FACTORH = 0
        Dim PREVE_ARHA As Integer = 1
        Dim PREVE_FACTORHA As Integer = 0
        Dim PREVE_HOST = 0

        numerin = NN.IRIS_WEBF_UPDATE_PREVISION(ID_PREVE, PREVE_COD, PREVE_DES, PREVE_ARH, PREVE_FACTORH, PREVE_ARHA, PREVE_FACTORHA, PREVE_HOST, ID_ESTADO)

        If LUGARES_TM.Length > 0 Then
            For i = 0 To LUGARES_TM.Length - 1
                Dim ID_PROCE As Integer = LUGARES_TM(i)
                If ID_PROCE <> 0 Then
                    numerin_relacion = NN_RELACION.IRIS_WEBF_UPDATE_RELACION_PRE_PROCE(ID_PREVE, CInt(LUGARES_TM(i)), ID_ESTADO)
                    If numerin_relacion = 0 Then
                        numerin_relacion = NN_RELACION_GRABA.IRIS_WEBF_GRABA_RELACION_PRE_PROCE(ID_PREVE, CInt(LUGARES_TM(i)), 1)
                    End If
                End If
            Next i
        End If




        Dim data_PROCE As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        Dim NN_PROCE As N_IRIS_WEBF_BUSCA_PROCEDENCIA = New N_IRIS_WEBF_BUSCA_PROCEDENCIA
        data_PROCE = NN_PROCE.IRIS_WEBF_BUSCA_PROCEDENCIA()
        data_rel_preve_proce = NN_BUSCA_RELACION.IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ID_PREVE)

        For i = 0 To data_PROCE.Count - 1
            If LUGARES_TM(i) = data_PROCE(i).ID_PROCEDENCIA Then
                numerin_relacion = NN_RELACION.IRIS_WEBF_UPDATE_RELACION_PRE_PROCE(ID_PREVE, CInt(LUGARES_TM(i)), ID_ESTADO)
            Else
                numerin_relacion = NN_RELACION.IRIS_WEBF_UPDATE_RELACION_PRE_PROCE(ID_PREVE, data_PROCE(i).ID_PROCEDENCIA, 2)
            End If
        Next i






        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ByVal ID_PREVE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_rel_preve_proce As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE)
        Dim NN As N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE = New N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE

        data_rel_preve_proce = NN.IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ID_PREVE)

        If (data_rel_preve_proce.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_rel_preve_proce, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function DELETE_PRE(ByVal ID_PREVE As Integer,
                                                      ByVal PREVE_COD As String,
                                                      ByVal PREVE_DES As String,
                                                      ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim numerin_relacion As Integer = 0
        Dim numerin_relacion_graba As Integer = 0

        Dim NN As N_IRIS_WEBF_UPDATE_PREVISION = New N_IRIS_WEBF_UPDATE_PREVISION
        Dim NN_RELACION As New N_IRIS_WEBF_UPDATE_RELACION_PRE_PROCE
        Dim NN_RELACION_GRABA As New N_IRIS_WEBF_GRABA_RELACION_PRE_PROCE

        Dim data_rel_preve_proce As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE)
        Dim NN_BUSCA_RELACION As N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE = New N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE

        data_rel_preve_proce = NN_BUSCA_RELACION.IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ID_PREVE)

        Dim PREVE_ARH As Integer = 1
        Dim PREVE_FACTORH = 0
        Dim PREVE_ARHA As Integer = 1
        Dim PREVE_FACTORHA As Integer = 0
        Dim PREVE_HOST = 0

        numerin = NN.IRIS_WEBF_UPDATE_PREVISION(ID_PREVE, PREVE_COD, PREVE_DES, PREVE_ARH, PREVE_FACTORH, PREVE_ARHA, PREVE_FACTORHA, PREVE_HOST, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
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