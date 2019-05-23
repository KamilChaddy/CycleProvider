using CycleProvider.Contracts;
using System;

namespace CycleProvider.Library
{
    public abstract class PersonBase : IPerson // gdy jest abstract to nie da sie zrobić new ale można dziedziczyć, jezeli jest seald to jest opieczętowana i nie da się dziedziczyć
    {
        public static int Counter { get; private set; } = 0; //dla składowych statycznech tworzony jest dodatkowy obiekt
        public int Id { get; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract DateTime BirthDate { get; set; }
        public PersonBase(string lastName) // coś co nie ma nazwiska nie istnieje
        {
            Id = ++Counter;
        }
        
        public override string ToString() //nadpisanie ToStringa i on zostanie użyta
        {
            return $"Person {Id} of {Counter} => {LastName} {FirstName}, was born {BirthDate}";
        }

        protected virtual void CalculatedAged() {}


        // public static void Do() { Counter++;  } gdy nie zostanie wywołana metoda Do to obiekt statyczny Counter nie powstanie chyba że przy inicjcjacji Person()
        // public void Do() { Id++; } tak sie nie da ustawić seta na Id ale w konstruktorze się da
    }
}
