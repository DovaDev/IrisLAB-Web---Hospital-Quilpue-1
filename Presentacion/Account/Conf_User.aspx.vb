Imports Negocio
Imports Entidades

Public Class E_Select
    Private E_Text As String
    Public Property text() As String
        Get
            Return E_Text
        End Get
        Set(ByVal value As String)
            E_Text = value
        End Set
    End Property

    Private E_Value As Integer
    Public Property value() As Integer
        Get
            Return E_Value
        End Get
        Set(ByVal value As Integer)
            E_Value = value
        End Set
    End Property
End Class

Public Class Conf_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Role() As List(Of E_Select)
        Dim NNN As New N_Conf_User
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.USU_ADMIN
            lol.text = xItem.ADMIN_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Proc(ByVal ID_PREV As Integer) As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(ID_PREV)

        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_PROCEDENCIA
            lol.text = xItem.PROC_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Prev(ByVal ID_PROC As Integer) As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim list_Out As New List(Of E_Select)

        If (ID_PROC = 0) Then
            List_Data = NNN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        Else
            List_Data = NNN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)
        End If
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_PREVE
            lol.text = xItem.PREVE_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Ciudad() As List(Of E_Select)
        Dim NNN As New N_IRIS_WEBF_BUSCA_CIUDAD
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_BUSCA_CIUDAD
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_CIUDAD
            lol.text = xItem.CIU_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Comuna(ByVal ID_CIUD As Integer) As List(Of E_Select)
        Dim NNN As New N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ID_CIUD)
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_COMUNA
            lol.text = xItem.COM_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Prefesion() As List(Of E_Select)
        Dim NNN As New N_IRIS_WEBF_BUSCA_PROFESION
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_PROFESION)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_BUSCA_PROFESION()
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_PRO
            lol.text = xItem.PRO_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Cargo() As List(Of E_Select)
        Dim NNN As New N_IRIS_WEBF_BUSCA_CARGO
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_CARGO)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_BUSCA_CARGO()
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_CAR
            lol.text = xItem.CARD_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Estados() As List(Of E_Select)
        Dim NNN As New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_ESTADO
            lol.text = xItem.EST_DESCRIPCION

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_Table_Data() As List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2)
        Dim NNN As New N_Conf_User
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2)

        List_Data = NNN.IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2()

        Return List_Data
    End Function

    <Services.WebMethod()>
    Public Shared Function Call_User_Data(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE
        Dim NNN As New N_Conf_User
        Dim List_Data As New E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE

        List_Data = NNN.IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE(ID_USER)

        Return List_Data
    End Function

    <Services.WebMethod()>
    Public Shared Function Change_Status(ByVal ID_USER As Long, ByVal ID_ESTADO As Boolean) As Boolean
        Dim NNN As New N_Conf_User
        Dim Response As New Boolean

        Response = NNN.IRIS_WEBF_CMVM_USER_UPDATE_STATUS(ID_USER, ID_ESTADO)

        Return Response
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_USER_UPDATE(ByVal ID_USER As Integer,
                                                      ByVal USU_NICK As String,
                                                      ByVal ID_ROLE As Integer,
                                                      ByVal USU_PASS As String,
                                                      ByVal USU_FNAC As String,
                                                      ByVal USU_RUT As String,
                                                      ByVal ID_PROC As Integer,
                                                      ByVal ID_PREV As Integer,
                                                      ByVal USU_NOMBRE As String,
                                                      ByVal USU_APELLIDO As String,
                                                      ByVal USU_DIR As String,
                                                      ByVal USU_EMAIL As String,
                                                      ByVal USU_FONO As String,
                                                      ByVal USU_MOVIL As String,
                                                      ByVal ID_CIUDAD As Integer,
                                                      ByVal ID_COMUNA As Integer,
                                                      ByVal ID_PROFESION As Integer,
                                                      ByVal ID_CARGO As Integer,
                                                      ByVal ID_ESTADO As Integer) As Boolean
        Dim NNN As New N_Conf_User
        Dim N_F As New N_Date_Operat

        Dim arrDate As String() = USU_FNAC.Split("/")

        Return NNN.IRIS_WEBF_CMVM_USER_UPDATE(
                                            ID_USER,
                                            USU_NICK,
                                            ID_ROLE,
                                            USU_PASS,
                                            N_F.strToDate(CInt(arrDate(2)), CInt(arrDate(1)), CInt(arrDate(0))),
                                            USU_RUT,
                                            ID_PROC,
                                            ID_PREV,
                                            USU_NOMBRE,
                                            USU_APELLIDO,
                                            USU_DIR,
                                            USU_EMAIL,
                                            USU_FONO,
                                            USU_MOVIL,
                                            ID_CIUDAD,
                                            ID_COMUNA,
                                            ID_PROFESION,
                                            ID_CARGO,
                                            ID_ESTADO)

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_USER_INSERT(ByVal ID_USER As Integer,
                                                      ByVal USU_NICK As String,
                                                      ByVal ID_ROLE As Integer,
                                                      ByVal USU_PASS As String,
                                                      ByVal USU_FNAC As String,
                                                      ByVal USU_RUT As String,
                                                      ByVal ID_PROC As Integer,
                                                      ByVal ID_PREV As Integer,
                                                      ByVal USU_NOMBRE As String,
                                                      ByVal USU_APELLIDO As String,
                                                      ByVal USU_DIR As String,
                                                      ByVal USU_EMAIL As String,
                                                      ByVal USU_FONO As String,
                                                      ByVal USU_MOVIL As String,
                                                      ByVal ID_CIUDAD As Integer,
                                                      ByVal ID_COMUNA As Integer,
                                                      ByVal ID_PROFESION As Integer,
                                                      ByVal ID_CARGO As Integer,
                                                      ByVal ID_ESTADO As Integer) As Boolean
        Dim NNN As New N_Conf_User
        Dim N_F As New N_Date_Operat

        Dim arrDate As String() = USU_FNAC.Split("/")

        Return NNN.IRIS_WEBF_CMVM_USER_INSERT(
                                            USU_NICK,
                                            ID_ROLE,
                                            USU_PASS,
                                            N_F.strToDate(CInt(arrDate(2)), CInt(arrDate(1)), CInt(arrDate(0))),
                                            USU_RUT,
                                            ID_PROC,
                                            ID_PREV,
                                            USU_NOMBRE,
                                            USU_APELLIDO,
                                            USU_DIR,
                                            USU_EMAIL,
                                            USU_FONO,
                                            USU_MOVIL,
                                            ID_CIUDAD,
                                            ID_COMUNA,
                                            ID_PROFESION,
                                            ID_CARGO,
                                            ID_ESTADO)

    End Function
End Class