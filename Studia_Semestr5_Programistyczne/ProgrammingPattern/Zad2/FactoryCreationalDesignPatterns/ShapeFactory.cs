namespace FactoryCreationalDesignPatterns;

public enum ShapeType
{
    Circle,
    Triangle,
    Rectangle
}
public class ShapeFactory
{
    public Shape CreateShape(ShapeType type)
    {
        switch (type)
        {
            case ShapeType.Circle:
                return new Circle();
            case ShapeType.Triangle:
                return new Triangle();
            case ShapeType.Rectangle:
                return new Rectangle();
            default:
            throw new Exception($"Shape type {type} is not handled");
        }
    }
}
