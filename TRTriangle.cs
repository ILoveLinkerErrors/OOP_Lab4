class TRTriangle {
    //     “Рівносторонній трикутник ” – TRTriangle
    // поля:
    //  для зберігання довжини сторін;
    // методи:
    //  конструктор без параметрів, конструктор з параметрами, конструктор копіювання;
    //  введення/виведення даних;
    //  визначення площі;
    //  визначення периметру;
    //  порівняння з іншим трикутником;
    //  перевантаження операторів + (додавання довжин сторін), – (віднімання
    // довжин відповідних сторін), * (множення сторін на деяке число).
    private double side;    

    public static readonly double EPSILON = 1e-8;

    public double Side {
        get {
            return side;
        }   
        set {
            if (value > EPSILON) {
                side = value;
            } else {
                throw new ArgumentException("side length can't be less than or equal to 0");
            }
        }
    }

    public double GetPerimeter() {
        return Side * 3;
    }

    public double GetArea() {
        return 0.43301270189 * Side * Side;
    }

    public TRTriangle() {
        Side = 1;
    }

    public TRTriangle(double side) {
        Side = side;
    }

    public TRTriangle(TRTriangle copy) {
        Side = copy.Side;
    }

    public void Print() {
        Console.WriteLine($"Side = {Side}");
    }

    public void Input() {
        double sideLen;
        while (true) {
            Console.Write("Side = ");
            var strSideLen = Console.ReadLine();
            try
            {
                sideLen = double.Parse(strSideLen);
            }
            catch
            {
                Console.WriteLine("Error: couldn't convert your input <\"{0}\"> to double, try again.", strSideLen);
                continue;
            }
            if (sideLen < EPSILON)
            {
                Console.WriteLine("Error: side length must be bigger than 0, try again.");
                continue;
            }
            break;
        }
        Side = sideLen;
    }

    public static TRTriangle operator+(TRTriangle t1, TRTriangle t2) {
        return new TRTriangle(t1.Side + t2.Side);
    }

    public static TRTriangle operator-(TRTriangle t1, TRTriangle t2) {
        return new TRTriangle(t1.Side - t2.Side);
    }

    public static TRTriangle operator*(TRTriangle t, double scalar) {
        return new TRTriangle(t.Side * scalar);
    }

    public static TRTriangle operator*(double scalar, TRTriangle t) {
        return t * scalar;
    }

    public static bool operator == (TRTriangle t1, TRTriangle t2) {
        return Math.Abs(t1.Side - t2.Side) < EPSILON;
    }

    public static bool operator != (TRTriangle t1, TRTriangle t2) {
        return !(t1 == t2);
    }
}