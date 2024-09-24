namespace BooksWeb.Models; // nome do projeto + nome do diretorio (pasta)
public class Book {
    // private string title;
    
    // public string GetTitle() {
    //     return title;
    // }
    
    // public void SetTitle(string title) {
    //     this.title = title;
    // }

    // public string Title { 
    //     get {return title;}
    //     set {title = value;}
    //     }

    // propriedade automatica
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Synopsis { get; set; }
    public string Gender { get; set; }
}