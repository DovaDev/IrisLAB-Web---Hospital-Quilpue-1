Imports System.Web.Script.Serialization
Imports Entidades
Imports Negocio
Public Class Rela_Pack_Cf
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function LLENAR_DDL_PACK() As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_PACK
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_PACK()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS(ByVal ID_PACK As Integer) As IEnumerable(Of Object)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_PACK = New N_IRIS_WEBF_BUSCA_PACK

        data_progra = NN_progra.IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS(ID_PACK)


        Return data_progra
    End Function


    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_MANTENEDOR_REL(ByVal ID_PACK As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_PACK
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Data_CF = NN_CF.IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_MANTENEDOR_REL(ID_PACK)

        Return Data_CF

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION(ByVal ARRAY_COD_FONASA As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PACK = New N_IRIS_WEBF_BUSCA_PACK

        For Each Item As Integer In ARRAY_COD_FONASA

            numerin = NN.IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION(Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_RELACION_PACK_CF(ByVal ID_PACK As Integer, ByVal ARRAY_COD_FONASA As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PACK = New N_IRIS_WEBF_BUSCA_PACK

        For Each Item As Integer In ARRAY_COD_FONASA

            numerin = NN.IRIS_WEBF_GRABA_RELACION_PACK_CF(ID_PACK, Item)
        Next

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
    Public Shared Function IRIS_WEBF_BUSCA_PACK_2023() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Dim NN As N_IRIS_WEBF_BUSCA_PACK = New N_IRIS_WEBF_BUSCA_PACK
        data_paciente = NN.IRIS_WEBF_BUSCA_PACK_2023()
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
    Public Shared Function IRIS_WEBF_GRABA_PACK(ByVal PACK_COD As String, ByVal PACK_DES As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PACK = New N_IRIS_WEBF_BUSCA_PACK
        numerin = NN.IRIS_WEBF_GRABA_PACK(PACK_COD, PACK_DES, ID_ESTADO)

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
    Public Shared Function IRIS_WEBF_CMVM_UPDATE_PACK(ByVal ID_PACK As Integer, ByVal PACK_COD As String, ByVal PACK_DES As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PACK = New N_IRIS_WEBF_BUSCA_PACK
        numerin = NN.IRIS_WEBF_CMVM_UPDATE_PACK(ID_PACK, PACK_COD, PACK_DES, ID_ESTADO)
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

End Class