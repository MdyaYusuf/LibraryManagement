using LibraryManagement.ConsoleUI.Models;

namespace LibraryManagement.ConsoleUI.Repository.Concrete;

public abstract class BaseRepository
{
  List<Book> books = new List<Book>()
  {
    new Book(new Guid("{D313A96A-1678-4AC3-9D6D-3A3F75382B3D}"), 1, 1, "Beyaz Diş", "Soylu ve onurlu bir vahşi kurtun gözünden hayatı konu eder.", 240, "1906 Ekim", "9786257784627"),
    new Book(new Guid("{2C17B47C-3A30-44DB-8094-8C33181AD76D}"), 1, 2, "Suç ve Ceza", "Raskolnikov'un hayatı ile suçun ahlaki boyutunu sorgulayan eşsiz bir eser.", 643, "1866 Aralık", "9786057738066"),
    new Book(new Guid("{AAA0826A-9A8C-4987-8666-37D6A5DCBA64}"), 1, 3, "Gün Olur Asra Bedel", "Dostunun cenazesini taşıyan Yedigey’in hayat yolculuğu.", 444, "1980 Haziran", "9786257303866"),
    new Book(new Guid("{F0EAD45B-0A1D-4DAE-8075-AF316AC63B96}"), 3, 4, "Olasılıksız", "Dejavu, geçmiş, rüya, gelecek. Zihnin sınırlarını zorlayan bir kitap.", 496, "2005 Mart", "9789756006054"),
    new Book(new Guid("{37F77149-CBB6-452C-87AE-E1EEA17CF7EF}"), 2, 5, "Yaban", "Milli mücadele döneminde, Orta Anadolu'da bir köyde geçen hikaye.", 215, "1932 Eylül", "9789754700060"),
    new Book(new Guid("{A312E5DC-7BE7-4AD9-82C1-52C26EFD53BA}"), 1, 6, "Babalar ve Oğullar", "Bazarov ile geleneklere sistemli bir karşı çıkışı anlatır.", 256, "1862 Şubat", "9786257751902"),
    new Book(new Guid("{9E0D5A1A-84CC-4B7B-A53A-B9570AAB49CF}"), 4, 7, "Dünyanın Tüm Dertleri", "Meraklı bir zihnin dünyada işlerin nasıl yürüdüğünü basit bir şekilde anlatması.", 384, "2021 Ocak", "9786054729531"),
    new Book(new Guid("{378E3F65-7953-4878-B95C-948FD2E7E376}"), 2, 8, "Günbegün Mahşer", "Hiç düşmeyen temposu ve süprizleriyle iyi bir zombi romanı.", 192, "2010 Haziran", "9786054090082"),
    new Book(new Guid("{D69E4169-8CEC-4496-9B5F-51789A6F3D8F}"), 2, 9, "Çocuk Kalbi", "Enrico adlı ilkokul öğrencisinin çocuk kalbiyle kaleme aldığı günlüğü.", 296, "1986 Ekim", "9786257784085")
  };

  List<Author> authors = new List<Author>()
  {
    new Author(1, "Jack", "London"),
    new Author(2, "Fyodor Mihailoviç", "Dostoyevski"),
    new Author(3, "Cengiz", "Aytmatov"),
    new Author(4, "Adam", "Fawer"),
    new Author(5, "Yakup Kadri", "Karaosmanoğlu"),
    new Author(6, "Ivan Sergeyeviç", "Turgenyev"),
    new Author(7, "Marcus", "Chown"),
    new Author(8, "J. L.", "Bourne"),
    new Author(9, "Edmondo", "De Amicis")
  };

  List<Category> categories = new List<Category>()
  {
    new Category(1, "Dünya Klasikleri"),
    new Category(2, "Türk Klasikleri"),
    new Category(3, "Bilim Kurgu"),
    new Category(4, "Popüler Bilim")
  };

  List<Member> members = new List<Member>()
  {
    new Member()
    {
      Id = "1",
      Age = 25,
      Name = "Eva",
      Surname = "Aydemir"
    },
    new Member()
    {
      Id = "2",
      Age = 25,
      Name = "Sofya",
      Surname = "Hür"
    },
    new Member()
    {
      Id = "3",
      Age = 25,
      Name = "Okay",
      Surname = "Aydın"
    }
  };

  public List<Book> Books()
  {
    return books;
  }

  public List<Author> Authors()
  {
    return authors;
  }

  public List<Category> Categories()
  {
    return categories;
  }

  public List<Member> Members()
  {
    return members;
  }
}
