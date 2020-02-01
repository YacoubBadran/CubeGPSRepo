
namespace CubeGPS.Models.APIResponse
{
    public class APISuccessResponse
    {
        public bool Value { get; set; }
        public string ErrorMsg { get; set; }

        public APISuccessResponse()
        {
            Value = true;
            ErrorMsg = string.Empty;
        }
        
        public APISuccessResponse(string errorMsg)
        {
            Value = false;
            ErrorMsg = errorMsg;
        }
    }
}