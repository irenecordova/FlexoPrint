Public Class vproducto
    Dim idproducto, stock As Integer
    Dim descripcion As String
    Dim precioventa As Double

    'Setter and getter

    Public Property gidproducto
        Get
            Return idproducto
        End Get
        Set(ByVal value)
            idproducto = value
        End Set
    End Property

    Public Property gdescripcion
        Get
            Return descripcion
        End Get
        Set(ByVal value)
            descripcion = value
        End Set
    End Property

    Public Property gstock
        Get
            Return stock
        End Get
        Set(ByVal value)
            stock = value
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

    'Constructores

    Public Sub New()

    End Sub

    Public Sub New(ByVal idproducto As Integer, ByVal descripcion As String, ByVal precioventa As Double, ByVal stock As Integer)
        gidproducto = idproducto
        gdescripcion = descripcion
        gprecioventa = precioventa
        gstock = stock
    End Sub
End Class