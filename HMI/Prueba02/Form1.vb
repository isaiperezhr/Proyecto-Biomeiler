﻿Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    ' Variables para los datos
    Dim Tiempo As Double
    Dim HumidityAmb As Double
    Dim HumidityLow As Double
    Dim HumidityHigh As Double
    Dim TemperatureAmb As Double
    Dim pH As Double
    Dim FlowRate As Double

    ' Variables para manejar la actualización de gráficas
    Dim graficasActualizadas As Boolean = False
    Dim buffer As String = ""  ' Buffer para datos incompletos

    Private Sub BotonDeterminarConexion_Click(sender As Object, e As EventArgs) Handles BotonDeterminarConexion.Click
        ComboPuertos.Items.Clear()
        For Each PuertoDisponible As String In My.Computer.Ports.SerialPortNames
            ComboPuertos.Items.Add(PuertoDisponible)
        Next
        If ComboPuertos.Items.Count > 0 Then
            ComboPuertos.Text = ComboPuertos.Items(0)
            MessageBox.Show("SELECCIONAR EL PUERTO DESEADO")
            BotonConectar.Enabled = True
            BotonConectar.BackColor = Color.Green
        Else
            MessageBox.Show("NINGUN PUERTO ENCONTRADO")
            BotonConectar.Enabled = False
            ComboPuertos.Items.Clear()
            ComboPuertos.Text = " "
        End If
    End Sub

    Private Sub BotonConectar_Click(sender As Object, e As EventArgs) Handles BotonConectar.Click
        If BotonConectar.Text = "CONECTAR" Then
            BotonConectar.BackColor = Color.Red
            BotonConectar.Text = "DESCONECTAR"
            Timer1.Enabled = True
            BotonControlBomba.Enabled = True
            BotonControlBomba.BackColor = Color.Green
            SerialPort1.PortName = ComboPuertos.Text
            SerialPort1.DtrEnable = True ' Habilita el handshake DTR
            SerialPort1.Open()
        Else
            BotonConectar.BackColor = Color.Green
            BotonConectar.Text = "CONECTAR"
            Timer1.Enabled = False
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        End If
    End Sub

    Private Sub BotonControlBomba_Click(sender As Object, e As EventArgs) Handles BotonControlBomba.Click
        If SerialPort1.IsOpen Then
            If BotonControlBomba.Text = "Encender Bomba" Then
                ' Enviar comando al Arduino para encender la bomba
                SerialPort1.WriteLine("ENCENDER_BOMBA")
                BotonControlBomba.Text = "Apagar Bomba"
                BotonControlBomba.BackColor = Color.Red
            Else
                ' Enviar comando al Arduino para apagar la bomba
                SerialPort1.WriteLine("APAGAR_BOMBA")
                BotonControlBomba.Text = "Encender Bomba"
                BotonControlBomba.BackColor = Color.Green
            End If
        Else
            MessageBox.Show("Puerto serial no conectado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Verifica si hay datos disponibles en el puerto serial
        If SerialPort1.IsOpen AndAlso SerialPort1.BytesToRead > 0 Then
            Try
                ' Lee los datos disponibles
                Dim data As String = SerialPort1.ReadExisting()
                buffer &= data ' Añade los datos leídos al buffer

                ' Verifica si el buffer contiene una línea completa de datos
                If buffer.Contains(vbLf) Then
                    Dim lines() As String = buffer.Split(New String() {vbLf}, StringSplitOptions.None)
                    For i As Integer = 0 To lines.Length - 2 ' Procesar todas las líneas completas
                        Dim dataLine As String = lines(i).Trim()
                        If dataLine.Split(",").Length = 7 Then ' Verificar si la línea es válida
                            ParseData(dataLine)
                            graficasActualizadas = True
                        End If
                    Next
                    buffer = lines.Last() ' Mantener cualquier dato incompleto en el buffer
                End If
            Catch ex As Exception
                ' Manejo de errores si es necesario
            End Try
        End If

        ' Actualiza las gráficas si es necesario
        If graficasActualizadas Then
            ActualizarGraficas()
            graficasActualizadas = False
        End If
    End Sub

    Private Sub ParseData(data As String)
        ' Dividir por coma para obtener cada valor
        Dim values() As String = data.Split(",")

        ' Verificar si los datos recibidos tienen la cantidad correcta de valores
        If values.Length = 7 Then
            Tiempo = Val(values(0))
            HumidityAmb = Val(values(1))
            TemperatureAmb = Val(values(2))
            HumidityLow = Val(values(3))
            HumidityHigh = Val(values(4))
            FlowRate = Val(values(5))
            pH = Val(values(6))
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 50

        ' Configura el chart cuando se carga el formulario
        ChartHumidity.Series.Clear()
        ChartTemp.Series.Clear()
        ChartFlow.Series.Clear()
        ChartpH.Series.Clear()

        ' Agregar las series de gráficos
        AgregarSeriesGraficas()
    End Sub

    Private Sub AgregarSeriesGraficas()
        ' Configuración de series para cada gráfica
        ChartHumidity.Series.Add(CrearSerie("HumidityAmb", Color.Green))
        ChartHumidity.Series.Add(CrearSerie("HumidityLow", Color.Blue))
        ChartHumidity.Series.Add(CrearSerie("HumidityHigh", Color.Red))
        ChartTemp.Series.Add(CrearSerie("TemperatureAmb", Color.Red))

        ' Etiquetas de los ejes
        ChartHumidity.ChartAreas(0).AxisX.Title = "Tiempo (s)"
        ChartHumidity.ChartAreas(0).AxisY.Title = "Humedad (%)"

        ChartTemp.ChartAreas(0).AxisX.Title = "Tiempo (s)"
        ChartTemp.ChartAreas(0).AxisY.Title = "Temperatura (°C)"

        ChartFlow.ChartAreas(0).AxisX.Title = "Tiempo (s)"
        ChartFlow.ChartAreas(0).AxisY.Title = "Flujo (L/min)"

        ChartpH.ChartAreas(0).AxisX.Title = "Tiempo (s)"
        ChartpH.ChartAreas(0).AxisY.Title = "pH"
    End Sub

    Private Function CrearSerie(nombre As String, color As Color) As Series
        Dim serie As New Series(nombre)
        serie.ChartType = SeriesChartType.Line
        serie.BorderWidth = 2
        serie.Color = color
        Return serie
    End Function

    Private Sub ActualizarGraficas()
        ' Añadir datos a la Chart Humidity
        ChartHumidity.Series("HumidityAmb").Points.AddXY(Tiempo, HumidityAmb)
        ChartHumidity.Series("HumidityLow").Points.AddXY(Tiempo, HumidityLow)
        ChartHumidity.Series("HumidityHigh").Points.AddXY(Tiempo, HumidityHigh)

        ' Añadir datos a la Chart Temp
        ChartTemp.Series("TemperatureAmb").Points.AddXY(Tiempo, TemperatureAmb)
    End Sub
End Class