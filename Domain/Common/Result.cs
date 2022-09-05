namespace Domain.Common;

[Serializable]
public class Result
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public Result(string text, int code)
        {
            this.Text = text;
            this.Code = code;
        }

        public Result() { }

        /// <summary>
        /// Human readable error message
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Machine readable error code
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Default error for when we receive an exception
        /// </summary>
        public static Result DefaultError => new Result("An exception occured.", 999);

        /// <summary>
        /// Default validation error. Use this for invalid parameters in controller actions and service methods.
        /// </summary>
        public static Result ModelStateError(string validationError)
        {
            return new Result(validationError, 998);
        }

        /// <summary>
        /// Use this for unauthorized responses.
        /// </summary>
        public static Result ForbiddenError => new Result("You are not authorized to call this action.", 998);

        /// <summary>
        /// Use this to send a custom error message
        /// </summary>
        public static Result CustomMessage(string errorMessage)
        {
            return new Result(errorMessage, 997);
        }
        
        public static Result SuccessAuthorization => new Result($"User email and password is correct {DateTime.Now}", 996);

        public static Result UserNotFound => new Result($"User with this id does not exist {DateTime.Now}", 996);
        
        public static Result IncorrectPassword => new Result($"Incorrect password {DateTime.Now}", 996);

        public static Result UserFailedToCreate => new Result("Failed to create User.", 995);
        
        public static Result UserAlreadyExist => new Result("User with this email already exist.", 995);

        public static Result Canceled => new Result("The request canceled successfully!", 994);

        public static Result NotFound => new Result("The specified resource was not found.", 990);

        public static Result ValidationFormat => new Result("Request object format is not true.", 901);
        
        public static Result Validation => new Result("One or more validation errors occurred.", 900);

        public static Result SearchAtLeastOneCharacter => new Result("Search parameter must have at least one character!", 898);

        /// <summary>
        /// Default error for when we receive an exception
        /// </summary>
        public static Result ServiceProviderNotFound => new Result("Service Provider with this name does not exist.", 700);

        public static Result ServiceProvider => new Result("Service Provider failed to return as expected.", 600);

        public static Result DateTimeFormatError => new Result("Date format is not true. Date format must be like yyyy-MM-dd (2019-07-19)", 500);
        
        public static Result QuizUserSolution => new Result($"User solution result {DateTime.Now}", 105);
        public static Result QuizSuccessGetById => new Result($"Quiz success Get by Id {DateTime.Now}", 104);
        public static Result QuizSuccessRemove => new Result($"Quiz success Remove {DateTime.Now}", 103);
        public static Result QuizSuccessAdd => new Result($"Quiz success Add {DateTime.Now}", 102);
        public static Result TokenClaimsPrincipal => new Result($"Token claims successfully getted {DateTime.Now}", 101);
        public static Result TokenGenerated => new Result($"Token successfully generated {DateTime.Now}", 100);
        
        #region Override Equals Operator

        /// <summary>
        /// Use this to compare if two errors are equal
        /// Ref: https://msdn.microsoft.com/ru-ru/library/ms173147(v=vs.80).aspx
        /// </summary>
        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to ServiceError or is null return false.
            var error = obj as Result;

            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public bool Equals(Result error)
        {
            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(Result a, Result b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(Result a, Result b)
        {
            return !(a == b);
        }

        #endregion
    }