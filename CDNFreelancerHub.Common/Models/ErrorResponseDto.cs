namespace CDNFreelancerHub.Common.Models
{
    public class ErrorResponseDto
    {
        public ErrorResponseDto(string error)
        {
            Error = error;
        }
        public string Error { get; set; }
    }
}
