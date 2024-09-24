// importando biblioteca
using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;

namespace BooksWeb.Controllers;

// controller = classe | action = metodo
public class BookController : Controller
{
    // estatico = compartilha a variavel
    private readonly BookDatabase db;

    public BookController(BookDatabase db) {
        this.db = db;
    }

    public ActionResult Read() {
        // enviando o livro para o view
        return View(db.Books.ToList()); // equivale ao SELECT * FROM Books
    }

    [HttpGet]
    public ActionResult Create() {
        return View();
    }

    // recebe os livros
    [HttpPost]
    public ActionResult Create(Book model) {
        // adiciona na lista
        db.Books.Add(model); // INSERT INTO Books VALUES -- preenche os dados no modelo e envia para o sql
        db.SaveChanges(); // equivalente a um commit
        // redireciona para um metodo existente
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id) {
        // filtrar 
        // var book = db.Books.Where(e => e.BookId == id).First() ou .Single(); < so usar quando tem ctz que so tem um dado 
        var book = db.Books.Single(e => e.BookId == id);  // retorna apenas um book

        // primeiro realiza a exclusao
        db.Books.Remove(book);
        db.SaveChanges();

        // depois redireciona pra pagina read de novo
        return RedirectToAction("Read");
    }

        [HttpGet]
    public ActionResult Update(int id) {
        Book book = db.Books.Single(e => id == e.BookId);
        return View(book);
    }

    // recebe os livros
    [HttpPost]
    public ActionResult Update(int id, Book model) {
        var book = db.Books.Single(e => e.BookId == id);
        // alterando os dados aqui
        book.Title = model.Title;
        book.Author = model.Author;
        book.Synopsis = model.Synopsis;
        book.Gender = model.Gender; 

        db.SaveChanges();

        return RedirectToAction("Read");
    }
}