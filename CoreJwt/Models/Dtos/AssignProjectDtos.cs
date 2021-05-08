using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace CoreJwt.Models.Dtos {

    public class AssignProjectDtos {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string UserName { get; set; }
        public string imgsrc { get; set; }
    }
}