using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SqlCommandeRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommandeRepo(CommanderContext context)
        {
            _context = context;
        }

        public void Create(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = _context.Commands.ToList();
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool Savechanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Command cmd)
        {
            //nothing
        }
    }
}
