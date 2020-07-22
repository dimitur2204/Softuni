
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (true)
            {
                var currentInstrument = dwarf.Instruments.FirstOrDefault();
                if (currentInstrument == null)
                {
                    break;
                }
                if (present.IsDone())
                {
                    break;
                }

                if (dwarf.Energy == 0)
                {
                    break;
                }

                if (currentInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(dwarf.Instruments.ElementAt(0));
                    if (!dwarf.Instruments.Any())
                    {
                        break;
                    }
                    currentInstrument = dwarf.Instruments.FirstOrDefault();
                }

                dwarf.Work();
                currentInstrument.Use();
                present.GetCrafted();
            }
        }
    }
}
