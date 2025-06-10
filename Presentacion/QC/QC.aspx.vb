Imports Entidades
Imports Negocio
Public Class QC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_Data(ByVal DESDE As String, ByVal HASTA As String, ByVal IRIS_LNK_MAQ_ID As Long, ByVal ID_PRUEBA As List(Of Long)) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Data As New N_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        Dim Data_F As New List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)

        For Each item In ID_PRUEBA
            Data = NN_Data.IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF(DESDE, HASTA, IRIS_LNK_MAQ_ID, item)

            For Each xItem In Data
                Dim E_DET As New E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF

                E_DET.ATE_RESULTADO = xItem.ATE_RESULTADO
                E_DET.ATE_RESULTADO_NUM = xItem.ATE_RESULTADO_NUM
                E_DET.ATE_R_DESDE = xItem.ATE_R_DESDE
                E_DET.ATE_R_HASTA = xItem.ATE_R_HASTA
                E_DET.ATE_RR_DESDE = xItem.ATE_RR_DESDE
                E_DET.ATE_RR_HASTA = xItem.ATE_RR_HASTA
                E_DET.ATE_NUM = xItem.ATE_NUM

                Data_F.Add(E_DET)
            Next

        Next


        If (Data_F.Count > 0) Then

            Return Data_F
        Else
            Return Nothing
        End If
    End Function

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
    Public Shared Function Llenar_Ddl_Det(ByVal IRIS_LNK_MAQ_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAKINA)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Det As New N_IRIS_WEBF_BUSCA_DET_POR_MAKINA
        Dim Data_Det As New List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAKINA)

        Data_Det = NN_Det.IRIS_WEBF_BUSCA_DET_POR_MAKINA(IRIS_LNK_MAQ_ID)
        If (Data_Det.Count > 0) Then

            Return Data_Det
        Else
            Return Nothing
        End If
    End Function

End Class