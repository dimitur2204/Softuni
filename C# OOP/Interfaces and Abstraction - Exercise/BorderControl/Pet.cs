using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Pet : IBirthable
    {
        private string name;
        private string birthdate;
        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.birthdate = birthdate;
        }

        public string Name => this.name;

        public string Birthdate => this.birthdate;
    }
}
