Public Class distrito
    Private Dist_id As Char
    Private Dist_desc As String

    Public Property ID As Char
        Get
            Return Dist_id
        End Get
        Set(value As Char)
            Dist_id = value
        End Set
    End Property
    Public Property NOMBRE As String
        Get
            Return Dist_desc
        End Get
        Set(value As String)
            Dist_desc = value
        End Set
    End Property
End Class