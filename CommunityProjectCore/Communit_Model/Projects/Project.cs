using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communit_Model.Projects
{
    public class Project
    {
        public int ProjectId {  get; set; }
        public string? ProjectType {  get; set; }
        public string? FileName {  get; set; }
        public string? FileType {  get; set; }
        public int LoginId { get; set; }
    }
}
