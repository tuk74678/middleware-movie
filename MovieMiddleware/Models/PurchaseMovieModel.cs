using MovieMiddleware.Validators;

namespace MovieMiddleware.Models;

public class PurchaseMovieModel
{
    public int MovieId { get; set; }

    [PurchaseDateValidator]
    public DateTime PurchaseDate { get; set; }
}