using MilitaryElite.Soldiers.Privates;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral:IPrivate
    {
        public List<Private> Privates { get; }
    }
}
