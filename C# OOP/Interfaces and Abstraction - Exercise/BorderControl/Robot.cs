using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Robot : IIdentifiable
    {
        private string model;
        private string Id;
        public Robot(string model, string Id)
        {
            this.model = model;
            this.Id = Id;
        }
        public string ID => this.Id;
    }
}
