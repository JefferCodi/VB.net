Imports System.Data
Imports System.Data.SqlClient
Imports clientes.entidades


Public Class DistritoDAO
    Inherits claseBaseDAO
    Public Function obtenerLstatdoDistritos() As List(Of distrito)
        Dim oComman As New SqlCommand
        Try
            Dim listadoCliente As List(Of distrito)
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "SELECT Dist_id, Dist_desc FROM tb_distri"
            oComman.Connection.Open()

            Dim oDataRead As SqlDataReader = oComman.ExecuteReader()
            listadoCliente = recuperarListado(oDataRead)
            oDataRead.IsClosed.ToString()
            oComman.Connection.Close()
            Return listadoCliente

        Catch ex As Exception
            Throw New System.AggregateException("No se puedo ejecutar la consuta del distrito", ex)
        End Try
    End Function

    Public Function obtenerListatdoDistritosPorId(ByVal Id As Char) As List(Of distrito)
        Dim oComman As New SqlCommand
        Try
            Dim listadoCliente As List(Of distrito)
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "SELECT Dist_id, Dist_desc FROM tb_distri WHERE Dist_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char).Value = Id
            oComman.Connection.Open()

            Dim oDataRead As SqlDataReader = oComman.ExecuteReader()
            listadoCliente = recuperarListado(oDataRead)
            oDataRead.IsClosed.ToString()
            oComman.Connection.Close()
            Return listadoCliente

        Catch ex As Exception
            Throw New System.AggregateException("No se puedo encontrar al distrito por Id", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Function

    Public Function recuperarListado(ByVal dataReader As SqlDataReader) As List(Of distrito)
        Try
            Dim listadoDistritos As New List(Of distrito)
            While (dataReader.Read)
                Dim x As New distrito
                x.ID = dataReader.GetChar(0)
                x.NOMBRE = dataReader.GetString(1)

                listadoDistritos.Add(x)
            End While
            Return listadoDistritos
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo crear el listado del distrito para consulta", ex)
        End Try
    End Function
    Public Sub actualizarDistrito(ByVal listadeCliente As List(Of distrito))
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "UPDATE tb_client SET  Dist_desc = @nombre WHERE Dist_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Parameters.Add("@nombre", SqlDbType.NChar)

            oComman.Connection.Open()

            For Each x As distrito In listadeCliente
                oComman.Parameters("@id").Value = x.ID
                oComman.Parameters("@nombre").Value = x.NOMBRE
                oComman.ExecuteNonQuery()
            Next
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo actualizar el registro", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Public Sub eliminarDistrito(ByVal listadeCliente As List(Of distrito))
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "DELETE FROM tb_distri WHERE Dist_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Connection.Open()

            For Each x As distrito In listadeCliente
                oComman.Parameters("@id").Value = x.ID
                oComman.ExecuteNonQuery()
            Next

            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo eliminar el distrito", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Public Sub eliminarDistritoporId(ByVal Id As Char)
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "DELETE FROM tb_distri WHERE Dist_id = @id"
            oComman.Parameters.Add("@id", SqlDbType.Char).Value = Id
            oComman.Connection.Open()
            oComman.ExecuteNonQuery()
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se puedo eliminar el distrito por id", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
    Public Sub insertarDistrto(ByVal listadeCliente As List(Of distrito))
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "INSERT INTO tb_distri VALUES (@id,@nombre)"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Parameters.Add("@nombre", SqlDbType.NChar)
            oComman.Connection.Open()

            For Each x As distrito In listadeCliente
                oComman.Parameters("@id").Value = capturarIdfinal()
                oComman.Parameters("@nombre").Value = x.NOMBRE
                oComman.ExecuteNonQuery()
            Next
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se pudo insertar los distrito", ex)
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
            oComman.CommandText = "SELECT MAX(Dist_id) FROM tb_distri"
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
    Public Sub insertarDistrito(ByVal oCliente As distrito)
        Dim oComman As New SqlCommand
        Try
            oComman.Connection = MyBase.ObtenerConexion()
            oComman.CommandText = "INSERT INTO tb_distri VALUES (@id,@nombre)"
            oComman.Parameters.Add("@id", SqlDbType.Char)
            oComman.Parameters.Add("@nombre", SqlDbType.NChar)
            oComman.Connection.Open()

            oComman.Parameters("@id").Value = capturarIdfinal()
            oComman.Parameters("@nombre").Value = oCliente.NOMBRE

            oComman.ExecuteNonQuery()
            oComman.Connection.Close()
        Catch ex As Exception
            Throw New System.AggregateException("No se pudo insertar el distrito", ex)
        Finally
            If oComman.Connection.State = ConnectionState.Open Then
                oComman.Connection.Close()
            End If
        End Try
    End Sub
End Class