Imports System.Web
Imports System.Web.Services

Public Class Uploads
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim files As HttpFileCollection
        Dim file As HttpPostedFile
        Dim fname As String

        files = context.Request.Files
        file = files(0)
        fname = context.Server.MapPath("~/uploads/" + file.FileName)
        'System.IO.File.Copy(fname, "C:/uploads_BACKUP/" & file.FileName)
        file.SaveAs(fname)

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class