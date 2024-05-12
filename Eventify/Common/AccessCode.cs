namespace Eventify.Common
{
    public class AccessCode
    {
        public static string ACCESS_CODE { get; set; }

        public static string CreateAccessCode()
        {
            string otp_char = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rnd = new Random();

            for (int i = 0; i < 6; i++)
            {

                var random_char = otp_char[rnd.Next(1, otp_char.Length)];
                ACCESS_CODE += random_char;

            }

            return ACCESS_CODE;
        }

    }
}
