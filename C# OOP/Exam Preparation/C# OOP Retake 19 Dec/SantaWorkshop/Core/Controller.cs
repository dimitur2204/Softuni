
using System;
using System.Linq;
using System.Text;
using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly DwarfRepository dwarfRepository;
        private readonly PresentRepository presentRepository;
        private int _countOfPresents;

        public Controller()
        {
            this.dwarfRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if (dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidOperationException("Invalid dwarf type.");
            }
            IDwarf dwarf;
            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else
            {
                dwarf = new SleepyDwarf(dwarfName);

            }
            dwarfRepository.Add(dwarf);
            return $"Successfully added {dwarfType} named {dwarfName}.";
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = dwarfRepository.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException("The dwarf you want to add an instrument to doesn't exist!");
            }
            dwarf.Instruments.Add(new Instrument(power));
            return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            presentRepository.Add(new Present(presentName, energyRequired));
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            var present = presentRepository.FindByName(presentName);
            while (dwarfRepository.Models.Any())
            {
                var currentDwarf = dwarfRepository.Models.FirstOrDefault(d => d.Energy >= 50);
                if (currentDwarf == null)
                {
                    currentDwarf = dwarfRepository.Models.FirstOrDefault();
                    if (currentDwarf == null)
                    {
                        throw new InvalidOperationException("There is no dwarf ready to start crafting!");
                    }
                }
                currentDwarf.Work();
                present.GetCrafted();
                if (present.IsDone())
                {
                    _countOfPresents++;
                    return $"Present {presentName} is done.";
                }
                if (currentDwarf.Energy == 0)
                {
                    dwarfRepository.Remove(currentDwarf);
                    continue;
                }
            }
            return $"Present {presentName} is not done.";
        }

        public string Report()
        {
           var sb = new StringBuilder();
           sb.AppendLine($"{_countOfPresents} presents are done!");
           sb.AppendLine("Dwarfs info:");
           foreach (var dwarf in this.dwarfRepository.Models)
           {
               sb.AppendLine($"Name: {dwarf.Name}");
               sb.AppendLine($"Energy: {dwarf.Energy}");
               sb.AppendLine($"Instruments {dwarf.Instruments.Count} not broken left");
           }

           return sb.ToString().Trim();
        }
    }
}
