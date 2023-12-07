class TPiramid : TRTriangle {
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

    public double GetVolume() {
        return GetArea() * Height / 3;
    } 

    public TPiramid() : base() {
        Height = 1;
    }

    public TPiramid(double height, double side) : base(side){
        Height = height;
    }

    public TPiramid(TPiramid copy) : this(copy.height, copy.Side) {
    }

    public new void Print() {
        base.Print();
        Console.WriteLine($"Height = {Height}");
    }

    public new void Input() {
        base.Input();
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
}

