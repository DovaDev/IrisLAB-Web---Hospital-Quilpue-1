Imports System.Drawing
Imports System.Drawing.Printing
Public Class Str_Imp
    Dim EE_Text As String
    Dim EE_Font_Size As Integer
    Public Property Text As String
        Get
            Return EE_Text
        End Get
        Set(value As String)
            EE_Text = value
        End Set
    End Property
    Public Property Font_Size As Integer
        Get
            Return EE_Font_Size
        End Get
        Set(value As Integer)
            EE_Font_Size = value
        End Set
    End Property
End Class
Public Class Impresora
    Dim ListString As List(Of Str_Imp)
    Dim Print As PrintDocument
    Public Sub New(List_In)
        Print = New PrintDocument
        ListString = New List(Of Str_Imp)
        ListString = List_In
        AddHandler Print.PrintPage, AddressOf PrintIt
        Print.Print()
    End Sub
    Private Sub PrintIt(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        'Posición de dibujo
        Dim xx As Single = 0
        Dim yy As Single = 0
        For y = 0 To (ListString.Count - 1)
            Dim xFont As New Font("Arial", ListString(y).Font_Size, FontStyle.Regular)
            Dim xF_H As Single = xFont.GetHeight(e.Graphics)
            xx = e.MarginBounds.Left
            yy += xF_H
            e.Graphics.DrawString(ListString(y).Text, xFont, Brushes.Black, xx, yy)
        Next y
        e.HasMorePages = False
    End Sub
End Class
