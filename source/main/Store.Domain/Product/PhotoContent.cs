namespace Store.Domain.Product
{
    public class PhotoContent
    {
        public string Url {get; protected set;}
        public bool Starred {get; protected set;}
        
        public PhotoContent(string url, bool starred){
            Url = url;
            Starred = starred;
        }
    }
}