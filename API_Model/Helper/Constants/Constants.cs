namespace API_Model
{
    public static class Constants
    {
        #region #Login
        public static string CreateSuccess => "Create Success";
        public static string IsNullValue => "Cannot Process ISNULL Value";
        public static string DeleteSuccess => "Delete Success";
        public static string UpdateSuccess => "Update Success";
        public static string NotFound => "NotFound";
        public static string NotFoundUserLogin => "Username Or Password Is Incorrect";
        #endregion


        #region [Token]

        public static string CannotFoundToken => "Token Not Found";
        public static string SuccessRevokeToken => "Token Revoked";
        public static string CannotRevokeToken => "This Token was Revoked  ";
        public static string InvalidToken => "Invalid Token";
        public static string TokenExpired => "Token Expired";

        #endregion
    }
}