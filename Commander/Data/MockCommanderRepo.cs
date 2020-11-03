using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void Create(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
           {
               new Command { Id = 0, HowTo = "make a cake", Line = "put all in the oven", Platform = "allthings" },
               new Command { Id = 1, HowTo = "boil an egg", Line = "boil a water", Platform = "knife&pan" },
               new Command { Id = 2, HowTo = "make juice", Line = "have cup", Platform = "cup" }
           };

           return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "make a cake", Line = "put all in the oven", Platform = "allthings" };
        }

        public bool Savechanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
