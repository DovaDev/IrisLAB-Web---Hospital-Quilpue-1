Imports Entidades
Imports Negocio
Public Class HT_Secc
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Seccion() As List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_SECC As New N_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
        Dim Data_SECC As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)

        Data_SECC = NN_SECC.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
        If (Data_SECC.Count > 0) Then
            Return Data_SECC
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As Date,
                                            ByVal HASTA As Date,
                                            ByVal ID_TP_PAGO As Integer) As List(Of E_IRIS_WEBF_BUSCA_HOJA_DE_TRABAJO_DE_SECCION_FECHA_AREA_DERIVADO)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_HOJA_DE_TRABAJO_DE_SECCION_FECHA_AREA_DERIVADO
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_HOJA_DE_TRABAJO_DE_SECCION_FECHA_AREA_DERIVADO)
        'Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_HOJA_DE_TRABAJO_DE_SECCION_FECHA_AREA_DERIVADO(DESDE, HASTA, ID_TP_PAGO)

        If (Data.Count > 0) Then
            For i = 0 To (Data.Count - 1)
                Data(i).ENCRYPTED_ID = N_ECrypt.Encode(Data(i).ID_ATENCION)
            Next i
            Return Data
        Else
            Return Nothing
        End If
    End Function
End Class