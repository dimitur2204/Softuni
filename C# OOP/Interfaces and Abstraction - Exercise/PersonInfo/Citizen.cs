using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen
        :IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name, int age, string ID, string birthdate)
        {
            this.name = name;
            this.age = age;
            this.id = ID;
            this.birthdate = birthdate;
        }

        public string Name => this.name;

        public int Age => this.age;

        public string Id => this.id;

        public string Birthdate => this.birthdate;
    }
}
