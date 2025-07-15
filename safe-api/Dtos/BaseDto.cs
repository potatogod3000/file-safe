namespace safe_api.Dtos;

public class BaseDto
{
    public bool IsSuccess { get; set; }

    public bool IsError { get; set; }

    public string ErrorMessage { get; set; }

    public BaseDto()
    {
        ErrorMessage = string.Empty;
        IsSuccess = false;
        IsError = false;
    }
}