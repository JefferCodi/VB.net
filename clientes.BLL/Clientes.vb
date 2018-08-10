Imports cliente.DAL
Imports clientes.entidades
Public Class Clientes
    Public Function obtenerLstatdoClientes() As List(Of clientetb)
        Dim x As New ClienteDAO

        Return x.obtenerLstatdoClientes()
    End Function
    Public Function obtenerListatdoClientesPorId(ByVal Id As Char) As List(Of clientetb)
        Dim x As New ClienteDAO

        Return x.obtenerListatdoClientesPorId(Id)
    End Function

    Public Sub actualizarCliente(ByVal listadeCliente As List(Of clientetb))
        Dim x As New ClienteDAO

        x.actualizarCliente(listadeCliente)
    End Sub
    Public Sub eliminarCliente(ByVal listadeCliente As List(Of clientetb))
        Dim x As New ClienteDAO

        x.eliminarCliente(listadeCliente)
    End Sub
    Public Sub eliminarClienteporId(ByVal Id As Char)
        Dim x As New ClienteDAO

        x.eliminarClienteporId(Id)
    End Sub
    Public Sub insertarCliente(ByVal listadeCliente As List(Of clientetb))
        Dim x As New ClienteDAO

        x.insertarCliente(listadeCliente)
    End Sub

    Public Sub insertarCliente(ByVal oCliente As clientetb)
        Dim x As New ClienteDAO

        x.insertarCliente(oCliente)
    End Sub
End Class
