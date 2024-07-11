Imports System.ComponentModel
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Newtonsoft.Json.Linq
Imports PryMPQR.Clase


Public Class frmMain

    Private pagoCompletado As Boolean = False ' Variable para controlar si el pago ha sido completado
    Private dotCount As Integer = 0
    Private cls As New Clase()



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Async Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click


        Dim estadoPago As Boolean = False
        Dim token As String = txtToken.Text
        Dim userID = txtUserId.Text
        Dim externalId = txtExternalId.Text
        Dim externalStoreId = txtExternalStoreId.Text
        Dim Monto As Decimal = Decimal.Parse(txtMonto.Text)

        ' Obtener la URL de la imagen QR antes de enviar el cobro
        Dim qrImageUrl As String = cls.ObtenerImagenQR(token, externalId)
        If qrImageUrl IsNot Nothing Then
            cls.ImagenQr(qrImageUrl, pbQr)
        Else
            MessageBox.Show("No se pudo obtener la imagen QR.")
            Return
        End If


        ' Enviar el cobro
        Dim CobroEnviado As Boolean = Await Clase.EnviarCobro(userID, externalStoreId, externalId, token, Monto)
        If CobroEnviado Then


            timeProceso.Enabled = True
            lblProceso.Visible = True

            Dim SePago As Boolean = Await cls.VerificarEstadoPagoAsync(userID, externalId, token)
            If SePago Then
                If lblProceso.Text <> "PAGO CANCELADO" Then
                    timeProceso.Enabled = False
                    lblProceso.ForeColor = Color.Green
                    lblProceso.Text = "Pago completado con éxito"
                End If
                txtMonto.Enabled = True
                txtMonto.Text = ""
            Else
                lblProceso.ForeColor = Color.Red
                lblProceso.Text = "Error al verificar el estado del pago."
            End If
        Else
            MessageBox.Show("Error al enviar el cobro.")
        End If
    End Sub

    Private Async Sub btnCancelarPago_Click(sender As Object, e As EventArgs) Handles btnCancelarPago.Click




        Dim token As String = txtToken.Text

        Dim userID = txtUserId.Text
        Dim externalId = txtExternalId.Text
        Dim externalStoreId = txtExternalStoreId.Text

        Dim PagoCancelado As Boolean = Await Clase.CancelarCobro(token, userID, externalId)

        If PagoCancelado Then
            timeProceso.Enabled = False
            lblProceso.ForeColor = Color.Red
            lblProceso.Text = "PAGO CANCELADO"
            txtMonto.Text = ""
        Else
            Return
        End If
    End Sub

    Private Sub timeProceso_Tick(sender As Object, e As EventArgs) Handles timeProceso.Tick
        dotCount = (dotCount + 1) Mod 4
        Dim dots As String = New String(".", dotCount)
        lblProceso.Text = "Pago en proceso" & dots
    End Sub
End Class
