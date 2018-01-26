Imports System.ComponentModel

Public Class frmservicio
    Private dt As New DataTable
    Dim save_edit As New Integer

    Private Sub bloqueartext()
        txtprecio.BorderStyle = BorderStyle.None
        txtarte.BorderStyle = BorderStyle.None
        txtmedidax.BorderStyle = BorderStyle.None
        txtmediday.BorderStyle = BorderStyle.None
        txtdiametro.BorderStyle = BorderStyle.None

        txtprecio.ReadOnly = True
        txtarte.ReadOnly = True
        txtmedidax.ReadOnly = True
        txtmediday.ReadOnly = True
        txtdiametro.ReadOnly = True
    End Sub

    Private Sub bloquearbtn()
        btnguardar.Enabled = False
        btncancelar.Enabled = False
        btneliminar.Enabled = False
        btneditar.Enabled = False
        btnnuevo.Enabled = False
    End Sub

    Private Sub desbloqueartext()
        txtprecio.BorderStyle = BorderStyle.FixedSingle
        txtarte.BorderStyle = BorderStyle.FixedSingle
        txtmedidax.BorderStyle = BorderStyle.FixedSingle
        txtmediday.BorderStyle = BorderStyle.FixedSingle
        txtdiametro.BorderStyle = BorderStyle.FixedSingle

        txtprecio.ReadOnly = False
        txtarte.ReadOnly = False
        txtmedidax.ReadOnly = False
        txtmediday.ReadOnly = False
        txtdiametro.ReadOnly = False
    End Sub

    Private Sub desbloquearbtn()
        btnguardar.Enabled = True
        btncancelar.Enabled = True
        btneliminar.Enabled = True
        btneditar.Enabled = True
        btnnuevo.Enabled = True
    End Sub

    Private Sub frmcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        bloqueartext()
        bloquearbtn()
        btnnuevo.Enabled = True
    End Sub

    Private Sub mostrar()
        Try
            Dim func As New fservicio
            dt = func.mostrar()

            If dt.Rows.Count <> 0 Then
                dgvlistado.DataSource = dt
                txtbuscar.Enabled = True
                dgvlistado.ColumnHeadersVisible = True
                modificar_columnas()
            Else
                dgvlistado.DataSource = Nothing
                txtbuscar.Enabled = False
                dgvlistado.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mostrarColor()
        Try
            Dim dts As New vcolor
            Dim func As New fcolor

            dts.gidetiqueta = dgvlistado.SelectedCells.Item(0).Value

            dt = func.mostrar(dts)

            If dt.Rows.Count <> 0 Then
                dgvcolores.DataSource = dt
                txtbuscar.Enabled = True
                dgvcolores.ColumnHeadersVisible = True
                modificar_columnas()
            Else
                dgvcolores.DataSource = Nothing
                txtbuscar.Enabled = False
                dgvcolores.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub modificar_columnas()

        dgvlistado.CurrentRow.Selected = False

        'Ocultas
        dgvlistado.Columns("idetiqueta").Visible = False
        dgvlistado.Columns("precioventa").Visible = False
        dgvcolores.Columns("idetiqueta").Visible = False

        'Visibles

        dgvlistado.Columns("arte").HeaderText = "Arte"
        dgvlistado.Columns("arte").Width = 200

        dgvlistado.Columns("medidax").HeaderText = "Medida X"
        dgvlistado.Columns("medidax").Width = 60

        dgvlistado.Columns("mediday").HeaderText = "Medida Y"
        dgvlistado.Columns("mediday").Width = 60

        dgvlistado.Columns("diametro").HeaderText = "Diámetro"
        dgvlistado.Columns("diametro").Width = 60


        dgvcolores.Columns("codigoColor").HeaderText = "Código Color"
        dgvcolores.Columns("codigoColor").Width = 380



    End Sub

    Private Sub buscar()
        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = "arte like '" & txtbuscar.Text & "%'"

            If dv.Count <> 0 Then
                dgvlistado.DataSource = dv
                modificar_columnas()
            Else
                dgvlistado.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub limpiar()
        txtprecio.Text = ""
        txtarte.Text = ""
        txtmedidax.Text = ""
        txtmediday.Text = ""
        txtdiametro.Text = ""
    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged
        buscar()
    End Sub

    Private Sub dgvlistado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlistado.CellClick
        limpiar()

        txtidetiqueta.Text = dgvlistado.SelectedCells.Item(0).Value.ToString
        txtarte.Text = dgvlistado.SelectedCells.Item(1).Value.ToString
        txtprecio.Text = dgvlistado.SelectedCells.Item(2).Value.ToString
        txtmedidax.Text = dgvlistado.SelectedCells.Item(3).Value.ToString
        txtmediday.Text = dgvlistado.SelectedCells.Item(4).Value.ToString
        txtdiametro.Text = dgvlistado.SelectedCells.Item(5).Value.ToString


        mostrarColor()
        desbloquearbtn()
        bloqueartext()
        desbloquearbtn()
        btnguardar.Enabled = False
        btncancelar.Enabled = False
    End Sub

    Private Sub dgvlistado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlistado.CellDoubleClick
        If txtbandera.Text = "1" Then
            frmventas.txtidetiqueta.Text = dgvlistado.SelectedCells.Item(0).Value.ToString
            frmventas.txtetiqueta.Text = dgvlistado.SelectedCells.Item(1).Value.ToString
            txtbandera.Text = "0"
            frmcontenedor.pnpantallas.Controls.Clear()
            frmventas.TopLevel = False
            frmventas.Visible = True
            frmcontenedor.pnpantallas.Controls.Add(frmventas)
            frmventas.Show()
            Me.Close()
        End If
    End Sub


    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        limpiar()
        desbloqueartext()
        save_edit = 1
        desbloquearbtn()
        btneditar.Enabled = False
        btneliminar.Enabled = False
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        txtbuscar.Select()
        Dim result As DialogResult

        result = MessageBox.Show("¿Desea eliminar los datos?", "Modificando Datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then

            If Me.ValidateChildren = True And txtprecio.Text <> "" And txtarte.Text <> "" And txtmedidax.Text <> "" Then
                Try
                    Dim dts As New vservicio
                    Dim func As New fservicio

                    dts.gidetiqueta = dgvlistado.SelectedCells.Item(0).Value

                    If func.eliminar(dts) Then
                        MessageBox.Show("Eliminar completado.", "Eliminando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mostrar()
                        limpiar()
                        bloqueartext()
                        bloquearbtn()
                        btnnuevo.Enabled = True
                    Else
                        MessageBox.Show("No se pudo completar la eliminación.", "Eliminando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("Datos incompletos. Llene los campos obligatorios.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        txtbuscar.Select()
        If save_edit = 1 Then
            If Me.ValidateChildren = True And txtprecio.Text <> "" And txtarte.Text <> "" Then
                Try
                    Dim dts As New vservicio
                    Dim func As New fservicio

                    dts.garte = txtarte.Text
                    dts.gprecioventa = txtprecio.Text
                    dts.gmedidax = txtmedidax.Text
                    dts.gmediday = txtmediday.Text
                    dts.gdiametro = txtdiametro.Text

                    If func.ingresar(dts) Then
                        MessageBox.Show("Registro completado.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mostrar()
                        limpiar()
                        bloqueartext()
                        bloquearbtn()
                        btnnuevo.Enabled = True
                    Else
                        MessageBox.Show("No se pudo completar el registro.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("Datos incompletos. Llene los campos obligatorios.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf save_edit = 0 Then
            Dim result As DialogResult

            result = MessageBox.Show("¿Desea modificar los datos?", "Modificando Datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then

                If Me.ValidateChildren = True And txtprecio.Text <> "" And txtarte.Text <> "" And txtmedidax.Text <> "" Then
                    'Try
                    Dim dts As New vservicio
                    Dim func As New fservicio

                    dts.gidetiqueta = dgvlistado.SelectedCells.Item(0).Value
                    dts.garte = txtarte.Text
                    dts.gprecioventa = txtprecio.Text
                    dts.gmedidax = txtmedidax.Text
                    dts.gmediday = txtmediday.Text
                    dts.gdiametro = txtdiametro.Text

                    If func.editar(dts) Then
                        MessageBox.Show("Edición completada.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mostrar()
                        limpiar()
                        bloqueartext()
                        bloquearbtn()
                        btnnuevo.Enabled = True
                    Else
                        MessageBox.Show("No se pudo completar la edición.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    'Catch ex As Exception
                    'MsgBox(ex.Message)
                    'End Try
                Else
                    MessageBox.Show("Datos incompletos. Llene los campos obligatorios.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        desbloqueartext()
        save_edit = 0
        desbloquearbtn()
        btnnuevo.Enabled = False
        btneliminar.Enabled = False
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        txtbuscar.Select()
        bloqueartext()
        bloquearbtn()
        btnnuevo.Enabled = True
    End Sub


    Private Sub btagregarc_Click(sender As Object, e As EventArgs) Handles btagregarc.Click
        If Me.ValidateChildren = True And txtprecio.Text <> "" And txtarte.Text <> "" Then
            Try
                Dim dts As New vcolor
                Dim func As New fcolor



                dts.gidetiqueta = txtidetiqueta.Text
                dts.gcodigoColor = txtcodigoColor.Text

                If func.ingresar(dts) Then
                    mostrar()

                    txtcodigoColor.Text = ""
                    txtidcolor.Text = ""

                Else
                    MessageBox.Show("No se pudo completar el registro", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    mostrar()

                    txtcodigoColor.Text = ""
                    txtidcolor.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Datos incompletos. Llene los campos obligatorios", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btbuscars_Click(sender As Object, e As EventArgs) Handles btbuscars.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            txtcodigoColor.Text = Convert.ToString(ColorDialog1.Color)
        End If
    End Sub
End Class