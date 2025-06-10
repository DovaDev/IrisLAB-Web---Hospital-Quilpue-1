Imports Entidades
Imports Datos
Imports System.Collections.Generic
Imports System.Linq

Public Class N_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
    End Sub
    Function IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE(ByVal RUT As String) As E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
        Return DD_Data.IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE(RUT)
    End Function
    Function IRIS_WEBF_BUSCA_DOC_POR_NOM_APE(ByVal NOM As String) As List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        Return DD_Data.IRIS_WEBF_BUSCA_DOC_POR_NOM_APE(NOM)
    End Function
    Function IRIS_WEBF_GRABA_EDITA_DOC(ByVal RUT As String, ByVal NOMBRE As String, ByVal ID As Long, ByVal TIPO As Integer) As Long
        Dim NNN As New List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        If (TIPO = 1) Then
            Return DD_Data.IRIS_WEBF_EDITA_DOC(RUT, NOMBRE, ID)
        Else

            Dim _Nom As String = "", _Ape As String = "", _NAP As String()



            _NAP = NOMBRE.Split(" ")

            If (_NAP.Count = 2) Then

                _Nom = _NAP(0)
                _Ape = _NAP(1)

                NNN = DD_Data.IRIS_WEBF_BUSCA_DOC_POR_NOM_APE_2(_Nom, _Ape)


            ElseIf (_NAP.Count = 3) Then

                _Nom = _NAP(0)
                _Ape = _NAP(1) + " " + _NAP(2)

                NNN = DD_Data.IRIS_WEBF_BUSCA_DOC_POR_NOM_APE_2(_Nom, _Ape)

            ElseIf (_NAP.Count = 4) Then

                _Nom = _NAP(0) + " " + _NAP(1)
                _Ape = _NAP(2) + " " + _NAP(3)

                NNN = DD_Data.IRIS_WEBF_BUSCA_DOC_POR_NOM_APE_2(_Nom, _Ape)


            End If

            If (NNN.Count > 0) Then

                For Each aah In NNN
                    If (aah.DOC_RUT <> "") Then
                        Return aah.ID_DOC
                    End If
                Next

                Return NNN(0).ID_DOC
            Else
                Return DD_Data.IRIS_WEBF_GRABA_DOC(RUT, _Nom, _Ape)
            End If

        End If



    End Function


End Class
