using System.ComponentModel.DataAnnotations;

namespace IvyGame.Models.DTO
{
    /// <summary>
    /// A game
    /// </summary>
    public class GameDto
    {
        /// <summary>
        /// Game ID
        /// </summary>
        public int GameId { get; set; }
        /// <summary>
        /// Game Name
        /// </summary>
        [Required]
        public string GameName { get; set; }
        //  public string Year { get; set; }
        //  public string Description { get; set; }

        //  public string Genre { get; set; }
        //  public Uri ImageUrl { get; set; }

    }
}
