using System;

namespace bookstore.Models.ViewModels
{
    public class PageInformation
    {
        public int NumOfProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(((double)NumOfProjects / ProjectsPerPage));
    }
}
