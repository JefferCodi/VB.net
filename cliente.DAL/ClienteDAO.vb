Imports System.Data
Imports System.Data.SqlClient
Imports clientes.entidades


Public Class ClienteDAO
    Inherits claseBaseDAO
    Public Function obtenerLstatdoClientes() As List(Of clientetb)
        Dim oComman As New SqlCommand
        Try
            Dim listadoCliente As List(Of clientetb)
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "SELECT Clie_id, Clie_nomb, Clie_fono FROM tb_client"
            oComman.Connection.Open()

            Dim oDataRead As SqlDataReader = oComman.ExecuteReader()
            listadoCliente = recuperarListado(oDataRead)
            oDataRead.IsClosed.ToString()
            oComman.Connection.Close()
            Return listadoCliente

        Catch ex As Exception
            Throw New System.AggregateException("No se puedo ejecutar la consuta del cliente", ex)
        End Try
    End Function
    Public Function obtenerListatdoClientesPorId(ByVal Id As Char) As List(Of clientetb)
        Dim oComman As New SqlCommand
        Try
            Dim listadoCliente As List(Of clientetb)
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "SELECT Clie_id, Clie_nomb, Clie_fono FROM tb_client WHERE Clie_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char).Value = Id
            oComman.Connection.Open()

            Dim oDataRead As SqlDataReader = oComman.ExecuteReader()
            listadoCliente = recuperarListado(oDataRead)
            oDataRead.IsClosed.ToString()
            oComman.Connection.Close()
            Return listadoCliente

        Catch ex As Exception
            Throw New System.AggregateException("No se puedo encontrar el cliente por Id", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Function
    Private Function recuperarListado(ByVal dataReader As SqlDataReader) As List(Of clientetb)
        Try
            Dim listadoClientes As New List(Of clientetb)
            While (dataReader.Read)
                Dim x As New clientetb
                x.ID = dataReader.GetChar(0)
                x.NOMBRE = dataReader.GetString(1)
                x.PATERNO = dataReader.GetString(2)
                x.MATERNO = dataReader.GetString(3)
                x.DIRECCION = dataReader.GetString(4)
                x.TELEFONO = dataReader.GetChar(5)
                x.EMAIL = dataReader.GetString(6)

                listadoClientes.Add(x)
            End While
            Return listadoClientes
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo crear el listado del cliente para consulta", ex)
        End Try
    End Function
    Public Sub actualizarCliente(ByVal listadeCliente As List(Of clientetb))
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "UPDATE tb_client SET  Clie_nomb = @nombre, Clie_pate = @paterno, Clie_mete = @materno, Clie_dire = @direccion, Clie_emai = @email, Clie_fono = @telefono, Dist_id = @distrito  WHERE Clie_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Parameters.Add("@nombre", SqlDbType.NChar)
            oComman.Parameters.Add("@paterno", SqlDbType.NChar)
            oComman.Parameters.Add("@materno", SqlDbType.NChar)
            oComman.Parameters.Add("@direccion", SqlDbType.NChar)
            oComman.Parameters.Add("@telefono", SqlDbType.NChar)
            oComman.Parameters.Add("@email", SqlDbType.NChar)
            oComman.Parameters.Add("@distrito", SqlDbType.Char)
            oComman.Connection.Open()

            For Each x As clientetb In listadeCliente
                oComman.Parameters("@id").Value = x.ID
                oComman.Parameters("@nombre").Value = x.NOMBRE
                oComman.Parameters("@paterno").Value = x.PATERNO
                oComman.Parameters("@materno").Value = x.MATERNO
                oComman.Parameters("@direccion").Value = x.DIRECCION
                oComman.Parameters("@telefono").Value = x.TELEFONO
                oComman.Parameters("@email").Value = x.EMAIL
                oComman.Parameters("@distrito").Value = x.DISTRITO

                oComman.ExecuteNonQuery()
            Next
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo actualizar el cliente", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Public Sub eliminarCliente(ByVal listadeCliente As List(Of clientetb))
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "DELETE FROM tb_client WHERE Clie_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Connection.Open()

            For Each x As clientetb In listadeCliente
                oComman.Parameters("@id").Value = x.ID
                oComman.ExecuteNonQuery()
            Next

            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo eliminar el cliente", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Public Sub eliminarClienteporId(ByVal Id As Char)
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "DELETE FROM tb_client WHERE Clie_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char).Value = Id
            oComman.Connection.Open()
            oComman.ExecuteNonQuery()
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo eliminar el cliente por id", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Public Sub insertarCliente(ByVal listadeCliente As List(Of clientetb))
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "INSERT INTO tb_client VALUES (@id,@nombre,@paterno,@materno,@direccion,@email,@telefono,@distrito)"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Parameters.Add("@nombre", SqlDbType.NChar)
            oComman.Parameters.Add("@paterno", SqlDbType.NChar)
            oComman.Parameters.Add("@materno", SqlDbType.NChar)
            oComman.Parameters.Add("@direccion", SqlDbType.NChar)
            oComman.Parameters.Add("@telefono", SqlDbType.NChar)
            oComman.Parameters.Add("@email", SqlDbType.NChar)
            oComman.Parameters.Add("@distrito", SqlDbType.Char)
            oComman.Connection.Open()

            For Each x As clientetb In listadeCliente
                oComman.Parameters("@id").Value = capturarIdfinal()
                oComman.Parameters("@nombre").Value = x.NOMBRE
                oComman.Parameters("@paterno").Value = x.PATERNO
                oComman.Parameters("@materno").Value = x.MATERNO
                oComman.Parameters("@direccion").Value = x.DIRECCION
                oComman.Parameters("@telefono").Value = x.TELEFONO
                oComman.Parameters("@email").Value = x.EMAIL
                oComman.Parameters("@distrito").Value = x.DISTRITO

                oComman.ExecuteNonQuery()
            Next
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo insertar los cliente", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Private Function capturarIdfinal() As Char
        Dim oComman = New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "SELECT MAX(Clie_id) FROM tb_client"
            oComman.Connection.Open()

            Dim ultimoId As Object = oComman.ExecuteScalar()
            If ultimoId Is Nothing Then
                ultimoId = 1
            Else
                ultimoId += 1
            End If
            Return Convert.ToChar(ultimoId)
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se pudo recuperar el registro", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Function
    Public Sub insertarCliente(ByVal oCliente As clientetb)
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "INSERT INTO tb_client VALUES (@id,@nombre,@paterno,@materno,@direccion,@email,@telefono,@distrito)"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Parameters.Add("@nombre", SqlDbType.NChar)
            oComman.Parameters.Add("@paterno", SqlDbType.NChar)
            oComman.Parameters.Add("@materno", SqlDbType.NChar)
            oComman.Parameters.Add("@direccion", SqlDbType.NChar)
            oComman.Parameters.Add("@telefono", SqlDbType.NChar)
            oComman.Parameters.Add("@email", SqlDbType.NChar)
            oComman.Parameters.Add("@distrito", SqlDbType.Char)
            oComman.Connection.Open()


            oComman.Parameters("@id").Value = capturarIdfinal()
            oComman.Parameters("@nombre").Value = oCliente.NOMBRE
            oComman.Parameters("@paterno").Value = oCliente.PATERNO
            oComman.Parameters("@materno").Value = oCliente.MATERNO
            oComman.Parameters("@direccion").Value = oCliente.DIRECCION
            oComman.Parameters("@telefono").Value = oCliente.TELEFONO
            oComman.Parameters("@email").Value = oCliente.EMAIL
            oComman.Parameters("@distrito").Value = oCliente.DISTRITO

            oComman.ExecuteNonQuery()
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se pudo insertar el cliente", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
End Class