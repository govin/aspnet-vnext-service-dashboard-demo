namespace AspNetVNext.ServiceDashboard
{
    public class UrlItemToProcess
    {
        public string Name {get;set;}

        public string Url {get;set;}

        public static UrlItemToProcess Create(string name, string url)
        {
            var item = new UrlItemToProcess { Name = name, Url = url };
            return item;
        }
    }

}