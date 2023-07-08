using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Model
{
    public class PhoneBookEntry
    {
        [RegularExpression(@"^(?=(\S+\s){0,2}\S+$)^([a-zA-Z]{2,}[,\s]?)?(([a-zA-Z]{2,}\s)?|(([a-zA-Z]{1,}')?\s?([a-zA-Z]{2,}\-[a-zA-Z]{2,})?)?|(([a-zA-Z]{1,}')?[a-zA-Z]{2,}\,)?)?\s?[a-zA-Z\s.]{2,}$")]
        [Required]
        public string? Name { get; set; }

        [RegularExpression(@"^(?=.{5,18}$)(\+?0(0|1{2}))?\s?([\+\(]?[1-9]{1,3}?[\s\)]?)((\(\d{1,3}\)\S)|(\d{1,3}\s?)|(\(\d{1,2}\)\s?))?([-.\s(]?\d{1,3}[)\s\-.]?)?(\d{1,3}[\s\-.]?){1,2}?\d{1,5}$")]
        [Required]
        public string? PhoneNumber { get; set; }
    }
}