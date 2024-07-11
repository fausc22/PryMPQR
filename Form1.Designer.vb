<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.button1 = New System.Windows.Forms.Button()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.btnCancelarPago = New System.Windows.Forms.Button()
        Me.gpDatosSucursal = New System.Windows.Forms.GroupBox()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.btnMostrarToken = New System.Windows.Forms.Button()
        Me.label6 = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtExternalId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExternalStoreId = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.timeProceso = New System.Windows.Forms.Timer(Me.components)
        Me.pbQr = New System.Windows.Forms.PictureBox()
        Me.gpDatosSucursal.SuspendLayout()
        CType(Me.pbQr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.button1.Location = New System.Drawing.Point(27, 234)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(138, 38)
        Me.button1.TabIndex = 0
        Me.button1.Text = "SOLICITAR PAGO"
        Me.button1.UseVisualStyleBackColor = False
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(145, 152)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 20)
        Me.txtMonto.TabIndex = 11
        '
        'btnCancelarPago
        '
        Me.btnCancelarPago.BackColor = System.Drawing.Color.Red
        Me.btnCancelarPago.Location = New System.Drawing.Point(171, 234)
        Me.btnCancelarPago.Name = "btnCancelarPago"
        Me.btnCancelarPago.Size = New System.Drawing.Size(138, 38)
        Me.btnCancelarPago.TabIndex = 15
        Me.btnCancelarPago.Text = "CANCELAR PAGO"
        Me.btnCancelarPago.UseVisualStyleBackColor = False
        '
        'gpDatosSucursal
        '
        Me.gpDatosSucursal.Controls.Add(Me.txtMonto)
        Me.gpDatosSucursal.Controls.Add(Me.button1)
        Me.gpDatosSucursal.Controls.Add(Me.Label12)
        Me.gpDatosSucursal.Controls.Add(Me.Label11)
        Me.gpDatosSucursal.Controls.Add(Me.txtExternalId)
        Me.gpDatosSucursal.Controls.Add(Me.btnCancelarPago)
        Me.gpDatosSucursal.Controls.Add(Me.Label4)
        Me.gpDatosSucursal.Controls.Add(Me.txtExternalStoreId)
        Me.gpDatosSucursal.Controls.Add(Me.Label7)
        Me.gpDatosSucursal.Controls.Add(Me.txtUserId)
        Me.gpDatosSucursal.Controls.Add(Me.Label3)
        Me.gpDatosSucursal.Controls.Add(Me.txtToken)
        Me.gpDatosSucursal.Controls.Add(Me.btnMostrarToken)
        Me.gpDatosSucursal.Controls.Add(Me.label6)
        Me.gpDatosSucursal.Location = New System.Drawing.Point(12, 37)
        Me.gpDatosSucursal.Name = "gpDatosSucursal"
        Me.gpDatosSucursal.Size = New System.Drawing.Size(333, 291)
        Me.gpDatosSucursal.TabIndex = 35
        Me.gpDatosSucursal.TabStop = False
        Me.gpDatosSucursal.Text = "INGRESE LOS DATOS"
        '
        'txtToken
        '
        Me.txtToken.Location = New System.Drawing.Point(145, 23)
        Me.txtToken.Name = "txtToken"
        Me.txtToken.Size = New System.Drawing.Size(100, 20)
        Me.txtToken.TabIndex = 22
        Me.txtToken.UseSystemPasswordChar = True
        '
        'btnMostrarToken
        '
        Me.btnMostrarToken.Location = New System.Drawing.Point(251, 23)
        Me.btnMostrarToken.Name = "btnMostrarToken"
        Me.btnMostrarToken.Size = New System.Drawing.Size(70, 22)
        Me.btnMostrarToken.TabIndex = 25
        Me.btnMostrarToken.Text = "MOSTRAR"
        Me.btnMostrarToken.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(24, 26)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(101, 13)
        Me.label6.TabIndex = 23
        Me.label6.Text = "ACCESS TOKEN"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(145, 54)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(100, 20)
        Me.txtUserId.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "USER ID"
        '
        'txtExternalId
        '
        Me.txtExternalId.Location = New System.Drawing.Point(145, 115)
        Me.txtExternalId.Name = "txtExternalId"
        Me.txtExternalId.Size = New System.Drawing.Size(100, 20)
        Me.txtExternalId.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "EXTERNAL ID"
        '
        'txtExternalStoreId
        '
        Me.txtExternalStoreId.Location = New System.Drawing.Point(145, 84)
        Me.txtExternalStoreId.Name = "txtExternalStoreId"
        Me.txtExternalStoreId.Size = New System.Drawing.Size(100, 20)
        Me.txtExternalStoreId.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "EXTERNAL STORE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(79, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(197, 25)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "MERCADO PAGO"
        '
        'lblProceso
        '
        Me.lblProceso.AutoSize = True
        Me.lblProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProceso.ForeColor = System.Drawing.Color.Blue
        Me.lblProceso.Location = New System.Drawing.Point(-2, 604)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(231, 29)
        Me.lblProceso.TabIndex = 38
        Me.lblProceso.Text = "pago en proceso..."
        Me.lblProceso.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(61, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "MONTO"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(128, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 13)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "$"
        '
        'timeProceso
        '
        '
        'pbQr
        '
        Me.pbQr.Location = New System.Drawing.Point(39, 334)
        Me.pbQr.Name = "pbQr"
        Me.pbQr.Size = New System.Drawing.Size(271, 255)
        Me.pbQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbQr.TabIndex = 39
        Me.pbQr.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 642)
        Me.Controls.Add(Me.pbQr)
        Me.Controls.Add(Me.lblProceso)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gpDatosSucursal)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QR"
        Me.gpDatosSucursal.ResumeLayout(False)
        Me.gpDatosSucursal.PerformLayout()
        CType(Me.pbQr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button1 As Button
    Private WithEvents txtMonto As TextBox
    Private WithEvents btnCancelarPago As Button
    Private WithEvents gpDatosSucursal As GroupBox
    Private WithEvents txtExternalId As TextBox
    Private WithEvents Label4 As Label
    Private WithEvents txtExternalStoreId As TextBox
    Private WithEvents Label7 As Label
    Private WithEvents txtUserId As TextBox
    Private WithEvents Label3 As Label
    Private WithEvents txtToken As TextBox
    Private WithEvents btnMostrarToken As Button
    Private WithEvents label6 As Label
    Private WithEvents Label8 As Label
    Private WithEvents lblProceso As Label
    Private WithEvents Label12 As Label
    Private WithEvents Label11 As Label
    Friend WithEvents timeProceso As Timer
    Private WithEvents pbQr As PictureBox
End Class
