<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabelTextBufferInn = New System.Windows.Forms.Label()
        Me.TextoBufferInn = New System.Windows.Forms.TextBox()
        Me.ComboPuertos = New System.Windows.Forms.ComboBox()
        Me.BotonDeterminarConexion = New System.Windows.Forms.Button()
        Me.BotonConectar = New System.Windows.Forms.Button()
        Me.ChartHumidity = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartTemp = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartFlow = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartpH = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BotonControlBomba = New System.Windows.Forms.Button()
        CType(Me.ChartHumidity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartFlow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartpH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 500000
        '
        'Timer1
        '
        '
        'LabelTextBufferInn
        '
        Me.LabelTextBufferInn.AutoSize = True
        Me.LabelTextBufferInn.Location = New System.Drawing.Point(12, 9)
        Me.LabelTextBufferInn.Name = "LabelTextBufferInn"
        Me.LabelTextBufferInn.Size = New System.Drawing.Size(84, 16)
        Me.LabelTextBufferInn.TabIndex = 0
        Me.LabelTextBufferInn.Text = "TextBufferInn"
        '
        'TextoBufferInn
        '
        Me.TextoBufferInn.Location = New System.Drawing.Point(15, 28)
        Me.TextoBufferInn.Multiline = True
        Me.TextoBufferInn.Name = "TextoBufferInn"
        Me.TextoBufferInn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextoBufferInn.Size = New System.Drawing.Size(165, 250)
        Me.TextoBufferInn.TabIndex = 3
        '
        'ComboPuertos
        '
        Me.ComboPuertos.FormattingEnabled = True
        Me.ComboPuertos.Location = New System.Drawing.Point(15, 284)
        Me.ComboPuertos.Name = "ComboPuertos"
        Me.ComboPuertos.Size = New System.Drawing.Size(165, 24)
        Me.ComboPuertos.TabIndex = 6
        '
        'BotonDeterminarConexion
        '
        Me.BotonDeterminarConexion.Location = New System.Drawing.Point(15, 314)
        Me.BotonDeterminarConexion.Name = "BotonDeterminarConexion"
        Me.BotonDeterminarConexion.Size = New System.Drawing.Size(165, 64)
        Me.BotonDeterminarConexion.TabIndex = 7
        Me.BotonDeterminarConexion.Text = "DETERMINAR CONEXIÓN"
        Me.BotonDeterminarConexion.UseVisualStyleBackColor = True
        '
        'BotonConectar
        '
        Me.BotonConectar.Enabled = False
        Me.BotonConectar.Location = New System.Drawing.Point(15, 384)
        Me.BotonConectar.Name = "BotonConectar"
        Me.BotonConectar.Size = New System.Drawing.Size(165, 64)
        Me.BotonConectar.TabIndex = 8
        Me.BotonConectar.Text = "CONECTAR"
        Me.BotonConectar.UseVisualStyleBackColor = True
        '
        'ChartHumidity
        '
        Me.ChartHumidity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.ChartHumidity.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ChartHumidity.Legends.Add(Legend1)
        Me.ChartHumidity.Location = New System.Drawing.Point(3, 3)
        Me.ChartHumidity.Name = "ChartHumidity"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartHumidity.Series.Add(Series1)
        Me.ChartHumidity.Size = New System.Drawing.Size(288, 237)
        Me.ChartHumidity.TabIndex = 12
        Me.ChartHumidity.Text = "Chart1"
        '
        'ChartTemp
        '
        Me.ChartTemp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Name = "ChartArea1"
        Me.ChartTemp.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.ChartTemp.Legends.Add(Legend2)
        Me.ChartTemp.Location = New System.Drawing.Point(297, 3)
        Me.ChartTemp.Name = "ChartTemp"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartTemp.Series.Add(Series2)
        Me.ChartTemp.Size = New System.Drawing.Size(288, 237)
        Me.ChartTemp.TabIndex = 13
        Me.ChartTemp.Text = "Chart1"
        '
        'ChartFlow
        '
        Me.ChartFlow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea3.Name = "ChartArea1"
        Me.ChartFlow.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.ChartFlow.Legends.Add(Legend3)
        Me.ChartFlow.Location = New System.Drawing.Point(3, 246)
        Me.ChartFlow.Name = "ChartFlow"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.ChartFlow.Series.Add(Series3)
        Me.ChartFlow.Size = New System.Drawing.Size(288, 238)
        Me.ChartFlow.TabIndex = 14
        Me.ChartFlow.Text = "Chart1"
        '
        'ChartpH
        '
        Me.ChartpH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea4.Name = "ChartArea1"
        Me.ChartpH.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.ChartpH.Legends.Add(Legend4)
        Me.ChartpH.Location = New System.Drawing.Point(297, 246)
        Me.ChartpH.Name = "ChartpH"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.ChartpH.Series.Add(Series4)
        Me.ChartpH.Size = New System.Drawing.Size(288, 238)
        Me.ChartpH.TabIndex = 15
        Me.ChartpH.Text = "Chart1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ChartpH, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ChartTemp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ChartFlow, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ChartHumidity, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(200, 28)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(588, 487)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'BotonControlBomba
        '
        Me.BotonControlBomba.Enabled = False
        Me.BotonControlBomba.Location = New System.Drawing.Point(15, 454)
        Me.BotonControlBomba.Name = "BotonControlBomba"
        Me.BotonControlBomba.Size = New System.Drawing.Size(165, 61)
        Me.BotonControlBomba.TabIndex = 17
        Me.BotonControlBomba.Text = "Encender Bomba"
        Me.BotonControlBomba.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 536)
        Me.Controls.Add(Me.BotonControlBomba)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.BotonConectar)
        Me.Controls.Add(Me.BotonDeterminarConexion)
        Me.Controls.Add(Me.ComboPuertos)
        Me.Controls.Add(Me.TextoBufferInn)
        Me.Controls.Add(Me.LabelTextBufferInn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.ChartHumidity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartFlow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartpH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LabelTextBufferInn As Label
    Friend WithEvents TextoBufferInn As TextBox
    Friend WithEvents ComboPuertos As ComboBox
    Friend WithEvents BotonDeterminarConexion As Button
    Friend WithEvents BotonConectar As Button
    Friend WithEvents ChartHumidity As DataVisualization.Charting.Chart
    Friend WithEvents ChartTemp As DataVisualization.Charting.Chart
    Friend WithEvents ChartFlow As DataVisualization.Charting.Chart
    Friend WithEvents ChartpH As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BotonControlBomba As Button
End Class
