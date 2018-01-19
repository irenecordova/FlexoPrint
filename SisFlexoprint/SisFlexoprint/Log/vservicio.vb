Public Class vservicio
    Dim idetiqueta As Integer
    Dim arte As String
    Dim precioventa, medidax, mediday, diametro As Double

    'Setter and getter

    Public Property gidetiqueta
        Get
            Return idetiqueta
        End Get
        Set(ByVal value)
            idetiqueta = value
        End Set
    End Property

    Public Property garte
        Get
            Return arte
        End Get
        Set(ByVal value)
            arte = value
        End Set
    End Property

    Public Property gprecioventa
        Get
            Return precioventa
        End Get
        Set(ByVal value)
            precioventa = value
        End Set
    End Property

    Public Property gmedidax
        Get
            Return medidax
        End Get
        Set(ByVal value)
            medidax = value
        End Set
    End Property

    Public Property gmediday
        Get
            Return mediday
        End Get
        Set(ByVal value)
            mediday = value
        End Set
    End Property

    Public Property gdiametro
        Get
            Return diametro
        End Get
        Set(ByVal value)
            diametro = value
        End Set
    End Property

    'Constructores

    Public Sub New()

    End Sub

    Public Sub New(ByVal idetiqueta As Integer, ByVal arte As String, ByVal precioventa As Double, ByVal medidax As Double, ByVal mediday As Double, ByVal diametro As Double)
        gidetiqueta = idetiqueta
        garte = arte
        gprecioventa = precioventa
        gmedidax = medidax
        gmediday = mediday
        gdiametro = diametro
    End Sub
End Class