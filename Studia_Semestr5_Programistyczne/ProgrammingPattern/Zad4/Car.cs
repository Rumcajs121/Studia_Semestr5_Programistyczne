using FluentBuilder;
namespace PP_Zad4;

//https://github.com/StefH/FluentBuilder

[AutoGenerateBuilder]
public class Car
{

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }


        public override string ToString(){
        return $"Brand: {Brand} ,Model: {Model}, Year: {Year}, Color: {Color}";
    }
}
