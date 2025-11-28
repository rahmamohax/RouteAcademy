
namespace E_Commerce.Shared.CommonResult
{
    public enum ErrorType
    {
        Failure,
        Validation,
        NotFound,
        Unauthorized,
        Forbidden,
        InvalidCredintials
    }
    
    public class Error
    {
        private Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        #region Static Factories
        //Static Factories to Create Error Object
        public static Error Failure(string code = "General.Failure", string description = "General Failure Occured")
        {
            return new Error(code, description, ErrorType.Failure);
        }

        public static Error Validation(string code = "General.Validation", string description = "Validation Error Occured")
        {
            return new Error(code, description, ErrorType.Validation);
        }
        public static Error NotFound(string code = "General.NotFound", string description = "Requested Resource was Not Found")
        {
            return new Error(code, description, ErrorType.NotFound);
        }

        public static Error Unauthorized(string code = "General.Unauthorized", string description = "You're not authorized to access")
        {
            return new Error(code, description, ErrorType.Unauthorized);
        }
        public static Error Forbidden(string code = "General.Forbidden", string description = "You dont have the permission to access")
        {
            return new Error(code, description, ErrorType.Forbidden);
        }
        public static Error InvalidCredintials(string code = "General.InvalidCredintials", string description = "Provided Credintials are Invalid")
        {
            return new Error(code, description, ErrorType.InvalidCredintials);
        } 
        #endregion
    }

}
