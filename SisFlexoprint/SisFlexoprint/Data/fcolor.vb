Imports System.Data.SqlClient

Public Class fcolor
    Inherits conexion
    Dim cmd As New SqlCommand

    Public Function mostrar(ByVal dts As vcolor) As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrar_color")
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = cn

            cmd.Parameters.AddWithValue("@idetiqueta", dts.gidetiqueta)

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function ingresar(ByVal dts As vcolor) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("ingresar_color")
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = cn

            cmd.Parameters.AddWithValue("@idetiqueta", dts.gidetiqueta)
            cmd.Parameters.AddWithValue("@codigoColor", dts.gcodigoColor)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

End Class
