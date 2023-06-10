using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Contracts;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly TaskBoardAppDbContext dbContext;
        public BoardService(TaskBoardAppDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }
    }
}
