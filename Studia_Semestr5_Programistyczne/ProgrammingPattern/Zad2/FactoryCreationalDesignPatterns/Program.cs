using FactoryCreationalDesignPatterns;

var shapeFactory=new ShapeFactory();
var circle=shapeFactory.CreateShape(ShapeType.Circle);
var rectangle = shapeFactory.CreateShape(ShapeType.Rectangle);
var triangle = shapeFactory.CreateShape(ShapeType.Triangle);
circle.Render();
rectangle.Render();
triangle.Render();
