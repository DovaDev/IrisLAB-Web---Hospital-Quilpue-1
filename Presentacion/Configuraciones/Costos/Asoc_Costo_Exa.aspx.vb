Imports Entidades
Imports Negocio
Public Class Asoc_Costo_Exa
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Examen() As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Costos() As List(Of E_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_COSTOS_ACTIVOS()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Control_Fonasa(ByVal ID_FONASA As Integer, ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA(ID_FONASA, ID_USUARIO)
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Cargados(ByVal ID_CONTROL As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS)
        Data_CF = NN_CF.IRIS_BUSCA_CONTROL_COSTO_RELACIONADOS(ID_CONTROL)
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Graba_Det_Control_Costo(ByVal Mx_Pos As List(Of E_Asoc_Costo_Exa)) As Integer

        Dim Data_CF As Integer
        Dim Arr_Pos As New List(Of E_Asoc_Costo_Exa)
        Arr_Pos = Mx_Pos

        For Each Item As E_Asoc_Costo_Exa In Arr_Pos
            'Declaraciones internas
            Dim NN_CF As New N_IRIS_WEBF_GRABA_DET_CONTROL_COSTO

            Dim ID_CONTROL As Integer = Item.ID_CONTROL
            Dim ID_COSTO As Integer = Item.ID_COSTO
            Dim PRECIO As Integer = Item.PRECIO
            Dim ID_USUARIO As Integer = Item.ID_USUARIO

            Data_CF += NN_CF.IRIS_WEBF_GRABA_DET_CONTROL_COSTO(ID_CONTROL, ID_COSTO, PRECIO, ID_USUARIO)
        Next

        If (Data_CF > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_Det_Control_Costo(ByVal Mx_Pos As List(Of E_Asoc_Costo_Exa)) As Integer

        Dim Data_CF As Integer
        Dim Arr_Pos2 As New List(Of E_Asoc_Costo_Exa)
        Arr_Pos2 = Mx_Pos

        For Each Item As E_Asoc_Costo_Exa In Arr_Pos2
            'Declaraciones internas
            Dim NN_CF As New N_IRIS_WEBF_UPDATE_QUITA_DETALLE_EXAMEN_FONASA

            Dim ID_REL As Integer = Item.ID_CONTROL
            Dim ID_COST As Integer = Item.ID_COSTO

            Data_CF += NN_CF.IRIS_WEBF_UPDATE_QUITA_DETALLE_EXAMEN_FONASA(ID_REL, ID_COST)
        Next

        If (Data_CF > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_CF_Control(ByVal Mx_Pos As List(Of E_UPDATE_CF_PRECIO)) As Integer

        Dim Arr_Pos3 As New List(Of E_UPDATE_CF_PRECIO)
        Arr_Pos3 = Mx_Pos
        Dim Data_CF As Integer
        For Each Item As E_UPDATE_CF_PRECIO In Arr_Pos3
            'Declaraciones internas
            Dim NN_CF As New N_IRIS_WEBF_UPDATE_CODIGO_FONASA_CONTROL_COSTO

            Dim ID_CONTROL_COSTO As Integer = Item.ID_CONTROL_COSTO
            Dim ID_COSTO As Integer = Item.ID_COSTO
            Dim PRECIO As Integer = Item.PRECIO
            Dim TOTAL_PRECIO As Integer = Convert.ToInt32(Item.TOTAL_PRECIO)

            Data_CF += NN_CF.IRIS_WEBF_UPDATE_CODIGO_FONASA_CONTROL_COSTO(ID_CONTROL_COSTO, ID_COSTO, PRECIO, TOTAL_PRECIO)

        Next

        If (Data_CF > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
End Class