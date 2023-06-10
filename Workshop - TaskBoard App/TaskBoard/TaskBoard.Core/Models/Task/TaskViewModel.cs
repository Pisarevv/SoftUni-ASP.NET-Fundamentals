using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Core.Models.Task
{
    public class TaskViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Owner { get; set; } = null!;
    }
}
