Imports Entidades
Imports Negocio

Public Class C_Can_Rang
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Int() As List(Of E_IRIS_WEBF_BUSCA_INTERFAZ)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Int As New N_IRIS_WEBF_BUSCA_INTERFAZ
        Dim Data_Int As New List(Of E_IRIS_WEBF_BUSCA_INTERFAZ)

        Data_Int = NN_Int.IRIS_WEBF_BUSCA_INTERFAZ()
        If (Data_Int.Count > 0) Then

            Return Data_Int
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Maq(ByVal IRIS_LNK_I_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Maq As New N_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ
        Dim Data_Maq As New List(Of E_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ)

        Data_Maq = NN_Maq.IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ(IRIS_LNK_I_ID)
        If (Data_Maq.Count > 0) Then

            Return Data_Maq
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Guardar_Rel_CR(ByVal ID_I As Integer,
                                          ByVal ID_MAQ As Integer,
                                          ByVal CANAL As String,
                                          ByVal DETER As String,
                                          ByVal R_DESDE As String,
                                          ByVal R_HASTA As String,
                                          ByVal RR_DESDE As String,
                                          ByVal RR_HASTA As String) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_ As New N_RELACION_CANAL_RANGOS
        Dim Data_ As Integer

        Data_ = NN_.IRIS_WEBF_GRABA_RELACION_CANAL_RANGOS(ID_I, ID_MAQ, CANAL, DETER, R_DESDE, R_HASTA, RR_DESDE, RR_HASTA)
        If (Data_ > 0) Then

            Return Data_
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Modificar_Rel_CR(ByVal ID_REL As Integer,
                                          ByVal ID_I As Integer,
                                          ByVal ID_MAQ As Integer,
                                          ByVal CANAL As String,
                                          ByVal DETER As String,
                                          ByVal R_DESDE As String,
                                          ByVal R_HASTA As String,
                                          ByVal RR_DESDE As String,
                                          ByVal RR_HASTA As String) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_ As New N_RELACION_CANAL_RANGOS
        Dim Data_ As Integer

        Data_ = NN_.IRIS_WEBF_UPDATE_RELACION_CANAL_RANGOS(ID_REL, ID_I, ID_MAQ, CANAL, DETER, R_DESDE, R_HASTA, RR_DESDE, RR_HASTA)
        If (Data_ > 0) Then

            Return Data_
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Cambia_Estado_Rel_CR(ByVal ID_REL As Integer,
                                          ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_ As New N_RELACION_CANAL_RANGOS
        Dim Data_ As Integer

        Data_ = NN_.IRIS_WEBF_UPDATE_ESTADO_RELACION_CANAL_RANGOS(ID_REL, ID_ESTADO)
        If (Data_ > 0) Then

            Return Data_
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Buscar_Rel_CR() As List(Of E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_ As New N_RELACION_CANAL_RANGOS
        Dim Data_ As List(Of E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS)

        Data_ = NN_.IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS()
        If (Data_.Count > 0) Then

            Return Data_
        Else
            Return Nothing
        End If
    End Function
End Class