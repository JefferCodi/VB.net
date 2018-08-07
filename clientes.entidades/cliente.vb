Public Class cliente
    Private Clie_id As Char
    Private Clie_nomb As String
    Private Clie_pate As String
    Private Clie_mate As String
    Private Clie_dire As String
    Private Clie_fono As String
    Private Clie_emai As String
    Private listaDistrito As List(Of distrito)

    Public Property ID() As Char
        Get
            Return Clie_id
        End Get
        Set(value As Char)
            Clie_id = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return Clie_nomb
        End Get
        Set(value As String)
            Clie_nomb = value
        End Set
    End Property
    Public Property PATERNO() As String
        Get
            Return Clie_pate
        End Get
        Set(value As String)
            Clie_pate = value
        End Set
    End Property
    Public Property MATERNO As String
        Get
            Return Clie_mate
        End Get
        Set(value As String)
            Clie_mate = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return Clie_dire
        End Get
        Set(value As String)
            Clie_dire = value
        End Set
    End Property
    Public Property TELEFONO As Char
        Get
            Return Clie_fono
        End Get
        Set(value As Char)
            Clie_fono = value
        End Set
    End Property
    Public Property EMAIL As String
        Get
            Return Clie_emai
        End Get
        Set(value As String)
            Clie_emai = value
        End Set
    End Property
    Public Property tb_distrito As List(Of distrito)
        Get
            Return listaDistrito
        End Get
        Set(value As List(Of distrito))
            listaDistrito = value
        End Set
    End Property
End Class
