using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model; 

//Value Object for address data.
public record Address([MaxLength(255)] string Street, [MaxLength(255)] string Zip, [MaxLength(255)] string City);
