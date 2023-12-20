class TPiramid : TRTriangle {
    // Створити клас-нащадок TPiramid (правильна трикутна піраміда) на основі класу TRTriangle.
    // Додати метод знаходження об’єму піраміди та перевизначити відповідні методи.
    public double height;

    public double Height {
        set {
            if (value > EPSILON) {
                height = value;
            } else {
                throw new ArgumentException("height can't be less than or equal to 0");
            }
        }
        get {
            return height;
        }
    }

    public TPiramid() : base() {
        Height = 1;
    }

    public TPiramid(double height, double side) : base(side){
        Height = height;
    }

    public TPiramid(TPiramid copy) : this(copy.height, copy.Side) {
    }

    public double GetVolume() {
        return base.GetArea() * Height / 3;
    } 

    public new double GetArea() {
        var m = Math.Sqrt(Math.Pow(Side * Math.Sqrt(3) / 6, 2) + Height * Height);
        return base.GetArea() + 0.5 * base.GetPerimeter() * m;
    }
    
    public new double GetPerimeter() {
        var edge = Math.Sqrt(Math.Pow(Side * Math.Sqrt(3) / 3, 2) + Height * Height);;
        return base.GetPerimeter() + 3 * edge;
    }

    public new void Print() {
        Print();
        Console.WriteLine($"Height = {Height}");
    }

    public new void Input() {
        Input();
        double heightLen;
        while (true) {
            Console.Write("Height = ");
            var strHeightLen = Console.ReadLine();
            try
            {
                heightLen = double.Parse(strHeightLen);
            }
            catch
            {
                Console.WriteLine("Error: couldn't convert your input <\"{0}\"> to double, try again.", strHeightLen);
                continue;
            }
            if (heightLen < EPSILON)
            {
                Console.WriteLine("Error: height length must be bigger than 0, try again.");
                continue;
            }
            break;
        } 
        Height = heightLen;       
    }

    public static TPiramid operator+(TPiramid p1, TPiramid p2) {
        return new TPiramid(p1.Height + p2.Height, p1.Side + p2.Side);
    }

    public static TPiramid operator-(TPiramid p1, TPiramid p2) {
        return new TPiramid(p1.Height - p2.Height, p1.Side - p2.Side);
    }

    public static TPiramid operator*(TPiramid p, double scalar) {
        return new TPiramid(p.height* scalar, p.Side * scalar);
    }

    public static TPiramid operator*(double scalar, TPiramid p) {
        return new TPiramid(p.height* scalar, p.Side * scalar);

    }

    public static bool operator == (TPiramid p1, TPiramid p2) {
        return Math.Abs(p1.Side - p2.Side) < EPSILON && Math.Abs(p1.Height - p2.Height) < EPSILON ;
    }

    public static bool operator != (TPiramid p1, TPiramid p2) {
        return !(p1 == p2);
    }
}

