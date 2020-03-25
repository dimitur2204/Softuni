using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {

            var doctorAndPatient = new Dictionary<string, List<string>>();

            var departmentAndPatients = new Dictionary<string, List<string>>();

            string inputInfo = Console.ReadLine();
            while (inputInfo != "Output")
            {
                string[] input = inputInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string department = input[0];
                string doctor = input[1] + " " + input[2];
                string patient = input[3];

                if (!doctorAndPatient.ContainsKey(doctor))
                {
                    doctorAndPatient.Add(doctor, new List<string>());
                }
                doctorAndPatient[doctor].Add(patient);

                if (!departmentAndPatients.ContainsKey(department))
                {
                    departmentAndPatients.Add(department, new List<string>());
                }
                departmentAndPatients[department].Add(patient);
                inputInfo = Console.ReadLine();
            }

            inputInfo = Console.ReadLine().Trim();

            while (inputInfo != "End")
            {
                var input = inputInfo.Split().ToArray();

                if (input.Length == 1)
                {
                    foreach (var patients in departmentAndPatients[inputInfo])
                    {
                        Console.WriteLine(patients);
                    }
                }
                else if (int.TryParse(input[1], out int result))
                {
                    if (int.Parse(input[1]) > 20)
                    {
                        continue;
                    }

                    var patients = departmentAndPatients[input[0]];

                    var room = patients.Skip(3 * (int.Parse(input[1]) - 1)).Take(3).OrderBy(p => p);

                    foreach (var patient in room)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var patients = doctorAndPatient[inputInfo];
                    patients.Sort();
                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient);
                    }
                }
                inputInfo = Console.ReadLine().Trim();
            }
        }
    }
}