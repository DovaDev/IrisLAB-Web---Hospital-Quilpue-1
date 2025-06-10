
Imports Entidades
Imports Negocio
Public Class B_Elec
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ATE_NUM As String) As E_IRIS_WEBF_CMVM_BUSCA_DATOS_BE

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_DATOS_BE
        Dim Data_Estado_Mant As New E_IRIS_WEBF_CMVM_BUSCA_DATOS_BE

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_DATOS_BE(ATE_NUM)
        If (Data_Estado_Mant IsNot Nothing) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Folio(ByVal ID_ATENCION As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_FOLIO_BE
        Dim Data_Estado_Mant_2 As Integer = 0

        Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_FOLIO_BE(ID_ATENCION)


        Return Data_Estado_Mant_2

    End Function


End Class