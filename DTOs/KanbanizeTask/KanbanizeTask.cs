using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanbanize.DTOs.KanbanizeTask
{
    public class KanbanizeTask
    {
        public string? id { get; set; }
        public string? boardid { get; set; }
        public string? taskid { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? priority { get; set; }
        public string? assignee { get; set; }
        public string? color { get; set; }
        public string? tags { get; set; }
        public string? deadline { get; set; }
        public string? column { get; set; }
        public string? status { get; set; }
        public string? details { get; set; }
        public string? movingerror { get; set; }
        public string? lane { get; set; }

        
    }
}
