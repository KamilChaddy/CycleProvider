using System;

namespace CycleProvider.Library
{
    public class PersonDto
    {
        private readonly PersonBase _personBase; //dobra praktka aby nikt nie modyfikował

        public int Id { get => _personBase.Id; }  //wrapowanie czyli opakowywanie
        public DateTime BirthDate { get => _personBase.BirthDate; }
        public PersonDto(PersonBase personBase)
        {
            _personBase = personBase;
        }
    }
}
