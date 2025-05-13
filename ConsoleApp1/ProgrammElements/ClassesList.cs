public abstract class LibraryItem
{
    string _title;
    Guid _id;
    int _yearPublished;
    int _availableCopies;

    public string Title
    {
        get {return _title;}
    }

    public Guid ID
    {
        get { return _id; }
        set { _id = value; }

    }
    public int YearPublished
    {
        get { return _yearPublished; }
        set { _yearPublished = value; }
    }

    public int AvailableCopies
    {
        get => _availableCopies;
        set { _availableCopies = value; }
    }


    public LibraryItem (string title, Guid id, int year, int copies)
    {
        _title = title;
        _id = id;
        _yearPublished = year;
        _availableCopies = copies;
    }

    public string GetDescription()
    {
        return $"Title of book = {Title}, ID = {ID}, Year of publishing = {YearPublished}, Available copies = {AvailableCopies}";
    }

    public virtual string AgeCategory()
    {
        return "All";
    }

}

public class Book : LibraryItem
{
    string _author;
    Genre _genre;
    static int _maxAvailableCopies;

    string Author
    {
        get => _author;
        set { _author = value; }
    }

    public Genre Genre
    {
        get => _genre;
        set { _genre = value; }
    }

    public Book (string title, Guid id, int year, string author, Genre genre) : base (title, id, year, _maxAvailableCopies)
    {
// base (title, id, year, _maxAvailableCopies)
        _author = author;
        _genre = genre;
    }

    static Book()
    {
        _maxAvailableCopies = 100;
    }

    public override string AgeCategory()
    {
        string ageCategory = "Undefined";
        if (Genre == Genre.ChildrensLiterature) ageCategory = "Children's Literature";
        else if (Genre == Genre.Erotic) { ageCategory = "Adult"; }
        else if (Genre == Genre.YoungEdult)
        {
            if (Title == "Haunting Adelina" || Title == "Buttons and laces") ageCategory = "Adult";
            else ageCategory = "Teenagers Literature";
        }
        return ageCategory; 
    }
}

public class Magazine : LibraryItem
{
    int _issueNumber;
    string _publisher;

    int IssueNumber
    {
        get => _issueNumber;
        set { _issueNumber = value; }
    }

    string Publisher
    {
        get => _publisher;
        set { _publisher = value; }
    }

    public Magazine (string title, Guid id, int year, int copies, int issue, string publisher) : base (title, id, year, copies)
    {
// base (title, id, year, copies)
        _issueNumber = issue;
        _publisher = publisher;
    }

    public override string AgeCategory()
    {
        string ageCategory;
        if (Publisher == "Playboy") ageCategory = "Adult";
        else if (Publisher == "KNU imeni Tarasa Shevchenko") ageCategory = "Students";
        else if (Publisher == "Lys Mykyta") ageCategory = "Children's Literature";
        else ageCategory = "Undefined";

        return ageCategory;
    }
}

public class AudioBook : Book
{
    int _duration;
    string _narrator;

    int Duration
    {
        get => _duration;
        set { _duration = value; }
    }
    string Narrator
    {
        get => _narrator;
        set { _narrator = value; }
    }

    public AudioBook (string title, Guid id, int year, int copies, string author, string genre, int dur, string narrator) : base (title, id, year, copies, author, genre)
    {
// base (title, id, year, copies, author, genre)
        _duration = dur;
        _narrator = narrator;
    }

    public new string AgeCategory()
    {
        string ageCategory;
        switch (this.Genre)
        {
            case Genre.All: 
                ageCategory = "Undefined" ;
                break;
            case Genre.Erotic: 
                ageCategory = "Adult";
                break;
            case Genre.ChildrensLiterature:
                ageCategory = "Children's Literature";
                break;
            case Genre.YoungEdult:
                ageCategory = "Teenagers";
                break;
            default:
                ageCategory = "Undefined";
                break;
        } 

        return ageCategory;
    }
}