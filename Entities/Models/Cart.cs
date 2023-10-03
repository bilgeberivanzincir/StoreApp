namespace Entities.Models
{

    public class Cart
    {
        public List<CartLine> Lines {get; set;}
        public Cart() //constructor
        {
            Lines= new List<CartLine>();
        }
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l=>l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault(); // sepette bu ürün var mı sorgusu?
            if(line is null)
            {
                Lines.Add(new CartLine(){
                    Product=product,
                    Quantity=quantity
                });
            }
            else
            {
                line.Quantity+= quantity;
            }
        }

        public virtual void RemoveLine(Product product)=>
            Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));

        public decimal ComputeTotalValue()=>
        Lines.Sum(e=> e.Product.Price*e.Quantity);

        public virtual void Clear()=> Lines.Clear();
    }
    //virtual anahtar sözcüğü kalıtım alındığında methodun geçersiz kılınması için eklenir.

}