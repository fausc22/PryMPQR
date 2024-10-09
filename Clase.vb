Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Security.Policy
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO


Public Class Clase
    Public Shared Async Function EnviarCobro(ByVal userId As Integer, ByVal externalStoreId As String, ByVal externalId As String, ByVal token As String, ByVal Monto As Decimal) As Task(Of Boolean)
        Dim Enviado As Boolean = False
        ' URL de la solicitud
        Dim url As String = "https://api.mercadopago.com/instore/qr/seller/collectors/" & userId & "/stores/" & externalStoreId & "/pos/" & externalId & "/orders?access_token=" & token




        ' Body de la solicitud
        Dim bodyData As New With {
        .description = "Item de prueba",
        .external_reference = "1",
        .items = New Object() {New With {
            .sku_number = "1",
            .category = "1",
            .title = "Item de prueba",
            .description = "Este es un Item de prueba",
            .unit_price = Monto,
            .quantity = 1,
            .unit_measure = "unit",
            .total_amount = Monto
        }},
        .notification_url = "https://b011-190-210-192-8.ngrok-free.app/notificacionesMP/webhook.php", 'LINK DEL SCRIPT DEL SERVIDOR
        .title = "Item de prueba",
        .total_amount = Monto
    }

        Dim body As String = JsonConvert.SerializeObject(bodyData)

        ' Crear cliente HttpClient
        Using client As New HttpClient()
            ' Configurar encabezados
            Dim request As New HttpRequestMessage(HttpMethod.Put, url)
            request.Headers.Add("Authorization", "Bearer " & token)
            request.Headers.Add("Accept", "application/json")
            request.Content = New StringContent(body, Encoding.UTF8, "application/json")

            ' Enviar solicitud
            Dim response As HttpResponseMessage = Await client.SendAsync(request)

            ' Verificar el código de estado
            If response.IsSuccessStatusCode Then
                Enviado = True
            Else
                MessageBox.Show(Await response.Content.ReadAsStringAsync())
                Enviado = False
            End If
        End Using
        Return Enviado
    End Function




    'Funciion para verificar el estado del PAGO
    Public Async Function VerificarEstadoPagoAsync(ByVal userId As Integer, ByVal externalId As String, ByVal token As String) As Task(Of Boolean)
        Dim url As String = "https://api.mercadopago.com/instore/qr/seller/collectors/" & userId & "/pos/" & externalId & "/orders?access_token=" & token
        Dim EstadoPago As Boolean = False
        ' Realizar solicitudes GET periódicas
        While Not EstadoPago
            Try
                Using client As New HttpClient()
                    Dim response As HttpResponseMessage = Await client.GetAsync(url)
                    If response.IsSuccessStatusCode Then
                        ' Pago sigue en proceso
                        EstadoPago = False
                    Else
                        ' Pago completado
                        EstadoPago = True
                        Exit While ' Salir del bucle
                    End If
                End Using
            Catch ex As Exception
                ' Manejar errores
                MessageBox.Show($"Error al verificar el estado del pago: {ex.Message}")
            End Try
            ' Esperar un tiempo antes de la siguiente verificación
            Await Task.Delay(TimeSpan.FromSeconds(3)) ' Esperar 10 segundos entre solicitudes
        End While
        Return EstadoPago
    End Function



    'FUNCION PARA BUSCAR EL LINK DE LA ORDEN DENTRO DEL SCRIPT DEL SERVIDOR, Y LO GUARDA EN UN STRING PARA LUEGO UTILIZARLO EN OTRA FUNCION
    Public Async Function ObtenerNotificacion() As Task(Of String)

        'LINK DEL SCRIPT EN EL SERVIDOR (search)
        Dim url As String = "https://b011-190-210-192-8.ngrok-free.app/notificacionesMP/search.php"


        Dim resourceLink As String = ""
        Dim recibido As Boolean = False

        While Not recibido
            Try
                Using client As New HttpClient()
                    Dim response As HttpResponseMessage = Await client.GetAsync(url)
                    If response.IsSuccessStatusCode Then
                        Dim json As String = Await response.Content.ReadAsStringAsync()

                        Dim notifications As JArray = JArray.Parse(json)

                        If notifications.Count > 0 AndAlso CType(notifications(0), JObject).ContainsKey("resource") Then
                            Dim firstResource As String = notifications(0)("resource").ToString()
                            resourceLink = firstResource
                            recibido = True
                            Return resourceLink
                        Else
                            ' Si no contiene "resource", continuar el bucle
                            recibido = False
                        End If

                    Else
                        recibido = False
                    End If
                End Using
            Catch ex As Exception
                ' Manejar errores
                MessageBox.Show($"Error al verificar el estado del pago: {ex.Message}")
            End Try
            Await Task.Delay(TimeSpan.FromSeconds(3)) ' Esperar 10 segundos entre solicitudes
        End While

        Return resourceLink

    End Function



    'FUNCION QUE UTILIZA EL LINK DE NOTIFICACION DE LA ORDEN DE MERCADO PAGO, Y ENVIA EL MENSAJE A LA INTERFAZ SEGUN EL ESTADO FINAL DE LA TRANSACCION
    Public Async Function ResultadoOrden(ByVal link As String, ByVal token As String) As Task(Of String)
        Dim label As String = ""
        Dim url As String = link & "?access_token=" & token
        Dim recibido As Boolean = False

        While Not recibido
            Try
                Using client As New HttpClient()
                    Dim response As HttpResponseMessage = Await client.GetAsync(url)

                    If response.IsSuccessStatusCode Then
                        ' Leer el JSON de la respuesta
                        Dim json As String = Await response.Content.ReadAsStringAsync()

                        ' Deserializar el JSON para trabajar con él
                        Dim paymentInfo As JObject = JObject.Parse(json)

                        ' Acceder al array 'payments' dentro del JSON
                        Dim payments As JArray = paymentInfo("payments")

                        ' Verificar el estado del primer pago (asumiendo que solo hay uno)
                        If payments.Any() Then

                            Dim status As String = payments(0)("status").ToString()

                            ' Determinar el mensaje según el estado del pago
                            If status = "approved" Then
                                label = "approved"
                                recibido = True
                            ElseIf status = "rejected" Then
                                label = "rejected"
                                recibido = True

                            End If
                        Else
                            recibido = False

                        End If
                    Else
                        ' Manejar error de solicitud HTTP
                        Return "Error al obtener el estado del pago (HTTP " & response.StatusCode.ToString() & ")"
                    End If
                End Using
            Catch ex As Exception
                ' Manejar errores
                Return $"Error al verificar el estado del pago: {ex.Message}"
            End Try
            Await Task.Delay(TimeSpan.FromSeconds(3)) ' Esperar 10 segundos entre solicitudes
        End While

        Return label
    End Function


    'Funcion para cancelar el PAGO
    Public Shared Async Function CancelarCobro(ByVal token As String, ByVal userId As Integer, ByVal externalStoreId As String) As Task(Of Boolean)
        Dim CobroCancelado As Boolean = False
        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & token)

            Dim url As String = $"https://api.mercadopago.com/instore/qr/seller/collectors/{userId}/pos/{externalStoreId}/orders"
            Dim response As HttpResponseMessage = Await client.DeleteAsync(url)

            If response.IsSuccessStatusCode Then
                CobroCancelado = True
            Else
                ' Manejar el caso en que la cancelación no fue exitosa
                MessageBox.Show("ERROR AL CANCELAR EL PAGO")
            End If
        End Using
        Return CobroCancelado
    End Function




    Public Function ObtenerImagenQR(ByVal accessToken As String, ByVal externalId As String) As String
        Try
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " & accessToken)
                Dim response As HttpResponseMessage = client.GetAsync($"https://api.mercadopago.com/pos?{externalId}").Result

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = response.Content.ReadAsStringAsync().Result
                    Dim jsonResponse As JObject = JObject.Parse(responseBody)
                    Dim resultsArray As JArray = DirectCast(jsonResponse("results"), JArray)

                    If resultsArray.Count > 0 Then
                        Dim qrImageUrl As String = resultsArray(1)("qr")("image").ToString()
                        Return qrImageUrl
                    Else
                        MessageBox.Show("No se encontraron resultados.")
                        Return Nothing
                    End If
                Else
                    MessageBox.Show($"Failed to get store data. Status code: {response.StatusCode}")
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al obtener la imagen QR: {ex.Message}")
            Return Nothing
        End Try
    End Function


    Public Shared Sub ImagenQr(ByVal imagenUrl As String, ByVal pb As PictureBox)
        ' Descargar la imagen
        Using webClient As New WebClient()
            Dim imageData As Byte() = webClient.DownloadData(imagenUrl)
            Using ms As New System.IO.MemoryStream(imageData)
                ' Crear una imagen desde los datos descargados
                Dim image As Image = Image.FromStream(ms)
                ' Mostrar la imagen en el PictureBox
                pb.Image = image
            End Using
        End Using
    End Sub


    'FUNCION PARA ELIMINAR EL CACHE DE LA ORDEN ANTERIOR
    Public Async Function EliminarNotificacion() As Task
        ' URL del script en el servidor para eliminar notificaciones
        Dim url As String = "https://b011-190-210-192-8.ngrok-free.app/notificacionesMP/delete.php"

        Try
            Using client As New HttpClient()
                ' Crear solicitud DELETE
                Dim response As HttpResponseMessage = Await client.DeleteAsync(url)

                ' Verificar el código de estado
                If response.IsSuccessStatusCode Then
                    ' Operación exitosa
                    MessageBox.Show("Notificación eliminada correctamente.")
                Else
                    ' Manejar errores según sea necesario
                    MessageBox.Show($"Error al eliminar notificación: {response.StatusCode}")
                End If
            End Using
        Catch ex As Exception
            ' Manejar errores
            MessageBox.Show($"Error al enviar solicitud DELETE: {ex.Message}")
        End Try
    End Function



End Class
