Imports cliente.DAL
Imports clientes.entidades
Public Class Distritos
    Public Function obtenerLstatdoDistritos() As List(Of distrito)
        Dim x As New DistritoDAO

        Return x.obtenerLstatdoDistritos()
    End Function
    Public Function obtenerListatdoDistritosPorId(ByVal Id As Char) As List(Of distrito)
        Dim x As New DistritoDAO

        Return x.obtenerListatdoDistritosPorId(Id)
    End Function

    Public Sub actualizarDistrito(ByVal listadeDistrito As List(Of distrito))
        Dim x As New DistritoDAO

        x.actualizarDistrito(listadeDistrito)
    End Sub
    Public Sub eliminarDistrito(ByVal listadeDistrito As List(Of distrito))
        Dim x As New DistritoDAO

        x.actualizarDistrito(listadeDistrito)
    End Sub
    Public Sub eliminarDistritoporId(ByVal Id As Char)
        Dim x As New DistritoDAO

        x.eliminarDistritoporId(Id)
    End Sub
    Public Sub insertarDistrito(ByVal listadeDistrito As List(Of distrito))
        Dim x As New DistritoDAO

        x.insertarDistrito(listadeDistrito)
    End Sub
    Public Sub insertarDistrito(ByVal oDistrito As distrito)
        Dim x As New DistritoDAO

        x.insertarDistrito(oDistrito)
    End Sub
End Class
