

Imports System.IO

Public Class Form1
    Public x, y As Integer
    Public StartPos, Lastpos As Integer
    Public Mdown As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim PicPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        ' *********************************************************************************
        ' Colocamos un panel sobre el layout para que no se vea la barra de desplazamiento.
        ' *********************************************************************************
        Panel1.Left = FlowLayoutPanel1.Left
        Panel1.Width = FlowLayoutPanel1.Width
        Panel1.Height = 50
        Panel1.Top = FlowLayoutPanel1.Top + FlowLayoutPanel1.Height - 50
        ' *********************************************************************************
        ' Cargamos 
        ' *********************************************************************************
        LoadLayoutImage(PicPath & "\cibaria\1.jpg", 1)
        LoadLayoutImage(PicPath & "\cibaria\2.jpg", 2)
        LoadLayoutImage(PicPath & "\cibaria\3.jpg", 3)
        LoadLayoutImage(PicPath & "\cibaria\4.jpg", 4)
        LoadLayoutImage(PicPath & "\cibaria\5.jpg", 5)
        LoadLayoutImage(PicPath & "\cibaria\6.jpg", 6)
        LoadLayoutImage(PicPath & "\cibaria\7.jpg", 7)
        LoadLayoutImage(PicPath & "\cibaria\8.jpg", 8)
        LoadLayoutImage(PicPath & "\cibaria\9.jpg", 9)
        LoadLayoutImage(PicPath & "\cibaria\10.jpg", 10)

        LoadLayoutImage(PicPath & "\cibaria\12.jpg", 12)
        LoadLayoutImage(PicPath & "\cibaria\13.jpg", 13)
        LoadLayoutImage(PicPath & "\cibaria\14.jpg", 14)
        LoadLayoutImage(PicPath & "\cibaria\15.jpg", 15)
        LoadLayoutImage(PicPath & "\cibaria\16.jpg", 16)
        LoadLayoutImage(PicPath & "\cibaria\18.jpg", 18)
        LoadLayoutImage(PicPath & "\cibaria\17.jpg", 17)
        LoadLayoutImage(PicPath & "\cibaria\11.jpg", 11)

    End Sub




    Sub PanelMouseDown()
        Dim MPos As Integer = Cursor.Position.X
        Lastpos = MPos
        Mdown = True
        StartPos = MPos + FlowLayoutPanel1.HorizontalScroll.Value

    End Sub
    Sub PanelMouseMove()
        Dim MPos As Integer = Cursor.Position.X
        Dim dif As Integer = (MPos - StartPos) * -1
        If mdown Then
            If dif > 0 Then
                FlowLayoutPanel1.HorizontalScroll.Value = dif
            End If

        End If
        Label3.Text = MPos
    End Sub

    Sub PanelMouseUp()
        Mdown = False
    End Sub

#Region "FlowLayoutPanel"

    ' ************************************************************************************************************************
    Private Sub FlowLayoutPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles FlowLayoutPanel1.MouseDown
        PanelMouseDown()

    End Sub
    Private Sub FlowLayoutPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles FlowLayoutPanel1.MouseMove
        PanelMouseMove()
    End Sub

    Private Sub FlowLayoutPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles FlowLayoutPanel1.MouseUp
        PanelMouseUp()
    End Sub
    '*************************************************************************************************************************
#End Region


    Sub LoadLayoutImage(ByVal fname As String, ByVal number As Integer)

        Dim pbx As New PictureBox
        pbx.SizeMode = PictureBoxSizeMode.StretchImage
        pbx.BackColor = Color.White
        pbx.Name = "Picture_" + Trim(Str(number))
        'pbx.Width = 400
        'pbx.Height = 266
        pbx.Width = 350
        pbx.Height = pbx.Width / 3 * 3
        pbx.Image = Image.FromFile(fname)
        AddHandler pbx.Click, AddressOf PictureBox_Click
        AddHandler pbx.MouseDown, AddressOf PictureBox_MouseDown
        AddHandler pbx.MouseUp, AddressOf PictureBox_MouseUp
        AddHandler pbx.MouseMove, AddressOf PictureBox_MouseMove
        FlowLayoutPanel1.Controls.Add(pbx)

    End Sub



    Sub GetDirPictures()

        Dim TheFilePath As String

        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            TheFilePath = fbd.SelectedPath
            Try
                For Each F As String In System.IO.Directory.GetFiles(fbd.SelectedPath)
                    Dim NewImage As Image = Image.FromFile(F)
                    NewImage = NewImage.GetThumbnailImage(150, 100, AddressOf Abort, System.IntPtr.Zero)
                    Dim P As New PictureBox
                    P.SizeMode = PictureBoxSizeMode.AutoSize
                    P.Image = NewImage
                    AddHandler P.Click, AddressOf PictureBox_Click
                    FlowLayoutPanel1.Controls.Add(P)
                    ' ListBox1.Items.Add(System.IO.Path.GetFileName(F))
                Next
            Catch ex As Exception

            End Try

        End If

    End Sub
    Sub PictureBox_Click(sender As Object, e As MouseEventArgs)


        If StartPos = Lastpos Then

        End If

    End Sub
    Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs)

        PanelMouseDown()
    End Sub

    Sub PictureBox_MouseUp(sender As Object, e As MouseEventArgs)
        PanelMouseUp()

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs)
        PanelMouseMove()
    End Sub
    Private Function Abort()
        Return False
    End Function





End Class
