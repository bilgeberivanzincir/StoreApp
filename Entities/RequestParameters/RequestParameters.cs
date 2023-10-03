namespace Entities.RequestParameters
{
    public abstract class RequestParameters
    {
        //abstract sınıfın newlenmesi mümkün değildir. Kalıtımla bu sınıf devraldığında ilgili sınıfa aktarılır. kalıtılan sınıf neewlenebilir.
        public String? SearchTerm { get; set; }

    }
}