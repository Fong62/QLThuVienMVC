namespace QLThuVienMVC.Controllers
{
    public static class GenerateCode
    {
         public static string GenerateNextCode(string lastCode, string prefix)
        {
            int number = 1;

            if (!string.IsNullOrEmpty(lastCode))
            {
                
                string numberPart = lastCode.Substring(prefix.Length);
                if (int.TryParse(numberPart, out number))
                {
                    number++;
                }
            }

            
            return $"{prefix}{number:D3}";
        }
    }
}
