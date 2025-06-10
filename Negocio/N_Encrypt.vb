Imports System.Text
Imports System.Security.Cryptography
Public Class N_Encrypt
    'Declaraciones
    Dim Clave_1 As String
    Dim Clave_2 As String
    Public Sub New()
        'La clave debe ser de 8 caracteres
        'Clave_1 = "qualityi"
        Clave_1 = "ilraibsw"
        'No se puede alterar la cantidad de caracteres pero si la clave
        'Clave_2 = "rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"
        Clave_2 = "r33316g3t320u764n0rm135/15321532"
    End Sub
    Function Encode(ByVal Input As String) As String
        'Aquí va la clave, debe de ser de 8 caracteres
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(Clave_1)
        'No se puede alterar la cantidad de caracteres pero si la clave
        Dim EncryptionKey() As Byte = Convert.FromBase64String(Clave_2)
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(Input)
        Dim Decrypter As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Decrypter.Key = EncryptionKey
        Decrypter.IV = IV
        Return Convert.ToBase64String(Decrypter.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function
    Function Decode(ByVal Input As String) As String
        Input = Input.Replace(" ", "+")
        'Aquí va la clave, debe de ser de 8 caracteres
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(Clave_1)
        'No se puede alterar la cantidad de caracteres pero si la clave
        Dim EncryptionKey() As Byte = Convert.FromBase64String(Clave_2)
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim Decrypter As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Decrypter.Key = EncryptionKey
        Decrypter.IV = IV
        Return Encoding.UTF8.GetString(Decrypter.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function
End Class
