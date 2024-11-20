namespace Auth.DEPI.Final.PL.ViewModels.HomeViewModels
{
    public class InstructorsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public IFormFile InstructorImage { get; set; }

    }
}
