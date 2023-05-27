namespace api
{
    public static class Utils
    {
        public static string ConvertAbsoluteImageFilePathToUrl(string absPath)
        {
            return absPath.Split("\\wwwroot\\")[1].Replace("\\", "/");
        }
    }
}
