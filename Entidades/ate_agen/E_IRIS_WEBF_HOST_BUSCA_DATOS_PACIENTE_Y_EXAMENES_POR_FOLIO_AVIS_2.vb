Public Class E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
    Dim EE_HO_ID As Integer
    Dim EE_HO_CP As String
    Dim EE_HO_CC As String
    Dim EE_HO_FechaAtencion As String
    Dim EE_HO_RutPaciente As String
    Dim EE_HO_DvPaciente As String
    Dim EE_HO_Nombres As String
    Dim EE_HO_ApellidoPaterno As String
    Dim EE_HO_ApellidoMaterno As String
    Dim EE_HO_Sexo As String
    Dim EE_HO_FechaNacimiento As String
    Dim EE_HO_TelefonoPaciente As String
    Dim EE_HO_EmailPaciente As String
    Dim EE_HO_RutMedico As String
    Dim EE_HO_DvMedico As String
    Dim EE_HO_NombreMedico As String
    Dim EE_HO_TipoAtencion As String
    Dim EE_HO_ServicioCodigo As String
    Dim EE_HO_ServicioDescripcion As String
    Dim EE_HO_ProcedenciaCodigo As String
    Dim EE_HO_ProcedenciaDescripcion As String
    Dim EE_HO_ExamenCodigo As String
    Dim EE_HO_ExamenDescripcion As String
    Dim EE_HO_FechaRegistro As String
    Dim EE_HO_EstadoProceso As String
    Dim EE_HO_EstadoFecha As String
    Dim EE_HO_Iris_EstadoCarga As String
    Dim EE_HO_Iris_FechaCarga As String
    Dim EE_HO_Iris_Ruta As String
    Dim EE_HO_Iris_PDF As String
    Dim EE_HO_Iris_Recepcion As String
    Dim EE_HO_Iris_FechaRecep As String
    Dim EE_HO_IdExamenIris As String
    Dim EE_HO_Fecha_D As String
    Dim EE_NumCorrelativoCero As String
    Dim EE_IdSolicitudCorrelativo As String
    Dim EE_IRIS_H_FECHA As String
    Dim EE_IRIS_H_ESTADO As String
    Dim EE_IRIS_H_ID_PREINGRESO As String
    Dim EE_HO_COD_DIAG As String
    Dim EE_HO_COD_PREVE As String
    Dim EE_HO_COD_PROGRA As String
    Dim EE_ID_DIAGNOSTICO As String
    Dim EE_ID_PROGRA As String
    Dim EE_ID_PREVE As String
    Dim EE_IRIS_H_ID_ATENCION As String



    Public Property IRIS_H_ID_ATENCION As Integer
        Get
            Return EE_IRIS_H_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_IRIS_H_ID_ATENCION = value
        End Set
    End Property


    Public Property HO_ID As Integer
        Get
            Return EE_HO_ID
        End Get
        Set(value As Integer)
            EE_HO_ID = value
        End Set
    End Property
    Public Property HO_CP As String
        Get
            Return EE_HO_CP
        End Get
        Set(value As String)
            EE_HO_CP = value
        End Set
    End Property
    Public Property HO_CC As String
        Get
            Return EE_HO_CC
        End Get
        Set(value As String)
            EE_HO_CC = value
        End Set
    End Property
    Public Property HO_FechaAtencion As String
        Get
            Return EE_HO_FechaAtencion
        End Get
        Set(value As String)
            EE_HO_FechaAtencion = value
        End Set
    End Property
    Public Property HO_RutPaciente As String
        Get
            Return EE_HO_RutPaciente
        End Get
        Set(value As String)
            EE_HO_RutPaciente = value
        End Set
    End Property
    Public Property HO_DvPaciente As String
        Get
            Return EE_HO_DvPaciente
        End Get
        Set(value As String)
            EE_HO_DvPaciente = value
        End Set
    End Property
    Public Property HO_Nombres As String
        Get
            Return EE_HO_Nombres
        End Get
        Set(value As String)
            EE_HO_Nombres = value
        End Set
    End Property
    Public Property HO_ApellidoPaterno As String
        Get
            Return EE_HO_ApellidoPaterno
        End Get
        Set(value As String)
            EE_HO_ApellidoPaterno = value
        End Set
    End Property
    Public Property HO_ApellidoMaterno As String
        Get
            Return EE_HO_ApellidoMaterno
        End Get
        Set(value As String)
            EE_HO_ApellidoMaterno = value
        End Set
    End Property
    Public Property HO_Sexo As String
        Get
            Return EE_HO_Sexo
        End Get
        Set(value As String)
            EE_HO_Sexo = value
        End Set
    End Property
    Public Property HO_FechaNacimiento As String
        Get
            Return EE_HO_FechaNacimiento
        End Get
        Set(value As String)
            EE_HO_FechaNacimiento = value
        End Set
    End Property
    Public Property HO_TelefonoPaciente As String
        Get
            Return EE_HO_TelefonoPaciente
        End Get
        Set(value As String)
            EE_HO_TelefonoPaciente = value
        End Set
    End Property
    Public Property HO_EmailPaciente As String
        Get
            Return EE_HO_EmailPaciente
        End Get
        Set(value As String)
            EE_HO_EmailPaciente = value
        End Set
    End Property
    Public Property HO_RutMedico As String
        Get
            Return EE_HO_RutMedico
        End Get
        Set(value As String)
            EE_HO_RutMedico = value
        End Set
    End Property
    Public Property HO_DvMedico As String
        Get
            Return EE_HO_DvMedico
        End Get
        Set(value As String)
            EE_HO_DvMedico = value
        End Set
    End Property
    Public Property HO_NombreMedico As String
        Get
            Return EE_HO_NombreMedico
        End Get
        Set(value As String)
            EE_HO_NombreMedico = value
        End Set
    End Property
    Public Property HO_TipoAtencion As String
        Get
            Return EE_HO_TipoAtencion
        End Get
        Set(value As String)
            EE_HO_TipoAtencion = value
        End Set
    End Property
    Public Property HO_ServicioCodigo As String
        Get
            Return EE_HO_ServicioCodigo
        End Get
        Set(value As String)
            EE_HO_ServicioCodigo = value
        End Set
    End Property
    Public Property HO_ServicioDescripcion As String
        Get
            Return EE_HO_ServicioDescripcion
        End Get
        Set(value As String)
            EE_HO_ServicioDescripcion = value
        End Set
    End Property
    Public Property HO_ProcedenciaCodigo As String
        Get
            Return EE_HO_ProcedenciaCodigo
        End Get
        Set(value As String)
            EE_HO_ProcedenciaCodigo = value
        End Set
    End Property
    Public Property HO_ProcedenciaDescripcion As String
        Get
            Return EE_HO_ProcedenciaDescripcion
        End Get
        Set(value As String)
            EE_HO_ProcedenciaDescripcion = value
        End Set
    End Property
    Public Property HO_ExamenCodigo As String
        Get
            Return EE_HO_ExamenCodigo
        End Get
        Set(value As String)
            EE_HO_ExamenCodigo = value
        End Set
    End Property
    Public Property HO_ExamenDescripcion As String
        Get
            Return EE_HO_ExamenDescripcion
        End Get
        Set(value As String)
            EE_HO_ExamenDescripcion = value
        End Set
    End Property
    Public Property HO_FechaRegistro As String
        Get
            Return EE_HO_FechaRegistro
        End Get
        Set(value As String)
            EE_HO_FechaRegistro = value
        End Set
    End Property
    Public Property HO_EstadoProceso As String
        Get
            Return EE_HO_EstadoProceso
        End Get
        Set(value As String)
            EE_HO_EstadoProceso = value
        End Set
    End Property
    Public Property HO_EstadoFecha As String
        Get
            Return EE_HO_EstadoFecha
        End Get
        Set(value As String)
            EE_HO_EstadoFecha = value
        End Set
    End Property
    Public Property HO_Iris_EstadoCarga As String
        Get
            Return EE_HO_Iris_EstadoCarga
        End Get
        Set(value As String)
            EE_HO_Iris_EstadoCarga = value
        End Set
    End Property
    Public Property HO_Iris_FechaCarga As String
        Get
            Return EE_HO_Iris_FechaCarga
        End Get
        Set(value As String)
            EE_HO_Iris_FechaCarga = value
        End Set
    End Property
    Public Property HO_Iris_Ruta As String
        Get
            Return EE_HO_Iris_Ruta
        End Get
        Set(value As String)
            EE_HO_Iris_Ruta = value
        End Set
    End Property
    Public Property HO_Iris_PDF As String
        Get
            Return EE_HO_Iris_PDF
        End Get
        Set(value As String)
            EE_HO_Iris_PDF = value
        End Set
    End Property
    Public Property HO_Iris_Recepcion As String
        Get
            Return EE_HO_Iris_Recepcion
        End Get
        Set(value As String)
            EE_HO_Iris_Recepcion = value
        End Set
    End Property
    Public Property HO_Iris_FechaRecep As String
        Get
            Return EE_HO_Iris_FechaRecep
        End Get
        Set(value As String)
            EE_HO_Iris_FechaRecep = value
        End Set
    End Property
    Public Property HO_IdExamenIris As String
        Get
            Return EE_HO_IdExamenIris
        End Get
        Set(value As String)
            EE_HO_IdExamenIris = value
        End Set
    End Property
    Public Property HO_Fecha_D As String
        Get
            Return EE_HO_Fecha_D
        End Get
        Set(value As String)
            EE_HO_Fecha_D = value
        End Set
    End Property
    Public Property NumCorrelativoCero As String
        Get
            Return EE_NumCorrelativoCero
        End Get
        Set(value As String)
            EE_NumCorrelativoCero = value
        End Set
    End Property
    Public Property IdSolicitudCorrelativo As String
        Get
            Return EE_IdSolicitudCorrelativo
        End Get
        Set(value As String)
            EE_IdSolicitudCorrelativo = value
        End Set
    End Property
    Public Property IRIS_H_FECHA As String
        Get
            Return EE_IRIS_H_FECHA
        End Get
        Set(value As String)
            EE_IRIS_H_FECHA = value
        End Set
    End Property
    Public Property IRIS_H_ESTADO As String
        Get
            Return EE_IRIS_H_ESTADO
        End Get
        Set(value As String)
            EE_IRIS_H_ESTADO = value
        End Set
    End Property
    Public Property IRIS_H_ID_PREINGRESO As String
        Get
            Return EE_IRIS_H_ID_PREINGRESO
        End Get
        Set(value As String)
            EE_IRIS_H_ID_PREINGRESO = value
        End Set
    End Property
    Public Property HO_COD_DIAG As String
        Get
            Return EE_HO_COD_DIAG
        End Get
        Set(value As String)
            EE_HO_COD_DIAG = value
        End Set
    End Property
    Public Property HO_COD_PREVE As String
        Get
            Return EE_HO_COD_PREVE
        End Get
        Set(value As String)
            EE_HO_COD_PREVE = value
        End Set
    End Property
    Public Property HO_COD_PROGRA As String
        Get
            Return EE_HO_COD_PROGRA
        End Get
        Set(value As String)
            EE_HO_COD_PROGRA = value
        End Set
    End Property
    Public Property ID_DIAGNOSTICO As String
        Get
            Return EE_ID_DIAGNOSTICO
        End Get
        Set(value As String)
            EE_ID_DIAGNOSTICO = value
        End Set
    End Property
    Public Property ID_PROGRA As String
        Get
            Return EE_ID_PROGRA
        End Get
        Set(value As String)
            EE_ID_PROGRA = value
        End Set
    End Property
    Public Property ID_PREVE As String
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As String)
            EE_ID_PREVE = value
        End Set
    End Property
End Class
