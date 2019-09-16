using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Errors
{
    public class ErrorsAuth
    {
        private OutputErrorsEnum Code { get; set; }
        private string Text { get; set; }

        public static DataErrors LoginError()
        {
            return new DataErrors
            {
                Errors = new[]
                {
                    new Error
                    {
                        Code = 1,
                        Text = "Incorrect login or password"
                    },
                }
            };
        }
        
        public static DataErrors TokenError()
        {
            return new DataErrors
            {
                Errors = new[]
                {
                    new Error
                    {
                        Code = 1015,
                        Text = "Неверно указан токен"
                    },
                }
            };
        }


        public static ErrorOther CheckLogin()
        {
            return new ErrorOther
            {
                Text = "Name is already taken"
            };
        }

        public static ErrorOther RegisterError()
        {
            return new ErrorOther
            {
                Text = "Incorrect login"
            };
        }

        public static ErrorOther UserNotFound()
        {
            return new ErrorOther
            {
                Text = "User not found"
            };
        }

        public static ErrorOther PasswordAlready()
        {
            return new ErrorOther
            {
                Text = "Old and new passwords must not match"
            };
        }
    }
}