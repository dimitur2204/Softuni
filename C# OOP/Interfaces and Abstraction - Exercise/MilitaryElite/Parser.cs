using MilitaryElite.Interfaces;
using MilitaryElite.Soldiers.Privates;
using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers.Commandos;
using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers.Engineers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    class Parser
    {
        public static List<Private> ParsePrivates(string[] privateIds, List<Private> privatesList) 
        {
            var privates = new List<Private>();
            foreach (var id in privateIds)
            {
                if (privatesList.Where(x => x.ID == id).ToList().Count > 0)
                {
                    privates.Add(privatesList.Where(x => x.ID == id).ToList()[0]);
                }
            }
            return privates;
        } 
        public static List<Repair> ParseRepairs(string[] repairsToParse)
        {
            var repairs = new List<Repair>();
            for (int i = 0; i < repairsToParse.Length; i += 2)
            {
                try
                {
                    var repairName = repairsToParse[i];
                    var repairHours = int.Parse(repairsToParse[i + 1]);
                    var repair = new Repair(repairName, repairHours);
                    repairs.Add(repair);
                }
                catch (Exception)
                {

                }
            }
            return repairs;
        }
        public static List<Mission> ParseMissions(string[] missionsToParse)
        {
            var missions = new List<Mission>();
            for (int i = 0; i < missionsToParse.Length; i += 2)
            {
                try
                {
                    var missionName = missionsToParse[i];
                    var missionStatus = missionsToParse[i + 1];
                    var mission = new Mission(missionName, missionStatus);
                    missions.Add(mission);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return missions;
        }
    }
}

