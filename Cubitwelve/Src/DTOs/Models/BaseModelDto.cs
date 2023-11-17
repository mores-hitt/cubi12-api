namespace Cubitwelve.Src.DTOs.Models
{
    /// <summary>
    /// Base Model DTO for all DTOs
    /// </summary>
    /// <remarks>
    /// Probably would be needed the id of the models in the client side
    /// But the real reason to do this BaseModelDto is to avoid expose 
    /// "audit" fields like CreatedAt, UpdatedAt, DeletedAt, etc.
    /// </remarks>
    public class BaseModelDto
    {
        public int Id { get; set; }
    }
}