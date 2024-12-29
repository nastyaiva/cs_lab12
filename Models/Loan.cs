namespace laboratory_12.Models
{
    public class Loan
    {
        public int Id { get; set; }          // Уникальный идентификатор займа
        public int MemberId { get; set; }    // Идентификатор члена библиотеки, который взял книгу
        public int BookId { get; set; }      // Идентификатор книги, которая была взята
        public DateTime LoanDate { get; set; } // Дата займа
        
    }
}
